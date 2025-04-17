namespace RecipeManager
{
    partial class SavedListsViewForm
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
            listsComboBox = new ComboBox();
            label1 = new Label();
            viewButton = new Button();
            missingFieldsLabel = new Label();
            deleteButton = new Button();
            SuspendLayout();
            // 
            // recipeName
            // 
            recipeName.Dock = DockStyle.Top;
            recipeName.Font = new Font("Tahoma", 16F, FontStyle.Bold);
            recipeName.Location = new Point(0, 0);
            recipeName.Name = "recipeName";
            recipeName.Size = new Size(1012, 33);
            recipeName.TabIndex = 1;
            recipeName.Text = "Saved Recipe Lists Selector";
            recipeName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // listsComboBox
            // 
            listsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            listsComboBox.FlatStyle = FlatStyle.Flat;
            listsComboBox.Font = new Font("Tahoma", 11.25F, FontStyle.Bold);
            listsComboBox.FormattingEnabled = true;
            listsComboBox.Location = new Point(12, 98);
            listsComboBox.Name = "listsComboBox";
            listsComboBox.Size = new Size(301, 26);
            listsComboBox.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 76);
            label1.Name = "label1";
            label1.Size = new Size(160, 19);
            label1.TabIndex = 8;
            label1.Text = "Select List Name *";
            // 
            // viewButton
            // 
            viewButton.BackColor = Color.Gray;
            viewButton.FlatAppearance.MouseDownBackColor = Color.White;
            viewButton.FlatStyle = FlatStyle.Flat;
            viewButton.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            viewButton.Location = new Point(12, 171);
            viewButton.Name = "viewButton";
            viewButton.Size = new Size(301, 30);
            viewButton.TabIndex = 10;
            viewButton.Text = "VIEW";
            viewButton.UseVisualStyleBackColor = false;
            viewButton.Click += viewButton_Click;
            // 
            // missingFieldsLabel
            // 
            missingFieldsLabel.AutoSize = true;
            missingFieldsLabel.Font = new Font("Tahoma", 10.2000008F);
            missingFieldsLabel.ForeColor = Color.Red;
            missingFieldsLabel.Location = new Point(68, 204);
            missingFieldsLabel.Name = "missingFieldsLabel";
            missingFieldsLabel.Size = new Size(191, 17);
            missingFieldsLabel.TabIndex = 44;
            missingFieldsLabel.Text = "* MISSING REQUIRED FIELDS";
            missingFieldsLabel.Visible = false;
            // 
            // deleteButton
            // 
            deleteButton.BackColor = Color.Gray;
            deleteButton.FlatAppearance.MouseDownBackColor = Color.White;
            deleteButton.FlatStyle = FlatStyle.Flat;
            deleteButton.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            deleteButton.Location = new Point(12, 230);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(301, 30);
            deleteButton.TabIndex = 45;
            deleteButton.Text = "CLICK TWICE TO DELETE";
            deleteButton.UseVisualStyleBackColor = false;
            deleteButton.Click += deleteButton_Click;
            // 
            // SavedListsViewForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1012, 496);
            Controls.Add(deleteButton);
            Controls.Add(missingFieldsLabel);
            Controls.Add(viewButton);
            Controls.Add(label1);
            Controls.Add(listsComboBox);
            Controls.Add(recipeName);
            Name = "SavedListsViewForm";
            Text = "SavedListsViewForm";
            Load += SavedListsViewForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label recipeName;
        private ComboBox listsComboBox;
        private Label label1;
        private Button viewButton;
        private Label missingFieldsLabel;
        private Button deleteButton;
    }
}