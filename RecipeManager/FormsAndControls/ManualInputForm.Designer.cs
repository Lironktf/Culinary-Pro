namespace RecipeManager
{
    partial class ManualInputForm
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
            formLabel = new Label();
            label1 = new Label();
            ingredientTextBox = new TextBox();
            instructionsTextBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            recipeNameBox = new TextBox();
            missingFieldsLabel = new Label();
            listsButton = new Button();
            SuspendLayout();
            // 
            // formLabel
            // 
            formLabel.Dock = DockStyle.Top;
            formLabel.Font = new Font("Tahoma", 19.2F, FontStyle.Bold);
            formLabel.Location = new Point(0, 0);
            formLabel.Name = "formLabel";
            formLabel.Size = new Size(995, 44);
            formLabel.TabIndex = 32;
            formLabel.Text = "MANUAL RECIPE CONFIGURATOR";
            formLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 13.2000008F, FontStyle.Bold);
            label1.Location = new Point(12, 138);
            label1.Name = "label1";
            label1.Size = new Size(198, 22);
            label1.TabIndex = 33;
            label1.Text = "Recipe Ingredients *";
            // 
            // ingredientTextBox
            // 
            ingredientTextBox.BackColor = Color.White;
            ingredientTextBox.Font = new Font("Sitka Text", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ingredientTextBox.Location = new Point(12, 163);
            ingredientTextBox.Multiline = true;
            ingredientTextBox.Name = "ingredientTextBox";
            ingredientTextBox.ScrollBars = ScrollBars.Vertical;
            ingredientTextBox.Size = new Size(907, 300);
            ingredientTextBox.TabIndex = 34;
            // 
            // instructionsTextBox
            // 
            instructionsTextBox.BackColor = Color.White;
            instructionsTextBox.Font = new Font("Sitka Text", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            instructionsTextBox.Location = new Point(12, 525);
            instructionsTextBox.Multiline = true;
            instructionsTextBox.Name = "instructionsTextBox";
            instructionsTextBox.ScrollBars = ScrollBars.Vertical;
            instructionsTextBox.Size = new Size(907, 300);
            instructionsTextBox.TabIndex = 35;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 13.2000008F, FontStyle.Bold);
            label2.Location = new Point(12, 500);
            label2.Name = "label2";
            label2.Size = new Size(203, 22);
            label2.TabIndex = 36;
            label2.Text = "Recipe Instructions *";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 13.2000008F, FontStyle.Bold);
            label3.Location = new Point(12, 35);
            label3.Name = "label3";
            label3.Size = new Size(145, 22);
            label3.TabIndex = 38;
            label3.Text = "Recipe Name *";
            // 
            // recipeNameBox
            // 
            recipeNameBox.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            recipeNameBox.Location = new Point(12, 60);
            recipeNameBox.Name = "recipeNameBox";
            recipeNameBox.Size = new Size(304, 26);
            recipeNameBox.TabIndex = 39;
            // 
            // missingFieldsLabel
            // 
            missingFieldsLabel.AutoSize = true;
            missingFieldsLabel.Font = new Font("Tahoma", 10.2000008F);
            missingFieldsLabel.ForeColor = Color.Red;
            missingFieldsLabel.Location = new Point(362, 842);
            missingFieldsLabel.Name = "missingFieldsLabel";
            missingFieldsLabel.Size = new Size(191, 17);
            missingFieldsLabel.TabIndex = 43;
            missingFieldsLabel.Text = "* MISSING REQUIRED FIELDS";
            missingFieldsLabel.Visible = false;
            // 
            // listsButton
            // 
            listsButton.BackColor = SystemColors.ControlDark;
            listsButton.FlatAppearance.MouseOverBackColor = Color.White;
            listsButton.FlatStyle = FlatStyle.Flat;
            listsButton.Font = new Font("Tahoma", 13.2000008F, FontStyle.Bold);
            listsButton.Location = new Point(12, 842);
            listsButton.Name = "listsButton";
            listsButton.Size = new Size(324, 43);
            listsButton.TabIndex = 44;
            listsButton.Text = "RECIPE LISTS";
            listsButton.UseVisualStyleBackColor = false;
            listsButton.Click += listsButton_Click;
            // 
            // ManualInputForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoScrollMinSize = new Size(0, 1000);
            ClientSize = new Size(1012, 496);
            Controls.Add(listsButton);
            Controls.Add(missingFieldsLabel);
            Controls.Add(recipeNameBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(instructionsTextBox);
            Controls.Add(ingredientTextBox);
            Controls.Add(label1);
            Controls.Add(formLabel);
            Name = "ManualInputForm";
            Text = "ManualInputForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label formLabel;
        private Label label1;
        private TextBox ingredientTextBox;
        private TextBox instructionsTextBox;
        private Label label2;
        private Label label3;
        private TextBox recipeNameBox;
        private Label missingFieldsLabel;
        private Button listsButton;
    }
}