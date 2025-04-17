namespace RecipeManager
{
    partial class MinimalRecipeCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            recipeNameLabel = new Label();
            saveBtn = new Button();
            SuspendLayout();
            // 
            // recipeNameLabel
            // 
            recipeNameLabel.AutoSize = true;
            recipeNameLabel.Font = new Font("Tahoma", 12.8F, FontStyle.Bold);
            recipeNameLabel.Location = new Point(114, 24);
            recipeNameLabel.MaximumSize = new Size(280, 0);
            recipeNameLabel.Name = "recipeNameLabel";
            recipeNameLabel.Size = new Size(64, 22);
            recipeNameLabel.TabIndex = 5;
            recipeNameLabel.Text = "label1";
            recipeNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            recipeNameLabel.Click += recipeNameLabel_Click;
            recipeNameLabel.MouseEnter += recipeNameLabel_MouseEnter;
            recipeNameLabel.MouseLeave += recipeNameLabel_MouseLeave;
            // 
            // saveBtn
            // 
            saveBtn.FlatStyle = FlatStyle.Flat;
            saveBtn.Font = new Font("Verdana", 8F, FontStyle.Bold);
            saveBtn.Location = new Point(178, 0);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(81, 21);
            saveBtn.TabIndex = 6;
            saveBtn.Text = "SAVE";
            saveBtn.UseVisualStyleBackColor = true;
            saveBtn.Click += saveBtn_Click;
            // 
            // MinimalRecipeCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PowderBlue;
            Controls.Add(saveBtn);
            Controls.Add(recipeNameLabel);
            Name = "MinimalRecipeCard";
            Size = new Size(297, 110);
            Load += MinimalRecipeCard_Load;
            MouseClick += MinimalRecipeCard_MouseClick;
            MouseEnter += MinimalRecipeCard_MouseEnter;
            MouseLeave += MinimalRecipeCard_MouseLeave;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label recipeNameLabel;
        private Button saveBtn;
    }
}
