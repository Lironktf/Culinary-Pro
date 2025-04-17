// Author: Liron Katsif
// File Name: UsersIO.cs
// Project Name: RecipeManager
// Creation Date: Dec 11, 2024
// Modified Date: Jan 10, 2025
// Description: UsersIO class handles the input and output operations related to user data.
//              It includes methods to save and load users, retrieve the dictionary of users, and construct file content for users.
//              The class utilizes various helper methods to build and parse strings representing user username and password pairs.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supabase;

namespace RecipeManager
{
    public class UsersIO
    {
        // Attributes of the UsersIO class
        private Dictionary<string, string> userDict;

        // Pre: None
        // Post: None
        // Description: Constructor for the UsersIO class that initializes the userDict attribute as an empty dictionary to store user username and password pairs.
        public UsersIO()
        {
            //init a new dictionary
            userDict = new Dictionary<string, string>();
        }

        // Pre: None
        // Post: Returns the dictionary of users.
        // Description: Retrieves the dictionary containing user username and password pairs.
        public Dictionary<string, string> GetUserDict()
        {
            return userDict;
        }

        // Pre: newUser - The new user to be saved.
        // Post: None
        // Description: Constructs a string representing the new user and appends it to the user file.
        //              There is one file called AllUsers, that holds all users, each user is represented by one like, in format:
        //              userName + Utils.ATTRIBUTES_SEPARATOR + password + Utils.ITEMS_SEPARATOR (for example: john_black,,,12345Blue;;;)
        public void SaveUser(User newUser)
        {
            StringBuilder sb = new StringBuilder();

            //create user line - user name and password
            string userAttributes = Utils.BuildAttributes([newUser.GetUserName(), newUser.GetPassword()]);
            Utils.AddItem(sb, userAttributes);

            //save the line to AllUsers.txt file
            AddUserToFile(sb, newUser);
        }

        // Pre: sb - The StringBuilder to which the user data will be added.
        //      currentUser - The current user whose data will be added to the file.
        // Post: None
        // Description: Appends the current user's data to the user file.
        private static void AddUserToFile(StringBuilder sb, User currentUser)
        {
            try
            {
                //AllUsers.txt file path: ../io
                string filePath = Utils.GetFilePath(null, Utils.USERS_FILE_NAME);

                // Write the constructed string to the file. 
                File.AppendAllText(filePath, sb.ToString());   
                File.AppendAllText(filePath, Environment.NewLine);

            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Unexpected error: {ex.Message}");
            }
        }

        // Pre: None
        // Post: Returns a dictionary of users loaded from the file.
        // Description: Reads the user file, parses its content, and constructs a dictionary of users.
        public Dictionary<string, string> LoadUsers()
        {
            //load AllUsers.txt file content, located under ../io directory
            string fileContent = Utils.GetFileContent(null, Utils.USERS_FILE_NAME);    
            
            // Split content into lines
            string[] usersLines = fileContent.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            //for each user line
            for (int i = 0; i < usersLines.Length; i++)
            {
                //store current user line in string, and check that it isn't empty
                string userLine = usersLines[i];
                if (userLine != "")
                {
                    //split the line into attributes (userName and password)
                    string[] attributes = userLine.Split(Utils.ATTRIBUTES_SEPARATOR);

                    //add user data (userName as the key and paswword as the value) to userDict dictionary
                    userDict.Add(attributes[0], attributes[1]);
                }
            }

            //return the dictionary of users
            return userDict;
        }
    }
}
