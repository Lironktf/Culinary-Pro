// Author: Liron Katsif
// File Name: SearchCriterionForm.cs
// Project Name: RecipeManager
// Creation Date: Dec 10, 2024
// Modified Date: Jan 11, 2025
// Description: SearchCriterionForm class represents a form for specifying search criteria for recipes.
//              It includes attributes for the parent menu form and a stack of recipe forms, and provides methods to handle user input, construct API requests, and fetch and display recipes.

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
    public partial class SearchCriterionForm : Form
    {
        // Class constants 
        private const string INGREDIENTS_SEPERATOR = ",";

        // Attributes of the SearchCriterionForm class
        MainMenuForm parentMenuForm;
        FormsStack recipesStack = new FormsStack();

        // Pre: None
        // Post: None.
        // Description: Constructor for the SearchCriterionForm class that initializes the form.
        public SearchCriterionForm()
        {
            InitializeComponent();
        }

        // Pre: parentMenuForm - The parent MainMenuForm instance.
        // Post: None.
        // Description: Constructor for the SearchCriterionForm class that initializes the form and sets the parent form.
        public SearchCriterionForm(MainMenuForm parentMenuForm)
        {
            //init the form, and set the attributes of the form (the parentMenuForm)
            InitializeComponent();
            this.parentMenuForm = parentMenuForm;
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the click event for the view recipes button, validates input fields, and fetches recipes from the API.
        private async void viewRecipesButton_Click(object sender, EventArgs e)
        {
            //check if no missing fields (user has filled out at least one field)
            if (!string.IsNullOrWhiteSpace(recipeNameBox.Text) || maxSugarBox.Value != 0
                || minProteinBox.Value != 0 || minProteinBox.Value != 0 || numIngredientsBox.Value != 0
                || maxCaloriesBox.Value != 0 || ingredientsCheckedBox.Items.Count != 0)
            {
                //set the missing fields label to off, and make the api call
                missingFieldsLabel.Visible = false;
                await FetchAndDisplayRecipesAsync(recipeNameBox.Text, ingredientsCheckedBox, Convert.ToInt32(numIngredientsBox.Value),
                                                  Convert.ToDouble(maxCaloriesBox.Value), Convert.ToDouble(maxSugarBox.Value),
                                                  Convert.ToDouble(minProteinBox.Value));
            }
            else
            {
                //set the missing fields label to true
                missingFieldsLabel.Visible = true;
            }
        }

        // Pre: recipeName - The name of the recipe to search for.
        //      checkedBox - The CheckedListBox containing selected ingredients.
        //      numRecipes - The number of recipes to fetch.
        //      maxCalories - The maximum number of calories for the recipes.
        //      maxSugar - The maximum amount of sugar for the recipes.
        //      minProtein - The minimum amount of protein for the recipes.
        // Post: None.
        // Description: Constructs the API request URL with the provided search criteria, fetches recipes from the API, and displays them in the next form.
        private async Task FetchAndDisplayRecipesAsync(string recipeName, CheckedListBox checkedBox, int numRecipes, double maxCalories, double maxSugar, double minProtein)
        {
            //get the current api key
            string apiKey = ApiKeyQueue.Peek();
            string url = $"https://api.spoonacular.com/recipes/complexSearch?apiKey={apiKey}&addRecipeInformation=true&addRecipeNutrition=true&sort=random";

            //based on the fields the user filled out, update the url with them
            if (recipeName != "")
            {
                url += $"&titleMatch={recipeName}";
            }
            if (checkedBox.Items.Count > 0)
            {
                url += $"&includeIngredients={ConstructIngredientCall(checkedBox)}";
            }
            if (numRecipes != 0)
            {
                url += $"&number={numRecipes}";
            }
            if (maxCalories != 0)
            {
                url += $"&maxCalories={maxCalories}";
            }
            if (maxSugar != 0)
            {
                url += $"&maxSugar={maxSugar}";
            }
            if (minProtein != 0)
            {
                url += $"&minProtein={minProtein}";
            }

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
                        //deserialize the resonse
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        var result = Newtonsoft.Json.JsonConvert.DeserializeObject<RecipesResponse>(jsonResponse);

                        //if the result isn't null, and the list of recipes isn't empty
                        if (result != null)
                        {
                            //convert the resultant list of recipes from type SpoonRecip to type Recipe, and build next form
                            List<Recipe> recipesFromApi = result.Recipes.Cast<Recipe>().ToList();
                            RecipesDisplayForm nextForm = new RecipesDisplayForm(parentMenuForm, recipesStack);

                            //if the number of resultant recipes is greater than zero, display the recipes
                            if (recipesFromApi.Count != 0)
                            {
                                nextForm.DisplayRecipes(recipesFromApi);
                            }
                            //if no recipes were found, turn on the next no results found on the next form
                            else
                            {
                                nextForm.SetNoResultLabel(true);
                            }

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

        // Pre: checkedBox - The CheckedListBox containing the selected ingredients.
        // Post: Returns a string of ingredients separated by commas.
        // Description: Constructs a string of selected ingredients for the API call.
        private string ConstructIngredientCall(CheckedListBox checkedBox)
        {
            //create an array of strings from the checkedListBox
            string[] items = checkedBox.CheckedItems.OfType<string>().ToArray();

            //check if items isn't null and has items inside
            if (items != null && items.Length > 0)
            {
                string finalString = "";

                //iterate through the items minus one (so that the final item woudln't have a comma after it)
                for (int i = 0; i < items.Length - 1; i++)
                {
                    //add the item and a seperator to the final string
                    finalString += items[i];
                    finalString += INGREDIENTS_SEPERATOR;
                }

                //add the final item to the string, and return it
                finalString += items[^1];
                return finalString;
            }

            //if no items were checked, return null
            return null;
        }

        // Pre: ingredientTextBox - The TextBox containing the ingredient to add.
        //      ingredientCheckedBox - The CheckedListBox to add the ingredient to.
        // Post: None.
        // Description: Adds the ingredient from the TextBox to the CheckedListBox and sets it as checked.
        private void CheckedListHelper(TextBox ingredientTextBox, CheckedListBox ingredientCheckedBox)
        {
            //checks if the textbox isn't empty
            if (!string.IsNullOrEmpty(ingredientTextBox.Text))
            {
                //adds the text to the checked box, checks it, and clears the textbox
                ingredientCheckedBox.Items.Add(ingredientTextBox.Text);
                ingredientCheckedBox.SetItemChecked(ingredientCheckedBox.Items.Count - 1, true);
                ingredientTextBox.Clear();
            }
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the click event
        private void ingredientEnterBtn_Click(object sender, EventArgs e)
        {
            //call the checked list helper to add the 
            CheckedListHelper(ingredientsTextBox, ingredientsCheckedBox);
        }
    }
}
