// Author: Liron Katsif
// File Name: RecipesIO.cs
// Project Name: RecipeManager
// Creation Date: Dec 11, 2024
// Modified Date: Jan 12, 2025
// Description: RecipesIO class handles the input and output operations related to recipes.
//              It includes methods to save and load user recipes, build file content for recipes, and parse file content to reconstruct recipes.
//              The class utilizes various helper methods to build and parse lines representing saved recipes and their attributes.

using System;
using System.Text;

namespace RecipeManager
{
    public class RecipesIO
    {
        //prefixes used to define recipes.txt structure
        private const string LIST_LINE_PREFIX = "_list_name:";
        private const string MANUAL_RECIPE_PREFIX = "_M:";
        private const string SPOON_RECIPE_PREFIX = "_S:";

        //helpers to remove prefix from lines.  
        private const int RECIPE_LINE_PREFIX_LENGTH = 3;
        private const int LIST_LINE_PREFIX_LENGTH = 11;  

        // Pre: None
        // Post: None.
        // Description: Constructor for the RecipesIO class that sets up constants and prepares the class for handling input and output operations related to recipes.
        public RecipesIO()
        {

        }

        // Pre: currentUser - The current user whose recipes list is to be saved.
        // Post: None.
        // Description: Iterates through the user's saved recipes list, builds the file content, and writes it to a file.
        public void SaveUserRecipesLists(User currentUser)
        {
            //get recipes list and init a string buldent to construct file content
            List<SavedRecipes> recipesList = currentUser.GetSavedRecipesList();
            StringBuilder sb = new StringBuilder();

            //iterate through recipes lists
            for (int i = 0; i < recipesList.Count; i++)
            {
                //store current list
                SavedRecipes currentList = recipesList[i];

                //check that not first saved list, as for first saved no need to go down
                if (i > 0) 
                {
                    sb.AppendLine();
                }

                //add current list to the string buffer
                SaveRecipesList(sb, currentList);
            }

            //recipes lists are saved in Recipes.txt file, located under io/currentUser.GetUserName() directory
            Utils.WriteToFile(sb, currentUser, Utils.RECIPES_FILE_NAME, "Selected Recipes");
        }

        // Pre: sb - The StringBuilder to which the recipes list is to be added.
        //      savedRecipes - The SavedRecipes object containing the list of recipes to be saved.
        // Post: None.
        // Description: Iterates through the saved recipes list, builds the file content, and appends it to the StringBuilder.
        // Example of a SavedRecipes object translated to string: 
        //     _list_name:Thanksgiving dinner,,,;;;
        //     _S:1095808,,,;;;
        //     _M:My chicken,,,;;;
        //     Add to ball,,,;;;Mix everything,,,;;;
        //     Chicken,,,;;;Egg,,,;;;
        //     _S:7395767,,,;;;
        // It represents a list called "Thanksgiving dinner" that has 3 saved recipes on it:
        // Two spoon recipes
        // One manual recipe called "My chicken" with its instructions ("Add to ball" and "Mix everything") and ingredients ("Chicken", "Eg")
        public void SaveRecipesList(StringBuilder sb, SavedRecipes savedRecipes)
        {
            //append list prefix to specify that next lines (until next line with this prefix) are representing a saved list
            sb.Append(LIST_LINE_PREFIX);

            //add list name, to form line that will looks like: _list_name:Thanksgiving dinner,,,;;;
            Utils.AddOneAttributeItem(sb, savedRecipes.GetListName());

            //iterate through saved lists
            for (int j = 0; j < savedRecipes.GetRecipesList().Count; j++)
            {
                //store current recipe
                Recipe currentRecipe = savedRecipes.GetRecipesList()[j];

                //for each recipe on the list, adds its details to the string buffer
                BuildRecipeLine(sb, currentRecipe);
            }
        }

        // Pre: sb - The StringBuilder to which the recipe line is to be added.
        //      recipe - The recipe whose details are to be added.
        // Post: None.
        // Description: Builds a line representing the recipe and appends it to the StringBuilder.
        public void BuildRecipeLine(StringBuilder sb, Recipe recipe)
        {
            //add a blank line
            sb.AppendLine(); 

            //check the type of recipe
            if (recipe.GetType() == typeof(ManualRecipe))
            {
                //for manual recipe, its name, list of instructions and ingredients should be saved
                BuildManualRecipeItem(sb, (ManualRecipe) recipe);
            }
            else
            {
                //build the spoonacular recipe line
                string recipeItem = BuildSpoonRecipeItem((SpoonRecipe) recipe);   
                
                //for spoon recipe - only its remote id is saved and all the data is extracted via api call when required for presentation
                Utils.AddOneAttributeItem(sb, recipeItem);
            }            
        }

