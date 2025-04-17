namespace RecipeManager
{
    partial class SaveRecipeForm
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
            listsCheckedBox = new CheckedListBox();
            label1 = new Label();
            label2 = new Label();
            newListBox = new TextBox();
            createButton = new Button();
            noListsLabel = new Label();
            saveButton = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // listsCheckedBox
            // 
            listsCheckedBox.BackColor = SystemColors.Control;
            listsCheckedBox.BorderStyle = BorderStyle.None;
            listsCheckedBox.Font = new Font("Tahoma", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listsCheckedBox.ForeColor = SystemColors.ActiveCaptionText;
            listsCheckedBox.FormattingEnabled = true;
            listsCheckedBox.Location = new Point(12, 49);
            listsCheckedBox.Name = "listsCheckedBox";
            listsCheckedBox.Size = new Size(234, 80);
            listsCheckedBox.TabIndex = 0;
            listsCheckedBox.ThreeDCheckBoxes = true;
            //listsCheckedBox.ControlAdded += listsCheckedBox_ControlAdded;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(306, 23);
            label1.TabIndex = 1;
            label1.Text = "Choose Where To Save Recipe:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 11.8F);
            label2.Location = new Point(12, 234);
            label2.Name = "label2";
            label2.Size = new Size(185, 19);
            label2.TabIndex = 3;
            label2.Text = "Enter Name Of New List:";
            // 
            // newListBox
            // 
            newListBox.Font = new Font("Tahoma", 11.8F);
            newListBox.Location = new Point(12, 162);
            newListBox.Name = "newListBox";
            newListBox.Size = new Size(234, 26);
            newListBox.TabIndex = 4;
            // 
            // createButton
            // 
            createButton.FlatStyle = FlatStyle.Flat;
            createButton.Font = new Font("Tahoma", 10.8F);
            createButton.ForeColor = SystemColors.ControlText;
            createButton.Location = new Point(252, 161);
            createButton.Name = "createButton";
            createButton.Size = new Size(85, 27);
            createButton.TabIndex = 5;
            createButton.Text = "Add";
            createButton.UseVisualStyleBackColor = true;
            createButton.Click += createButton_Click;
            // 
            // noListsLabel
            // 
            noListsLabel.AutoSize = true;
            noListsLabel.Font = new Font("Tahoma", 10.8F);
            noListsLabel.ForeColor = Color.Red;
            noListsLabel.Location = new Point(12, 49);
            noListsLabel.Name = "noListsLabel";
            noListsLabel.Size = new Size(279, 18);
            noListsLabel.TabIndex = 6;
            noListsLabel.Text = "No Lists Created Yet, Create a New One.";
            noListsLabel.Visible = false;
            // 
            // saveButton
            // 
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.Font = new Font("Tahoma", 10.8F);
            saveButton.ForeColor = SystemColors.ControlText;
            saveButton.Location = new Point(12, 226);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(325, 27);
            saveButton.TabIndex = 7;
            saveButton.Text = "Save Selection";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 9F);
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(12, 142);
            label3.Name = "label3";
            label3.Size = new Size(98, 14);
            label3.TabIndex = 8;
            label3.Text = "Create New List:";
            // 
            // SaveRecipeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(349, 271);
            Controls.Add(label3);
            Controls.Add(saveButton);
            Controls.Add(noListsLabel);
            Controls.Add(createButton);
            Controls.Add(newListBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listsCheckedBox);
            ForeColor = SystemColors.Control;
            MaximumSize = new Size(365, 367);
            MinimumSize = new Size(365, 267);
            Name = "SaveRecipeForm";
            Text = "SaveRecipeForm";
            Load += SaveRecipeForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox listsCheckedBox;
        private Label label1;
        private Label label2;
        private TextBox newListBox;
        private Button createButton;
        private Label noListsLabel;
        private Button saveButton;
        private Label label3;
    }
}