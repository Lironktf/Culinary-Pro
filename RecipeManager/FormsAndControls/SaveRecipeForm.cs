// Author: Liron Katsif
// File Name: SaveRecipeForm.cs
// Project Name: RecipeManager
// Creation Date: Jan 3, 2025
// Modified Date: Jan 14, 2025
// Description: SaveRecipeForm class represents a form for saving a recipe to a user's saved recipes list.
//              It includes attributes for the current user, the parent menu form, the current recipe, and the recipes IO, and provides methods to load the form, create new recipe lists, and save the current recipe to selected lists.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace RecipeManager
{
    public partial class SaveRecipeForm : Form
    {
        // Attributes of the SaveRecipeForm class
        RecipesIO recipesIO;
        User curUser;
        MainMenuForm parentMenuForm;
        Recipe curRecipe;
        ManualInputForm previousForm;

        // Pre: parentMenuForm - The parent menu form.
        //      curRecipe - The current recipe to be saved.
        // Post: None.
        // Description: Constructor for the SaveRecipeForm class that initializes the parent menu form, current user, recipes IO, and current recipe.
        public SaveRecipeForm(MainMenuForm parentMenuForm, Recipe curRecipe)
        {
            //init the form, and set the attributes of the form
            InitializeComponent();
            this.parentMenuForm = parentMenuForm;
            this.curUser = parentMenuForm.GetCurUser();
            this.recipesIO = parentMenuForm.GetRecipesIO();
            this.curRecipe = curRecipe;
        }

        // Pre: parentMenuForm - The parent menu form.
        //      curRecipe - The current recipe to be saved.
        //      previousForm - the form from which this form was called
        // Post: None.
        // Description: Constructor for the SaveRecipeForm class that initializes the parent menu form, current user, recipes IO, previous form, and current recipe.
        public SaveRecipeForm(MainMenuForm parentMenuForm, Recipe curRecipe, ManualInputForm previousForm)
        {
            //init the form, and set the attributes of the form
            InitializeComponent();
            this.parentMenuForm = parentMenuForm;
            this.curUser = parentMenuForm.GetCurUser();
            this.recipesIO = parentMenuForm.GetRecipesIO();
            this.curRecipe = curRecipe;
            this.previousForm = previousForm;
        }

        // Pre: sender - The source of the event.
        //      e - The event data.
        // Post: None.
        // Description: Event handler for the Load event of the SaveRecipeForm. It populates the listsCheckedBox with the user's saved recipe lists and checks the boxes for lists that already contain the current recipe.
        private void SaveRecipeForm_Load(object sender, EventArgs e)
        {
            //load the saved recipes lists
            List<SavedRecipes> savedRecipes = curUser.GetSavedRecipesList();

            //check if there are saved recipes
            if (savedRecipes.Count > 0)
            {
                //iterate through the saved recipes, and add them to the checked list box for selection
                for (int i = 0; i < savedRecipes.Count; i++)
                {
                    listsCheckedBox.Items.Add(savedRecipes[i].GetListName());

                    //if the list already contains the recipe, check the box
                    if (savedRecipes[i].GetRecipesList().Contains(curRecipe))
                    {
                        listsCheckedBox.SetItemChecked(i, true);
                    }
                }
            }
            else
            {
                //if no recipes found, display error message
                noListsLabel.Visible = true;
            }
        }

        // Pre: sender - The source of the event.
        //      e - The event data.
        // Post: None.
        // Description: Event handler for the Click event of the createButton. It adds a new recipe list to the user's saved recipes list and updates the listsCheckedBox with the new list.
        private void createButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(newListBox.Text))
            {
                listsCheckedBox.Items.Add(newListBox.Text);
                SavedRecipes newRecipeList = new SavedRecipes(newListBox.Text);
                curUser.GetSavedRecipesList().Add(newRecipeList);
                newListBox.Clear();
            }

            if (listsCheckedBox.Items.Count > 0)
            {
                noListsLabel.Visible = false;
            }
        }

        // Pre: sender - The source of the event.
        //      e - The event data.
        // Post: None.
        // Description: Event handler for the Click event of the saveButton. It saves the current recipe to the selected recipe lists in the user's saved recipes list and closes the form.
        private void button1_Click(object sender, EventArgs e)
        {
            //get the saved recipes and selected lists
            List<SavedRecipes> savedRecipes = curUser.GetSavedRecipesList();
            string[] checkedLists = listsCheckedBox.CheckedItems.OfType<string>().ToArray();

            //iterate through the checked lists
            for(int i = 0; i < checkedLists.Length; i++)
            {
                //iterate through all of the saved recipes
                for(int j = 0; j < savedRecipes.Count; j++)
                {
                    //check if the list selected is equal to a saved recipe list. Also check that the list doesn't already contain the recipe
                    if (savedRecipes[j].GetListName() == checkedLists[i] &&
                        !savedRecipes[j].GetRecipesList().Contains(curRecipe))
                    {
                        //add the recipe to the list
                        savedRecipes[j].GetRecipesList().Add(curRecipe);
                    }
                }
            }

            //check if the previous form was passed, indicating this form was called from the manual input form
            if (previousForm != null)
            {
                //clear the previous form, and set focus to the top label of the previous form, to scroll up for polish
                previousForm.ClearForm();
                previousForm.GetFormLabel().Focus();     
            }

            //close this form
            this.Close();
        }
    }
}