        // Pre: recipe - The SpoonRecipe object whose details are to be converted to a string.
        // Post: Returns a string representing the SpoonRecipe object.
        // Description: Converts the SpoonRecipe object to a string with a specific prefix.
        public string BuildSpoonRecipeItem(SpoonRecipe recipe)
        {
            //for spoon recipe, only one line is added in following format: _S:1095808,,,;;;
            string prefix = SPOON_RECIPE_PREFIX;
            string data = Convert.ToString(recipe.Id);
            return prefix + data;
        }

        // Pre: sb - The StringBuilder to which the manual recipe item is to be added.
        //      recipe - The ManualRecipe object whose details are to be added.
        // Post: Adds the manual recipe item to the StringBuilder.
        // Description: Builds a string representing the manual recipe and appends it to the StringBuilder.
        private string BuildManualRecipeItem(StringBuilder sb, ManualRecipe recipe)
        {
            //for manual recipe, three lines are added: 1. recipe type and name, 2. intructions, 3. ingredients 
            //add first line, in following format: _M:My chicken,,,;;;
            Utils.AddOneAttributeItem(sb, MANUAL_RECIPE_PREFIX + recipe.Title);

            //add instructions line, in following format: Add to ball,,,;;;Mix everything,,,;;;
            BuildListLine(sb, recipe.GetInstructions());

            //add ingredients line, in following format: Chicken,,,;;;Egg,,,;;;
            BuildListLine(sb, recipe.GetIngredients());

            //return the new string
            return sb.ToString();
        }

        // Pre: sb - The StringBuilder to which the list line is to be added.
        //      list - The list of strings to be added.
        // Post: None.
        // Description: Builds lines representing the list and appends them to the StringBuilder.
        private void BuildListLine(StringBuilder sb, List<string> list)
        {
            //add a blank line
            sb.AppendLine();

            //check that lists aren't empty
            if (list.Count != 0)
            {
                //iterate through the passed list
                for (int i = 0; i < list.Count; i++)
                {
                    //store the current item
                    string item = list[i];

                    //for each item in the list, add it to the buffer, followed by ATTRIBUTES_SEPARATOR. At the end of the line, append ITEMS_SEPARATOR 
                    Utils.AddOneAttributeItem(sb, item);
                }
            }
        }

        // Pre: currentUser - The current user whose saved recipes are to be loaded.
        // Post: Returns a list of saved recipes for the user.
        // Description: Loads the user's saved recipes from a file and returns them as a list.
        public List<SavedRecipes> LoadUserSavedRecipes(User currentUser)
        {
            //new list of recipes list to be populated
            List<SavedRecipes> recipesList = new List<SavedRecipes>();
            try
            {
                //load data from Recipes.txt file - each user has its own recipes file, located under io/currentUser.GetUserName() directory
                string fileContent = Utils.GetFileContent(currentUser, Utils.RECIPES_FILE_NAME);

                //checks if the file content isn't empty
                if (fileContent != "")
                {
                    // Split content into lines
                    string[] newFileContent = fileContent.Split(new[] { Environment.NewLine }, StringSplitOptions.None); 
                    SavedRecipes? currentSavedRecipes = null;

                    //iterate through the file's contents by line
                    for (int i = 0; i < newFileContent.Length; i++)
                    {
                        //store the current line
                        string line = newFileContent[i];

                        // checks if starts with LIST_LINE_PREFIX
                        if (line.StartsWith(LIST_LINE_PREFIX)) 
                        {
                            // create new SavedRecipes object with the saved name
                            currentSavedRecipes = LoadListLine(recipesList, line);                            
                        }
                        else if (currentSavedRecipes == null)
                        {
                            //if recipe is not under list, we cannot parse the file 
                            MessageBox.Show($"Corrupted recipes file, recipe must be under list"); 
                        }
                        else 
                        {
                            //if not list line, it is recipe, create Recipe object
                            Recipe recipe = LoadRecipeLine(currentSavedRecipes, line);

                            //if manual recipe, load also two next lines into the recipe - one is instructions line and the one after is ingredients line
                            if (recipe.GetType() == typeof(ManualRecipe)) 
                            {
                                string instructionsStr = newFileContent[++i]; //advance i counter, so that for loop will skip it
                                string ingredientsStr = newFileContent[++i]; 

                                //load instruction and ingredients lines into the recipe object 
                                AddInstructionsAndIngredients((ManualRecipe) recipe, instructionsStr, ingredientsStr);
                            }
                        }
                    }
                }
            }
            catch (FileNotFoundException fnfEx)
            {
                MessageBox.Show($"File not found: {fnfEx.Message}");
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Unexpected error: {ex.Message}");
            }

            //return the loaded recipes list
            return recipesList;
        }

