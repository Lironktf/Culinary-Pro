namespace RecipeManager
{
    partial class SignUp
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
            loginPictureBox = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            userNameTextBox = new TextBox();
            passwordTextBox = new TextBox();
            passwordCheckBox = new TextBox();
            continueBtn = new Button();
            backImageButton = new Button();
            ((System.ComponentModel.ISupportInitialize)loginPictureBox).BeginInit();
            SuspendLayout();
            // 
            // loginPictureBox
            // 
            loginPictureBox.ErrorImage = null;
            loginPictureBox.Image = Properties.Resources.signUp3;
            loginPictureBox.Location = new Point(88, 41);
            loginPictureBox.Name = "loginPictureBox";
            loginPictureBox.Size = new Size(162, 99);
            loginPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            loginPictureBox.TabIndex = 0;
            loginPictureBox.TabStop = false;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Tahoma", 18F, FontStyle.Bold);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(344, 28);
            label1.TabIndex = 1;
            label1.Text = "SIGN UP";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 12F);
            label2.Location = new Point(12, 160);
            label2.Name = "label2";
            label2.Size = new Size(91, 19);
            label2.TabIndex = 2;
            label2.Text = "USERNAME";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 12F);
            label3.Location = new Point(12, 233);
            label3.Name = "label3";
            label3.Size = new Size(94, 19);
            label3.TabIndex = 3;
            label3.Text = "PASSWORD";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 12F);
            label4.Location = new Point(12, 305);
            label4.Name = "label4";
            label4.Size = new Size(173, 19);
            label4.TabIndex = 4;
            label4.Text = "RE-ENTER PASSWORD";
            // 
            // userNameTextBox
            // 
            userNameTextBox.Font = new Font("Tahoma", 10F);
            userNameTextBox.Location = new Point(12, 192);
            userNameTextBox.Name = "userNameTextBox";
            userNameTextBox.Size = new Size(320, 24);
            userNameTextBox.TabIndex = 5;
            userNameTextBox.TextChanged += userNameTextBox_TextChanged;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Font = new Font("Tahoma", 10F);
            passwordTextBox.Location = new Point(12, 266);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(320, 24);
            passwordTextBox.TabIndex = 6;
            passwordTextBox.TextChanged += passwordTextBox_TextChanged;
            // 
            // passwordCheckBox
            // 
            passwordCheckBox.Font = new Font("Tahoma", 10F);
            passwordCheckBox.Location = new Point(12, 339);
            passwordCheckBox.Name = "passwordCheckBox";
            passwordCheckBox.Size = new Size(320, 24);
            passwordCheckBox.TabIndex = 7;
            passwordCheckBox.Leave += passwordCheckBox_Leave;
            // 
            // continueBtn
            // 
            continueBtn.FlatStyle = FlatStyle.Flat;
            continueBtn.Font = new Font("Tahoma", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            continueBtn.Location = new Point(12, 392);
            continueBtn.Name = "continueBtn";
            continueBtn.Size = new Size(320, 46);
            continueBtn.TabIndex = 8;
            continueBtn.Text = "CONTINUE";
            continueBtn.UseVisualStyleBackColor = true;
            continueBtn.Click += continueBtn_Click;
            // 
            // backImageButton
            // 
            backImageButton.BackColor = SystemColors.Control;
            backImageButton.BackgroundImage = Properties.Resources.Back_Button_Transparent;
            backImageButton.BackgroundImageLayout = ImageLayout.Zoom;
            backImageButton.FlatStyle = FlatStyle.Flat;
            backImageButton.Font = new Font("Tahoma", 12F);
            backImageButton.Location = new Point(0, 0);
            backImageButton.Name = "backImageButton";
            backImageButton.Size = new Size(37, 27);
            backImageButton.TabIndex = 9;
            backImageButton.UseVisualStyleBackColor = false;
            backImageButton.Click += backImageButton_Click;
            // 
            // SignUp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(344, 450);
            Controls.Add(backImageButton);
            Controls.Add(continueBtn);
            Controls.Add(passwordCheckBox);
            Controls.Add(passwordTextBox);
            Controls.Add(userNameTextBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(loginPictureBox);
            Name = "SignUp";
            Text = "SignUp";
            ((System.ComponentModel.ISupportInitialize)loginPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox loginPictureBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox userNameTextBox;
        private TextBox passwordTextBox;
        private TextBox passwordCheckBox;
        private Button continueBtn;
        private Button backImageButton;
    }
}