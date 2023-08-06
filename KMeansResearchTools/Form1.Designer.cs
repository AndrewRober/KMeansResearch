namespace KMeansResearchTools
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            btnAddPoints = new Button();
            btnAddCentroids = new Button();
            statusStrip1 = new StatusStrip();
            lblCurrentMode = new ToolStripStatusLabel();
            ClearBtn = new Button();
            SaveBtn = new Button();
            LoadBtn = new Button();
            dataGridView1 = new DataGridView();
            ShowGridBtn = new Button();
            ShowConnectionsBtn = new Button();
            AssociatePointsBtn = new Button();
            AddNewCentroidBtn = new Button();
            OptimizeCentroidPositionBtn = new Button();
            dataGridView2 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(600, 600);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnAddPoints
            // 
            btnAddPoints.Location = new Point(12, 618);
            btnAddPoints.Name = "btnAddPoints";
            btnAddPoints.Size = new Size(94, 29);
            btnAddPoints.TabIndex = 1;
            btnAddPoints.Text = "Add Points";
            btnAddPoints.UseVisualStyleBackColor = true;
            // 
            // btnAddCentroids
            // 
            btnAddCentroids.Location = new Point(112, 618);
            btnAddCentroids.Name = "btnAddCentroids";
            btnAddCentroids.Size = new Size(122, 29);
            btnAddCentroids.TabIndex = 2;
            btnAddCentroids.Text = "Add Centroids";
            btnAddCentroids.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblCurrentMode });
            statusStrip1.Location = new Point(0, 691);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1311, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblCurrentMode
            // 
            lblCurrentMode.Name = "lblCurrentMode";
            lblCurrentMode.Size = new Size(0, 16);
            // 
            // ClearBtn
            // 
            ClearBtn.Location = new Point(318, 618);
            ClearBtn.Name = "ClearBtn";
            ClearBtn.Size = new Size(94, 29);
            ClearBtn.TabIndex = 4;
            ClearBtn.Text = "Clear";
            ClearBtn.UseVisualStyleBackColor = true;
            ClearBtn.Click += ClearBtn_Click;
            // 
            // SaveBtn
            // 
            SaveBtn.Location = new Point(418, 618);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(94, 29);
            SaveBtn.TabIndex = 5;
            SaveBtn.Text = "Save";
            SaveBtn.UseVisualStyleBackColor = true;
            SaveBtn.Click += SaveBtn_Click;
            // 
            // LoadBtn
            // 
            LoadBtn.Location = new Point(518, 618);
            LoadBtn.Name = "LoadBtn";
            LoadBtn.Size = new Size(94, 29);
            LoadBtn.TabIndex = 6;
            LoadBtn.Text = "Load";
            LoadBtn.UseVisualStyleBackColor = true;
            LoadBtn.Click += LoadBtn_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(618, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(681, 370);
            dataGridView1.TabIndex = 7;
            // 
            // ShowGridBtn
            // 
            ShowGridBtn.Location = new Point(12, 653);
            ShowGridBtn.Name = "ShowGridBtn";
            ShowGridBtn.Size = new Size(134, 29);
            ShowGridBtn.TabIndex = 8;
            ShowGridBtn.Text = "Show/Hide Grid";
            ShowGridBtn.UseVisualStyleBackColor = true;
            ShowGridBtn.Click += ShowGridBtn_Click;
            // 
            // ShowConnectionsBtn
            // 
            ShowConnectionsBtn.Location = new Point(152, 653);
            ShowConnectionsBtn.Name = "ShowConnectionsBtn";
            ShowConnectionsBtn.Size = new Size(174, 29);
            ShowConnectionsBtn.TabIndex = 9;
            ShowConnectionsBtn.Text = "Show/Hide Centroids";
            ShowConnectionsBtn.UseVisualStyleBackColor = true;
            ShowConnectionsBtn.Click += ShowConnectionsBtn_Click;
            // 
            // AssociatePointsBtn
            // 
            AssociatePointsBtn.Location = new Point(618, 618);
            AssociatePointsBtn.Name = "AssociatePointsBtn";
            AssociatePointsBtn.Size = new Size(129, 29);
            AssociatePointsBtn.TabIndex = 10;
            AssociatePointsBtn.Text = "Associate points";
            AssociatePointsBtn.UseVisualStyleBackColor = true;
            AssociatePointsBtn.Click += AssociatePointsBtn_Click;
            // 
            // AddNewCentroidBtn
            // 
            AddNewCentroidBtn.Location = new Point(753, 618);
            AddNewCentroidBtn.Name = "AddNewCentroidBtn";
            AddNewCentroidBtn.Size = new Size(204, 29);
            AddNewCentroidBtn.TabIndex = 11;
            AddNewCentroidBtn.Text = "New Centroid (Kmean++)";
            AddNewCentroidBtn.UseVisualStyleBackColor = true;
            AddNewCentroidBtn.Click += AddNewCentroidBtn_Click;
            // 
            // OptimizeCentroidPositionBtn
            // 
            OptimizeCentroidPositionBtn.Location = new Point(963, 618);
            OptimizeCentroidPositionBtn.Name = "OptimizeCentroidPositionBtn";
            OptimizeCentroidPositionBtn.Size = new Size(208, 29);
            OptimizeCentroidPositionBtn.TabIndex = 12;
            OptimizeCentroidPositionBtn.Text = "Optimize Centroid Position";
            OptimizeCentroidPositionBtn.UseVisualStyleBackColor = true;
            OptimizeCentroidPositionBtn.Click += OptimizeCentroidPositionBtn_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(618, 388);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.RowTemplate.Height = 29;
            dataGridView2.Size = new Size(681, 224);
            dataGridView2.TabIndex = 13;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1311, 713);
            Controls.Add(dataGridView2);
            Controls.Add(OptimizeCentroidPositionBtn);
            Controls.Add(AddNewCentroidBtn);
            Controls.Add(AssociatePointsBtn);
            Controls.Add(ShowConnectionsBtn);
            Controls.Add(ShowGridBtn);
            Controls.Add(dataGridView1);
            Controls.Add(LoadBtn);
            Controls.Add(SaveBtn);
            Controls.Add(ClearBtn);
            Controls.Add(statusStrip1);
            Controls.Add(btnAddCentroids);
            Controls.Add(btnAddPoints);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button btnAddPoints;
        private Button btnAddCentroids;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblCurrentMode;
        private Button ClearBtn;
        private Button SaveBtn;
        private Button LoadBtn;
        private DataGridView dataGridView1;
        private Button ShowGridBtn;
        private Button ShowConnectionsBtn;
        private Button AssociatePointsBtn;
        private Button AddNewCentroidBtn;
        private Button OptimizeCentroidPositionBtn;
        private DataGridView dataGridView2;
    }
}