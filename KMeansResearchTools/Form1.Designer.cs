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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
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
            statusStrip1.Location = new Point(0, 679);
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
            dataGridView1.Size = new Size(681, 446);
            dataGridView1.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1311, 701);
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
    }
}