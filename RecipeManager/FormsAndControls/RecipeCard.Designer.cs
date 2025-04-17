namespace RecipeManager
{
    partial class RecipeCard
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
            recipeImage = new PictureBox();
            saveBtn = new Button();
            recipeNameLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)recipeImage).BeginInit();
            SuspendLayout();
            // 
            // recipeImage
            // 
            recipeImage.Image = Properties.Resources.Deafult_Recipe_Image;
            recipeImage.Location = new Point(10, 76);
            recipeImage.Name = "recipeImage";
            recipeImage.Size = new Size(422, 248);
            recipeImage.SizeMode = PictureBoxSizeMode.Zoom;
            recipeImage.TabIndex = 0;
            recipeImage.TabStop = false;
            recipeImage.Click += recipeImage_Click;
            recipeImage.MouseEnter += recipeImage_MouseEnter;
            recipeImage.MouseLeave += recipeImage_MouseLeave;
            // 
            // saveBtn
            // 
            saveBtn.FlatStyle = FlatStyle.Flat;
            saveBtn.Font = new Font("Verdana", 8F, FontStyle.Bold);
            saveBtn.Location = new Point(334, 0);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(81, 21);
            saveBtn.TabIndex = 2;
            saveBtn.Text = "SAVE";
            saveBtn.UseVisualStyleBackColor = true;
            saveBtn.Click += saveBtn_Click;
            // 
            // recipeNameLabel
            // 
            recipeNameLabel.AutoSize = true;
            recipeNameLabel.Font = new Font("Tahoma", 13.8F, FontStyle.Bold);
            recipeNameLabel.Location = new Point(159, 24);
            recipeNameLabel.MaximumSize = new Size(450, 0);
            recipeNameLabel.Name = "recipeNameLabel";
            recipeNameLabel.Size = new Size(68, 23);
            recipeNameLabel.TabIndex = 4;
            recipeNameLabel.Text = "label1";
            recipeNameLabel.TextAlign = ContentAlignment.TopCenter;
            recipeNameLabel.Click += recipeNameLabel_Click;
            recipeNameLabel.MouseEnter += recipeNameLabel_MouseEnter;
            recipeNameLabel.MouseLeave += recipeNameLabel_MouseLeave;
            // 
            // RecipeCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PowderBlue;
            Controls.Add(recipeNameLabel);
            Controls.Add(saveBtn);
            Controls.Add(recipeImage);
            Name = "RecipeCard";
            Padding = new Padding(10, 20, 10, 5);
            Size = new Size(442, 329);
            Load += RecipeCard_Load_1;
            MouseClick += RecipeCard_MouseClick;
            MouseEnter += RecipeCard_MouseEnter;
            MouseLeave += RecipeCard_MouseLeave;
            ((System.ComponentModel.ISupportInitialize)recipeImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox recipeImage;
        private Button saveBtn;
        private Label recipeNameLabel;
    }
}
