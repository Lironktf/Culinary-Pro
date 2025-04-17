namespace RecipeManager
{
    partial class MealPlanForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            backImageButton = new Button();
            planNameLabel = new Label();
            tableLayout = new TableLayoutPanel();
            label9 = new Label();
            label2 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label11 = new Label();
            label10 = new Label();
            loadingTimer = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            tableLayout.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(backImageButton);
            panel1.Controls.Add(planNameLabel);
            panel1.Controls.Add(tableLayout);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(847, 450);
            panel1.TabIndex = 0;
            // 
            // backImageButton
            // 
            backImageButton.BackColor = SystemColors.Control;
            backImageButton.BackgroundImage = Properties.Resources.Back_Button_Transparent;
            backImageButton.BackgroundImageLayout = ImageLayout.Zoom;
            backImageButton.FlatStyle = FlatStyle.Flat;
            backImageButton.Font = new Font("Tahoma", 12F);
            backImageButton.Location = new Point(4, 3);
            backImageButton.Name = "backImageButton";
            backImageButton.Size = new Size(37, 27);
            backImageButton.TabIndex = 10;
            backImageButton.UseVisualStyleBackColor = false;
            backImageButton.Click += backImageButton_Click;
            // 
            // planNameLabel
            // 
            planNameLabel.Dock = DockStyle.Top;
            planNameLabel.Font = new Font("Tahoma", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            planNameLabel.Location = new Point(0, 0);
            planNameLabel.Name = "planNameLabel";
            planNameLabel.Size = new Size(1197, 28);
            planNameLabel.TabIndex = 7;
            planNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayout
            // 
            tableLayout.AutoSize = true;
            tableLayout.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayout.ColumnCount = 8;
            tableLayout.ColumnStyles.Add(new ColumnStyle());
            tableLayout.ColumnStyles.Add(new ColumnStyle());
            tableLayout.ColumnStyles.Add(new ColumnStyle());
            tableLayout.ColumnStyles.Add(new ColumnStyle());
            tableLayout.ColumnStyles.Add(new ColumnStyle());
            tableLayout.ColumnStyles.Add(new ColumnStyle());
            tableLayout.ColumnStyles.Add(new ColumnStyle());
            tableLayout.ColumnStyles.Add(new ColumnStyle());
            tableLayout.Controls.Add(label9, 0, 1);
            tableLayout.Controls.Add(label2, 1, 0);
            tableLayout.Controls.Add(label8, 7, 0);
            tableLayout.Controls.Add(label7, 6, 0);
            tableLayout.Controls.Add(label6, 5, 0);
            tableLayout.Controls.Add(label5, 4, 0);
            tableLayout.Controls.Add(label4, 3, 0);
            tableLayout.Controls.Add(label3, 2, 0);
            tableLayout.Controls.Add(label11, 0, 2);
            tableLayout.Controls.Add(label10, 0, 3);
            tableLayout.Location = new Point(3, 30);
            tableLayout.MinimumSize = new Size(850, 0);
            tableLayout.Name = "tableLayout";
            tableLayout.RowCount = 4;
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayout.RowStyles.Add(new RowStyle());
            tableLayout.RowStyles.Add(new RowStyle());
            tableLayout.RowStyles.Add(new RowStyle());
            tableLayout.Size = new Size(1194, 402);
            tableLayout.TabIndex = 0;
            tableLayout.Visible = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Tahoma", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(4, 22);
            label9.Name = "label9";
            label9.Size = new Size(137, 24);
            label9.TabIndex = 9;
            label9.Text = "BREAKFAST:";
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Tahoma", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(148, 1);
            label2.Name = "label2";
            label2.Size = new Size(100, 20);
            label2.TabIndex = 8;
            label2.Text = "MONDAY";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // label8
            // 
            label8.Dock = DockStyle.Fill;
            label8.Font = new Font("Tahoma", 15F, FontStyle.Bold);
            label8.Location = new Point(866, 1);
            label8.Name = "label8";
            label8.Size = new Size(324, 20);
            label8.TabIndex = 7;
            label8.Text = "SUNDAY";
            label8.TextAlign = ContentAlignment.TopCenter;
            // 
            // label7
            // 
            label7.Dock = DockStyle.Fill;
            label7.Font = new Font("Tahoma", 15F, FontStyle.Bold);
            label7.Location = new Point(738, 1);
            label7.Name = "label7";
            label7.Size = new Size(121, 20);
            label7.TabIndex = 6;
            label7.Text = "SATURDAY";
            label7.TextAlign = ContentAlignment.TopCenter;
            // 
            // label6
            // 
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("Tahoma", 15F, FontStyle.Bold);
            label6.Location = new Point(642, 1);
            label6.Name = "label6";
            label6.Size = new Size(89, 20);
            label6.TabIndex = 5;
            label6.Text = "FRIDAY";
            label6.TextAlign = ContentAlignment.TopCenter;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Tahoma", 15F, FontStyle.Bold);
            label5.Location = new Point(513, 1);
            label5.Name = "label5";
            label5.Size = new Size(122, 20);
            label5.TabIndex = 4;
            label5.Text = "THURSDAY";
            label5.TextAlign = ContentAlignment.TopCenter;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Tahoma", 15F, FontStyle.Bold);
            label4.Location = new Point(366, 1);
            label4.Name = "label4";
            label4.Size = new Size(140, 20);
            label4.TabIndex = 3;
            label4.Text = "WEDNESDAY";
            label4.TextAlign = ContentAlignment.TopCenter;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Tahoma", 15F, FontStyle.Bold);
            label3.Location = new Point(255, 1);
            label3.Name = "label3";
            label3.Size = new Size(104, 20);
            label3.TabIndex = 2;
            label3.Text = "TUESDAY";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Tahoma", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(4, 47);
            label11.Name = "label11";
            label11.Size = new Size(86, 24);
            label11.TabIndex = 11;
            label11.Text = "LUNCH:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Tahoma", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(4, 72);
            label10.Name = "label10";
            label10.Size = new Size(99, 24);
            label10.TabIndex = 12;
            label10.Text = "DINNER:";
            // 
            // loadingTimer
            // 
            loadingTimer.Interval = 500;
            loadingTimer.Tick += loadingTimer_Tick;
            // 
            // MealPlanForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(847, 450);
            Controls.Add(panel1);
            Name = "MealPlanForm";
            Text = "MealPlanForm";
            Load += MealPlanForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayout.ResumeLayout(false);
            tableLayout.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TableLayoutPanel tableLayout;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label9;
        private Label label2;
        private Label label11;
        private Label label10;
        private Label planNameLabel;
        private Button backImageButton;
        private System.Windows.Forms.Timer loadingTimer;
    }
}