        // Pre: recipesList - The list of SavedRecipes objects to which the new list is to be added.
        //      line - The line representing the list name.
        // Post: Adds a new SavedRecipes object to the list.
        // Description: Parses the line to extract the list name and creates a new SavedRecipes object.
        private SavedRecipes LoadListLine(List<SavedRecipes> recipesList, string line)
        {
            //extract list name from the recived line, which is in following format: _list_name:Thanksgiving dinner,,,;;;           
            string listName = Utils.RemovePrefixAndSufix(line, LIST_LINE_PREFIX_LENGTH, Utils.ATTRIBUTES_AND_ITEM_SEPARATOR_LENGTH);

            //create new SavedRecipes object, and add it to the list passed
            SavedRecipes savedRecipes = new SavedRecipes(listName);
            recipesList.Add(savedRecipes);

            //return the created list
            return savedRecipes;
        }

        // Pre: currentSavedRecipes - The SavedRecipes object to which the recipe is to be added.
        //      line - The line representing the recipe.
        // Post: Adds a new Recipe object to the SavedRecipes object.
        // Description: Parses the line to extract the recipe details and creates a new Recipe object. The line can be in two formats, depends on recipe type (spoon or manual):
        //      _S:1095808,,,;;;
        //      _M:My chicken,,,;;;
        private Recipe LoadRecipeLine(SavedRecipes currentSavedRecipes, string line)
        {
            //remove separators (,,,;;;) and create Recipe object based on line
            string noSeparatorsLine = Utils.RemovePrefixAndSufix(line, null, Utils.ATTRIBUTES_AND_ITEM_SEPARATOR_LENGTH); 
            Recipe recipe = LoadRecipe(noSeparatorsLine);

            //add recipe to the list 
            currentSavedRecipes.GetRecipesList().Add(recipe);

            //return the created recipe
            return recipe;
        }

        // Pre: line - The string representing the recipe.
        // Post: Returns a Recipe object constructed from the provided string.
        // Description: Parses the string to extract the recipe details and creates a new Recipe object.
        public Recipe LoadRecipe(string line)
        {
            //remove file io seperators from the line passed
            string recipeData = Utils.RemovePrefixAndSufix(line, RECIPE_LINE_PREFIX_LENGTH, null);

            Recipe recipe;

            //check if manual recipes, which are in following format: _M:My chicken,,,;;; (recipe type prefix followed by recipe name)
            if (line.StartsWith(MANUAL_RECIPE_PREFIX))
            {
                //create ManualRecipe object for the recipe
                recipe = new ManualRecipe(recipeData);
            }
            else
            {
                //spoon recipe is in following format: _S:1095808,,,;;; (recipe type prefix followed by spoon recipe id)
                //create SpoonRecipe object for the recipe
                recipe = new SpoonRecipe(Convert.ToInt32(recipeData));
            }

            //return the loaded recipe
            return recipe;
        }

        // Pre: recipe - The ManualRecipe object to which the instructions and ingredients are to be added.
        //      instructionsStr - The string representing the instructions.
        //      ingredientsStr - The string representing the ingredients.
        // Post: None.
        // Description: Parses the strings to extract the instructions and ingredients and adds them to the ManualRecipe object.
        private void AddInstructionsAndIngredients(ManualRecipe recipe, string instructionsStr, string ingredientsStr)
        {
            //create list of strings from instructions line, which looks like: "Add to ball,,,;;;Mix everything,,,;;;". also set the instructions into attriute
            List<string> instructions = LoadListLine(instructionsStr);
            recipe.SetInstructions(instructions);

            //create list of strings from ingredients line, which looks like: "Chicken,,,;;;Egg,,,;;;". set the ingredients into attribute
            List<string> ingredients = LoadListLine(ingredientsStr);
            recipe.SetIngredients(ingredients);
        }

        // Pre: line - The line representing the list.
        // Post: Returns a list of strings constructed from the provided line.
        // Description: Parses the line to extract the list items and creates a list of strings.
        private List<string> LoadListLine(string line)
        {
            //make new list to be populated
            List<string> list = new List<string>();

            //check that not an empty line
            if (!line.Equals("")) 
            {
                //divide the list (which can be either ingredients list or instructions list into separate items)
                string[] items = line.Split(Utils.ATTRIBUTES_AND_ITEM_SEPARATOR);

                //iterate through number of items
                for (int i = 0; i < items.Length; i++)
                {
                    string item = items[i];

                    //check that the item isn't blank
                    if (!item.Equals(""))
                    {
                        //add each item into eventually returned "list" parameter
                        list.Add(item);
                    }
                }
            }

            //return the newly populated list, constructed from the passed line
            return list;
        }
    }
}