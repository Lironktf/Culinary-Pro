// Author: Liron Katsif
// File Name: SavedListsViewForm.cs
// Project Name: RecipeManager
// Creation Date: Jan 2, 2025
// Modified Date: Jan 11, 2025
// Description:  SavedListsViewForm class represents a form for viewing and managing saved recipe lists.
//               It includes attributes for the current user, the parent menu form, the saved recipe lists, and a stack for managing forms, and provides methods to load the form, fetch recipes from a selected list, and display the recipes.

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
    public partial class SavedListsViewForm : Form
    {
        // Attributes of the SavedListsViewForm class
        MainMenuForm parentMenuForm;
        User curUser;
        List<SavedRecipes> savedRecipeLists;
        FormsStack recipesStack = new FormsStack();
        bool hasClicked;

        // Pre: parentMenuForm - The parent menu form.
        //      curUser - The current user.
        // Post: None.
        // Description: Constructor for the SavedListsViewForm class that initializes the parent menu form, current user, and saved recipe lists.
        public SavedListsViewForm(MainMenuForm parentMenuForm, User curUser)
        {
            //init the form, and set the attributes of the form
            InitializeComponent();
            this.parentMenuForm = parentMenuForm;
            this.curUser = curUser;
            savedRecipeLists = curUser.GetSavedRecipesList();
        }

        // Pre: sender - The source of the event.
        //      e - The event data.
        // Post: None.
        // Description: Event handler for the Load event of the SavedListsViewForm. It populates the listsComboBox with the user's saved recipe lists.
        private void SavedListsViewForm_Load(object sender, EventArgs e)
        {
            //iterate through the saved lists, and add each one to the combo box for user selection
            for (int i = 0; i < savedRecipeLists.Count; i++)
            {
                listsComboBox.Items.Add(savedRecipeLists[i].GetListName());
            }
        }

        // Pre: comboBox - The ComboBox containing the selected saved recipe list.
        // Post: None.
        // Description: Fetches recipes from the selected saved recipe list, constructs the API call, and displays the recipes in the RecipesDisplayForm.
        private async Task FetchRecipesFromList(ComboBox comboBox)
        {
            //make object for the selected list
            SavedRecipes selectedList = savedRecipeLists[comboBox.SelectedIndex];

            //make two lists, one holding the spoonrecipes, the other the manual recipes
            List<Recipe> spoonRecipes;
            List<Recipe> manualRecipe;

            //update both lists by calling a helper method
            (spoonRecipes, manualRecipe) = RecipeSeperatorHelper(selectedList);

            //construct the id-call
            string idsCall = ConstructIdsCall(spoonRecipes);

            //get the current apikey and create a string holding the url for this call (Bulk ids)
            string apiKey = ApiKeyQueue.Peek();
            string url = $"https://api.spoonacular.com/recipes/informationBulk?ids={idsCall}&apiKey={apiKey}&includeNutrition=true";

            try
            {
                //using the http api client
                using (HttpClient client = new HttpClient())
                {
                    //make the request, and check if current key should be dequed
                    HttpResponseMessage response = await client.GetAsync(url);
                    ApiKeyQueue.DequeueIfFullyUsed(response);

                    //if the request was successful
                    if (response.IsSuccessStatusCode)
                    {
                        //deserialize the response
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<SpoonRecipe>>(jsonResponse);

                        //if the result isn't empty
                        if (result != null)
                        {
                            //cast the result to type Recipe, and store in list. add to the list the manual recipes acquired above
                            List<Recipe> recipesFromList = result.Cast<Recipe>().ToList();
                            recipesFromList.AddRange(manualRecipe);

                            //create the next form and display these recipes in it.
                            RecipesDisplayForm nextForm = new RecipesDisplayForm(parentMenuForm, recipesStack);
                            nextForm.DisplayRecipes(recipesFromList, null, true);

                            //push this form onto the stack, and load the next form
                            recipesStack.Push(this);
                            parentMenuForm.LoadNextForm(nextForm);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        // Pre: selectedList - The selected saved recipes list.
        // Post: Returns a tuple containing lists of SpoonRecipe and ManualRecipe objects.
        // Description: Separates the recipes in the selected saved recipes list into SpoonRecipe and ManualRecipe lists.
        private (List<Recipe> spoonRecipes, List<Recipe> manualRecipe) RecipeSeperatorHelper(SavedRecipes selectedList)
        {
            //create lists to hold the types of recipes
            List<Recipe> spoonRecipes = new List<Recipe>();
            List<Recipe> manualRecipe = new List<Recipe>();

            //iterate through the recipes in the selected list
            foreach (var recipe in selectedList.GetRecipesList())
            {
                //if the recipe is a spoon recipe add it to the list of spoonrecipes
                if (recipe is SpoonRecipe)
                {
                    spoonRecipes.Add(recipe);
                }
                //the recipe is a manual recipe add it to the list of manual recipes
                else
                {
                    manualRecipe.Add(recipe);
                }
            }

            //return the two lists as a tuple
            return (spoonRecipes, manualRecipe);
        }

        // Pre: selectedList - The list of selected recipes.
        // Post: Returns a string containing the IDs of the selected recipes, separated by commas.
        // Description: Constructs a string of recipe IDs from the selected list for the API call.
        private string ConstructIdsCall(List<Recipe> selectedList)
        {
            //blank string to be populated
            string line = "";

            //iterate through the selected list
            for (int i = 0; i < selectedList.Count; i++)
            {
                //if recipe is a SpoonRecipe
                if (selectedList[i] is SpoonRecipe spoonRecipe)
                {
                    //variable housing the idea for current recipe, and to the line string
                    int currentRecipeId = spoonRecipe.Id;
                    line += $"{currentRecipeId.ToString()}";

                    //if not the last index, add a comma
                    if (i != selectedList.Count - 1)
                    {
                        line += ",";
                    }
                }
            }

            //return the string which houses the id's for call
            return line;
        }

        // Pre: sender - The source of the event.
        //      e - The event data.
        // Post: None.
        // Description: Event handler for the Click event of the viewButton. It fetches recipes from the selected saved recipe list and displays them in the RecipesDisplayForm.
        private async void viewButton_Click(object sender, EventArgs e)
        {
            //check if the user has selected a list
            if (listsComboBox.SelectedItem != null)
            {
                //set the missing fields label to false, and make the api call to fetch the recipes
                missingFieldsLabel.Visible = false;
                await FetchRecipesFromList(listsComboBox);
            }
            else
            {
                //set the missiling label to true
                missingFieldsLabel.Visible = true;
            }
        }

        // Pre: sender - The source of the event.
        //      e - The event data.
        // Post: None.
        // Description:Event handler for the press of the deleteButton. It ends up deleting the saved recipes list from the users
        private void deleteButton_Click(object sender, EventArgs e)
        {
            //check if user has selected a list to delete
            if (listsComboBox.SelectedItem != null)
            {
                //check if the button has already been clicked once before
                if (hasClicked == true)
                {
                    //erase the saved list from the user's lists, and clear the combo box of it
                    curUser.GetSavedRecipesList().RemoveAt(listsComboBox.SelectedIndex);
                    listsComboBox.Items.RemoveAt(listsComboBox.SelectedIndex);
                }
                else
                {
                    //set the has been clicked bool to true (user has alreadt clicked once)
                    hasClicked = true;
                }
            }
            else
            {
                //set the missiling label to true
                missingFieldsLabel.Visible = true;
            }
        }
    }
}
