namespace RecipeManager
{
    partial class RecipeInfoForm
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
            recipeName = new Label();
            ingredientTextBox = new TextBox();
            instructionTextBox = new TextBox();
            ingredientLabel = new Label();
            instructionLabel = new Label();
            backButton = new Button();
            recipeImage = new PictureBox();
            nutritionLabel = new Label();
            nutritionTable = new TableLayoutPanel();
            servingsLabel = new Label();
            label11 = new Label();
            watchersLabel = new Label();
            healthLabel = new Label();
            priceLabel = new Label();
            fatLabel = new Label();
            sugarLabel = new Label();
            proteinLabel = new Label();
            calorieLabel = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)recipeImage).BeginInit();
            nutritionTable.SuspendLayout();
            SuspendLayout();
            // 
            // recipeName
            // 
            recipeName.Dock = DockStyle.Top;
            recipeName.Font = new Font("Tahoma", 16F, FontStyle.Bold);
            recipeName.Location = new Point(0, 0);
            recipeName.Name = "recipeName";
            recipeName.Size = new Size(948, 33);
            recipeName.TabIndex = 0;
            recipeName.Text = "Recipe Name";
            recipeName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ingredientTextBox
            // 
            ingredientTextBox.Font = new Font("Sitka Text", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ingredientTextBox.Location = new Point(12, 535);
            ingredientTextBox.Multiline = true;
            ingredientTextBox.Name = "ingredientTextBox";
            ingredientTextBox.ReadOnly = true;
            ingredientTextBox.ScrollBars = ScrollBars.Vertical;
            ingredientTextBox.Size = new Size(867, 265);
            ingredientTextBox.TabIndex = 1;
            ingredientTextBox.Enter += ingredientTextBox_Enter;
            // 
            // instructionTextBox
            // 
            instructionTextBox.Font = new Font("Sitka Text", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            instructionTextBox.Location = new Point(12, 825);
            instructionTextBox.Multiline = true;
            instructionTextBox.Name = "instructionTextBox";
            instructionTextBox.ReadOnly = true;
            instructionTextBox.ScrollBars = ScrollBars.Vertical;
            instructionTextBox.Size = new Size(867, 289);
            instructionTextBox.TabIndex = 2;
            instructionTextBox.Enter += stepTextBox_Enter;
            // 
            // ingredientLabel
            // 
            ingredientLabel.AutoSize = true;
            ingredientLabel.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ingredientLabel.Location = new Point(12, 513);
            ingredientLabel.Name = "ingredientLabel";
            ingredientLabel.Size = new Size(89, 19);
            ingredientLabel.TabIndex = 3;
            ingredientLabel.Text = "Ingredients";
            // 
            // instructionLabel
            // 
            instructionLabel.AutoSize = true;
            instructionLabel.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            instructionLabel.Location = new Point(12, 803);
            instructionLabel.Name = "instructionLabel";
            instructionLabel.Size = new Size(92, 19);
            instructionLabel.TabIndex = 4;
            instructionLabel.Text = "Instructions";
            // 
            // backButton
            // 
            backButton.BackColor = SystemColors.Control;
            backButton.BackgroundImage = Properties.Resources.Back_Button_Transparent;
            backButton.BackgroundImageLayout = ImageLayout.Zoom;
            backButton.FlatStyle = FlatStyle.Flat;
            backButton.Font = new Font("Tahoma", 12F);
            backButton.Location = new Point(4, 3);
            backButton.Name = "backButton";
            backButton.Size = new Size(37, 27);
            backButton.TabIndex = 5;
            backButton.UseVisualStyleBackColor = false;
            backButton.Click += backButton_Click;
            // 
            // recipeImage
            // 
            recipeImage.BackgroundImageLayout = ImageLayout.None;
            recipeImage.Location = new Point(308, 49);
            recipeImage.Name = "recipeImage";
            recipeImage.Size = new Size(548, 346);
            recipeImage.SizeMode = PictureBoxSizeMode.Zoom;
            recipeImage.TabIndex = 6;
            recipeImage.TabStop = false;
            // 
            // nutritionLabel
            // 
            nutritionLabel.AutoSize = true;
            nutritionLabel.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nutritionLabel.Location = new Point(12, 234);
            nutritionLabel.Name = "nutritionLabel";
            nutritionLabel.Size = new Size(127, 19);
            nutritionLabel.TabIndex = 8;
            nutritionLabel.Text = "Nutritional Value";
            // 
            // nutritionTable
            // 
            nutritionTable.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            nutritionTable.ColumnCount = 2;
            nutritionTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 137F));
            nutritionTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            nutritionTable.Controls.Add(servingsLabel, 1, 7);
            nutritionTable.Controls.Add(label11, 0, 7);
            nutritionTable.Controls.Add(watchersLabel, 1, 6);
            nutritionTable.Controls.Add(healthLabel, 1, 5);
            nutritionTable.Controls.Add(priceLabel, 1, 4);
            nutritionTable.Controls.Add(fatLabel, 1, 3);
            nutritionTable.Controls.Add(sugarLabel, 1, 2);
            nutritionTable.Controls.Add(proteinLabel, 1, 1);
            nutritionTable.Controls.Add(calorieLabel, 1, 0);
            nutritionTable.Controls.Add(label5, 0, 1);
            nutritionTable.Controls.Add(label6, 0, 2);
            nutritionTable.Controls.Add(label7, 0, 3);
            nutritionTable.Controls.Add(label8, 0, 4);
            nutritionTable.Controls.Add(label9, 0, 5);
            nutritionTable.Controls.Add(label10, 0, 6);
            nutritionTable.Controls.Add(label4, 0, 0);
            nutritionTable.Location = new Point(12, 256);
            nutritionTable.Name = "nutritionTable";
            nutritionTable.RowCount = 8;
            nutritionTable.RowStyles.Add(new RowStyle());
            nutritionTable.RowStyles.Add(new RowStyle());
            nutritionTable.RowStyles.Add(new RowStyle());
            nutritionTable.RowStyles.Add(new RowStyle());
            nutritionTable.RowStyles.Add(new RowStyle());
            nutritionTable.RowStyles.Add(new RowStyle());
            nutritionTable.RowStyles.Add(new RowStyle());
            nutritionTable.RowStyles.Add(new RowStyle());
            nutritionTable.Size = new Size(251, 225);
            nutritionTable.TabIndex = 9;
            // 
            // servingsLabel
            // 
            servingsLabel.AutoSize = true;
            servingsLabel.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            servingsLabel.Location = new Point(142, 179);
            servingsLabel.Name = "servingsLabel";
            servingsLabel.Size = new Size(0, 19);
            servingsLabel.TabIndex = 25;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(4, 179);
            label11.Name = "label11";
            label11.Size = new Size(75, 19);
            label11.TabIndex = 24;
            label11.Text = "Servings:";
            // 
            // watchersLabel
            // 
            watchersLabel.AutoSize = true;
            watchersLabel.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            watchersLabel.Location = new Point(142, 140);
            watchersLabel.Name = "watchersLabel";
            watchersLabel.Size = new Size(0, 19);
            watchersLabel.TabIndex = 23;
            // 
            // healthLabel
            // 
            healthLabel.AutoSize = true;
            healthLabel.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            healthLabel.Location = new Point(142, 120);
            healthLabel.Name = "healthLabel";
            healthLabel.Size = new Size(0, 19);
            healthLabel.TabIndex = 22;
            // 
            // priceLabel
            // 
            priceLabel.AutoSize = true;
            priceLabel.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            priceLabel.Location = new Point(142, 81);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new Size(0, 19);
            priceLabel.TabIndex = 21;
            // 
            // fatLabel
            // 
            fatLabel.AutoSize = true;
            fatLabel.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            fatLabel.Location = new Point(142, 61);
            fatLabel.Name = "fatLabel";
            fatLabel.Size = new Size(0, 19);
            fatLabel.TabIndex = 20;
            // 
            // sugarLabel
            // 
            sugarLabel.AutoSize = true;
            sugarLabel.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            sugarLabel.Location = new Point(142, 41);
            sugarLabel.Name = "sugarLabel";
            sugarLabel.Size = new Size(0, 19);
            sugarLabel.TabIndex = 19;
            // 
            // proteinLabel
            // 
            proteinLabel.AutoSize = true;
            proteinLabel.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            proteinLabel.Location = new Point(142, 21);
            proteinLabel.Name = "proteinLabel";
            proteinLabel.Size = new Size(0, 19);
            proteinLabel.TabIndex = 18;
            // 
            // calorieLabel
            // 
            calorieLabel.AutoSize = true;
            calorieLabel.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            calorieLabel.Location = new Point(142, 1);
            calorieLabel.Name = "calorieLabel";
            calorieLabel.Size = new Size(0, 19);
            calorieLabel.TabIndex = 17;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(4, 21);
            label5.Name = "label5";
            label5.Size = new Size(126, 19);
            label5.TabIndex = 11;
            label5.Text = "Protein (grams):";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(4, 41);
            label6.Name = "label6";
            label6.Size = new Size(117, 19);
            label6.TabIndex = 12;
            label6.Text = "Sugar (grams):";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(4, 61);
            label7.Name = "label7";
            label7.Size = new Size(97, 19);
            label7.TabIndex = 13;
            label7.Text = "Fat (grams):";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(4, 81);
            label8.Name = "label8";
            label8.Size = new Size(129, 38);
            label8.TabIndex = 14;
            label8.Text = "Price Per Serving ($):";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(4, 120);
            label9.Name = "label9";
            label9.Size = new Size(104, 19);
            label9.TabIndex = 15;
            label9.Text = "Health Score:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(4, 140);
            label10.Name = "label10";
            label10.Size = new Size(125, 38);
            label10.TabIndex = 16;
            label10.Text = "Weight Watcher SmartPoints:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(4, 1);
            label4.Name = "label4";
            label4.Size = new Size(71, 19);
            label4.TabIndex = 10;
            label4.Text = "Calories:";
            // 
            // RecipeInfoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoScrollMinSize = new Size(0, 1300);
            ClientSize = new Size(965, 468);
            Controls.Add(ingredientLabel);
            Controls.Add(instructionLabel);
            Controls.Add(instructionTextBox);
            Controls.Add(ingredientTextBox);
            Controls.Add(recipeImage);
            Controls.Add(backButton);
            Controls.Add(recipeName);
            Controls.Add(nutritionLabel);
            Controls.Add(nutritionTable);
            Name = "RecipeInfoForm";
            Text = "RecipeInfoForm";
            Load += RecipeInfoForm_Load;
            ((System.ComponentModel.ISupportInitialize)recipeImage).EndInit();
            nutritionTable.ResumeLayout(false);
            nutritionTable.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label recipeName;
        private TextBox ingredientTextBox;
        private TextBox instructionTextBox;
        private Label ingredientLabel;
        private Label instructionLabel;
        private Button backButton;
        private PictureBox recipeImage;
        private Label nutritionLabel;
        private TableLayoutPanel nutritionTable;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label fatLabel;
        private Label sugarLabel;
        private Label proteinLabel;
        private Label calorieLabel;
        private Label label10;
        private Label priceLabel;
        private Label watchersLabel;
        private Label healthLabel;
        private Label servingsLabel;
        private Label label11;
    }
}