namespace RecipeManager
{
    partial class SearchCriterionForm
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
            label1 = new Label();
            label2 = new Label();
            ingredientsTextBox = new TextBox();
            ingredientEnterBtn = new Button();
            recipeNameBox = new TextBox();
            ingredientsCheckedBox = new CheckedListBox();
            label3 = new Label();
            numIngredientsBox = new NumericUpDown();
            label4 = new Label();
            maxCaloriesBox = new NumericUpDown();
            label5 = new Label();
            maxSugarBox = new NumericUpDown();
            label6 = new Label();
            minProteinBox = new NumericUpDown();
            label7 = new Label();
            viewRecipesButton = new Button();
            missingFieldsLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)numIngredientsBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)maxCaloriesBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)maxSugarBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)minProteinBox).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Tahoma", 12.500001F, FontStyle.Bold);
            label1.Location = new Point(12, 64);
            label1.Name = "label1";
            label1.Size = new Size(310, 23);
            label1.TabIndex = 0;
            label1.Text = "Recipe Name (If Desired)";
            // 
            // label2
            // 
            label2.Font = new Font("Tahoma", 13.2000008F, FontStyle.Bold);
            label2.Location = new Point(12, 136);
            label2.Name = "label2";
            label2.Size = new Size(318, 58);
            label2.TabIndex = 1;
            label2.Text = "Ingredients You Would Like to Search By (If Desired)";
            // 
            // ingredientsTextBox
            // 
            ingredientsTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            ingredientsTextBox.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ingredientsTextBox.Location = new Point(12, 182);
            ingredientsTextBox.Name = "ingredientsTextBox";
            ingredientsTextBox.Size = new Size(237, 22);
            ingredientsTextBox.TabIndex = 2;
            // 
            // ingredientEnterBtn
            // 
            ingredientEnterBtn.FlatStyle = FlatStyle.Flat;
            ingredientEnterBtn.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ingredientEnterBtn.Location = new Point(255, 182);
            ingredientEnterBtn.Name = "ingredientEnterBtn";
            ingredientEnterBtn.Size = new Size(67, 22);
            ingredientEnterBtn.TabIndex = 20;
            ingredientEnterBtn.Text = "ENTER";
            ingredientEnterBtn.UseVisualStyleBackColor = true;
            ingredientEnterBtn.Click += ingredientEnterBtn_Click;
            // 
            // recipeNameBox
            // 
            recipeNameBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            recipeNameBox.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            recipeNameBox.Location = new Point(12, 88);
            recipeNameBox.Name = "recipeNameBox";
            recipeNameBox.Size = new Size(310, 22);
            recipeNameBox.TabIndex = 21;
            // 
            // ingredientsCheckedBox
            // 
            ingredientsCheckedBox.CheckOnClick = true;
            ingredientsCheckedBox.Font = new Font("Tahoma", 9F);
            ingredientsCheckedBox.FormattingEnabled = true;
            ingredientsCheckedBox.Location = new Point(12, 211);
            ingredientsCheckedBox.Name = "ingredientsCheckedBox";
            ingredientsCheckedBox.Size = new Size(310, 38);
            ingredientsCheckedBox.TabIndex = 22;
            // 
            // label3
            // 
            label3.Font = new Font("Tahoma", 12.500001F, FontStyle.Bold);
            label3.Location = new Point(344, 136);
            label3.Name = "label3";
            label3.Size = new Size(331, 71);
            label3.TabIndex = 23;
            label3.Text = "Amount Of Recipes You Would Like To View (Default 10)";
            // 
            // numIngredientsBox
            // 
            numIngredientsBox.Font = new Font("Tahoma", 9F);
            numIngredientsBox.Location = new Point(344, 181);
            numIngredientsBox.Name = "numIngredientsBox";
            numIngredientsBox.Size = new Size(299, 22);
            numIngredientsBox.TabIndex = 24;
            // 
            // label4
            // 
            label4.Font = new Font("Tahoma", 13.2000008F, FontStyle.Bold);
            label4.Location = new Point(681, 137);
            label4.Name = "label4";
            label4.Size = new Size(305, 71);
            label4.TabIndex = 25;
            label4.Text = "Max Calories in Recipes (If Desired)";
            // 
            // maxCaloriesBox
            // 
            maxCaloriesBox.DecimalPlaces = 2;
            maxCaloriesBox.Font = new Font("Tahoma", 9F);
            maxCaloriesBox.Increment = new decimal(new int[] { 30, 0, 0, 0 });
            maxCaloriesBox.Location = new Point(681, 181);
            maxCaloriesBox.Maximum = new decimal(new int[] { 15000, 0, 0, 0 });
            maxCaloriesBox.Name = "maxCaloriesBox";
            maxCaloriesBox.Size = new Size(305, 22);
            maxCaloriesBox.TabIndex = 26;
            // 
            // label5
            // 
            label5.Font = new Font("Tahoma", 13.2000008F, FontStyle.Bold);
            label5.Location = new Point(341, 44);
            label5.Name = "label5";
            label5.Size = new Size(319, 71);
            label5.TabIndex = 27;
            label5.Text = "Max Sugar in Recipes in Grams (If Desired)";
            // 
            // maxSugarBox
            // 
            maxSugarBox.DecimalPlaces = 2;
            maxSugarBox.Font = new Font("Tahoma", 9F);
            maxSugarBox.Location = new Point(344, 88);
            maxSugarBox.Name = "maxSugarBox";
            maxSugarBox.Size = new Size(299, 22);
            maxSugarBox.TabIndex = 28;
            // 
            // label6
            // 
            label6.Font = new Font("Tahoma", 13.2000008F, FontStyle.Bold);
            label6.Location = new Point(678, 44);
            label6.Name = "label6";
            label6.Size = new Size(308, 71);
            label6.TabIndex = 29;
            label6.Text = "Min Protein in Recipes in Grams (If Desired)";
            // 
            // minProteinBox
            // 
            minProteinBox.DecimalPlaces = 2;
            minProteinBox.Font = new Font("Tahoma", 9F);
            minProteinBox.Location = new Point(681, 88);
            minProteinBox.Name = "minProteinBox";
            minProteinBox.Size = new Size(305, 22);
            minProteinBox.TabIndex = 30;
            // 
            // label7
            // 
            label7.Dock = DockStyle.Top;
            label7.Font = new Font("Tahoma", 19.2F, FontStyle.Bold);
            label7.Location = new Point(0, 0);
            label7.Name = "label7";
            label7.Size = new Size(1017, 44);
            label7.TabIndex = 31;
            label7.Text = "SEARCH CRITERION CONFIGURATOR";
            label7.TextAlign = ContentAlignment.TopCenter;
            // 
            // viewRecipesButton
            // 
            viewRecipesButton.FlatStyle = FlatStyle.Flat;
            viewRecipesButton.Font = new Font("Tahoma", 13.2000008F, FontStyle.Bold);
            viewRecipesButton.Location = new Point(255, 441);
            viewRecipesButton.Name = "viewRecipesButton";
            viewRecipesButton.Size = new Size(516, 43);
            viewRecipesButton.TabIndex = 32;
            viewRecipesButton.Text = "VIEW RECIPES";
            viewRecipesButton.UseVisualStyleBackColor = true;
            viewRecipesButton.Click += viewRecipesButton_Click;
            // 
            // missingFieldsLabel
            // 
            missingFieldsLabel.AutoSize = true;
            missingFieldsLabel.Font = new Font("Tahoma", 10.2000008F);
            missingFieldsLabel.ForeColor = Color.Red;
            missingFieldsLabel.Location = new Point(383, 406);
            missingFieldsLabel.Name = "missingFieldsLabel";
            missingFieldsLabel.Size = new Size(260, 17);
            missingFieldsLabel.TabIndex = 44;
            missingFieldsLabel.Text = "* MUST HAVE AT LEAST ONE CRITERION";
            missingFieldsLabel.Visible = false;
            // 
            // SearchCriterionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1017, 517);
            Controls.Add(missingFieldsLabel);
            Controls.Add(viewRecipesButton);
            Controls.Add(label7);
            Controls.Add(minProteinBox);
            Controls.Add(label6);
            Controls.Add(maxSugarBox);
            Controls.Add(label5);
            Controls.Add(maxCaloriesBox);
            Controls.Add(label4);
            Controls.Add(numIngredientsBox);
            Controls.Add(label3);
            Controls.Add(ingredientsCheckedBox);
            Controls.Add(recipeNameBox);
            Controls.Add(ingredientEnterBtn);
            Controls.Add(ingredientsTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "SearchCriterionForm";
            Text = "SearchCriterionForm";
            ((System.ComponentModel.ISupportInitialize)numIngredientsBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)maxCaloriesBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)maxSugarBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)minProteinBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox ingredientsTextBox;
        private Button ingredientEnterBtn;
        private TextBox recipeNameBox;
        private CheckedListBox ingredientsCheckedBox;
        private Label label3;
        private NumericUpDown numIngredientsBox;
        private Label label4;
        private NumericUpDown maxCaloriesBox;
        private Label label5;
        private NumericUpDown maxSugarBox;
        private Label label6;
        private NumericUpDown minProteinBox;
        private Label label7;
        private Button viewRecipesButton;
        private Label missingFieldsLabel;
    }
}