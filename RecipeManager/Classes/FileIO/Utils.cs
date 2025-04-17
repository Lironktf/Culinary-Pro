// Author: Liron Katsif
// File Name: Utils.cs
// Project Name: RecipeManager
// Creation Date: Dec 13, 2024
// Modified Date: Jan 10, 2025
// Description: Utils class handles various utility operations related to file input and output.
//              It includes methods to construct file paths, read and write file content, build attribute strings, and add items to files.
//              The class utilizes various helper methods to manage file directories, handle exceptions, and format data for storage and retrieval.

using System.Text;

namespace RecipeManager
{
    public static class Utils
    {
        //directory constants
        private const string IO_DIRECTORY = "io";
        public const string MEALS_FILE_NAME = "Meals.txt";
        public const string RECIPES_FILE_NAME = "Recipes.txt";
        public const string USERS_FILE_NAME = "AllUsers.txt";

        //file reading/writing constants
        public const string ATTRIBUTES_SEPARATOR = ",,,";
        public const string ITEMS_SEPARATOR = ";;;";
        public const string ATTRIBUTES_AND_ITEM_SEPARATOR = ",,,;;;";
        public const int ATTRIBUTES_AND_ITEM_SEPARATOR_LENGTH = 6; //lenght of ATTRIBUTES_AND_ITEM_SEPARATOR;

        // Pre: currentUser - The current user whose file path is to be retrieved. 
        //       fileName - The name of the file.
        // Post: Returns the file path as a string. If the path does not exist, the method creates the necessary directory and file.
        // Description: Constructs and returns the file path for the given user and file name. 
        //              If the path does not exist, the method creates the necessary directory and fil
        public static string GetFilePath(User? currentUser, string fileName)
        {
            //get the folder name andfilepatch for the current user
            string folderName = GetFileDirectory(currentUser);           
            string filePath = Path.Combine(folderName, fileName);

            try
            {
                //read all text from user folder
                string fileReadText = File.ReadAllText(filePath);
            }
            catch
            {
                //if fails, it means that no such file exists. Create a new file path for this user
                File.Create(filePath);
            }

            //return the file path found
            return filePath;
        }

        // Pre: currentUser - The current user whose file directory is to be retrieved. If null, a general directory is used.
        // Post: Returns the file directory path as a string. If the directory does not exist, it is created.
        // Description: Constructs and returns the directory path for the given user. 
        //              If the user is provided, the directory will include the user's name. 
        //              If the directory does not exist, it is created.
        public static string GetFileDirectory(User? currentUser)
        {
            //blank username string to be populated
            string userName = "";

            //if the current user passed exists (isn't null)
            if (currentUser != null)
            {
                //if currentUser is provided, file path will include userName on it. set the blank string to this username of user
                userName = currentUser.GetUserName();
            }            

            //file location (folder) is ../io is no currentUser is provided, and ../io/currentUser.GetUserName() otherwise
            string innerFolderName = Path.Combine(IO_DIRECTORY, userName);
            string folderName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, innerFolderName);

            //if the directory doesn't exist, create it
            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }

            //return the folder name found
            return folderName;
        }

        // Pre: currentUser - The current user whose file content is to be retrieved.
        //       fileName - The name of the file.
        // Post: Returns the content of the file as a string.
        // Description: Reads and returns the content of the specified file for the given user.
        public static string GetFileContent(User currentUser, string fileName)
        {            
            //get the file directory of the current user
            string folderName = GetFileDirectory(currentUser);

            //get the file path 
            string filePath = Path.Combine(folderName, fileName);

            //init empty string to populate
            string fileContents;
            try
            {
                //try to read the file contents
                fileContents = File.ReadAllText(filePath);
            }
            catch
            {
                //if fails, write in the file path a blank string, creating the file, and set the file contents to empty, as it didn't exist
                File.WriteAllText(filePath, "");
                fileContents = "";
            }

            //return the file contents
            return fileContents;
        }

        // Pre: attributes - An array of objects representing the attributes.
        // Post: Returns a string representing the concatenated attributes.
        // Description: Concatenates the attributes into a single string separated by the attributes separator.
        public static string BuildAttributes(Object[] attributes)
        {
            string result = "";

            //iterate through the attributes, and add them to the string with a seperator
            for (int i = 0; i < attributes.Length; i++)
            {
                result = result + attributes[i] + ATTRIBUTES_SEPARATOR;
            }

            //return the string built
            return result;
        }

        // Pre: sb - The StringBuilder to which the item will be added.
        //      item - The item to be added.
        // Post: None.
        // Description: Appends the specified item to the StringBuilder followed by the item separator.
        public static void AddItem(StringBuilder sb, string item)
        {
            //add to the passed string builder the item, and seperate it
            sb.Append(item + ITEMS_SEPARATOR);
        }

        // Pre: sb - The StringBuilder to which the attribute item will be added.
        //      attribute - The attribute to be added.
        // Post: None.
        // Description: Builds an attribute item from the specified attribute and appends it to the StringBuilder followed by the item separator.
        public static void AddOneAttributeItem(StringBuilder sb, string attribute)
        {
            //build the attribute and append it to sb with a seperator
            string item = BuildAttributes([attribute]);
            sb.Append(item + ITEMS_SEPARATOR);
        }

        // Pre: line - The string from which the prefix and suffix will be removed.
        //      prefixLength - The length of the prefix to be removed.
        //      sufixLength - The length of the suffix to be removed.
        // Post: Returns the string with the specified prefix and suffix removed.
        // Description: Removes the specified prefix and suffix from the given string and returns the result.
        public static string RemovePrefixAndSufix(string line, int? prefixLength, int? sufixLength)
        {
            //store the passed string to remove the prefix/suffix from
            string result = line;

            //check if the prefix length passed isn't empty
            if (prefixLength != null)
            {
                //update the result string with a substring without the prefix
                result = result.Substring((int)prefixLength);
            }

            //check if the suffix length passed isn't empty
            if (sufixLength != null)
            {
                //update the result string with a substring without the suffix
                result = result.Substring(0, result.Length - (int)sufixLength);
            }

            //return the string without any seperators
            return result;
        }

        // Pre: sb - The StringBuilder containing the data to be written.
        //      currentUser - The current user whose file will be written to.
        //      fileName - The name of the file to write to.
        //      dataSaved - The description of the data being saved.
        // Post: None. 
        // Description: Writes the data from the StringBuilder to the specified file for the current user.
        public static void WriteToFile(StringBuilder sb, User currentUser, string fileName, string dataSaved)
        {
            try
            {
                //try getting the file path, and write the constructed stringto the file
                string? filePath = GetFilePath(currentUser, fileName); 
                File.WriteAllText(filePath, sb.ToString());              
            }
            catch (FileNotFoundException fnfEx)  
            {
                MessageBox.Show($"File not found: {fnfEx.Message}");
            }
            catch (Exception ex)  
            {
                MessageBox.Show($"Unexpected error: {ex.Message}");
            }
        }
    }
}
