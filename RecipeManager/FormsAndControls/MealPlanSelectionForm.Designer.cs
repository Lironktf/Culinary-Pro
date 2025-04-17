namespace RecipeManager
{
    partial class MealPlanSelectionForm
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
            breakfastTextBox = new TextBox();
            lunchTextBox = new TextBox();
            dinnerTextBox = new TextBox();
            label4 = new Label();
            fitnessButton = new Button();
            caloricIntakeBox = new Label();
            ContinueBtn = new Button();
            breakfastCheckedBox = new CheckedListBox();
            lunchCheckedBox = new CheckedListBox();
            dinnerCheckedBox = new CheckedListBox();
            breakfastEnterBtn = new Button();
            lunchEnterBtn = new Button();
            dinnerEnterBtn = new Button();
            label5 = new Label();
            label6 = new Label();
            label2 = new Label();
            label3 = new Label();
            caloricIntakeLabel = new Label();
            includeCaloriesBox = new CheckBox();
            label7 = new Label();
            existingPlanBox = new ComboBox();
            label8 = new Label();
            newPlanName = new TextBox();
            loadPlanButton = new Button();
            label9 = new Label();
            notFoundLabel = new Label();
            missingFieldsLabel = new Label();
            missingFieldsLabel2 = new Label();
            ingredientCheckingBox = new CheckBox();
            deleteButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Tahoma", 11.2000008F);
            label1.Location = new Point(12, 120);
            label1.Name = "label1";
            label1.Size = new Size(337, 50);
            label1.TabIndex = 0;
            label1.Text = "Desired Breakfast Ingredients (Optional)";
            // 
            // breakfastTextBox
            // 
            breakfastTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            breakfastTextBox.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            breakfastTextBox.Location = new Point(12, 144);
            breakfastTextBox.Name = "breakfastTextBox";
            breakfastTextBox.Size = new Size(246, 22);
            breakfastTextBox.TabIndex = 1;
            // 
            // lunchTextBox
            // 
            lunchTextBox.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lunchTextBox.Location = new Point(355, 144);
            lunchTextBox.Name = "lunchTextBox";
            lunchTextBox.Size = new Size(246, 22);
            lunchTextBox.TabIndex = 3;
            // 
            // dinnerTextBox
            // 
            dinnerTextBox.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dinnerTextBox.Location = new Point(697, 144);
            dinnerTextBox.Name = "dinnerTextBox";
            dinnerTextBox.Size = new Size(226, 22);
            dinnerTextBox.TabIndex = 5;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Top;
            label4.Font = new Font("Tahoma", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(1017, 50);
            label4.TabIndex = 6;
            label4.Text = "MEAL PLAN OPTIONS";
            label4.TextAlign = ContentAlignment.TopCenter;
            // 
            // fitnessButton
            // 
            fitnessButton.BackColor = SystemColors.ButtonShadow;
            fitnessButton.FlatStyle = FlatStyle.Flat;
            fitnessButton.Font = new Font("Tahoma", 9F, FontStyle.Bold);
            fitnessButton.Location = new Point(12, 257);
            fitnessButton.Name = "fitnessButton";
            fitnessButton.Size = new Size(95, 22);
            fitnessButton.TabIndex = 7;
            fitnessButton.Text = "CALCULATE";
            fitnessButton.UseVisualStyleBackColor = false;
            fitnessButton.Click += fitnessButton_Click;
            // 
            // caloricIntakeBox
            // 
            caloricIntakeBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            caloricIntakeBox.AutoSize = true;
            caloricIntakeBox.BackColor = SystemColors.Control;
            caloricIntakeBox.Font = new Font("Tahoma", 11.2000008F);
            caloricIntakeBox.Location = new Point(255, 235);
            caloricIntakeBox.Name = "caloricIntakeBox";
            caloricIntakeBox.Size = new Size(0, 18);
            caloricIntakeBox.TabIndex = 9;
            // 
            // ContinueBtn
            // 
            ContinueBtn.BackColor = SystemColors.ButtonShadow;
            ContinueBtn.FlatStyle = FlatStyle.Flat;
            ContinueBtn.Font = new Font("Tahoma", 9F, FontStyle.Bold);
            ContinueBtn.Location = new Point(12, 312);
            ContinueBtn.Name = "ContinueBtn";
            ContinueBtn.Size = new Size(117, 22);
            ContinueBtn.TabIndex = 10;
            ContinueBtn.Text = "CREATE PLAN";
            ContinueBtn.UseVisualStyleBackColor = false;
            ContinueBtn.Click += generateNewPlan_Click;
            // 
            // breakfastCheckedBox
            // 
            breakfastCheckedBox.CheckOnClick = true;
            breakfastCheckedBox.Font = new Font("Tahoma", 9F);
            breakfastCheckedBox.FormattingEnabled = true;
            breakfastCheckedBox.Location = new Point(12, 172);
            breakfastCheckedBox.Name = "breakfastCheckedBox";
            breakfastCheckedBox.Size = new Size(319, 38);
            breakfastCheckedBox.TabIndex = 13;
            // 
            // lunchCheckedBox
            // 
            lunchCheckedBox.CheckOnClick = true;
            lunchCheckedBox.Font = new Font("Tahoma", 9F);
            lunchCheckedBox.FormattingEnabled = true;
            lunchCheckedBox.Location = new Point(355, 171);
            lunchCheckedBox.Name = "lunchCheckedBox";
            lunchCheckedBox.Size = new Size(319, 38);
            lunchCheckedBox.TabIndex = 14;
            // 
            // dinnerCheckedBox
            // 
            dinnerCheckedBox.CheckOnClick = true;
            dinnerCheckedBox.Font = new Font("Tahoma", 9F);
            dinnerCheckedBox.FormattingEnabled = true;
            dinnerCheckedBox.Location = new Point(697, 172);
            dinnerCheckedBox.Name = "dinnerCheckedBox";
            dinnerCheckedBox.Size = new Size(295, 38);
            dinnerCheckedBox.TabIndex = 15;
            // 
            // breakfastEnterBtn
            // 
            breakfastEnterBtn.BackColor = SystemColors.ButtonShadow;
            breakfastEnterBtn.FlatStyle = FlatStyle.Flat;
            breakfastEnterBtn.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            breakfastEnterBtn.Location = new Point(264, 144);
            breakfastEnterBtn.Name = "breakfastEnterBtn";
            breakfastEnterBtn.Size = new Size(67, 22);
            breakfastEnterBtn.TabIndex = 19;
            breakfastEnterBtn.Text = "ENTER";
            breakfastEnterBtn.UseVisualStyleBackColor = false;
            breakfastEnterBtn.Click += breakfastEnterBtn_Click;
            // 
            // lunchEnterBtn
            // 
            lunchEnterBtn.BackColor = SystemColors.ButtonShadow;
            lunchEnterBtn.FlatStyle = FlatStyle.Flat;
            lunchEnterBtn.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lunchEnterBtn.Location = new Point(607, 144);
            lunchEnterBtn.Name = "lunchEnterBtn";
            lunchEnterBtn.Size = new Size(67, 22);
            lunchEnterBtn.TabIndex = 20;
            lunchEnterBtn.Text = "ENTER";
            lunchEnterBtn.UseVisualStyleBackColor = false;
            lunchEnterBtn.Click += lunchEnterBtn_Click;
            // 
            // dinnerEnterBtn
            // 
            dinnerEnterBtn.BackColor = SystemColors.ButtonShadow;
            dinnerEnterBtn.FlatStyle = FlatStyle.Flat;
            dinnerEnterBtn.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dinnerEnterBtn.Location = new Point(929, 144);
            dinnerEnterBtn.Name = "dinnerEnterBtn";
            dinnerEnterBtn.Size = new Size(63, 22);
            dinnerEnterBtn.TabIndex = 21;
            dinnerEnterBtn.Text = "ENTER";
            dinnerEnterBtn.UseVisualStyleBackColor = false;
            dinnerEnterBtn.Click += dinnerEnterBtn_Click;
            // 
            // label5
            // 
            label5.Font = new Font("Tahoma", 11.2000008F);
            label5.Location = new Point(355, 120);
            label5.Name = "label5";
            label5.Size = new Size(319, 20);
            label5.TabIndex = 22;
            label5.Text = "Desired Lunch Ingredients (Optional)";
            // 
            // label6
            // 
            label6.Font = new Font("Tahoma", 11.2000008F);
            label6.Location = new Point(697, 120);
            label6.Name = "label6";
            label6.Size = new Size(385, 21);
            label6.TabIndex = 23;
            label6.Text = "Desired Dinner Ingredients (Optional)";
            // 
            // label2
            // 
            label2.Font = new Font("Tahoma", 14.2000008F, FontStyle.Bold);
            label2.Location = new Point(12, 35);
            label2.Name = "label2";
            label2.Size = new Size(337, 30);
            label2.TabIndex = 24;
            label2.Text = "Create New Meal Plan";
            // 
            // label3
            // 
            label3.Font = new Font("Tahoma", 14.2000008F, FontStyle.Bold);
            label3.Location = new Point(12, 365);
            label3.Name = "label3";
            label3.Size = new Size(378, 30);
            label3.TabIndex = 25;
            label3.Text = "Load Existing Meal Plan";
            // 
            // caloricIntakeLabel
            // 
            caloricIntakeLabel.Font = new Font("Tahoma", 11.2000008F);
            caloricIntakeLabel.Location = new Point(14, 235);
            caloricIntakeLabel.Name = "caloricIntakeLabel";
            caloricIntakeLabel.Size = new Size(235, 19);
            caloricIntakeLabel.TabIndex = 8;
            caloricIntakeLabel.Text = "Recommended Daily Caloric Intake";
            // 
            // includeCaloriesBox
            // 
            includeCaloriesBox.AutoSize = true;
            includeCaloriesBox.Font = new Font("Tahoma", 11.2000008F);
            includeCaloriesBox.Location = new Point(125, 257);
            includeCaloriesBox.Name = "includeCaloriesBox";
            includeCaloriesBox.Size = new Size(238, 22);
            includeCaloriesBox.TabIndex = 27;
            includeCaloriesBox.Text = "Include In Meal Plan Calculation?";
            includeCaloriesBox.UseVisualStyleBackColor = true;
            includeCaloriesBox.Visible = false;
            // 
            // label7
            // 
            label7.BorderStyle = BorderStyle.Fixed3D;
            label7.Location = new Point(0, 346);
            label7.Name = "label7";
            label7.Size = new Size(1014, 10);
            label7.TabIndex = 28;
            // 
            // existingPlanBox
            // 
            existingPlanBox.DropDownStyle = ComboBoxStyle.DropDownList;
            existingPlanBox.FlatStyle = FlatStyle.Flat;
            existingPlanBox.Font = new Font("Tahoma", 9F);
            existingPlanBox.FormattingEnabled = true;
            existingPlanBox.Location = new Point(12, 423);
            existingPlanBox.Name = "existingPlanBox";
            existingPlanBox.Size = new Size(319, 22);
            existingPlanBox.TabIndex = 29;
            // 
            // label8
            // 
            label8.Font = new Font("Tahoma", 11.2000008F);
            label8.Location = new Point(12, 65);
            label8.Name = "label8";
            label8.Size = new Size(124, 24);
            label8.TabIndex = 30;
            label8.Text = "Plan Name *";
            // 
            // newPlanName
            // 
            newPlanName.AutoCompleteMode = AutoCompleteMode.Suggest;
            newPlanName.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            newPlanName.Location = new Point(12, 84);
            newPlanName.Name = "newPlanName";
            newPlanName.Size = new Size(319, 22);
            newPlanName.TabIndex = 31;
            // 
            // loadPlanButton
            // 
            loadPlanButton.BackColor = SystemColors.ButtonShadow;
            loadPlanButton.FlatStyle = FlatStyle.Flat;
            loadPlanButton.Font = new Font("Tahoma", 9F, FontStyle.Bold);
            loadPlanButton.Location = new Point(12, 462);
            loadPlanButton.Name = "loadPlanButton";
            loadPlanButton.Size = new Size(117, 22);
            loadPlanButton.TabIndex = 32;
            loadPlanButton.Text = "LOAD PLAN";
            loadPlanButton.UseVisualStyleBackColor = false;
            loadPlanButton.Click += loadPlanButton_Click;
            // 
            // label9
            // 
            label9.Font = new Font("Tahoma", 11.2000008F);
            label9.Location = new Point(12, 401);
            label9.Name = "label9";
            label9.Size = new Size(95, 19);
            label9.TabIndex = 33;
            label9.Text = "Plan Name * ";
            // 
            // notFoundLabel
            // 
            notFoundLabel.AutoSize = true;
            notFoundLabel.Font = new Font("Tahoma", 10.2000008F);
            notFoundLabel.ForeColor = Color.Red;
            notFoundLabel.Location = new Point(398, 212);
            notFoundLabel.Name = "notFoundLabel";
            notFoundLabel.Size = new Size(238, 17);
            notFoundLabel.TabIndex = 34;
            notFoundLabel.Text = "Ingredient Not Found. Check Spelling.";
            notFoundLabel.Visible = false;
            // 
            // missingFieldsLabel
            // 
            missingFieldsLabel.AutoSize = true;
            missingFieldsLabel.Font = new Font("Tahoma", 10.2000008F);
            missingFieldsLabel.ForeColor = Color.Red;
            missingFieldsLabel.Location = new Point(140, 312);
            missingFieldsLabel.Name = "missingFieldsLabel";
            missingFieldsLabel.Size = new Size(191, 17);
            missingFieldsLabel.TabIndex = 45;
            missingFieldsLabel.Text = "* MISSING REQUIRED FIELDS";
            missingFieldsLabel.Visible = false;
            // 
            // missingFieldsLabel2
            // 
            missingFieldsLabel2.AutoSize = true;
            missingFieldsLabel2.Font = new Font("Tahoma", 10.2000008F);
            missingFieldsLabel2.ForeColor = Color.Red;
            missingFieldsLabel2.Location = new Point(355, 462);
            missingFieldsLabel2.Name = "missingFieldsLabel2";
            missingFieldsLabel2.Size = new Size(191, 17);
            missingFieldsLabel2.TabIndex = 46;
            missingFieldsLabel2.Text = "* MISSING REQUIRED FIELDS";
            missingFieldsLabel2.Visible = false;
            // 
            // ingredientCheckingBox
            // 
            ingredientCheckingBox.AutoSize = true;
            ingredientCheckingBox.Font = new Font("Tahoma", 11.2000008F);
            ingredientCheckingBox.ImageAlign = ContentAlignment.TopLeft;
            ingredientCheckingBox.Location = new Point(355, 83);
            ingredientCheckingBox.Name = "ingredientCheckingBox";
            ingredientCheckingBox.Size = new Size(214, 22);
            ingredientCheckingBox.TabIndex = 48;
            ingredientCheckingBox.Text = "Include Ingredient Checking?";
            ingredientCheckingBox.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            deleteButton.BackColor = SystemColors.ButtonShadow;
            deleteButton.FlatAppearance.MouseDownBackColor = Color.White;
            deleteButton.FlatStyle = FlatStyle.Flat;
            deleteButton.Font = new Font("Tahoma", 9F, FontStyle.Bold);
            deleteButton.Location = new Point(153, 462);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(178, 22);
            deleteButton.TabIndex = 49;
            deleteButton.Text = "CLICK TWICE TO DELETE";
            deleteButton.UseVisualStyleBackColor = false;
            deleteButton.Click += deleteButton_Click;
            // 
            // MealPlanSelectionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1017, 496);
            Controls.Add(deleteButton);
            Controls.Add(ingredientCheckingBox);
            Controls.Add(missingFieldsLabel2);
            Controls.Add(missingFieldsLabel);
            Controls.Add(notFoundLabel);
            Controls.Add(label9);
            Controls.Add(loadPlanButton);
            Controls.Add(newPlanName);
            Controls.Add(label8);
            Controls.Add(existingPlanBox);
            Controls.Add(label7);
            Controls.Add(includeCaloriesBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(dinnerEnterBtn);
            Controls.Add(lunchEnterBtn);
            Controls.Add(breakfastEnterBtn);
            Controls.Add(dinnerCheckedBox);
            Controls.Add(lunchCheckedBox);
            Controls.Add(breakfastCheckedBox);
            Controls.Add(ContinueBtn);
            Controls.Add(caloricIntakeBox);
            Controls.Add(caloricIntakeLabel);
            Controls.Add(fitnessButton);
            Controls.Add(label4);
            Controls.Add(dinnerTextBox);
            Controls.Add(lunchTextBox);
            Controls.Add(breakfastTextBox);
            Controls.Add(label1);
            Name = "MealPlanSelectionForm";
            Text = "MealPlanSelectionForm";
            Load += MealPlanSelectionForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox breakfastTextBox;
        private TextBox lunchTextBox;
        private TextBox dinnerTextBox;
        private Label label4;
        private Button fitnessButton;
        private Label caloricIntakeBox;
        private Button ContinueBtn;
        private CheckedListBox breakfastCheckedBox;
        private CheckedListBox lunchCheckedBox;
        private CheckedListBox dinnerCheckedBox;
        private Button breakfastEnterBtn;
        private Button lunchEnterBtn;
        private Button dinnerEnterBtn;
        private Label label5;
        private Label label6;
        private Label label2;
        private Label label3;
        private CheckedListBox previousPlanSelect;
        private Label caloricIntakeLabel;
        private CheckBox includeCaloriesBox;
        private Label label7;
        private ComboBox existingPlanBox;
        private Label label8;
        private TextBox newPlanName;
        private Button loadPlanButton;
        private Label label9;
        private Label notFoundLabel;
        private Label missingFieldsLabel;
        private Label missingFieldsLabel2;
        private CheckBox ingredientCheckingBox;
        private Button deleteButton;
    }
}