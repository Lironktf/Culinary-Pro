// Author: Liron Katsif
// File Name: MealPlanSelectionForm.cs
// Project Name: RecipeManager
// Creation Date: Dec 29, 2024
// Modified Date: Jan 11, 2025
// Description: Represents a form that allows users to select ingredients for meal planning.
//              It includes attributes for the parent menu form, user, daily caloric intake, and existing meal plans.
//              The class provides methods to set daily caloric intake, load existing meal plans, generate new meal plans, and verify ingredients.

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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RecipeManager
{
    public partial class MealPlanSelectionForm : Form
    {
        //Constants of caloric split per meal
        const double BREAKFAST_CALORIE_SPLIT = 0.3;
        const double LUNCH_CALORIE_SPLIT = 0.4;
        const double DINNER_CALORIE_SPLIT = 0.3;

        //constants for number of meals and days
        const int NUM_DAYS_PER_WEEK = 7;
        const int NUM_MEALS_PER_DAY = 3;

        //Class constants
        private const string INGREDIENTS_SEPERATOR = ",";
        private const int INVALID_VALUE = -1;

        // Attributes of the MealPlanSelectionForm class
        MainMenuForm parentMenuForm;
        private double dailyCaloricIntake;
        User curUser;
        List<MealPlan> existingMealPlans;
        FormsStack formStack = new FormsStack();
        private System.Windows.Forms.Timer timer;
        bool hasClickedDelete;        
        bool hasClickedCreate;        


        // Pre: parentMenuForm - The parent form that contains the ingredient checkboxes.
        //      curUser - The current user using the application.
        // Post: None.
        // Description: Constructor for the ingredientCheckBox class that initializes the parent form and user attributes.
        public MealPlanSelectionForm(MainMenuForm parentMenuForm, User curUser)
        {
            //init form and set attributes of form
            InitializeComponent();
            this.parentMenuForm = parentMenuForm;
            this.curUser = curUser;

            //init timer
            this.timer = new System.Windows.Forms.Timer();
            timer.Interval = 3000;
            timer.Tick += timer_Tick; // Subscribe to the Tick event
        }

        // Pre: dailyCaloricIntake - The daily caloric intake to be set.
        // Post: None.
        // Description: Sets the daily caloric intake and makes the calorie input box visible.
        public void SetDailyCaloricIntake(double dailyCaloricIntake)
        {
            //set the caloric intake label and round the value
            this.dailyCaloricIntake = Math.Round(dailyCaloricIntake, 0);
            caloricIntakeBox.Text = this.dailyCaloricIntake.ToString();
            includeCaloriesBox.Visible = true;
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: This method is triggered when the form is loaded and populates the existing meal plans.
        private void MealPlanSelectionForm_Load(object sender, EventArgs e)
        {
            //load the meal plans list
            existingMealPlans = curUser.GetMealPlansList();

            //iterate through meal plans, and add them to the combo-box
            for (int i = 0; i < existingMealPlans.Count; i++)
            {
                existingPlanBox.Items.Add(existingMealPlans[i].GetPlanName());
            }
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: This method is triggered when the fitness button is clicked and opens the fitness goals form.
        private void fitnessButton_Click(object sender, EventArgs e)
        {
            //show the fitness config form
            FitnessGoalsForm nextForm = new FitnessGoalsForm(this);
            nextForm.Show();
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: This method is triggered when the load plan button is clicked and loads the selected meal plan.
        private async void loadPlanButton_Click(object sender, EventArgs e)
        {
            //get the index selected
            int indexSelected = existingPlanBox.SelectedIndex;

            //check if the user has selected a meal plan to load
            if (indexSelected != INVALID_VALUE)
            {
                //make the missing label invisible
                missingFieldsLabel2.Visible = false;

                //call the recipes by passing the combo box, and the meal indicator. This then updates the meal plan with the full recipes
                await FetchRecipesFromList(indexSelected, MealPlan.BREAKFAST_INDICATOR);
                await FetchRecipesFromList(indexSelected, MealPlan.LUNCH_INDICATOR);
                await FetchRecipesFromList(indexSelected, MealPlan.DINNER_INDICATOR);

                //create the next meal plan form
                MealPlanForm nextForm = new MealPlanForm(parentMenuForm, existingMealPlans[indexSelected], formStack, curUser);

                //push onto the stack this form, and load the next meal plan form
                formStack.Push(this);
                parentMenuForm.LoadNextForm(nextForm);
            }
            else
            {
                //didn't select, so set label to invisible
                missingFieldsLabel2.Visible = true;
            }
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: This method is triggered when the generate new plan button is clicked and creates a new meal plan.
        private async void generateNewPlan_Click(object sender, EventArgs e)
        {
            //check that the user has not already clicked this button, to prevent the same meal plan being added twice
            if (!hasClickedCreate)
            {
                //check if not missing field ( the new meal plan name)
                if (!string.IsNullOrWhiteSpace(newPlanName.Text))
                {
                    hasClickedCreate = true;
                    missingFieldsLabel.Visible = false;

                    //creates a new calorie int
                    int calories = -1;

                    //if the label isn't empty, set the calories var to its contents
                    if (caloricIntakeBox.Text != "")
                    {
                        calories = Convert.ToInt32(caloricIntakeBox.Text);
                    }

                    //create and add a new plan to the user's lists
                    MealPlan curPlan = new MealPlan(newPlanName.Text, calories);
                    curUser.GetMealPlansList().Add(curPlan);

                    //create the nextform
                    MealPlanForm nextForm = new MealPlanForm(parentMenuForm, curPlan, formStack, curUser);

                    //make the API calls to fetch the recipes for each meal
                    await FetchAndDisplayRecipes(MealPlan.BREAKFAST_INDICATOR, breakfastCheckedBox, nextForm, curPlan);
                    await FetchAndDisplayRecipes(MealPlan.LUNCH_INDICATOR, lunchCheckedBox, nextForm, curPlan);
                    await FetchAndDisplayRecipes(MealPlan.DINNER_INDICATOR, dinnerCheckedBox, nextForm, curPlan);

                    //push this form to the stack, and load the next form
                    formStack.Push(this);
                    parentMenuForm.LoadNextForm(nextForm);
                }
                else
                {
                    missingFieldsLabel.Visible = true;
                }
            }
        }

        // Pre: mealIndicator - The indicator for the type of meal (breakfast, lunch, dinner).
        //      checkedBox - The CheckedListBox containing the selected ingredients.
        //      nextForm - The MealPlanForm to display the new meal plan.
        //      newPlan - The new meal plan to be populated with recipes.
        // Post: None.
        // Description: Fetches recipes from an API and populates the new meal plan with the fetched recipes.
        private async Task FetchAndDisplayRecipes(int mealIndicator, CheckedListBox checkedBox, MealPlanForm nextForm, MealPlan newPlan)
        {
            //peek to view the current apiKey, and construct the ingredient call line
            string apiKey = ApiKeyQueue.Peek();
            string ingredientsForCall = ConstructIngredientCall(checkedBox);

            //check if the user opted to have specific ingredients for this meal
            if (ingredientsForCall != null)
            {
                //url for ingredients included search
                string url = $"https://api.spoonacular.com/recipes/complexSearch?apiKey={apiKey}&number=7&includeIngredients={ingredientsForCall}&addRecipeInformation=true&addRecipeNutrition=true";

                //check if user opted to include calories
                if (includeCaloriesBox.Checked)
                {
                    //based on current meal, add to the url the max calories
                    if (mealIndicator == MealPlan.BREAKFAST_INDICATOR) url += $"&maxCalories={newPlan.GetDailyCalories() * BREAKFAST_CALORIE_SPLIT}";
                    else if (mealIndicator == MealPlan.LUNCH_INDICATOR) url += $"&maxCalories={newPlan.GetDailyCalories() * LUNCH_CALORIE_SPLIT}";
                    else url += $"&maxCalories={newPlan.GetDailyCalories() * DINNER_CALORIE_SPLIT}";
                }

                //make the api call for the recipes
                await RecipesApiCallHelper(mealIndicator, newPlan, NUM_DAYS_PER_WEEK, apiKey, url);
            }
            else
            {
                //url for no ingredients search, therefore random
                string url = $"https://api.spoonacular.com/recipes/complexSearch?apiKey={apiKey}&sort=Random&addRecipeInformation=true&addRecipeNutrition=true";

                //check if user opted to include calories
                if (includeCaloriesBox.Checked)
                {
                    //based on current meal, add to the url the max calories
                    if (mealIndicator == MealPlan.BREAKFAST_INDICATOR) url += $"&maxCalories={Convert.ToInt32(caloricIntakeBox.Text) * BREAKFAST_CALORIE_SPLIT}";
                    else if (mealIndicator == MealPlan.LUNCH_INDICATOR) url += $"&maxCalories={Convert.ToInt32(caloricIntakeBox.Text) * LUNCH_CALORIE_SPLIT}";
                    else url += $"&maxCalories={Convert.ToInt32(caloricIntakeBox.Text) * DINNER_CALORIE_SPLIT}";
                }

                //make the api call
                await RecipesApiCallHelper(mealIndicator, newPlan, NUM_DAYS_PER_WEEK, apiKey, url);
            }
        }

        // Pre: mealIndicator - The indicator for the type of meal (breakfast, lunch, dinner).
        //      newPlan - The new meal plan to be populated with recipes.
        //      numCalls - The number of API calls to make.
        //      apiKey - The API key for the recipe API.
        //      ingredientsUrl - The URL for fetching recipes based on ingredients (optional).
        // Post: None.
        // Description: Helper method to make API calls for fetching recipes and populating the meal plan.
        private async Task RecipesApiCallHelper(int mealIndicator, MealPlan newPlan, int numCalls, string apiKey, string givenUrl = "")
        {
            string url;

            //check if the given url isn't empty, meaning one has been passed
            if (givenUrl != "")
            {
                //make the url the given url
                url = givenUrl;
            }
            else
            {
                //if the given url is empty, make the url the random url.
                //This happens for when the api call occurs, but not enough recipes are found. In that case, deafult to this url.
                url = $"https://api.spoonacular.com/recipes/complexSearch?apiKey={apiKey}&sort=Random&addRecipeInformation=true&addRecipeNutrition=true";
            }

            //add to url num calls
            url += $"&number={numCalls}";

            try
            {
                //using http api call client (built in)
                using (HttpClient client = new HttpClient())
                {
                    //make the api call and check in the api queue if it should dequeue
                    HttpResponseMessage response = await client.GetAsync(url);
                    ApiKeyQueue.DequeueIfFullyUsed(response);

                    //if succesful call
                    if (response.IsSuccessStatusCode)
                    {
                        //deserialize response
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        var result = Newtonsoft.Json.JsonConvert.DeserializeObject<RecipesResponse>(jsonResponse);

                        //if response not empty
                        if (result != null)
                        {
                            //check if enough recipes have been returned (7 for each day of week), populate the new plan with these recipes
                            if (result.Recipes.Count == MealPlan.DAYS_PER_WEEK)
                            {
                                //populate the new plan with these recipes
                                newPlan.PopulateMeal(result.Recipes, mealIndicator);
                            }
                            else
                            {
                                //if not enoug recipes returned, recuriovly call this method again, use the random url, and call the
                                //amount of recipes missing
                                await RecipesApiCallHelper(mealIndicator, newPlan, NUM_DAYS_PER_WEEK - result.Recipes.Count, apiKey);
                            }
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

            //if items isn't null and has items inside
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

        // Pre: mealTextBox - The TextBox containing the ingredient to be added.
        //      mealCheckedBox - The CheckedListBox to add the ingredient to.
        // Post: None.
        // Description: Helper method to add ingredients from the TextBox to the CheckedListBox.
        private void CheckedListHelper(TextBox mealTextBox, CheckedListBox mealCheckedBox)
        {
            //checks if the textbox isn't empty
            if (!string.IsNullOrEmpty(mealTextBox.Text))
            {
                //adds the text to the checked box, checks it, and clears the textbox
                mealCheckedBox.Items.Add(mealTextBox.Text);
                mealCheckedBox.SetItemChecked(mealCheckedBox.Items.Count - 1, true);
                mealTextBox.Clear();
            }
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: This method is triggered when the breakfast enter button is clicked and adds the ingredient to the breakfast list.
        private void breakfastEnterBtn_Click(object sender, EventArgs e)
        {
            //calls the verify ingredient method, and sends the controls related to this meal
            VerifyIngredientHelper(breakfastTextBox, breakfastCheckedBox);
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: This method is triggered when the lunch enter button is clicked and adds the ingredient to the lunch list.
        private void lunchEnterBtn_Click(object sender, EventArgs e)
        {
            //calls the verify ingredient method, and sends the controls related to this meal
            VerifyIngredientHelper(lunchTextBox, lunchCheckedBox);
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: This method is triggered when the dinner enter button is clicked and adds the ingredient to the dinner list.
        private void dinnerEnterBtn_Click(object sender, EventArgs e)
        {
            //calls the verify ingredient method, and sends the controls related to this meal
            VerifyIngredientHelper(dinnerTextBox, dinnerCheckedBox);
        }

        // Pre: textBox - The TextBox containing the ingredient to be verified.
        //      checkedBox - The CheckedListBox to add the ingredient to if verified.
        // Post: None.
        // Description: Helper method to verify the ingredient and add it to the CheckedListBox if valid.
        private async void VerifyIngredientHelper(TextBox textBox, CheckedListBox checkedBox)
        {
            //checks if the user has opted to have ingredient checking on
            if (ingredientCheckingBox.Checked)
            {
                //if the ingredient is found in the spoonacular api
                if (await VerifyIngredient(textBox.Text))
                {
                    //call checked list helper and pass controls
                    CheckedListHelper(textBox, checkedBox);
                }
                //if ingredient not found show the notfound label and start the timer
                else
                {
                    notFoundLabel.Visible = true;
                    timer.Start();
                }
            }
            else
            {
                //if user doesn't want ingredient checking on, just call the checkedlisthelper without verifying
                CheckedListHelper(textBox, checkedBox);
            }
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: This method is triggered when the timer ticks and hides the not found label.
        private void timer_Tick(object sender, EventArgs e)
        {
            //Actions to perform when the timer ticks
            notFoundLabel.Visible = false;
            timer.Stop();
        }

        // Pre: ingredient - The ingredient to be verified.
        // Post: Returns true if the ingredient is valid and exists in the database, otherwise false.
        // Description: Verifies if the provided ingredient exists in the database and is valid.
        private async Task<bool> VerifyIngredient(string ingredient)
        {
            //peeks in the api queue to find the current key, and sets the url for this call
            string apiKey = ApiKeyQueue.Peek();
            string url = $"https://api.spoonacular.com/food/ingredients/search?apiKey={apiKey}&query={ingredient}&number=5";

            try
            {
                // using the http api client
                using (HttpClient client = new HttpClient())
                {
                    //make the call, and check if the api queue should dequeue
                    HttpResponseMessage response = await client.GetAsync(url);
                    ApiKeyQueue.DequeueIfFullyUsed(response);

                    //if the request is succesfull
                    if (response.IsSuccessStatusCode)
                    {
                        //deserialize the response
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        var result = Newtonsoft.Json.JsonConvert.DeserializeObject<RecipesResponse>(jsonResponse);

                        //if the result is not null, and the recipes list exists
                        if (result != null && result.Recipes != null)
                        {
                            //iterate through the list of recipes
                            foreach (SpoonRecipe recipe in result.Recipes)
                            {
                                //if a recipe name is equal to the ingredient inputed by the user, return true
                                if (recipe.Name == ingredient)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            //if ingredient not found, return null
            return false;
        }

        // Pre: comboBoxIndex - The ComboBox index selected from the combobox containing the list of recipes.
        //      mealIndicator - An integer indicating the type of meal (e.g., breakfast, lunch, dinner).
        // Post: None.
        // Description: Fetches recipes from the list in the ComboBox and updates the meal plan based on the meal indicator.
        private async Task FetchRecipesFromList(int comboBoxIndex, int mealIndicator)
        {
            //set a meal plan object based index selected, and construct the id's call string
            MealPlan selectedPlan = existingMealPlans[comboBoxIndex];
            string idsCall = ConstructIdHelper(mealIndicator, selectedPlan);

            //peek the current apiKey and set the url variable with the reuquired url for a bulk api call
            string apiKey = ApiKeyQueue.Peek();
            string url = $"https://api.spoonacular.com/recipes/informationBulk?ids={idsCall}&apiKey={apiKey}&includeNutrition=true";

            try
            {
                //using the http api client
                using (HttpClient client = new HttpClient())
                {
                    //make the call, and check if the api queue should dequeue
                    HttpResponseMessage response = await client.GetAsync(url);
                    ApiKeyQueue.DequeueIfFullyUsed(response);

                    //check if the request is succesfull
                    if (response.IsSuccessStatusCode)
                    {
                        //deserrialize response
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<SpoonRecipe>>(jsonResponse);

                        //if the result aqcuired by the request isn't null, populate the current meal plan
                        if (result != null)
                        {
                            selectedPlan.PopulateMeal(result, mealIndicator);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        // Pre: mealIndicator - An integer indicating the type of meal (e.g., breakfast, lunch, or dinner).
        //      selectedPlan - The selected meal plan containing the recipes.
        // Post: Returns a comma-separated string of recipe IDs for the specified meal type.
        // Description: Iterates through each day of the week in the selected meal plan and appends the recipe ID for the specified meal type to a string. The resulting string contains the recipe IDs separated by commas.
        private string ConstructIdHelper(int mealIndicator, MealPlan selectedPlan)
        {
            // Initialize a blank string to be filled with recipe IDs.
            string line = "";

            // Iterate through each day of the week.
            for (int i = 0; i < NUM_DAYS_PER_WEEK; i++)
            {
                // Append the recipe ID for the specified meal type to the string.
                if (mealIndicator == MealPlan.BREAKFAST_INDICATOR)
                {
                    line += ((SpoonRecipe)selectedPlan.GetWeekPlan()[i].GetBreakfast().GetRecipe()).Id + ",";
                }
                else if (mealIndicator == MealPlan.LUNCH_INDICATOR)
                {
                    line += ((SpoonRecipe)selectedPlan.GetWeekPlan()[i].GetLunch().GetRecipe()).Id + ",";
                }
                else
                {
                    line += ((SpoonRecipe)selectedPlan.GetWeekPlan()[i].GetDinner().GetRecipe()).Id + ",";
                }
            }

            // Remove the trailing comma from the string.
            line = line.Remove(line.Length - 1);

            // Return the constructed string of recipe IDs.
            return line;
        }

        // Pre: sender - The source of the event.
        //      e - The event data.
        // Post: None.
        // Description: Event handler for the press of the deleteButton. It ends up deleting the meal plan from the users meal plans
        private void deleteButton_Click(object sender, EventArgs e)
        {
            //check if user has selected a list to delete
            if (existingPlanBox.SelectedItem != null)
            {
                //check if the button has already been clicked once before
                if (hasClickedDelete == true)
                {
                    //erase the meal plan from the list, and clear the combo box of it
                    curUser.GetMealPlansList().RemoveAt(existingPlanBox.SelectedIndex);
                    existingPlanBox.Items.RemoveAt(existingPlanBox.SelectedIndex);
                }
                else
                {
                    //set the bool to already clicked once
                    hasClickedDelete = true;
                }
            }
            else
            {
                //set the missiling label to true
                missingFieldsLabel2.Visible = true;
            }
        }
    }
}
