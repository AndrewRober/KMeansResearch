namespace KMeansResearchTools
{
    partial class MainForm
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
            PointsDgv = new DataGridView();
            ShowGridBtn = new Button();
            ShowConnectionsBtn = new Button();
            AssociatePointsBtn = new Button();
            AddNewCentroidBtn = new Button();
            OptimizeCentroidPositionBtn = new Button();
            CentroidsDgv = new DataGridView();
            FullKmeanBtn = new Button();
            CreateRandomPointsBtn = new Button();
            SaveImgBtn = new Button();
            CreateCentralizedRandomPointsBtn = new Button();
            NewCentroidAndFullKmeanBtn = new Button();
            ShowVirtualCCBtn = new Button();
            ShowCentroidsBoundriesBtn = new Button();
            pictureBox2 = new PictureBox();
            elbowDgv = new DataGridView();
            RemoveCentroidAndFullKmeanBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PointsDgv).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CentroidsDgv).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)elbowDgv).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(750, 750);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnAddPoints
            // 
            btnAddPoints.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddPoints.Location = new Point(1174, 682);
            btnAddPoints.Name = "btnAddPoints";
            btnAddPoints.Size = new Size(94, 29);
            btnAddPoints.TabIndex = 1;
            btnAddPoints.Text = "Add Points";
            btnAddPoints.UseVisualStyleBackColor = true;
            // 
            // btnAddCentroids
            // 
            btnAddCentroids.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddCentroids.Location = new Point(1274, 682);
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
            statusStrip1.Location = new Point(0, 960);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1859, 22);
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
            ClearBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ClearBtn.Location = new Point(1612, 682);
            ClearBtn.Name = "ClearBtn";
            ClearBtn.Size = new Size(94, 29);
            ClearBtn.TabIndex = 4;
            ClearBtn.Text = "Clear";
            ClearBtn.UseVisualStyleBackColor = true;
            ClearBtn.Click += ClearBtn_Click;
            // 
            // PointsDgv
            // 
            PointsDgv.AllowUserToAddRows = false;
            PointsDgv.AllowUserToDeleteRows = false;
            PointsDgv.AllowUserToResizeColumns = false;
            PointsDgv.AllowUserToResizeRows = false;
            PointsDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PointsDgv.Location = new Point(777, 12);
            PointsDgv.MultiSelect = false;
            PointsDgv.Name = "PointsDgv";
            PointsDgv.ReadOnly = true;
            PointsDgv.RowHeadersWidth = 51;
            PointsDgv.RowTemplate.Height = 29;
            PointsDgv.Size = new Size(384, 750);
            PointsDgv.TabIndex = 7;
            // 
            // ShowGridBtn
            // 
            ShowGridBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ShowGridBtn.Location = new Point(1174, 715);
            ShowGridBtn.Name = "ShowGridBtn";
            ShowGridBtn.Size = new Size(134, 29);
            ShowGridBtn.TabIndex = 8;
            ShowGridBtn.Text = "Show/Hide Grid";
            ShowGridBtn.UseVisualStyleBackColor = true;
            ShowGridBtn.Click += ShowGridBtn_Click;
            // 
            // ShowConnectionsBtn
            // 
            ShowConnectionsBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ShowConnectionsBtn.Location = new Point(1314, 715);
            ShowConnectionsBtn.Name = "ShowConnectionsBtn";
            ShowConnectionsBtn.Size = new Size(174, 29);
            ShowConnectionsBtn.TabIndex = 9;
            ShowConnectionsBtn.Text = "Show/Hide Centroids";
            ShowConnectionsBtn.UseVisualStyleBackColor = true;
            ShowConnectionsBtn.Click += ShowConnectionsBtn_Click;
            // 
            // AssociatePointsBtn
            // 
            AssociatePointsBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            AssociatePointsBtn.Location = new Point(1182, 854);
            AssociatePointsBtn.Name = "AssociatePointsBtn";
            AssociatePointsBtn.Size = new Size(129, 29);
            AssociatePointsBtn.TabIndex = 10;
            AssociatePointsBtn.Text = "Associate points";
            AssociatePointsBtn.UseVisualStyleBackColor = true;
            AssociatePointsBtn.Click += AssociatePointsBtn_Click;
            // 
            // AddNewCentroidBtn
            // 
            AddNewCentroidBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            AddNewCentroidBtn.Location = new Point(1323, 854);
            AddNewCentroidBtn.Name = "AddNewCentroidBtn";
            AddNewCentroidBtn.Size = new Size(204, 29);
            AddNewCentroidBtn.TabIndex = 11;
            AddNewCentroidBtn.Text = "New Centroid (Kmean++)";
            AddNewCentroidBtn.UseVisualStyleBackColor = true;
            AddNewCentroidBtn.Click += AddNewCentroidBtn_Click;
            // 
            // OptimizeCentroidPositionBtn
            // 
            OptimizeCentroidPositionBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            OptimizeCentroidPositionBtn.Location = new Point(1539, 854);
            OptimizeCentroidPositionBtn.Name = "OptimizeCentroidPositionBtn";
            OptimizeCentroidPositionBtn.Size = new Size(208, 29);
            OptimizeCentroidPositionBtn.TabIndex = 12;
            OptimizeCentroidPositionBtn.Text = "Optimize Centroid Position";
            OptimizeCentroidPositionBtn.UseVisualStyleBackColor = true;
            OptimizeCentroidPositionBtn.Click += OptimizeCentroidPositionBtn_Click;
            // 
            // CentroidsDgv
            // 
            CentroidsDgv.AllowUserToAddRows = false;
            CentroidsDgv.AllowUserToDeleteRows = false;
            CentroidsDgv.AllowUserToResizeColumns = false;
            CentroidsDgv.AllowUserToResizeRows = false;
            CentroidsDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CentroidsDgv.Location = new Point(12, 768);
            CentroidsDgv.MultiSelect = false;
            CentroidsDgv.Name = "CentroidsDgv";
            CentroidsDgv.ReadOnly = true;
            CentroidsDgv.RowHeadersWidth = 51;
            CentroidsDgv.RowTemplate.Height = 29;
            CentroidsDgv.Size = new Size(626, 189);
            CentroidsDgv.TabIndex = 13;
            // 
            // FullKmeanBtn
            // 
            FullKmeanBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            FullKmeanBtn.Location = new Point(1759, 854);
            FullKmeanBtn.Name = "FullKmeanBtn";
            FullKmeanBtn.Size = new Size(94, 29);
            FullKmeanBtn.TabIndex = 14;
            FullKmeanBtn.Text = "Full Kmean";
            FullKmeanBtn.UseVisualStyleBackColor = true;
            FullKmeanBtn.Click += FullKmeanBtn_Click;
            // 
            // CreateRandomPointsBtn
            // 
            CreateRandomPointsBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            CreateRandomPointsBtn.Location = new Point(1182, 889);
            CreateRandomPointsBtn.Name = "CreateRandomPointsBtn";
            CreateRandomPointsBtn.Size = new Size(174, 29);
            CreateRandomPointsBtn.TabIndex = 15;
            CreateRandomPointsBtn.Text = "Create Random Points";
            CreateRandomPointsBtn.UseVisualStyleBackColor = true;
            CreateRandomPointsBtn.Click += CreateRandomPointsBtn_Click;
            // 
            // SaveImgBtn
            // 
            SaveImgBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            SaveImgBtn.Location = new Point(1713, 682);
            SaveImgBtn.Name = "SaveImgBtn";
            SaveImgBtn.Size = new Size(134, 29);
            SaveImgBtn.TabIndex = 16;
            SaveImgBtn.Text = "Save Image";
            SaveImgBtn.UseVisualStyleBackColor = true;
            SaveImgBtn.Click += SaveImgBtn_Click;
            // 
            // CreateCentralizedRandomPointsBtn
            // 
            CreateCentralizedRandomPointsBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            CreateCentralizedRandomPointsBtn.Location = new Point(1362, 889);
            CreateCentralizedRandomPointsBtn.Name = "CreateCentralizedRandomPointsBtn";
            CreateCentralizedRandomPointsBtn.Size = new Size(244, 29);
            CreateCentralizedRandomPointsBtn.TabIndex = 17;
            CreateCentralizedRandomPointsBtn.Text = "Create Centralized Random Points";
            CreateCentralizedRandomPointsBtn.UseVisualStyleBackColor = true;
            CreateCentralizedRandomPointsBtn.Click += CreateCentralizedRandomPointsBtn_Click;
            // 
            // NewCentroidAndFullKmeanBtn
            // 
            NewCentroidAndFullKmeanBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            NewCentroidAndFullKmeanBtn.Location = new Point(1612, 889);
            NewCentroidAndFullKmeanBtn.Name = "NewCentroidAndFullKmeanBtn";
            NewCentroidAndFullKmeanBtn.Size = new Size(243, 29);
            NewCentroidAndFullKmeanBtn.TabIndex = 18;
            NewCentroidAndFullKmeanBtn.Text = "New Centroid and FULL Kmean++";
            NewCentroidAndFullKmeanBtn.UseVisualStyleBackColor = true;
            NewCentroidAndFullKmeanBtn.Click += NewCentroidAndFullKmeanBtn_Click;
            // 
            // ShowVirtualCCBtn
            // 
            ShowVirtualCCBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ShowVirtualCCBtn.Location = new Point(1408, 750);
            ShowVirtualCCBtn.Name = "ShowVirtualCCBtn";
            ShowVirtualCCBtn.Size = new Size(166, 29);
            ShowVirtualCCBtn.TabIndex = 19;
            ShowVirtualCCBtn.Text = "Show/Hide Virtual CC";
            ShowVirtualCCBtn.UseVisualStyleBackColor = true;
            ShowVirtualCCBtn.Click += ShowVirtualCCBtn_Click;
            // 
            // ShowCentroidsBoundriesBtn
            // 
            ShowCentroidsBoundriesBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ShowCentroidsBoundriesBtn.Location = new Point(1174, 750);
            ShowCentroidsBoundriesBtn.Name = "ShowCentroidsBoundriesBtn";
            ShowCentroidsBoundriesBtn.Size = new Size(228, 29);
            ShowCentroidsBoundriesBtn.TabIndex = 20;
            ShowCentroidsBoundriesBtn.Text = "Show/Hide Centroids Boundries";
            ShowCentroidsBoundriesBtn.UseVisualStyleBackColor = true;
            ShowCentroidsBoundriesBtn.Click += ShowCentroidsBoundriesBtn_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox2.Location = new Point(1167, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(680, 664);
            pictureBox2.TabIndex = 21;
            pictureBox2.TabStop = false;
            // 
            // elbowDgv
            // 
            elbowDgv.AllowUserToAddRows = false;
            elbowDgv.AllowUserToDeleteRows = false;
            elbowDgv.AllowUserToResizeColumns = false;
            elbowDgv.AllowUserToResizeRows = false;
            elbowDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            elbowDgv.Location = new Point(644, 768);
            elbowDgv.MultiSelect = false;
            elbowDgv.Name = "elbowDgv";
            elbowDgv.ReadOnly = true;
            elbowDgv.RowHeadersWidth = 51;
            elbowDgv.RowTemplate.Height = 29;
            elbowDgv.Size = new Size(517, 189);
            elbowDgv.TabIndex = 22;
            // 
            // RemoveCentroidAndFullKmeanBtn
            // 
            RemoveCentroidAndFullKmeanBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            RemoveCentroidAndFullKmeanBtn.Location = new Point(1575, 924);
            RemoveCentroidAndFullKmeanBtn.Name = "RemoveCentroidAndFullKmeanBtn";
            RemoveCentroidAndFullKmeanBtn.Size = new Size(280, 29);
            RemoveCentroidAndFullKmeanBtn.TabIndex = 23;
            RemoveCentroidAndFullKmeanBtn.Text = "Remove Centroid and FULL Kmean++";
            RemoveCentroidAndFullKmeanBtn.UseVisualStyleBackColor = true;
            RemoveCentroidAndFullKmeanBtn.Click += RemoveCentroidAndFullKmeanBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1859, 982);
            Controls.Add(RemoveCentroidAndFullKmeanBtn);
            Controls.Add(elbowDgv);
            Controls.Add(pictureBox2);
            Controls.Add(ShowCentroidsBoundriesBtn);
            Controls.Add(ShowVirtualCCBtn);
            Controls.Add(NewCentroidAndFullKmeanBtn);
            Controls.Add(CreateCentralizedRandomPointsBtn);
            Controls.Add(SaveImgBtn);
            Controls.Add(CreateRandomPointsBtn);
            Controls.Add(FullKmeanBtn);
            Controls.Add(CentroidsDgv);
            Controls.Add(OptimizeCentroidPositionBtn);
            Controls.Add(AddNewCentroidBtn);
            Controls.Add(AssociatePointsBtn);
            Controls.Add(ShowConnectionsBtn);
            Controls.Add(ShowGridBtn);
            Controls.Add(PointsDgv);
            Controls.Add(ClearBtn);
            Controls.Add(statusStrip1);
            Controls.Add(btnAddCentroids);
            Controls.Add(btnAddPoints);
            Controls.Add(pictureBox1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PointsDgv).EndInit();
            ((System.ComponentModel.ISupportInitialize)CentroidsDgv).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)elbowDgv).EndInit();
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
        private DataGridView PointsDgv;
        private Button ShowGridBtn;
        private Button ShowConnectionsBtn;
        private Button AssociatePointsBtn;
        private Button AddNewCentroidBtn;
        private Button OptimizeCentroidPositionBtn;
        private DataGridView CentroidsDgv;
        private Button FullKmeanBtn;
        private Button CreateRandomPointsBtn;
        private Button SaveImgBtn;
        private Button CreateCentralizedRandomPointsBtn;
        private Button NewCentroidAndFullKmeanBtn;
        private Button ShowVirtualCCBtn;
        private Button ShowCentroidsBoundriesBtn;
        private PictureBox pictureBox2;
        private DataGridView elbowDgv;
        private Button RemoveCentroidAndFullKmeanBtn;
    }
}