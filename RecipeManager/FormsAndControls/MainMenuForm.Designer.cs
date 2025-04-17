namespace RecipeManager
{
    partial class MainMenuForm
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
            sideBar = new FlowLayoutPanel();
            panel1 = new Panel();
            panel5 = new Panel();
            menuImageButton = new Button();
            button4 = new Button();
            menuBtn = new Button();
            buttonPanel = new Panel();
            discoverImageButton = new Button();
            discoverButton = new Button();
            panel2 = new Panel();
            searchImageButton = new Button();
            searchButton = new Button();
            panel3 = new Panel();
            mealImageButton = new Button();
            mealPlanButton = new Button();
            panel4 = new Panel();
            savedImageButton = new Button();
            savedRecipesButton = new Button();
            panel6 = new Panel();
            manualImageButton = new Button();
            manualInputButton = new Button();
            panel7 = new Panel();
            panel8 = new Panel();
            panel9 = new Panel();
            powerImageButton = new Button();
            powerDownButton = new Button();
            sideBarTimer = new System.Windows.Forms.Timer(components);
            mainPanel = new Panel();
            sideBar.SuspendLayout();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            buttonPanel.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel6.SuspendLayout();
            panel9.SuspendLayout();
            SuspendLayout();
            // 
            // sideBar
            // 
            sideBar.BackColor = Color.Black;
            sideBar.Controls.Add(panel1);
            sideBar.Controls.Add(buttonPanel);
            sideBar.Controls.Add(panel2);
            sideBar.Controls.Add(panel3);
            sideBar.Controls.Add(panel4);
            sideBar.Controls.Add(panel6);
            sideBar.Controls.Add(panel7);
            sideBar.Controls.Add(panel8);
            sideBar.Controls.Add(panel9);
            sideBar.Dock = DockStyle.Left;
            sideBar.Location = new Point(0, 0);
            sideBar.MaximumSize = new Size(200, 535);
            sideBar.MinimumSize = new Size(54, 535);
            sideBar.Name = "sideBar";
            sideBar.Size = new Size(54, 535);
            sideBar.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel5);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(194, 63);
            panel1.TabIndex = 1;
            // 
            // panel5
            // 
            panel5.Controls.Add(menuImageButton);
            panel5.Controls.Add(button4);
            panel5.Controls.Add(menuBtn);
            panel5.Location = new Point(0, 9);
            panel5.Name = "panel5";
            panel5.Size = new Size(194, 32);
            panel5.TabIndex = 3;
            // 
            // menuImageButton
            // 
            menuImageButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            menuImageButton.BackgroundImage = Properties.Resources.menu3;
            menuImageButton.BackgroundImageLayout = ImageLayout.Zoom;
            menuImageButton.FlatAppearance.BorderSize = 0;
            menuImageButton.FlatAppearance.MouseOverBackColor = Color.Gray;
            menuImageButton.FlatStyle = FlatStyle.Flat;
            menuImageButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuImageButton.ForeColor = Color.White;
            menuImageButton.ImageAlign = ContentAlignment.MiddleLeft;
            menuImageButton.Location = new Point(10, 3);
            menuImageButton.Name = "menuImageButton";
            menuImageButton.Size = new Size(34, 29);
            menuImageButton.TabIndex = 6;
            menuImageButton.UseVisualStyleBackColor = true;
            menuImageButton.Click += menuImageButton_Click;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            button4.BackgroundImage = Properties.Resources.searchImg;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.White;
            button4.ImageAlign = ContentAlignment.MiddleLeft;
            button4.Location = new Point(0, -34);
            button4.Name = "button4";
            button4.Size = new Size(168, 32);
            button4.TabIndex = 0;
            button4.Text = "DISCOVER";
            button4.UseVisualStyleBackColor = true;
            // 
            // menuBtn
            // 
            menuBtn.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            menuBtn.BackgroundImage = Properties.Resources.searchImg;
            menuBtn.FlatAppearance.BorderSize = 0;
            menuBtn.FlatAppearance.MouseOverBackColor = Color.Gray;
            menuBtn.FlatStyle = FlatStyle.Flat;
            menuBtn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuBtn.ForeColor = Color.White;
            menuBtn.ImageAlign = ContentAlignment.MiddleLeft;
            menuBtn.Location = new Point(2, 0);
            menuBtn.Name = "menuBtn";
            menuBtn.Size = new Size(191, 32);
            menuBtn.TabIndex = 2;
            menuBtn.Text = "  MENU";
            menuBtn.UseVisualStyleBackColor = true;
            menuBtn.Click += menuBtn_Click;
            // 
            // buttonPanel
            // 
            buttonPanel.Controls.Add(discoverImageButton);
            buttonPanel.Controls.Add(discoverButton);
            buttonPanel.Location = new Point(3, 72);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.Size = new Size(194, 32);
            buttonPanel.TabIndex = 2;
            // 
            // discoverImageButton
            // 
            discoverImageButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            discoverImageButton.BackgroundImage = Properties.Resources.explore_transparent_2;
            discoverImageButton.BackgroundImageLayout = ImageLayout.Zoom;
            discoverImageButton.FlatAppearance.BorderSize = 0;
            discoverImageButton.FlatAppearance.MouseOverBackColor = Color.Gray;
            discoverImageButton.FlatStyle = FlatStyle.Flat;
            discoverImageButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            discoverImageButton.ForeColor = Color.White;
            discoverImageButton.ImageAlign = ContentAlignment.MiddleLeft;
            discoverImageButton.Location = new Point(10, 0);
            discoverImageButton.Name = "discoverImageButton";
            discoverImageButton.Size = new Size(34, 29);
            discoverImageButton.TabIndex = 5;
            discoverImageButton.UseVisualStyleBackColor = true;
            discoverImageButton.Click += discoverImageButton_Click;
            // 
            // discoverButton
            // 
            discoverButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            discoverButton.BackgroundImage = Properties.Resources.searchImg;
            discoverButton.FlatAppearance.BorderSize = 0;
            discoverButton.FlatAppearance.MouseOverBackColor = Color.Gray;
            discoverButton.FlatStyle = FlatStyle.Flat;
            discoverButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            discoverButton.ForeColor = Color.White;
            discoverButton.ImageAlign = ContentAlignment.MiddleLeft;
            discoverButton.Location = new Point(0, 0);
            discoverButton.Name = "discoverButton";
            discoverButton.Size = new Size(191, 32);
            discoverButton.TabIndex = 0;
            discoverButton.Text = "   DISCOVER";
            discoverButton.UseVisualStyleBackColor = true;
            discoverButton.Click += discoverButton_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(searchImageButton);
            panel2.Controls.Add(searchButton);
            panel2.Location = new Point(3, 110);
            panel2.Name = "panel2";
            panel2.Size = new Size(197, 32);
            panel2.TabIndex = 3;
            // 
            // searchImageButton
            // 
            searchImageButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            searchImageButton.BackgroundImage = Properties.Resources.discover_transparent;
            searchImageButton.BackgroundImageLayout = ImageLayout.Zoom;
            searchImageButton.FlatAppearance.BorderSize = 0;
            searchImageButton.FlatAppearance.MouseOverBackColor = Color.Gray;
            searchImageButton.FlatStyle = FlatStyle.Flat;
            searchImageButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchImageButton.ForeColor = Color.White;
            searchImageButton.ImageAlign = ContentAlignment.MiddleLeft;
            searchImageButton.Location = new Point(10, 2);
            searchImageButton.Name = "searchImageButton";
            searchImageButton.Size = new Size(34, 29);
            searchImageButton.TabIndex = 4;
            searchImageButton.UseVisualStyleBackColor = true;
            searchImageButton.Click += searchImageButton_Click;
            // 
            // searchButton
            // 
            searchButton.BackgroundImage = Properties.Resources.searchImg;
            searchButton.FlatAppearance.BorderSize = 0;
            searchButton.FlatAppearance.MouseOverBackColor = Color.Gray;
            searchButton.FlatStyle = FlatStyle.Flat;
            searchButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchButton.ForeColor = Color.White;
            searchButton.ImageAlign = ContentAlignment.MiddleLeft;
            searchButton.Location = new Point(1, 0);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(194, 32);
            searchButton.TabIndex = 0;
            searchButton.Text = "   SEARCH     ";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += searchButton_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(mealImageButton);
            panel3.Controls.Add(mealPlanButton);
            panel3.Location = new Point(3, 148);
            panel3.Name = "panel3";
            panel3.Size = new Size(194, 32);
            panel3.TabIndex = 4;
            // 
            // mealImageButton
            // 
            mealImageButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            mealImageButton.BackgroundImage = Properties.Resources.meals_transparent;
            mealImageButton.BackgroundImageLayout = ImageLayout.Zoom;
            mealImageButton.FlatAppearance.BorderSize = 0;
            mealImageButton.FlatAppearance.MouseOverBackColor = Color.Gray;
            mealImageButton.FlatStyle = FlatStyle.Flat;
            mealImageButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            mealImageButton.ForeColor = Color.White;
            mealImageButton.ImageAlign = ContentAlignment.MiddleLeft;
            mealImageButton.Location = new Point(9, 0);
            mealImageButton.Name = "mealImageButton";
            mealImageButton.Size = new Size(34, 29);
            mealImageButton.TabIndex = 3;
            mealImageButton.UseVisualStyleBackColor = true;
            mealImageButton.Click += mealImageButton_Click;
            // 
            // mealPlanButton
            // 
            mealPlanButton.BackgroundImage = Properties.Resources.searchImg;
            mealPlanButton.FlatAppearance.BorderSize = 0;
            mealPlanButton.FlatAppearance.MouseOverBackColor = Color.Gray;
            mealPlanButton.FlatStyle = FlatStyle.Flat;
            mealPlanButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            mealPlanButton.ForeColor = Color.White;
            mealPlanButton.ImageAlign = ContentAlignment.MiddleLeft;
            mealPlanButton.Location = new Point(3, 0);
            mealPlanButton.Name = "mealPlanButton";
            mealPlanButton.Size = new Size(194, 32);
            mealPlanButton.TabIndex = 0;
            mealPlanButton.Text = "  MEAL PLAN";
            mealPlanButton.UseVisualStyleBackColor = true;
            mealPlanButton.Click += mealPlanButton_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(savedImageButton);
            panel4.Controls.Add(savedRecipesButton);
            panel4.Location = new Point(3, 186);
            panel4.Name = "panel4";
            panel4.Size = new Size(194, 32);
            panel4.TabIndex = 5;
            // 
            // savedImageButton
            // 
            savedImageButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            savedImageButton.BackgroundImage = Properties.Resources.saved_transparent;
            savedImageButton.BackgroundImageLayout = ImageLayout.Zoom;
            savedImageButton.FlatAppearance.BorderSize = 0;
            savedImageButton.FlatAppearance.MouseOverBackColor = Color.Gray;
            savedImageButton.FlatStyle = FlatStyle.Flat;
            savedImageButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            savedImageButton.ForeColor = Color.White;
            savedImageButton.ImageAlign = ContentAlignment.MiddleLeft;
            savedImageButton.Location = new Point(9, 3);
            savedImageButton.Name = "savedImageButton";
            savedImageButton.Size = new Size(34, 32);
            savedImageButton.TabIndex = 4;
            savedImageButton.UseVisualStyleBackColor = true;
            savedImageButton.Click += savedImageButton_Click;
            // 
            // savedRecipesButton
            // 
            savedRecipesButton.BackgroundImage = Properties.Resources.searchImg;
            savedRecipesButton.FlatAppearance.BorderSize = 0;
            savedRecipesButton.FlatAppearance.MouseOverBackColor = Color.Gray;
            savedRecipesButton.FlatStyle = FlatStyle.Flat;
            savedRecipesButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            savedRecipesButton.ForeColor = Color.White;
            savedRecipesButton.ImageAlign = ContentAlignment.MiddleLeft;
            savedRecipesButton.Location = new Point(2, 0);
            savedRecipesButton.Name = "savedRecipesButton";
            savedRecipesButton.Size = new Size(206, 32);
            savedRecipesButton.TabIndex = 0;
            savedRecipesButton.Text = "    SAVED RECIPES";
            savedRecipesButton.UseVisualStyleBackColor = true;
            savedRecipesButton.Click += savedRecipesButton_Click;
            // 
            // panel6
            // 
            panel6.Controls.Add(manualImageButton);
            panel6.Controls.Add(manualInputButton);
            panel6.Location = new Point(3, 224);
            panel6.Name = "panel6";
            panel6.Size = new Size(200, 100);
            panel6.TabIndex = 6;
            // 
            // manualImageButton
            // 
            manualImageButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            manualImageButton.BackgroundImage = Properties.Resources.pencil_no_background;
            manualImageButton.BackgroundImageLayout = ImageLayout.Zoom;
            manualImageButton.FlatAppearance.BorderSize = 0;
            manualImageButton.FlatAppearance.MouseOverBackColor = Color.Gray;
            manualImageButton.FlatStyle = FlatStyle.Flat;
            manualImageButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            manualImageButton.ForeColor = Color.White;
            manualImageButton.ImageAlign = ContentAlignment.MiddleLeft;
            manualImageButton.Location = new Point(10, 3);
            manualImageButton.Name = "manualImageButton";
            manualImageButton.Size = new Size(28, 32);
            manualImageButton.TabIndex = 5;
            manualImageButton.UseVisualStyleBackColor = true;
            manualImageButton.Click += manualImageButton_Click;
            // 
            // manualInputButton
            // 
            manualInputButton.BackgroundImage = Properties.Resources.searchImg;
            manualInputButton.FlatAppearance.BorderSize = 0;
            manualInputButton.FlatAppearance.MouseOverBackColor = Color.Gray;
            manualInputButton.FlatStyle = FlatStyle.Flat;
            manualInputButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            manualInputButton.ForeColor = Color.White;
            manualInputButton.ImageAlign = ContentAlignment.MiddleLeft;
            manualInputButton.Location = new Point(-3, 3);
            manualInputButton.Name = "manualInputButton";
            manualInputButton.Size = new Size(208, 32);
            manualInputButton.TabIndex = 5;
            manualInputButton.Text = "   ENTER RECIPE";
            manualInputButton.UseVisualStyleBackColor = true;
            manualInputButton.Click += manualInputButton_Click;
            // 
            // panel7
            // 
            panel7.Location = new Point(3, 330);
            panel7.Name = "panel7";
            panel7.Size = new Size(200, 100);
            panel7.TabIndex = 7;
            // 
            // panel8
            // 
            panel8.Location = new Point(3, 436);
            panel8.Name = "panel8";
            panel8.Size = new Size(200, 48);
            panel8.TabIndex = 7;
            // 
            // panel9
            // 
            panel9.Controls.Add(powerImageButton);
            panel9.Controls.Add(powerDownButton);
            panel9.Location = new Point(3, 490);
            panel9.Name = "panel9";
            panel9.Size = new Size(200, 42);
            panel9.TabIndex = 7;
            // 
            // powerImageButton
            // 
            powerImageButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            powerImageButton.BackgroundImage = Properties.Resources.Power_Icon_Image;
            powerImageButton.BackgroundImageLayout = ImageLayout.Zoom;
            powerImageButton.FlatAppearance.BorderSize = 0;
            powerImageButton.FlatAppearance.MouseOverBackColor = Color.Gray;
            powerImageButton.FlatStyle = FlatStyle.Flat;
            powerImageButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            powerImageButton.ForeColor = Color.White;
            powerImageButton.ImageAlign = ContentAlignment.MiddleLeft;
            powerImageButton.Location = new Point(8, 9);
            powerImageButton.Name = "powerImageButton";
            powerImageButton.Size = new Size(30, 27);
            powerImageButton.TabIndex = 4;
            powerImageButton.UseVisualStyleBackColor = true;
            powerImageButton.Click += powerImageButton_Click;
            // 
            // powerDownButton
            // 
            powerDownButton.BackgroundImage = Properties.Resources.searchImg;
            powerDownButton.FlatAppearance.BorderSize = 0;
            powerDownButton.FlatAppearance.MouseOverBackColor = Color.Gray;
            powerDownButton.FlatStyle = FlatStyle.Flat;
            powerDownButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            powerDownButton.ForeColor = Color.White;
            powerDownButton.ImageAlign = ContentAlignment.MiddleLeft;
            powerDownButton.Location = new Point(1, 6);
            powerDownButton.Name = "powerDownButton";
            powerDownButton.Size = new Size(213, 32);
            powerDownButton.TabIndex = 1;
            powerDownButton.Text = "  POWER DOWN";
            powerDownButton.UseVisualStyleBackColor = true;
            powerDownButton.Click += powerDownButton_Click;
            // 
            // sideBarTimer
            // 
            sideBarTimer.Interval = 3;
            sideBarTimer.Tick += sideBarTimer_Tick;
            // 
            // mainPanel
            // 
            mainPanel.Location = new Point(53, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(0, 0, 30, 0);
            mainPanel.Size = new Size(1028, 535);
            mainPanel.TabIndex = 1;
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1087, 535);
            Controls.Add(sideBar);
            Controls.Add(mainPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "MainMenuForm";
            Text = "MainMenuForm";
            FormClosed += MainMenuForm_FormClosed;
            Load += MainMenuForm_Load;
            sideBar.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel5.ResumeLayout(false);
            buttonPanel.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel9.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel sideBar;
        private Panel panel1;
        private Button discoverButton;
        private Panel buttonPanel;
        private Panel panel2;
        private Button searchButton;
        private Panel panel3;
        private Button mealPlanButton;
        private Panel panel4;
        private Button savedRecipesButton;
        private System.Windows.Forms.Timer sideBarTimer;
        private Panel mainPanel;
        private Panel panel5;
        private Button button4;
        private Button menuBtn;
        private Button menuImageButton;
        private Button discoverImageButton;
        private Button searchImageButton;
        private Button mealImageButton;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private Panel panel9;
        private Button powerImageButton;
        private Button savedImageButton;
        private Button powerDownButton;
        private Button manualInputButton;
        private Button manualImageButton;
    }
}