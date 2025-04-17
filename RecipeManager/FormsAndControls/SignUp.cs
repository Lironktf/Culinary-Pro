// Author: Liron Katsif
// File Name: SignUp.cs
// Project Name: RecipeManager
// Creation Date: Dec 8, 2024
// Modified Date: Jan 11, 2025
// Description: SignUp class represents a form for user registration.
//               It includes attributes for the user's username and password, and provides methods to handle user input,
//               validate password matching, and save the new user's information.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeManager
{
    public partial class SignUp : Form
    {
        // Attributes of the SignUp class
        string userName;
        string password;
        bool isMatch = false;
        UsersIO usersFileIO = new UsersIO();

        // Pre: None
        // Post: None.
        // Description: Constructor for the SignUp class that initializes the form and sets up password fields.
        public SignUp()
        {
            //init the form, and set the password boxes to display an astrix for safety
            InitializeComponent();
            passwordTextBox.PasswordChar = '*';
            passwordCheckBox.PasswordChar = '*';
            usersFileIO.LoadUsers();
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the text changed event for the username text box and updates the username attribute.
        private void userNameTextBox_TextChanged(object sender, EventArgs e)
        {
            //set the attribute userrname to the text from the textbox
            userName = userNameTextBox.Text;
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the text changed event for the password text box and updates the password attribute.
        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            //set the password attribute to the text from the textbox
            password = passwordTextBox.Text;
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the leave event for the password confirmation text box and checks if the passwords match.
        private void passwordCheckBox_Leave(object sender, EventArgs e)
        {
            //check if the passwords match between the two boxes
            if (password != passwordCheckBox.Text && passwordCheckBox.Text != "")
            {
                //set the isMatch to false, and show a messegebox that the passwords don't match
                isMatch = false;
                MessageBox.Show("The passwords don't match!");
            }
            else
            {
                //set the is match boolean to true, to indicate that they match
                isMatch = true;
            }
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the click event for the continue button, validates the passwords, creates a new user, and navigates to the main menu form.
        private void continueBtn_Click(object sender, EventArgs e)
        {
            //check if the isMatch bool is true, meaning that the passwords match between the two boxes. Also check if the username doesn't exists already
            if (isMatch && !usersFileIO.GetUserDict().ContainsKey(userName))
            {
                //create a new user and save it
                User newUser = new User(userName, password);
                usersFileIO.SaveUser(newUser);

                //create the next form and show it
                MainMenuForm nextForm = new MainMenuForm(newUser);
                this.Hide();
                nextForm.Show();
            }
            else
            {
                //show error message
                MessageBox.Show("The passwords don't match or user already exists...");
            }
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the click event for the back button and navigates back to the login form.
        private void backImageButton_Click(object sender, EventArgs e)
        {
            //go back to the Login form
            LoginForm nextForm = new LoginForm();
            this.Hide();
            nextForm.Show();
        }
    }
}
