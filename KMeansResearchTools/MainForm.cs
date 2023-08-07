using System;
using System.Drawing;
using System.Numerics;
using System.Text.Json;
using System.Windows.Forms;

using static System.Net.Mime.MediaTypeNames;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace KMeansResearchTools
{
    public partial class MainForm : Form
    {
        private List<PointData> points;
        private List<CentroidData> centroids;
        private CentroidData VCC;
        private List<Color> colors = new()
        {
            Color.DarkRed, Color.DarkBlue, Color.DarkGreen, Color.DarkOrange,
            Color.DarkViolet, Color.DarkCyan, Color.DarkMagenta, Color.DarkGray,
            Color.DarkOliveGreen, Color.DarkGoldenrod, Color.DarkSeaGreen,
            Color.DarkSlateBlue, Color.DarkSlateGray, Color.DarkTurquoise,
            Color.IndianRed, Color.Maroon, Color.Navy, Color.MidnightBlue,
            Color.Chocolate, Color.SaddleBrown, Color.Indigo
        };
        private Random rand;
        private ToolTip toolTip;
        private bool isAddingPoints;
        private bool isAddingCentroids;
        private bool showConnections = true;
        private bool showGrid = true;
        private bool showVCC = true;
        private bool ShowCentroidsBoundries = true;
        private List<ElbowChartData> elbowChartData = new();
        private double lambda = 5e-1;
        private double dimensiality = (1.0 / 2.0);


        /// <summary>
        /// The Form1 class is the main form and the entry point of your application.
        /// It initializes the form, sets up the graphics, and handles user interaction
        /// with the form (mouse clicks and mouse movements).
        /// It also calculates and displays various information such as the within-cluster sum of squares (WCSS),
        /// density factor, and distances between centroids and points.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            points = new List<PointData>();
            centroids = new List<CentroidData>();
            rand = new Random();
            toolTip = new ToolTip();


            elbowDgv.Columns.Add("Cn", "Cn");
            elbowDgv.Columns.Add("WCSS", "WCSS");
            elbowDgv.Columns.Add("sumOfDistances", "Σd(C,VCC)");
            elbowDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            elbowDgv.DataBindingComplete += (s, args) => elbowDgv.ClearSelection();
            elbowDgv.RowsAdded += (s, args) => elbowDgv.ClearSelection();
            elbowDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            elbowDgv.RowHeadersVisible = false;

            PointsDgv.Columns.Add("X", "X");
            PointsDgv.Columns.Add("Y", "Y");
            PointsDgv.Columns.Add("DistancetoC", "Distance to C");
            PointsDgv.Columns.Add("DistancetoCSquared", "Dc²");
            PointsDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            PointsDgv.DataBindingComplete += (s, args) => PointsDgv.ClearSelection();
            PointsDgv.RowsAdded += (s, args) => PointsDgv.ClearSelection();
            PointsDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            PointsDgv.DefaultCellStyle.SelectionBackColor = PointsDgv.DefaultCellStyle.BackColor;
            PointsDgv.DefaultCellStyle.SelectionForeColor = PointsDgv.DefaultCellStyle.ForeColor;
            PointsDgv.ForeColor = Color.White;


            CentroidsDgv.Columns.Add("X", "X");
            CentroidsDgv.Columns.Add("Y", "Y");
            CentroidsDgv.Columns.Add("Kpn", "Kpn");
            CentroidsDgv.Columns.Add("SumDistancetoC", "Σ d(Pi, C)²");
            CentroidsDgv.Columns.Add("SumDistancetoCAvg", "Σ d(Pi, C)² / Kpn");
            CentroidsDgv.Columns.Add("DensityFactor", "ρ");
            CentroidsDgv.Columns.Add("VCC", "VCC");
            CentroidsDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            CentroidsDgv.DataBindingComplete += (s, args) => CentroidsDgv.ClearSelection();
            CentroidsDgv.RowsAdded += (s, args) => CentroidsDgv.ClearSelection();
            CentroidsDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            CentroidsDgv.DefaultCellStyle.SelectionBackColor = CentroidsDgv.DefaultCellStyle.BackColor;
            CentroidsDgv.DefaultCellStyle.SelectionForeColor = CentroidsDgv.DefaultCellStyle.ForeColor;
            CentroidsDgv.ForeColor = Color.White;

            pictureBox1.Paint += pictureBox1_Paint;
            pictureBox1.MouseClick += pictureBox1_MouseClick;
            pictureBox1.MouseMove += pictureBox1_MouseMove;

            lblCurrentMode.Text = "Mode: Neutral";

            btnAddPoints.Click += (s, e) =>
            {
                lblCurrentMode.Text = lblCurrentMode.Text == "Mode: Adding Points"
                    ? "Mode: Neutral"
                    : "Mode: Adding Points";
            };
            btnAddCentroids.Click += (s, e) =>
            {
                lblCurrentMode.Text = lblCurrentMode.Text == "Mode: Adding Centroids"
                    ? "Mode: Neutral"
                    : "Mode: Adding Centroids";
            };
        }

        /// <summary>
        /// This function is called whenever the picture box needs to be repainted.
        /// It is responsible for drawing all of the graphics on the form.
        /// This includes the points, centroids, gridlines, axis, tooltips, and various text displays.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The paint event arguments.</param>
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (showConnections)
            {
                foreach (var point in points.Where(p => p.Centroid != null))
                {
                    var pen = new Pen(Color.LightGray, 0.5f);
                    g.DrawLine(pen, point.Point, point.Centroid.Point);
                }
            }

            int padding = 20; // Amount of padding to add
            int arrowSize = 10; // Size of the arrow heads
            int axisLength =
                Math.Min(pictureBox1.Width, pictureBox1.Height) - 2 * padding; // Ensure the axis are of the same length

            // Adjusted axis
            Point origin = new Point(padding, pictureBox1.Height - padding);
            Point xEnd = new Point(padding + axisLength, pictureBox1.Height - padding);
            Point yEnd = new Point(padding, pictureBox1.Height - padding - axisLength);

            // Draw axis with padding
            g.DrawLine(Pens.Black, origin, xEnd); // X-axis
            g.DrawLine(Pens.Black, origin, yEnd); // Y-axis

            // Draw arrows
            g.DrawLine(Pens.Black, xEnd, new Point(xEnd.X - arrowSize, xEnd.Y - arrowSize));
            g.DrawLine(Pens.Black, xEnd, new Point(xEnd.X - arrowSize, xEnd.Y + arrowSize));
            g.DrawLine(Pens.Black, yEnd, new Point(yEnd.X - arrowSize, yEnd.Y + arrowSize));
            g.DrawLine(Pens.Black, yEnd, new Point(yEnd.X + arrowSize, yEnd.Y + arrowSize));


            if (showGrid)
            {
                // Draw gridlines
                Pen gridPen = new Pen(Color.LightGray, 1);
                for (int i = 10; i < 100; i += 10)
                {
                    int x = i * axisLength / 100 + padding;
                    int y = pictureBox1.Height - i * axisLength / 100 - padding;
                    g.DrawLine(gridPen, x, pictureBox1.Height - padding, x,
                        pictureBox1.Height - padding - axisLength); // vertical line
                    g.DrawLine(gridPen, padding, y, padding + axisLength, y); // horizontal line
                }
            }

            // Draw scale with padding
            for (int i = 0; i <= 100; i += 10)
            {
                int x = i * axisLength / 100 + padding;
                int y = pictureBox1.Height - i * axisLength / 100 - padding;
                g.DrawString(i.ToString(), this.Font, Brushes.Black, new Point(x, pictureBox1.Height - padding));
                g.DrawString(i.ToString(), this.Font, Brushes.Black, new Point(padding, y));
            }

            foreach (var point in points)
            {
                var pen = new Pen(point.Color);
                g.DrawLine(pen, point.Point.X - 5, point.Point.Y - 5, point.Point.X + 5, point.Point.Y + 5);
                g.DrawLine(pen, point.Point.X - 5, point.Point.Y + 5, point.Point.X + 5, point.Point.Y - 5);
            }

            foreach (var centroid in centroids)
            {
                var brush = new SolidBrush(centroid.Color);
                g.FillEllipse(brush, centroid.Point.X, centroid.Point.Y, 10, 10);
            }

            if (PointsDgv.Rows.Count > 0 &&
                CentroidsDgv.Rows.Count > 0 &&
                DataGridViewColumnHasValues(PointsDgv, "DistancetoC") &&
                DataGridViewColumnHasValues(PointsDgv, "DistancetoCSquared") &&
                DataGridViewColumnHasValues(CentroidsDgv, "Kpn") &&
                DataGridViewColumnHasValues(CentroidsDgv, "SumDistancetoC") &&
                DataGridViewColumnHasValues(CentroidsDgv, "SumDistancetoCAvg") &&
                DataGridViewColumnHasValues(CentroidsDgv, "DensityFactor"))
            {
                // Calculate WCSS
                double wcss = 0;
                foreach (DataGridViewRow row in CentroidsDgv.Rows)
                {
                    if (row.Cells["SumDistancetoC"].Value != null)
                    {
                        wcss += double.Parse(row.Cells["SumDistancetoC"].Value.ToString());
                    }
                }

                // Calculate density factor ρ
                double densityFactor = 0;
                foreach (DataGridViewRow row in CentroidsDgv.Rows)
                {
                    if (row.Cells["SumDistancetoCAvg"].Value != null)
                    {
                        densityFactor += double.Parse(row.Cells["SumDistancetoCAvg"].Value.ToString());
                    }
                }

                densityFactor /= CentroidsDgv.Rows.Count;

                // Translate centroids to normalized coordinate system
                List<PointF> translatedCentroids = centroids
                    .Select(c => Utilities.TranslatePoint(c.Point, pictureBox1.Width, pictureBox1.Height)).ToList();


                // Calculate the sum of distances and the sum of squared distances from each translated centroid to the virtual centroid
                float sumOfDistances = translatedCentroids.Sum(c => (float)Math.Sqrt(
                    (c.X - VCC.Point.X) * (c.X - VCC.Point.X)
                    + (c.Y - VCC.Point.Y) * (c.Y - VCC.Point.Y)));
                float sumOfSquaredDistances = translatedCentroids.Sum(c => (c.X - VCC.Point.X) * (c.X - VCC.Point.X)
                                                                           + (c.Y - VCC.Point.Y) * (c.Y - VCC.Point.Y));
                double diff = (wcss / (lambda * densityFactor * dimensiality)) - (sumOfDistances + 4 * densityFactor / lambda);

                // Draw WCSS, density factor ρ and sum of distances and sum of squared distances
                string displayText =
                    $"WCSS: {wcss:F2}\nDensity: {densityFactor:F2}\nDimensionality(1/d): {(1.0 / 2.0):F2}\nVirtual CC Sum Distances: {sumOfDistances:F2}\nVirtual CC Sum Squared Distances: {sumOfSquaredDistances:F2}\nλ: {lambda:F2}, 1/λ: {1/lambda:F2}, ρ: {densityFactor}, d: {dimensiality}\nΔ((WCSS/(λ*ρ*d)),Σd(C,VCC) + 4ρ/λ): {diff:F2}";
                //SizeF textSize = e.Graphics.MeasureString(displayText, this.Font);
                PointF textLocation = new PointF(70, 20);
                e.Graphics.DrawString(displayText, this.Font, Brushes.Red, textLocation);
                UpdateElbowChart(wcss, sumOfDistances);

                if (showVCC && VCC != null)
                {
                    // Create a bold font
                    var boldFont = new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold);


                    // Create a bold pen
                    var boldPen = new Pen(Color.Red, 2.0f); // Change the second parameter to adjust the thickness

                    // Draw lines from virtual centroid to each centroid using the bold pen
                    foreach (PointF cp in centroids.Select(c => c.Point))
                        e.Graphics.DrawLine(boldPen, VCC.Point, cp);

                    // Draw the virtual centroid as the text "VC", not an ellipse, in bold
                    e.Graphics.DrawString("VC", boldFont, Brushes.DarkRed, VCC.Point);
                }

                if (ShowCentroidsBoundries)
                {
                    foreach (var centroid in centroids)
                    {
                        var brush = new SolidBrush(centroid.Color);

                        // Get all points for this centroid
                        var centroidPoints = points.Where(p => p.Centroid != null && p.Centroid.Id == centroid.Id)
                            .ToList();

                        if (centroidPoints.Any())
                        {
                            // Calculate the maximum distance from the centroid in x and y directions
                            float maxXDistance = centroidPoints.Max(p => Math.Abs(p.Point.X - centroid.Point.X));
                            float maxYDistance = centroidPoints.Max(p => Math.Abs(p.Point.Y - centroid.Point.Y));

                            // Calculate the width and height using these maximum distances
                            float width = 2 * maxXDistance;
                            float height = 2 * maxYDistance;

                            // Add some padding
                            padding = 25;
                            width += 2 * padding;
                            height += 2 * padding;

                            // Adjust x and y to be the upper-left corner of the bounding rectangle around the centroid
                            float x = centroid.Point.X - Math.Max(width, height) / 2;
                            float y = centroid.Point.Y - Math.Max(width, height) / 2;

                            // Draw an ellipse around each centroid
                            g.DrawEllipse(Pens.Black, x, y, Math.Max(width, height), Math.Max(width, height));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// This function is called whenever the user clicks their mouse on the picture box.
        /// It is responsible for handling the user's interaction with the form, such as adding and removing points and centroids.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The mouse event arguments.</param>
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            // Translate the mouse coordinates
            PointF translatedPoint = Utilities.TranslatePoint(new PointF(e.X, e.Y),
                pictureBox1.Width, pictureBox1.Height);

            // Round the translated coordinates to the nearest whole number
            int x = (int)Math.Round(translatedPoint.X);
            int y = (int)Math.Round(translatedPoint.Y);

            // Reverse translate the rounded point
            PointF point = Utilities.ReverseTranslatePoint(new PointF(x, y),
                pictureBox1.Width, pictureBox1.Height);

            if (e.Button == MouseButtons.Left)
            {
                if (lblCurrentMode.Text == "Mode: Adding Points")
                {
                    var centroid = centroids.FirstOrDefault(pt =>
                        Math.Sqrt(Math.Pow(pt.Point.X - x, 2) + Math.Pow(pt.Point.Y - y, 2)) < 10);
                    if (centroid != null)
                    {
                        centroids.Remove(centroid);
                        points.Add(new PointData { Point = point, Color = centroid.Color });
                    }
                    else
                    {
                        points.Add(new PointData { Point = point, Color = Color.Blue });
                    }
                }
                else if (lblCurrentMode.Text == "Mode: Adding Centroids")
                {
                    var pointData = points.FirstOrDefault(pt =>
                        Math.Sqrt(Math.Pow(pt.Point.X - x, 2) + Math.Pow(pt.Point.Y - y, 2)) < 10);
                    if (pointData != null)
                    {
                        points.Remove(pointData);
                        centroids.Add(new CentroidData { Point = point, Color = colors[rand.Next(colors.Count)] });
                    }
                    else
                    {
                        // Get list of used colors by centroids
                        var usedColors = centroids.Select(c => c.Color).ToList();

                        // Get list of available colors (all colors except those already used)
                        var availableColors = colors.Except(usedColors).ToList();

                        // Pick a random color from the available ones
                        var color = availableColors[rand.Next(availableColors.Count)];

                        // Add the new centroid with the chosen color
                        centroids.Add(new CentroidData { Point = point, Color = color });
                    }
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                points.RemoveAll(pt => Math.Sqrt(Math.Pow(pt.Point.X - x, 2) + Math.Pow(pt.Point.Y - y, 2)) < 10);
                centroids.RemoveAll(pt => Math.Sqrt(Math.Pow(pt.Point.X - x, 2) + Math.Pow(pt.Point.Y - y, 2)) < 10);
            }

            pictureBox1.Invalidate();
            UpdateDataGridView();
        }

        /// <summary>
        /// This function is called whenever the user moves their mouse on the picture box.
        /// It is responsible for displaying tooltips when the user hovers their mouse over a point or a centroid.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The mouse event arguments.</param>
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            string tooltipText = "";

            foreach (var point in points)
            {
                if (Math.Sqrt(Math.Pow(point.Point.X - e.X, 2) + Math.Pow(point.Point.Y - e.Y, 2)) < 10)
                {
                    var p = Utilities.TranslatePoint(point.Point, pictureBox1.Width, pictureBox1.Height);
                    tooltipText = $"Point: ({p.X:F}, {p.Y:F})";
                    break;
                }
            }

            foreach (var centroid in centroids)
            {
                if (Math.Sqrt(Math.Pow(centroid.Point.X - e.X, 2) + Math.Pow(centroid.Point.Y - e.Y, 2)) < 10)
                {
                    var c = Utilities.TranslatePoint(centroid.Point, pictureBox1.Width, pictureBox1.Height);
                    tooltipText = $"Centroid: ({c.X:F}, {c.Y:F})";
                    break;
                }
            }

            if (string.IsNullOrEmpty(tooltipText))
                return;

            toolTip.SetToolTip(pictureBox1, tooltipText);
        }

        /// <summary>
        /// This function is called when the user clicks the Clear button.
        /// It is responsible for clearing all data and resetting the form to its initial state.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments.</param>
        private void ClearBtn_Click(object sender, EventArgs e)
        {
            points.Clear();
            elbowChartData.Clear();
            centroids.Clear();
            VCC = null;
            elbowDgv.Rows.Clear();
            CentroidsDgv.Rows.Clear();
            PointsDgv.Rows.Clear();
            pictureBox1.Invalidate();
            pictureBox2.Invalidate();
            UpdateDataGridView();
        }

        /// <summary>
        /// This function updates the virtual centroid of clusters (VCC) based on the current centroids.
        /// </summary>
        private void UpdateVCC()
        {
            if (!centroids.Any())
                return;

            var virtualCentroidX = centroids.Average(c => c.Point.X);
            var virtualCentroidY = centroids.Average(c => c.Point.Y);

            // Update the VCC
            if (VCC == null)
                VCC = new CentroidData { Point = new PointF(virtualCentroidX, virtualCentroidY), Color = Color.Black };
            else
                VCC.Point = new PointF(virtualCentroidX, virtualCentroidY);
        }

        /// <summary>
        /// This function updates the DataGrid view elements in the form.
        /// It displays the current points and centroids, along with their associated data.
        /// </summary>
        private void UpdateDataGridView()
        {
            // Clear existing rows
            UpdateVCC();
            PointsDgv.Rows.Clear();
            CentroidsDgv.Rows.Clear();


            int index = 0;
            foreach (var centroid in centroids)
            {
                var c = Utilities.TranslatePoint(centroid.Point, pictureBox1.Width, pictureBox1.Height);
                var pointsCount = points.Count(pt => pt.Centroid == centroid);
                var wcss = Utilities.CalculateWCSS(centroid, points, pictureBox1.Width, pictureBox1.Height);

                var pointsForCentroid = points.Where(pt => pt.Centroid == centroid).ToList();
                double densityFactor = 0;
                if (pointsForCentroid.Count > 1)
                    foreach (var point in pointsForCentroid)
                    {
                        double minDistance = pointsForCentroid.Where(p => p != point)
                            .Min(p => Utilities.CalculateDistance(point, p, pictureBox1.Width, pictureBox1.Height));
                        densityFactor += minDistance;
                    }

                densityFactor /= pointsForCentroid.Count;

                // Calculate distance to virtual centroid
                double distanceToVcc = Math.Sqrt((c.X - VCC.Point.X) * (c.X - VCC.Point.X) +
                                                 (c.Y - VCC.Point.Y) * (c.Y - VCC.Point.Y));

                CentroidsDgv.Rows.Add(c.X, c.Y, pointsCount,
                    Math.Round(wcss, 2), Math.Round(wcss / pointsCount, 2),
                    Math.Round(densityFactor, 2), Math.Round(distanceToVcc, 2));
                CentroidsDgv.Rows[index].DefaultCellStyle.BackColor = centroid.Color;
                index++;
            }

            index = 0;

            // Add rows for points
            foreach (var point in points.Where(p => p.Centroid != null).OrderBy(p => p.Centroid.Id))
            {
                var p = Utilities.TranslatePoint(point.Point, pictureBox1.Width, pictureBox1.Height);

                if (point.Centroid != null)
                {
                    var c = Utilities.TranslatePoint(point.Centroid.Point, pictureBox1.Width, pictureBox1.Height);
                    var d2c = (float)Math.Sqrt(Math.Pow(p.X - c.X, 2) + Math.Pow(p.Y - c.Y, 2));
                    PointsDgv.Rows.Add(p.X, p.Y, Math.Round(d2c, 2), Math.Round(Math.Pow(d2c, 2), 2));
                    PointsDgv.Rows[index].DefaultCellStyle.BackColor = point.Centroid.Color;
                }
                else
                {
                    PointsDgv.Rows.Add(p.X, p.Y, string.Empty, string.Empty);
                }

                index++;
            }
        }

        /// <summary>
        /// This function is called when the user clicks the Show Grid button.
        /// It toggles the state of the grid in the picture box and refreshes the picture box.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments.</param>
        private void ShowGridBtn_Click(object sender, EventArgs e)
        {
            showGrid = !showGrid;
            pictureBox1.Invalidate();
        }

        /// <summary>
        /// This function is called when the user clicks the Show Connections button.
        /// It toggles the state of the connections in the picture box and refreshes the picture box.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments.</param>
        private void ShowConnectionsBtn_Click(object sender, EventArgs e)
        {
            showConnections = !showConnections;
            pictureBox1.Invalidate();
        }

        /// <summary>
        /// This function is called when the user clicks the Associate Points button.
        /// It associates each point with the closest centroid and updates the DataGrid view and the picture box.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments.</param>
        private void AssociatePointsBtn_Click(object sender, EventArgs e)
        {
            Utilities.AssociateToClosestCentroid(points, centroids);
            UpdateDataGridView();
            pictureBox1.Invalidate();
        }

        /// <summary>
        /// This function is called when the user clicks the Add New Centroid button.
        /// It adds a new centroid at the location of a randomly selected point or the furthest point from existing centroids.
        /// It then updates the DataGrid view and the picture box.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments.</param>
        private void AddNewCentroidBtn_Click(object sender, EventArgs e)
        {
            if (!points.Any()) return;

            if (!centroids.Any())
            {
                centroids.Add(new CentroidData()
                {
                    Color = colors[rand.Next(colors.Count)],
                    Point = points[rand.Next(points.Count)].Point
                });
            }
            else
            {
                var furthestPoint = Utilities.GetFurthestPointFromCentroids(centroids, points);
                centroids.Add(new CentroidData()
                {
                    Color = colors.Except(centroids.Select(c => c.Color)).ToArray()[
                        rand.Next(colors.Count - centroids.Count)],
                    Point = furthestPoint.Point
                });
            }

            UpdateDataGridView();
            pictureBox1.Invalidate();
        }

        /// <summary>
        /// This function is called when the user clicks the Optimize Centroid Position button.
        /// It optimizes the positions of the centroids and updates the DataGrid view and the picture box.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments.</param>
        private void OptimizeCentroidPositionBtn_Click(object sender, EventArgs e)
        {
            Utilities.AssociateToClosestCentroid(points, centroids);
            Utilities.OptimizeCentroidPosition(points, centroids);
            UpdateDataGridView();
            pictureBox1.Invalidate();
        }

        /// <summary>
        /// This function is called when the user clicks the Full K-means button.
        /// It performs the full K-means algorithm, including associating points to centroids and optimizing centroid positions.
        /// It then updates the DataGrid view and the picture box.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments.</param>
        private void FullKmeanBtn_Click(object sender, EventArgs e)
        {
            var centroidsLocations = centroids.Select(c => c.Point).ToList();
            var lastCentroidsLocations = new List<PointF>();

            int limit = 50;

            while (limit-- > 0 && !centroidsLocations.SequenceEqual(lastCentroidsLocations))
            {
                lastCentroidsLocations = new List<PointF>(centroidsLocations);
                Utilities.AssociateToClosestCentroid(points, centroids);
                Utilities.OptimizeCentroidPosition(points, centroids);
                centroidsLocations = centroids.Select(c => c.Point).ToList();
            }

            UpdateDataGridView();
            pictureBox1.Invalidate();
        }

        /// <summary>
        /// This function is called when the user clicks the Save Image button.
        /// It saves the current image in the picture box to a file selected by the user.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments.</param>
        private void SaveImgBtn_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Images|*.png;*.bmp;*.jpg";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    pictureBox1.DrawToBitmap(bmp, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
                    bmp.Save(sfd.FileName);
                }
            }
        }

        /// <summary>
        /// This function is called when the user clicks the Create Random Points button.
        /// It creates a set number of random points and refreshes the picture box.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments.</param>
        private void CreateRandomPointsBtn_Click(object sender, EventArgs e)
        {
            points.Clear();
            elbowChartData.Clear();
            centroids.Clear();
            VCC = null;
            Random random = new Random();
            for (int i = 0; i < 20; i++)
            {
                float x = (float)random.NextDouble() * pictureBox1.Width;
                float y = (float)random.NextDouble() * pictureBox1.Height;
                points.Add(new PointData { Point = new PointF(x, y), Color = Color.Black });
            }

            pictureBox1.Invalidate();
        }

        /// <summary>
        /// This function checks if a column in a DataGridView has any values.
        /// It returns true if the column exists and all its cells have values, false otherwise.
        /// </summary>
        /// <param name="dgv">The DataGridView to check.</param>
        /// <param name="columnName">The name of the column to check.</param>
        /// <returns>A boolean indicating whether the column has any values.</returns>
        private bool DataGridViewColumnHasValues(DataGridView dgv, string columnName)
        {
            if (!dgv.Columns.Contains(columnName))
            {
                return false;
            }

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells[columnName].Value == null ||
                    string.IsNullOrWhiteSpace(row.Cells[columnName].Value.ToString()))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// This function is called when the user clicks the Create Centralized Random Points button.
        /// It creates a number of clusters of random points around central points and refreshes the picture box.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments.</param>
        private void CreateCentralizedRandomPointsBtn_Click(object sender, EventArgs e)
        {
            points.Clear();
            elbowChartData.Clear();
            centroids.Clear();
            VCC = null;
            Random random = new Random();

            int numClusters = 4;
            int pointsPerCluster = 5; // Change this to control the number of points per cluster
            float radius = 50; // Change this to control the radius around each cluster center
            int padding = 100; // Padding from the edges of the PictureBox

            for (int i = 0; i < numClusters; i++)
            {
                // Generate a random central point for the cluster, with padding
                float centerX = padding + (float)random.NextDouble() * (pictureBox1.Width - 2 * padding);
                float centerY = padding + (float)random.NextDouble() * (pictureBox1.Height - 2 * padding);

                // Generate points around the central point
                for (int j = 0; j < pointsPerCluster; j++)
                {
                    double angle = random.NextDouble() * Math.PI * 2; // Random angle
                    float x = centerX +
                              radius * (float)Math.Cos(angle); // X position with respect to the radius and angle
                    float y = centerY +
                              radius * (float)Math.Sin(angle); // Y position with respect to the radius and angle

                    // Ensure the points are within the PictureBox
                    x = Math.Max(0, Math.Min(pictureBox1.Width, x));
                    y = Math.Max(0, Math.Min(pictureBox1.Height, y));

                    points.Add(new PointData { Point = new PointF(x, y), Color = Color.Black });
                }
            }

            pictureBox1.Invalidate();
        }

        /// <summary>
        /// This function is called when the user clicks the New Centroid and Full K-mean button.
        /// It adds a new centroid and performs the full K-means algorithm.
        /// It then updates the DataGrid view and the picture box.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments.</param>
        private void NewCentroidAndFullKmeanBtn_Click(object sender, EventArgs e)
        {
            if (!points.Any()) return;

            if (!centroids.Any())
            {
                centroids.Add(new CentroidData()
                {
                    Color = colors[rand.Next(colors.Count)],
                    Point = points[rand.Next(points.Count)].Point
                });
            }
            else
            {
                var furthestPoint = Utilities.GetFurthestPointFromCentroids(centroids, points);
                centroids.Add(new CentroidData()
                {
                    Color = colors.Except(centroids.Select(c => c.Color)).ToArray()[
                        rand.Next(colors.Count - centroids.Count)],
                    Point = furthestPoint.Point
                });
            }

            var centroidsLocations = centroids.Select(c => c.Point).ToList();
            var lastCentroidsLocations = new List<PointF>();

            int limit = 50;

            while (limit-- > 0 && !centroidsLocations.SequenceEqual(lastCentroidsLocations))
            {
                lastCentroidsLocations = new List<PointF>(centroidsLocations);
                Utilities.AssociateToClosestCentroid(points, centroids);
                Utilities.OptimizeCentroidPosition(points, centroids);
                centroidsLocations = centroids.Select(c => c.Point).ToList();
            }

            UpdateDataGridView();
            pictureBox1.Invalidate();
        }

        /// <summary>
        /// This function is called when the user clicks the Show Virtual Centroid button.
        /// It toggles the state of the virtual centroid in the picture box and refreshes the picture box.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments.</param>
        private void ShowVirtualCCBtn_Click(object sender, EventArgs e)
        {
            showVCC = !showVCC;
            UpdateDataGridView();
            pictureBox1.Invalidate();
        }

        /// <summary>
        /// This function is called when the user clicks the Show Centroids Boundaries button.
        /// It toggles the visibility of the centroids boundaries in the picture box and refreshes the picture box.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments.</param>
        private void ShowCentroidsBoundriesBtn_Click(object sender, EventArgs e)
        {
            ShowCentroidsBoundries = !ShowCentroidsBoundries;
            UpdateDataGridView();
            pictureBox1.Invalidate();
        }

        /// <summary>
        /// This function updates the elbow chart with a new data point.
        /// It then refreshes the elbow chart to reflect the new data.
        /// </summary>
        /// <param name="wcss">The within-cluster sum of squares for the new data point.</param>
        /// <param name="sumOfDistances">The sum of distances for the new data point.</param>
        private void UpdateElbowChart(double wcss, float sumOfDistances)
        {
            if (!elbowChartData.Any(x => x.WCSS == wcss && sumOfDistances == sumOfDistances))
                elbowChartData.Add(new ElbowChartData { centroidsCount = centroids.Count, WCSS = wcss, SumOfDistances = sumOfDistances });

            elbowDgv.Rows.Clear();
            foreach (var elbowChartDatum in elbowChartData)
            {
                elbowDgv.Rows.Add(elbowChartDatum.centroidsCount, elbowChartDatum.WCSS, elbowChartDatum.SumOfDistances);
            }

            using (Graphics g = pictureBox2.CreateGraphics())
            {
                g.Clear(Color.White);

                int padding = 40;

                DrawGridAndAxes(g, padding);

                float prevX = -1, prevYWCSS = -1, prevYSumOfDistances = -1;

                for (int i = 0; i < elbowChartData.Count; i++)
                {
                    float x = ((i + 1) * (pictureBox2.Width - 2 * padding) / 10f) + padding;
                    float yWCSS = pictureBox2.Height - padding - (float)((elbowChartData[i].WCSS) / 10000f * (pictureBox2.Height - 2 * padding));
                    float ySumOfDistances = pictureBox2.Height - padding - (float)((elbowChartData[i].SumOfDistances) / 10000f * (pictureBox2.Height - 2 * padding));

                    g.FillEllipse(Brushes.Red, x - 5, yWCSS - 5, 10, 10); // WCSS
                    g.FillEllipse(Brushes.Blue, x - 5, ySumOfDistances - 5, 10, 10); // SumOfDistances

                    if (prevX != -1)
                    {
                        g.DrawLine(Pens.Red, prevX, prevYWCSS, x, yWCSS);
                        g.DrawLine(Pens.Blue, prevX, prevYSumOfDistances, x, ySumOfDistances);
                    }

                    prevX = x;
                    prevYWCSS = yWCSS;
                    prevYSumOfDistances = ySumOfDistances;
                }

                Font axisFont = new Font("Arial", 10);

                for (int i = 0; i < elbowChartData.Count - 1; i++)
                {
                    if (elbowChartData.Count > 1)
                    {
                        if ((elbowChartData[i].WCSS >= elbowChartData[i].SumOfDistances && elbowChartData[i + 1].WCSS <= elbowChartData[i + 1].SumOfDistances) ||
                            (elbowChartData[i].WCSS <= elbowChartData[i].SumOfDistances && elbowChartData[i + 1].WCSS >= elbowChartData[i + 1].SumOfDistances))
                        {
                            // Calculate the intersection point
                            float x1 = (i + 1) * (pictureBox2.Width - 2 * padding) / 10f + padding;
                            float y1WCSS = pictureBox2.Height - padding - (float)((elbowChartData[i].WCSS) / 10000f * (pictureBox2.Height - 2 * padding));
                            float y1SumOfDistances = pictureBox2.Height - padding - (float)((elbowChartData[i].SumOfDistances) / 10000f * (pictureBox2.Height - 2 * padding));
                            float x2 = (i + 2) * (pictureBox2.Width - 2 * padding) / 10f + padding;
                            float y2WCSS = pictureBox2.Height - padding - (float)((elbowChartData[i + 1].WCSS) / 10000f * (pictureBox2.Height - 2 * padding));
                            float y2SumOfDistances = pictureBox2.Height - padding - (float)((elbowChartData[i + 1].SumOfDistances) / 10000f * (pictureBox2.Height - 2 * padding));

                            float m1 = (y2WCSS - y1WCSS) / (x2 - x1); // Slope of the WCSS line
                            float m2 = (y2SumOfDistances - y1SumOfDistances) / (x2 - x1); // Slope of the SumOfDistances line
                            float c1 = y1WCSS - m1 * x1; // y-intercept of the WCSS line
                            float c2 = y1SumOfDistances - m2 * x1; // y-intercept of the SumOfDistances line

                            float intersectionX = (c2 - c1) / (m1 - m2);
                            float intersectionY = m1 * intersectionX + c1;

                            // Draw horizontal dashed red line
                            Pen dashedRedPen = new Pen(Color.Red) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };
                            g.DrawLine(dashedRedPen, padding, intersectionY, pictureBox2.Width - padding, intersectionY);

                            // Draw intersection values
                            string labelText = $"\t\tCn: {elbowChartData[i + 1].centroidsCount}, WCSS = Σd(C,VCC) = {elbowChartData[i + 1].SumOfDistances}";
                            g.DrawString(labelText, axisFont, Brushes.Red, intersectionX, intersectionY - 20);

                            break; // Exit the loop
                        }
                    }
                }

            }

        }

        /// <summary>
        /// This function draws the grid and axes for the elbow chart.
        /// </summary>
        /// <param name="g">The graphics object to draw on.</param>
        /// <param name="padding">The padding around the grid and axes.</param>
        private void DrawGridAndAxes(Graphics g, int padding)
        {
            // Define axis properties
            Pen axisPen = Pens.Black;
            Font axisFont = new Font("Arial", 10);
            Brush axisBrush = Brushes.Black;
            int arrowSize = 10;
            int numberOfGridLines = 10;

            // Draw x and y axes with arrows
            g.DrawLine(axisPen, padding, pictureBox2.Height - padding, pictureBox2.Width - padding, pictureBox2.Height - padding); // X-axis
            g.DrawLine(axisPen, padding, padding, padding, pictureBox2.Height - padding); // Y-axis

            // Draw grid lines and axis labels
            for (int i = 0; i <= numberOfGridLines; i++)
            {
                int x = i * (pictureBox2.Width - 2 * padding) / numberOfGridLines + padding;
                int y = pictureBox2.Height - i * (pictureBox2.Height - 2 * padding) / numberOfGridLines - padding;

                // Draw vertical grid line and x-axis label
                g.DrawLine(Pens.LightGray, x, pictureBox2.Height - padding, x, padding);
                g.DrawString((i).ToString(), axisFont, axisBrush, x, pictureBox2.Height - padding + (arrowSize / 2));

                // Draw horizontal grid line and y-axis label
                g.DrawLine(Pens.LightGray, padding, y, pictureBox2.Width - padding, y);
                g.DrawString((10000 * i / numberOfGridLines).ToString(), axisFont, axisBrush, padding - (arrowSize * 2), y - axisFont.Height / 2);
            }
        }

        /// <summary>
        /// This function is called when the user clicks the Remove Centroid and Full K-mean button.
        /// It removes the last centroid added, performs the full K-means algorithm, and updates the elbow chart.
        /// It then updates the DataGrid view and the picture box.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments.</param>
        private void RemoveCentroidAndFullKmeanBtn_Click(object sender, EventArgs e)
        {
            if (!centroids.Any())
                return;

            centroids.RemoveAt(centroids.Count - 1);
            elbowChartData.Remove(elbowChartData.Last());
            CentroidsDgv.Rows.RemoveAt(CentroidsDgv.Rows.Count - 1);

            elbowDgv.Rows.Clear();
            foreach (var elbowChartDatum in elbowChartData)
            {
                elbowDgv.Rows.Add(elbowChartDatum.centroidsCount, elbowChartDatum.WCSS,
                    Math.Round(elbowChartDatum.SumOfDistances, 2));
            }

            var centroidsLocations = centroids.Select(c => c.Point).ToList();
            var lastCentroidsLocations = new List<PointF>();

            int limit = 50;

            while (limit-- > 0 && !centroidsLocations.SequenceEqual(lastCentroidsLocations))
            {
                lastCentroidsLocations = new List<PointF>(centroidsLocations);
                Utilities.AssociateToClosestCentroid(points, centroids);
                Utilities.OptimizeCentroidPosition(points, centroids);
                centroidsLocations = centroids.Select(c => c.Point).ToList();
            }

            UpdateVCC();
            UpdateDataGridView();
            pictureBox1.Invalidate();
        }
    }
}