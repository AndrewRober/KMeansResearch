using System.Drawing;
using System.Text.Json;

namespace KMeansResearchTools
{
    public partial class Form1 : Form
    {
        private List<PointF> points;
        private List<PointF> centroids;
        private ToolTip toolTip;
        private bool isAddingPoints;
        private bool isAddingCentroids;

        public Form1()
        {
            InitializeComponent();

            points = new List<PointF>();
            centroids = new List<PointF>();
            toolTip = new ToolTip();

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

            // Draw original points and centroids
            foreach (var point in points)
            {
                g.DrawLine(Pens.Blue, point.X - 5, point.Y - 5, point.X + 5, point.Y + 5);
                g.DrawLine(Pens.Blue, point.X - 5, point.Y + 5, point.X + 5, point.Y - 5);
            }

            foreach (var centroid in centroids)
            {
                g.FillEllipse(Brushes.Red, centroid.X, centroid.Y, 10, 10);
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (lblCurrentMode.Text == "Mode: Adding Points")
                {
                    // Switch from centroid to point if clicked on centroid
                    var centroid = centroids.FirstOrDefault(pt => Math.Sqrt(Math.Pow(pt.X - e.X, 2) + Math.Pow(pt.Y - e.Y, 2)) < 10);
                    if (centroid != default(PointF))
                    {
                        centroids.Remove(centroid);
                        points.Add(centroid);
                    }
                    else
                    {
                        points.Add(new PointF(e.X, e.Y));
                    }
                }
                else if (lblCurrentMode.Text == "Mode: Adding Centroids")
                {
                    // Switch from point to centroid if clicked on point
                    var point = points.FirstOrDefault(pt => Math.Sqrt(Math.Pow(pt.X - e.X, 2) + Math.Pow(pt.Y - e.Y, 2)) < 10);
                    if (point != default(PointF))
                    {
                        points.Remove(point);
                        centroids.Add(point);
                    }
                    else
                    {
                        centroids.Add(new PointF(e.X, e.Y));
                    }
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                points.RemoveAll(pt => Math.Sqrt(Math.Pow(pt.X - e.X, 2) + Math.Pow(pt.Y - e.Y, 2)) < 10);
                centroids.RemoveAll(pt => Math.Sqrt(Math.Pow(pt.X - e.X, 2) + Math.Pow(pt.Y - e.Y, 2)) < 10);
            }

            pictureBox1.Invalidate();  // Force the PictureBox to redraw itself.
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            string tooltipText = "";

            foreach (var point in points)
            {
                if (Math.Sqrt(Math.Pow(point.X - e.X, 2) + Math.Pow(point.Y - e.Y, 2)) < 10)
                {
                    var p = TranslatePoint(point);
                    tooltipText = $"Point: ({p.X}, {p.Y})";
                    break;
                }
            }

            foreach (var centroid in centroids)
            {
                if (Math.Sqrt(Math.Pow(centroid.X - e.X, 2) + Math.Pow(centroid.Y - e.Y, 2)) < 10)
                {
                    var c = TranslatePoint(centroid);
                    tooltipText = $"Centroid: ({c.X}, {c.Y})";
                    break;
                }
            }

            toolTip.SetToolTip(pictureBox1, tooltipText);
        }

        private PointF TranslatePoint(PointF originalPoint)
        {
            int padding = 20;
            int axisLength = Math.Min(pictureBox1.Width, pictureBox1.Height) - 2 * padding;  // Ensure the axis are of the same length

            // Translate and scale points relative to the new origin with padding and invert Y-axis
            return new PointF(
                (originalPoint.X - padding) * 100 / axisLength,
                100 - (originalPoint.Y - padding) * 100 / axisLength
            );
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            points.Clear();
            centroids.Clear();
            pictureBox1.Invalidate();
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
                Load(openFileDialog.FileName, out points, out centroids);
            pictureBox1.Invalidate();  // Redraw the picture box
        }

        public void Save(string filePath, List<PointF> points, List<PointF> centroids)
        {
            // Create a dictionary to hold the points and centroids
            var data = new Dictionary<string, List<PointF>>
            {
                {"Points", points},
                {"Centroids", centroids}
            };

            // Convert the dictionary to a JSON string
            var jsonString = JsonSerializer.Serialize(data);

            // Write the JSON string to the file
            File.WriteAllText(filePath, jsonString);
        }

        public void Load(string filePath, out List<PointF> points, out List<PointF> centroids)
        {
            // Read the JSON string from the file
            var jsonString = File.ReadAllText(filePath);

            // Convert the JSON string back to a dictionary
            var data = JsonSerializer.Deserialize<Dictionary<string, List<PointF>>>(jsonString);

            points = data["Points"];
            centroids = data["Centroids"];
        }
    }
}