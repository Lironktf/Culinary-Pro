// Author: Liron Katsif
// File Name: LoginForm.cs
// Project Name: RecipeManager
// Creation Date: Dec 11, 2024
// Modified Date: Jan 11, 2025
// Description: Represents a login form for the RecipeManager application.
//              It includes attributes for the user's userName and password, and provides methods to handle user input, verify user credentials, and navigate to other forms based on the login status.

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
    public partial class LoginForm : Form
    {
        // Attributes of the LoginForm class
        private string userName;
        private string password;
        private UsersIO usersFileIO = new UsersIO();

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Constructor for the LoginForm class that initializes the form components and sets the password character.
        public LoginForm()
        {
            //initialize the form, and set the text displayed to an astrix, for security
            InitializeComponent();            
            passwordTextBox.PasswordChar = '*';
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the Load event of the LoginForm to initialize the users' dictionary.
        private void LoginForm_Load(object sender, EventArgs e)
        {
            //load users
            usersFileIO.LoadUsers();
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the TextChanged event of the userName to update the userName attribute.
        private void userNameTextBox_TextChanged(object sender, EventArgs e)
        {
            //set userName from the textbox
            userName = userNameTextBox.Text;
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the TextChanged event of the passwordTextBox to update the password attribute.
        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            //set the password from the textbox
            password = passwordTextBox.Text;
        }

        // Pre: None
        // Post: Returns true if the userName and password are not empty and match an entry in the users' dictionary, otherwise false.
        // Description: Verifies if the user credentials are valid by checking the userName and password against the users' dictionary
        private bool VerifyUser()
        {
            //loads the users
            Dictionary<string, string> usersDict = usersFileIO.GetUserDict();

            //check that no fields are missing, and the userNames and passwords are contained previously
            return (!String.IsNullOrEmpty(userNameTextBox.Text) && !String.IsNullOrEmpty(passwordTextBox.Text)) && (usersDict.ContainsKey(userName) && usersDict.ContainsValue(password));
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the Click event of the enterBtn to verify the user and navigate to the MainMenuForm or show an error message.
        private void enterBtn_Click(object sender, EventArgs e)
        {
            //check if user exists
            if (VerifyUser())
            {
                //set next form with current user, hide current form, and show next
                MainMenuForm nextForm = new MainMenuForm(new User(userName, password));
                this.Hide();
                nextForm.Show();
            }
            else
            {
                //error box
                MessageBox.Show("User not found. Try again or sign up! ");
            }
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the Click event of the sign up form to navigate to the SignUp form.
        private void button1_Click(object sender, EventArgs e)
        {
            //init and show sign up form
            SignUp nextForm = new SignUp();
            this.Hide();
            nextForm.Show();
        }
    }
}
