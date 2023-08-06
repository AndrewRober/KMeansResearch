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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PointsDgv).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CentroidsDgv).BeginInit();
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
            statusStrip1.Location = new Point(0, 728);
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
            // PointsDgv
            // 
            PointsDgv.AllowUserToAddRows = false;
            PointsDgv.AllowUserToDeleteRows = false;
            PointsDgv.AllowUserToResizeColumns = false;
            PointsDgv.AllowUserToResizeRows = false;
            PointsDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PointsDgv.Location = new Point(618, 12);
            PointsDgv.MultiSelect = false;
            PointsDgv.Name = "PointsDgv";
            PointsDgv.ReadOnly = true;
            PointsDgv.RowHeadersWidth = 51;
            PointsDgv.RowTemplate.Height = 29;
            PointsDgv.Size = new Size(681, 370);
            PointsDgv.TabIndex = 7;
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
            // CentroidsDgv
            // 
            CentroidsDgv.AllowUserToAddRows = false;
            CentroidsDgv.AllowUserToDeleteRows = false;
            CentroidsDgv.AllowUserToResizeColumns = false;
            CentroidsDgv.AllowUserToResizeRows = false;
            CentroidsDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CentroidsDgv.Location = new Point(618, 388);
            CentroidsDgv.MultiSelect = false;
            CentroidsDgv.Name = "CentroidsDgv";
            CentroidsDgv.ReadOnly = true;
            CentroidsDgv.RowHeadersWidth = 51;
            CentroidsDgv.RowTemplate.Height = 29;
            CentroidsDgv.Size = new Size(681, 224);
            CentroidsDgv.TabIndex = 13;
            // 
            // FullKmeanBtn
            // 
            FullKmeanBtn.Location = new Point(1177, 618);
            FullKmeanBtn.Name = "FullKmeanBtn";
            FullKmeanBtn.Size = new Size(122, 29);
            FullKmeanBtn.TabIndex = 14;
            FullKmeanBtn.Text = "Full Kmean";
            FullKmeanBtn.UseVisualStyleBackColor = true;
            FullKmeanBtn.Click += FullKmeanBtn_Click;
            // 
            // CreateRandomPointsBtn
            // 
            CreateRandomPointsBtn.Location = new Point(618, 653);
            CreateRandomPointsBtn.Name = "CreateRandomPointsBtn";
            CreateRandomPointsBtn.Size = new Size(174, 29);
            CreateRandomPointsBtn.TabIndex = 15;
            CreateRandomPointsBtn.Text = "Create Random Points";
            CreateRandomPointsBtn.UseVisualStyleBackColor = true;
            CreateRandomPointsBtn.Click += CreateRandomPointsBtn_Click;
            // 
            // SaveImgBtn
            // 
            SaveImgBtn.Location = new Point(478, 653);
            SaveImgBtn.Name = "SaveImgBtn";
            SaveImgBtn.Size = new Size(134, 29);
            SaveImgBtn.TabIndex = 16;
            SaveImgBtn.Text = "Save Image";
            SaveImgBtn.UseVisualStyleBackColor = true;
            SaveImgBtn.Click += SaveImgBtn_Click;
            // 
            // CreateCentralizedRandomPointsBtn
            // 
            CreateCentralizedRandomPointsBtn.Location = new Point(798, 653);
            CreateCentralizedRandomPointsBtn.Name = "CreateCentralizedRandomPointsBtn";
            CreateCentralizedRandomPointsBtn.Size = new Size(252, 29);
            CreateCentralizedRandomPointsBtn.TabIndex = 17;
            CreateCentralizedRandomPointsBtn.Text = "Create Centralized Random Points";
            CreateCentralizedRandomPointsBtn.UseVisualStyleBackColor = true;
            CreateCentralizedRandomPointsBtn.Click += CreateCentralizedRandomPointsBtn_Click;
            // 
            // NewCentroidAndFullKmeanBtn
            // 
            NewCentroidAndFullKmeanBtn.Location = new Point(1056, 653);
            NewCentroidAndFullKmeanBtn.Name = "NewCentroidAndFullKmeanBtn";
            NewCentroidAndFullKmeanBtn.Size = new Size(243, 29);
            NewCentroidAndFullKmeanBtn.TabIndex = 18;
            NewCentroidAndFullKmeanBtn.Text = "New Centroid and FULL Kmean++";
            NewCentroidAndFullKmeanBtn.UseVisualStyleBackColor = true;
            NewCentroidAndFullKmeanBtn.Click += NewCentroidAndFullKmeanBtn_Click;
            // 
            // ShowVirtualCCBtn
            // 
            ShowVirtualCCBtn.Location = new Point(246, 688);
            ShowVirtualCCBtn.Name = "ShowVirtualCCBtn";
            ShowVirtualCCBtn.Size = new Size(166, 29);
            ShowVirtualCCBtn.TabIndex = 19;
            ShowVirtualCCBtn.Text = "Show/Hide Virtual CC";
            ShowVirtualCCBtn.UseVisualStyleBackColor = true;
            ShowVirtualCCBtn.Click += ShowVirtualCCBtn_Click;
            // 
            // ShowCentroidsBoundriesBtn
            // 
            ShowCentroidsBoundriesBtn.Location = new Point(12, 688);
            ShowCentroidsBoundriesBtn.Name = "ShowCentroidsBoundriesBtn";
            ShowCentroidsBoundriesBtn.Size = new Size(228, 29);
            ShowCentroidsBoundriesBtn.TabIndex = 20;
            ShowCentroidsBoundriesBtn.Text = "Show/Hide Centroids Boundries";
            ShowCentroidsBoundriesBtn.UseVisualStyleBackColor = true;
            ShowCentroidsBoundriesBtn.Click += ShowCentroidsBoundriesBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1311, 750);
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
            ((System.ComponentModel.ISupportInitialize)PointsDgv).EndInit();
            ((System.ComponentModel.ISupportInitialize)CentroidsDgv).EndInit();
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
    }
}