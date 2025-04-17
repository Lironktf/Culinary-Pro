namespace RecipeManager
{
    partial class LoginForm
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
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            userNameTextBox = new TextBox();
            passwordTextBox = new TextBox();
            enterBtn = new Button();
            label3 = new Label();
            signUpButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.login_image;
            pictureBox1.Location = new Point(84, 42);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(160, 149);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 206);
            label1.Name = "label1";
            label1.Size = new Size(91, 19);
            label1.TabIndex = 1;
            label1.Text = "USERNAME";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 281);
            label2.Name = "label2";
            label2.Size = new Size(94, 19);
            label2.TabIndex = 2;
            label2.Text = "PASSWORD";
            // 
            // userNameTextBox
            // 
            userNameTextBox.Location = new Point(12, 237);
            userNameTextBox.Name = "userNameTextBox";
            userNameTextBox.Size = new Size(320, 23);
            userNameTextBox.TabIndex = 3;
            userNameTextBox.TextChanged += userNameTextBox_TextChanged;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(12, 314);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(320, 23);
            passwordTextBox.TabIndex = 4;
            passwordTextBox.TextChanged += passwordTextBox_TextChanged;
            // 
            // enterBtn
            // 
            enterBtn.FlatStyle = FlatStyle.Flat;
            enterBtn.Font = new Font("Tahoma", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            enterBtn.Location = new Point(12, 366);
            enterBtn.Name = "enterBtn";
            enterBtn.Size = new Size(320, 32);
            enterBtn.TabIndex = 5;
            enterBtn.Text = "CONTINUE";
            enterBtn.UseVisualStyleBackColor = true;
            enterBtn.Click += enterBtn_Click;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Tahoma", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(344, 28);
            label3.TabIndex = 6;
            label3.Text = "LOGIN";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // signUpButton
            // 
            signUpButton.FlatStyle = FlatStyle.Flat;
            signUpButton.Font = new Font("Tahoma", 9F);
            signUpButton.ForeColor = SystemColors.MenuHighlight;
            signUpButton.Location = new Point(84, 414);
            signUpButton.Name = "signUpButton";
            signUpButton.Size = new Size(160, 24);
            signUpButton.TabIndex = 7;
            signUpButton.Text = "New? Sign Up";
            signUpButton.UseVisualStyleBackColor = true;
            signUpButton.Click += button1_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(344, 450);
            Controls.Add(signUpButton);
            Controls.Add(label3);
            Controls.Add(enterBtn);
            Controls.Add(passwordTextBox);
            Controls.Add(userNameTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "LoginForm";
            Text = "LoginForm";
            Load += LoginForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private TextBox userNameTextBox;
        private TextBox passwordTextBox;
        private Button enterBtn;
        private Label label3;
        private Button signUpButton;
    }
}