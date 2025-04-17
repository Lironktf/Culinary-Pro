namespace RecipeManager
{
    partial class FitnessGoalsForm
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
            label2 = new Label();
            heightBox = new NumericUpDown();
            label3 = new Label();
            weightBox = new NumericUpDown();
            calculateButton = new Button();
            label4 = new Label();
            genderBox = new ComboBox();
            label5 = new Label();
            ageBox = new NumericUpDown();
            label6 = new Label();
            activityLevelBox = new ComboBox();
            label7 = new Label();
            missingFieldsLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)heightBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)weightBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ageBox).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.Font = new Font("Tahoma", 13.2000008F, FontStyle.Bold);
            label2.Location = new Point(12, 196);
            label2.Name = "label2";
            label2.Size = new Size(325, 56);
            label2.TabIndex = 2;
            label2.Text = "Current Height (centimeters) *";
            // 
            // heightBox
            // 
            heightBox.DecimalPlaces = 2;
            heightBox.Font = new Font("Tahoma", 11F);
            heightBox.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            heightBox.Location = new Point(12, 227);
            heightBox.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            heightBox.Name = "heightBox";
            heightBox.Size = new Size(325, 25);
            heightBox.TabIndex = 3;
            // 
            // label3
            // 
            label3.Font = new Font("Tahoma", 13.2000008F, FontStyle.Bold);
            label3.Location = new Point(12, 122);
            label3.Name = "label3";
            label3.Size = new Size(375, 28);
            label3.TabIndex = 4;
            label3.Text = "Current Weight (kg's) *";
            // 
            // weightBox
            // 
            weightBox.DecimalPlaces = 2;
            weightBox.Font = new Font("Tahoma", 11F);
            weightBox.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            weightBox.Location = new Point(12, 151);
            weightBox.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            weightBox.Name = "weightBox";
            weightBox.Size = new Size(325, 25);
            weightBox.TabIndex = 5;
            // 
            // calculateButton
            // 
            calculateButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            calculateButton.FlatStyle = FlatStyle.Flat;
            calculateButton.Font = new Font("Tahoma", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            calculateButton.Location = new Point(12, 433);
            calculateButton.Name = "calculateButton";
            calculateButton.Size = new Size(669, 52);
            calculateButton.TabIndex = 6;
            calculateButton.Text = "CLICK TO CALCULATE DAILY CALORIC INTAKE\r\n";
            calculateButton.UseVisualStyleBackColor = true;
            calculateButton.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 13.2000008F, FontStyle.Bold);
            label4.Location = new Point(12, 54);
            label4.Name = "label4";
            label4.Size = new Size(92, 22);
            label4.TabIndex = 7;
            label4.Text = "Gender *";
            // 
            // genderBox
            // 
            genderBox.DropDownStyle = ComboBoxStyle.DropDownList;
            genderBox.FlatStyle = FlatStyle.Flat;
            genderBox.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            genderBox.FormattingEnabled = true;
            genderBox.Items.AddRange(new object[] { "Male", "Female" });
            genderBox.Location = new Point(12, 79);
            genderBox.Name = "genderBox";
            genderBox.Size = new Size(325, 22);
            genderBox.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tahoma", 13.2000008F, FontStyle.Bold);
            label5.Location = new Point(370, 54);
            label5.Name = "label5";
            label5.Size = new Size(60, 22);
            label5.TabIndex = 9;
            label5.Text = "Age *";
            // 
            // ageBox
            // 
            ageBox.DecimalPlaces = 1;
            ageBox.Font = new Font("Tahoma", 11F);
            ageBox.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            ageBox.Location = new Point(370, 79);
            ageBox.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            ageBox.Name = "ageBox";
            ageBox.Size = new Size(292, 25);
            ageBox.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Tahoma", 13.2000008F, FontStyle.Bold);
            label6.Location = new Point(370, 122);
            label6.Name = "label6";
            label6.Size = new Size(149, 22);
            label6.TabIndex = 11;
            label6.Text = "Activity Level * ";
            // 
            // activityLevelBox
            // 
            activityLevelBox.DropDownStyle = ComboBoxStyle.DropDownList;
            activityLevelBox.FlatStyle = FlatStyle.Flat;
            activityLevelBox.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            activityLevelBox.FormattingEnabled = true;
            activityLevelBox.Items.AddRange(new object[] { "Sedentary (little to no activity)", "Lightly active (light exercise/sports 1-3 days/week)", "Moderatly active (moderate exercise/sports 3-5 days/week)  ", "Very active (hard exercise/sports 6-7 days/week)  ", "Extra active (very hard exercise/sports & a physical job)", "Mr. Lane level (professional athlete)" });
            activityLevelBox.Location = new Point(370, 151);
            activityLevelBox.Name = "activityLevelBox";
            activityLevelBox.Size = new Size(292, 22);
            activityLevelBox.TabIndex = 12;
            // 
            // label7
            // 
            label7.Dock = DockStyle.Top;
            label7.Font = new Font("Tahoma", 22.2F, FontStyle.Bold);
            label7.Location = new Point(0, 0);
            label7.Name = "label7";
            label7.Size = new Size(693, 39);
            label7.TabIndex = 13;
            label7.Text = "DAILY CALORIE CALCULATOR";
            label7.TextAlign = ContentAlignment.TopCenter;
            // 
            // missingFieldsLabel
            // 
            missingFieldsLabel.AutoSize = true;
            missingFieldsLabel.Font = new Font("Tahoma", 10.2000008F);
            missingFieldsLabel.ForeColor = Color.Red;
            missingFieldsLabel.Location = new Point(257, 413);
            missingFieldsLabel.Name = "missingFieldsLabel";
            missingFieldsLabel.Size = new Size(191, 17);
            missingFieldsLabel.TabIndex = 46;
            missingFieldsLabel.Text = "* MISSING REQUIRED FIELDS";
            missingFieldsLabel.Visible = false;
            // 
            // FitnessGoalsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(693, 497);
            Controls.Add(missingFieldsLabel);
            Controls.Add(label7);
            Controls.Add(activityLevelBox);
            Controls.Add(label6);
            Controls.Add(ageBox);
            Controls.Add(label5);
            Controls.Add(genderBox);
            Controls.Add(label4);
            Controls.Add(calculateButton);
            Controls.Add(weightBox);
            Controls.Add(label3);
            Controls.Add(heightBox);
            Controls.Add(label2);
            Name = "FitnessGoalsForm";
            Text = "FitnessGoalsForm";
            ((System.ComponentModel.ISupportInitialize)heightBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)weightBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)ageBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private NumericUpDown heightBox;
        private Label label3;
        private NumericUpDown weightBox;
        private Button calculateButton;
        private Label label4;
        private ComboBox genderBox;
        private Label label5;
        private NumericUpDown ageBox;
        private Label label6;
        private ComboBox activityLevelBox;
        private Label label7;
        private Label missingFieldsLabel;
    }
}