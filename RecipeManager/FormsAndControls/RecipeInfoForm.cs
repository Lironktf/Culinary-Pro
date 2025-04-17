// Author: Liron Katsif
// File Name: RecipeInfoForm.cs
// Project Name: RecipeManager
// Creation Date: Dec 16, 2024
// Modified Date: Jan 11, 2025
// Description: RecipeInfoForm class represents a form that displays detailed information about a specific recipe.
//              It includes attributes for the current recipe, the previous display form, and the parent menu form.
//              The class provides methods to fetch recipe information, display nutritional values, and handle user interactions.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RecipeManager
{
    public partial class RecipeInfoForm : Form
    {
        // Class constants 
        const int MANUAL_Y_LOCATION_DIFFERENCE = 470;
        const int MANUAL_FORM_MIN_SIZE = 700;
        const int INVALID_VALUE = -1;

        // Attributes of the RecipeInfoForm class
        private Recipe curRecipe;
        private Form previousDisplayForm;
        private MainMenuForm parentMenuForm;

        // Pre: None
        // Post: None.
        // Description: Default constructor for the RecipeInfoForm class.
        public RecipeInfoForm()
        {
            InitializeComponent();
        }

        // Pre: curRecipe - The current recipe to be displayed.
        //      previousDisplayForm - The form that was displayed before this one.
        //      parentMenuForm - The main menu form that contains this form.
        // Post: None.
        // Description: Constructor for the RecipeInfoForm class that initializes the current recipe, previous display form, and parent menu form.
        public RecipeInfoForm(Recipe curRecipe, Form previousDisplayForm, MainMenuForm parentMenuForm)
        {
            //init the form, and set the form attributes
            InitializeComponent();
            this.curRecipe = curRecipe;
            this.previousDisplayForm = previousDisplayForm;
            this.parentMenuForm = parentMenuForm;

            //add the recime name onto a label
            recipeName.Text = curRecipe.Title;

            //if the current recipe is a SpoonRecipe
            if (curRecipe is SpoonRecipe spoonRecipe)
            {
                //if the image isn't null, load it onto a pictureBox
                if (spoonRecipe.Image != null) recipeImage.Load(spoonRecipe.Image);
            }
        }

        // Pre: sender - The source of the event.
        //      e - The event data.
        // Post: None.
        // Description: Event handler for the form load event that fetches and displays the recipe information.
        private async void RecipeInfoForm_Load(object sender, EventArgs e)
        {
            //check the type of recipe the current recipe is
            if (curRecipe is SpoonRecipe spoonRecipe)
            {
                //fetch the recipe information
                await FetchRecipeInfo();

                //set variables for the nutrients, and init them with an invalid value of -1
                double caloriesAmount = INVALID_VALUE;
                double proteinAmount = INVALID_VALUE;
                double sugarAmount = INVALID_VALUE;
                double fatAmount = INVALID_VALUE;
                double pricePerServing = INVALID_VALUE;
                double healthScore = INVALID_VALUE;
                double weightWatcherPoints = INVALID_VALUE;
                double servings = INVALID_VALUE;

                //update the variable initated above with the value from the recipe
                caloriesAmount = spoonRecipe.GetCalorieAmount();
                proteinAmount = spoonRecipe.GetProteinAmount();
                sugarAmount = spoonRecipe.GetSugarAmount();
                fatAmount = spoonRecipe.GetFatAmount();
                pricePerServing = spoonRecipe.PricePerServing;
                healthScore = spoonRecipe.HealthScore;
                weightWatcherPoints = spoonRecipe.WeightWatcherPoints;
                servings = spoonRecipe.Servings;

                //call a helper method for each nutrient, to post the value into the label
                FillNutritionValueHelper(caloriesAmount, calorieLabel);
                FillNutritionValueHelper(proteinAmount, proteinLabel);
                FillNutritionValueHelper(sugarAmount, sugarLabel);
                FillNutritionValueHelper(fatAmount, fatLabel);
                FillNutritionValueHelper(pricePerServing, priceLabel);
                FillNutritionValueHelper(healthScore, healthLabel);
                FillNutritionValueHelper(weightWatcherPoints, watchersLabel);
                FillNutritionValueHelper(servings, servingsLabel);
            }
            else
            {
                //set the labels for the nutrition tag and the nutrition table to invisible
                nutritionLabel.Visible = false;
                nutritionTable.Visible = false;

                //call a helper method to move the labels and textboxes relevent for the manualrecipe up
                SetManualControlLocation(ingredientLabel);
                SetManualControlLocation(ingredientTextBox);
                SetManualControlLocation(instructionLabel);
                SetManualControlLocation(instructionTextBox);

                //lower the autoscroll minsize for polish
                AutoScrollMinSize = new Size(this.Width, MANUAL_FORM_MIN_SIZE);

                //iterate through the ingredients in the recipe
                foreach (string ingredient in ((ManualRecipe)curRecipe).GetIngredients())
                {
                    //add the ingredient to the text box, add a line, and ensure that the textbox isn't being viewed at the bottom of it
                    ingredientTextBox.Text += ingredient + System.Environment.NewLine;
                    instructionTextBox.ScrollToCaret();
                }

                //iterate through the instructions in the recipe
                foreach (string instruction in ((ManualRecipe)curRecipe).GetInstructions())
                {
                    //add the instructions to the text box, add a line, and ensure that the textbox isn't being viewed at the bottom of it
                    instructionTextBox.Text += instruction + System.Environment.NewLine;
                    instructionTextBox.ScrollToCaret();
                }
            }
        }

        // Pre: control - The control whose location is to be set.
        // Post: None.
        // Description: Sets the location of the control for manual recipes by adjusting the Y coordinate.
        private void SetManualControlLocation(Control control)
        {
            //set a new location for the control, which is higher than previously
            control.Location = new Point(control.Location.X, control.Location.Y - MANUAL_Y_LOCATION_DIFFERENCE);
        }

        // Pre: nutrientAmount - The amount of the nutrient to be displayed.
        //      label - The label to display the nutrient amount.
        // Post: None.
        // Description: Helper method to fill the label with the nutrient amount or indicate that the information is unavailable.
        private void FillNutritionValueHelper(double nutrientAmount, Label label)
        {
            //check if the nutrient amount variable is an invalid value (-1), and update the value of the label
            if (nutrientAmount == INVALID_VALUE)
            {
                label.Text = "Information Unavailable";
            }
            else
            {
                label.Text = Math.Round(nutrientAmount, 1).ToString();
            }
        }


        // Pre: None
        // Post: None.
        // Description: Fetches the recipe information including ingredients and instructions from the Spoonacular API and updates the form.
        private async Task FetchRecipeInfo()
        {
            //peek in the apiqueue to get the current key, and initialize the url's for the instructions and the ingredients
            string apiKey = ApiKeyQueue.Peek();
            string urlInstructions = $"https://api.spoonacular.com/recipes/{((SpoonRecipe)curRecipe).Id}/analyzedInstructions?apiKey={apiKey}";
            string urlIIngredients = $"https://api.spoonacular.com/recipes/{((SpoonRecipe)curRecipe).Id}/information?apiKey={apiKey}";

            try
            {
                //using the http api client
                using (HttpClient client = new HttpClient())
                {
                    //make the two calls (one for the ingredients and the other for instructions), and check if the api queue should dequeue
                    HttpResponseMessage responseIngredient = await client.GetAsync(urlIIngredients);
                    HttpResponseMessage responseInstructions = await client.GetAsync(urlInstructions);
                    ApiKeyQueue.DequeueIfFullyUsed(responseIngredient);

                    //check if the instructions call was succesfull
                    if (responseInstructions.IsSuccessStatusCode)
                    {
                        //deserialize the response
                        string jsonResponse = await responseInstructions.Content.ReadAsStringAsync();
                        var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<InstructionsResponse>>(jsonResponse);

                        //check if result is not null, and the result at the first position (because of the way this deserializes, I have to make it a list, and select the zero'th index)
                        //and the resultant list isn't empty
                        if (result != null && result[0].Instructions != null && result.Count > 0)
                        {
                            //init a counter for UI purposes
                            int stepCounter = 1;

                            //iterate through each instruction
                            foreach (var step in result[0].Instructions)
                            {
                                //add the instructions to the text box, add two lines (for visual), and ensure that the textbox isn't being viewed at the bottom of it, and increment the counter
                                instructionTextBox.Text += stepCounter + ": " + step.Step + System.Environment.NewLine + System.Environment.NewLine;
                                instructionTextBox.ScrollToCaret();
                                stepCounter++;
                            }
                        }
                    }

                    //if the ingredients call was succesfull
                    if (responseIngredient.IsSuccessStatusCode)
                    {
                        //deserialize the response
                        string jsonResponse = await responseIngredient.Content.ReadAsStringAsync();
                        var result = Newtonsoft.Json.JsonConvert.DeserializeObject<IngredientResponse>(jsonResponse);

                        //if the result isn't null, and list of ingredients isnt empty
                        if (result != null && result.Ingredients.Count > 0)
                        {
                            //init an ingredient counter for ui
                            int ingredientCounter = 1;

                            //iterate through each ingredient
                            foreach (var ingredient in result.Ingredients)
                            {
                                //add the ingredient to the text box, add a line, and ensure that the textbox isn't being viewed at the bottom of it, and increment the counter
                                ingredientTextBox.Text += "Ingredient" + " " + ingredientCounter + ": " + ingredient.Original + System.Environment.NewLine;
                                ingredientTextBox.ScrollToCaret();
                                ingredientCounter++;
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

        // Pre: sender - The source of the event.
        //      e - The event data.
        // Post: None.
        // Description: Event handler for the ingredient text box enter event that sets the active control to the recipe name text box.
        private void ingredientTextBox_Enter(object sender, EventArgs e)
        {
            //set the active control to the ingredient label, so that way it doens't appear like there is a cursor in the textbox
            ActiveControl = ingredientLabel;
        }

        // Pre: sender - The source of the event.
        //      e - The event data.
        // Post: None.
        // Description: Event handler for the step text box enter event that sets the active control to the recipe name text box.
        private void stepTextBox_Enter(object sender, EventArgs e)
        {
            //set the active control to the instruction label, so that way it doens't appear like there is a cursor in the textbox
            ActiveControl = instructionLabel;
        }

        // Pre: sender - The source of the event.
        //      e - The event data.
        // Post: None.
        // Description: Event handler for the back button click event that loads the previous display form.
        private void backButton_Click(object sender, EventArgs e)
        {
            //load the previous form
            parentMenuForm.LoadNextForm(previousDisplayForm);
        }
    }
}
