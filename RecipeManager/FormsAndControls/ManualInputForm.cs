// Author: Liron Katsif
// File Name: ManualInputForm.cs
// Project Name: RecipeManager
// Creation Date: Jan 3, 2025
// Modified Date: Jan 11, 2025
// Description: Represents a form that allows users to manually input and save recipes.
//              It includes attributes for the parent menu form, the current user, and the user's saved recipes lists.
//              The class provides methods to confirm and save the new recipe, clear the form fields, and load the saved recipes lists into the form.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeManager
{
    public partial class ManualInputForm : Form
    {
        // Class constants 
        const int INVALID_INT_VALUE = -1;

        // Attributes of the ManualInputForm class
        MainMenuForm parentMenuForm;
        User curUser;
        List<SavedRecipes> savedRecipesLists;

        // Pre: None
        // Post: Returns the Label control representing the form label.
        // Description: Gets the label control of the form, which can be used to retrieve or modify its properties.
        public Label GetFormLabel()
        {
            return formLabel;
        }

        // Pre: parentMenuForm - The parent form that contains the manual input form.
        //      curUser - The current user using the application.
        // Post: None.
        // Description: Constructor for the ManualInputForm class that initializes the parent form and current user.
        public ManualInputForm(MainMenuForm parentMenuForm, User curUser)
        {
            //inits form, and sets the attributes of the form
            InitializeComponent();
            this.parentMenuForm = parentMenuForm;
            this.curUser = curUser;
            this.savedRecipesLists = curUser.GetSavedRecipesList();
        }

        // Pre: None
        // Post: None.
        // Description: Clears the input fields and resets the form to its initial state.
        public void ClearForm()
        {
            //clear all the controls on the form 
            ingredientTextBox.Clear();
            instructionsTextBox.Clear();
            recipeNameBox.Clear();
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the Click event of the listsButton control. 
        //              This method checks if the necessary input fields are filled, creates a new recipe from the input data, 
        //              and opens a SaveRecipeForm to save the new recipe. If any input fields are missing, it displays a warning label.
        private void listsButton_Click(object sender, EventArgs e)
        {
            //check if non of the neccesary fields are empty or not selected
            if (!String.IsNullOrWhiteSpace(ingredientTextBox.Text) && !String.IsNullOrWhiteSpace(instructionsTextBox.Text)
                && !String.IsNullOrWhiteSpace(recipeNameBox.Text))
            {
                //lists of strings of the textboxes which hold the recipe instructions/ingredients
                List<string> recipeIngredients = ingredientTextBox.Text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList();
                List<string> recipeInstructions = instructionsTextBox.Text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList();

                //creates the new recipes inputed
                ManualRecipe newRecipe = new ManualRecipe(recipeNameBox.Text, recipeIngredients, recipeInstructions);

                //creates and shows a new instance of the recipe save form
                SaveRecipeForm newForm = new SaveRecipeForm(parentMenuForm, (Recipe)newRecipe, this);
                newForm.Show();
            }
            else
            {
                //set the missing fields label to visible
                missingFieldsLabel.Visible = true;
            }
        }
    }
}
