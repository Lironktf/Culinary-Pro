namespace RecipeManager
{
    partial class RecipesDisplayForm
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
            layoutPanel = new FlowLayoutPanel();
            noResultsLabel = new Label();
            sortByBox = new ComboBox();
            backImageButton = new Button();
            label1 = new Label();
            coverPanel = new Panel();
            callBackTimer = new System.Windows.Forms.Timer(components);
            layoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // layoutPanel
            // 
            layoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            layoutPanel.AutoScroll = true;
            layoutPanel.Controls.Add(noResultsLabel);
            layoutPanel.Location = new Point(4, 36);
            layoutPanel.Name = "layoutPanel";
            layoutPanel.Padding = new Padding(30, 0, 0, 0);
            layoutPanel.Size = new Size(1011, 456);
            layoutPanel.TabIndex = 0;
            layoutPanel.Scroll += layoutPanel_Scroll;
            layoutPanel.MouseWheel += layoutPanel_MouseWheel;
            // 
            // noResultsLabel
            // 
            noResultsLabel.AutoSize = true;
            noResultsLabel.Font = new Font("Tahoma", 17.2F);
            noResultsLabel.ForeColor = Color.Red;
            noResultsLabel.Location = new Point(33, 0);
            noResultsLabel.Name = "noResultsLabel";
            noResultsLabel.Size = new Size(435, 28);
            noResultsLabel.TabIndex = 46;
            noResultsLabel.Text = "NO RESULT FOUND. TRY LESS CRITERIA.";
            noResultsLabel.Visible = false;
            // 
            // sortByBox
            // 
            sortByBox.BackColor = Color.White;
            sortByBox.DropDownStyle = ComboBoxStyle.DropDownList;
            sortByBox.FlatStyle = FlatStyle.Flat;
            sortByBox.Font = new Font("Tahoma", 11.25F, FontStyle.Bold);
            sortByBox.FormattingEnabled = true;
            sortByBox.Items.AddRange(new object[] { "Calories", "Price", "Popularity", "Health Score", "SmartPoints®", "Protein", "Sugar", "Fat" });
            sortByBox.Location = new Point(662, 5);
            sortByBox.Name = "sortByBox";
            sortByBox.Size = new Size(304, 26);
            sortByBox.TabIndex = 3;
            sortByBox.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            sortByBox.MouseClick += sortByBox_MouseClick;
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
            backImageButton.TabIndex = 6;
            backImageButton.UseVisualStyleBackColor = false;
            backImageButton.Click += backImageButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(582, 7);
            label1.Name = "label1";
            label1.Size = new Size(74, 19);
            label1.TabIndex = 7;
            label1.Text = "Sort By:";
            // 
            // coverPanel
            // 
            coverPanel.BackColor = Color.White;
            coverPanel.Location = new Point(664, 5);
            coverPanel.Name = "coverPanel";
            coverPanel.Size = new Size(282, 26);
            coverPanel.TabIndex = 47;
            coverPanel.Visible = false;
            coverPanel.MouseClick += coverPanel_MouseClick;
            // 
            // callBackTimer
            // 
            callBackTimer.Interval = 200;
            // 
            // RecipesDisplayForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1019, 496);
            Controls.Add(coverPanel);
            Controls.Add(label1);
            Controls.Add(backImageButton);
            Controls.Add(sortByBox);
            Controls.Add(layoutPanel);
            Name = "RecipesDisplayForm";
            Text = "RecipeDisplayForm";
            Load += RecipeDisplayForm_Load_1;
            layoutPanel.ResumeLayout(false);
            layoutPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel layoutPanel;
        private ComboBox sortByBox;
        private Button backImageButton;
        private Label label1;
        private Label noResultsLabel;
        private Panel coverPanel;
        private System.Windows.Forms.Timer callBackTimer;
    }
}