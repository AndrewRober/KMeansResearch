using System.Drawing;
using System.Text.Json;

namespace KMeansResearchTools
{
    public partial class Form1 : Form
    {
        private List<PointData> points;
        private List<CentroidData> centroids;
        List<Color> colors = new()
        {
            Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.Purple,
            Color.Orange, Color.Pink, Color.Brown, Color.Gray, Color.Cyan,
            Color.Magenta, Color.Lime, Color.Maroon, Color.Navy, Color.Olive,
            Color.Teal, Color.Azure, Color.Gold, Color.Silver, Color.RosyBrown
        };
        private Random rand;
        private ToolTip toolTip;
        private bool isAddingPoints;
        private bool isAddingCentroids;

        public Form1()
        {
            InitializeComponent();

            points = new List<PointData>();
            centroids = new List<CentroidData>();
            rand = new Random();
            toolTip = new ToolTip();

            dataGridView1.Columns.Add("EntryType", "EntryType");
            dataGridView1.Columns.Add("X", "X");
            dataGridView1.Columns.Add("Y", "Y");
            dataGridView1.Columns.Add("DistancetoC", "Distance to C");

            pictureBox1.Paint += pictureBox1_Paint;
            pictureBox1.MouseClick += pictureBox1_MouseClick;
            pictureBox1.MouseMove += pictureBox1_MouseMove;

            lblCurrentMode.Text = "Mode: Neutral";

            btnAddPoints.Click += (s, e) => { lblCurrentMode.Text = lblCurrentMode.Text == "Mode: Adding Points" ? "Mode: Neutral" : "Mode: Adding Points"; };
            btnAddCentroids.Click += (s, e) => { lblCurrentMode.Text = lblCurrentMode.Text == "Mode: Adding Centroids" ? "Mode: Neutral" : "Mode: Adding Centroids"; };
        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int padding = 20;  // Amount of padding to add
            int arrowSize = 10;  // Size of the arrow heads
            int axisLength = Math.Min(pictureBox1.Width, pictureBox1.Height) - 2 * padding;  // Ensure the axis are of the same length

            // Adjusted axis
            Point origin = new Point(padding, pictureBox1.Height - padding);
            Point xEnd = new Point(padding + axisLength, pictureBox1.Height - padding);
            Point yEnd = new Point(padding, pictureBox1.Height - padding - axisLength);

            // Draw axis with padding
            g.DrawLine(Pens.Black, origin, xEnd);  // X-axis
            g.DrawLine(Pens.Black, origin, yEnd);  // Y-axis

            // Draw arrows
            g.DrawLine(Pens.Black, xEnd, new Point(xEnd.X - arrowSize, xEnd.Y - arrowSize));
            g.DrawLine(Pens.Black, xEnd, new Point(xEnd.X - arrowSize, xEnd.Y + arrowSize));
            g.DrawLine(Pens.Black, yEnd, new Point(yEnd.X - arrowSize, yEnd.Y + arrowSize));
            g.DrawLine(Pens.Black, yEnd, new Point(yEnd.X + arrowSize, yEnd.Y + arrowSize));

            // Draw gridlines
            Pen gridPen = new Pen(Color.LightGray, 1);
            for (int i = 10; i < 100; i += 10)
            {
                int x = i * axisLength / 100 + padding;
                int y = pictureBox1.Height - i * axisLength / 100 - padding;
                g.DrawLine(gridPen, x, pictureBox1.Height - padding, x, pictureBox1.Height - padding - axisLength); // vertical line
                g.DrawLine(gridPen, padding, y, padding + axisLength, y); // horizontal line
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
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            // Translate the mouse coordinates
            PointF translatedPoint = TranslatePoint(new PointF(e.X, e.Y));

            // Round the translated coordinates to the nearest whole number
            int x = (int)Math.Round(translatedPoint.X);
            int y = (int)Math.Round(translatedPoint.Y);

            // Reverse translate the rounded point
            PointF point = ReverseTranslatePoint(new PointF(x, y));

            if (e.Button == MouseButtons.Left)
            {
                if (lblCurrentMode.Text == "Mode: Adding Points")
                {
                    var centroid = centroids.FirstOrDefault(pt => Math.Sqrt(Math.Pow(pt.Point.X - x, 2) + Math.Pow(pt.Point.Y - y, 2)) < 10);
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
                    var pointData = points.FirstOrDefault(pt => Math.Sqrt(Math.Pow(pt.Point.X - x, 2) + Math.Pow(pt.Point.Y - y, 2)) < 10);
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

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            string tooltipText = "";

            foreach (var point in points)
            {
                if (Math.Sqrt(Math.Pow(point.Point.X - e.X, 2) + Math.Pow(point.Point.Y - e.Y, 2)) < 10)
                {
                    var p = TranslatePoint(point.Point);
                    tooltipText = $"Point: ({p.X:F}, {p.Y:F})";
                    break;
                }
            }

            foreach (var centroid in centroids)
            {
                if (Math.Sqrt(Math.Pow(centroid.Point.X - e.X, 2) + Math.Pow(centroid.Point.Y - e.Y, 2)) < 10)
                {
                    var c = TranslatePoint(centroid.Point);
                    tooltipText = $"Centroid: ({c.X:F}, {c.Y:F})";
                    break;
                }
            }

            if (string.IsNullOrEmpty(tooltipText))
                return;

            toolTip.SetToolTip(pictureBox1, tooltipText);
        }

        private PointF TranslatePoint(PointF originalPoint)
        {
            int padding = 20;
            int axisLength = Math.Min(pictureBox1.Width, pictureBox1.Height) - 2 * padding;  // Ensure the axis are of the same length

            // Translate and scale points relative to the new origin with padding and invert Y-axis
            float x = (originalPoint.X - padding) * 100 / axisLength;
            float y = 100 - (originalPoint.Y - padding) * 100 / axisLength;

            // Round the translated values to the nearest whole number
            return new PointF((float)Math.Round(x), (float)Math.Round(y));
        }

        private PointF ReverseTranslatePoint(PointF translatedPoint)
        {
            int padding = 20;
            int axisLength = Math.Min(pictureBox1.Width, pictureBox1.Height) - 2 * padding;  // Ensure the axis are of the same length

            // Reverse translate and scale points relative to the new origin with padding and invert Y-axis
            float x = (translatedPoint.X * axisLength / 100) + padding;
            float y = padding + (100 - translatedPoint.Y) * axisLength / 100;

            return new PointF(x, y);
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            points.Clear();
            centroids.Clear();
            pictureBox1.Invalidate();
            UpdateDataGridView();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "KMP files (*.kmp)|*.kmp";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                Save(saveFileDialog.FileName, points, centroids);
        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "KMP files (*.kmp)|*.kmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Load(openFileDialog.FileName, out points, out centroids);
                pictureBox1.Invalidate();  // Redraw the picture box
            }
        }

        public void Save(string filePath, List<PointData> points, List<CentroidData> centroids)
        {
            // Create a dictionary to hold the points and centroids
            var data = new Dictionary<string, object>
            {
                {"Points", points},
                {"Centroids", centroids}
            };

            // Convert the dictionary to a JSON string
            var jsonString = JsonSerializer.Serialize(data);

            // Write the JSON string to the file
            File.WriteAllText(filePath, jsonString);
            UpdateDataGridView();
        }

        public void Load(string filePath, out List<PointData> points, out List<CentroidData> centroids)
        {
            // Read the JSON string from the file
            var jsonString = File.ReadAllText(filePath);

            // Convert the JSON string back to a dictionary
            var data = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(jsonString);

            points = JsonSerializer.Deserialize<List<PointData>>(data["Points"].ToString());
            centroids = JsonSerializer.Deserialize<List<CentroidData>>(data["Centroids"].ToString());
            UpdateDataGridView();
        }

        private void UpdateDataGridView()
        {
            // Clear existing rows
            dataGridView1.Rows.Clear();

            int index = 0;

            // Add rows for centroids
            foreach (var centroid in centroids)
            {
                dataGridView1.Rows.Add("Centroid",
                    TranslatePoint(centroid.Point).X, TranslatePoint(centroid.Point).Y);
                dataGridView1.Rows[index].DefaultCellStyle.BackColor = centroid.Color;
                index++;
            }

            // Add rows for points
            foreach (var point in points)
            {
                dataGridView1.Rows.Add("Point",
                    TranslatePoint(point.Point).X, TranslatePoint(point.Point).Y, point.DistanceToCentroid);
                if (point.Centroid != null)
                {
                    dataGridView1.Rows[index].DefaultCellStyle.BackColor = point.Centroid.Color;
                }
                index++;
            }
        }
    }

    public class PointData
    {
        public PointF Point { get; set; }
        public Color Color { get; set; }
        public CentroidData Centroid { get; set; }
        public float DistanceToCentroid => (float)Math.Sqrt(Math.Pow(Point.X - Centroid.Point.X, 2) + Math.Pow(Point.Y - Centroid.Point.Y, 2));
    }

    public class CentroidData
    {
        public PointF Point { get; set; }
        public Color Color { get; set; }
    }

    public static class Utilities
    {
        public static double CalculateEuclideanDistance(PointF point1, PointF point2)
        {
            return Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2));
        }

        public static PointF CalculateCentroid(List<PointF> points)
        {
            float x = 0;
            float y = 0;

            foreach (var point in points)
            {
                x += point.X;
                y += point.Y;
            }

            return new PointF(x / points.Count, y / points.Count);
        }

        public static PointF GetFurthestPoint(PointF startPoint, List<PointF> points)
        {
            PointF furthestPoint = new PointF();
            double maxDistance = 0;

            foreach (var point in points)
            {
                double distance = CalculateEuclideanDistance(startPoint, point);
                if (distance > maxDistance)
                {
                    maxDistance = distance;
                    furthestPoint = point;
                }
            }

            return furthestPoint;
        }
    }
}