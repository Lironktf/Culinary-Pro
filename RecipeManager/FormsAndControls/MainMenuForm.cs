// Author: Liron Katsif
// File Name: MainMenuForm.cs
// Project Name: RecipeManager
// Creation Date: Dec 18, 2024
// Modified Date: Jan 11, 2025
// Description: Represents the main menu of the RecipeManager application.
//              It includes attributes for the current user, recipes input/output operations, and meals input/output operations.
//              The class provides methods to initialize user attributes, save user attributes, handle sidebar expansion, and load various forms based on user interactions.
//              essentially the driver class of the program
//
///Use of the class concepts:
//Stack: I use a stack in the FormStack class, and this is used to hold the different forms viewed.
//      For example, if the user has pressed on a recipe in recipesDisplayForm, it gets pushed onto the stack, and then later on the user can press back and view the recipes he was at.
//      These stacks are pretty much everywhere
//Queue:  I use a queue in the ApiKeyQueue, and this is used to hold the different apikeys, and check if there is a need to dequeue, as an apikey has run out.
//Sorting: I have sorting in the RecipesDisplayForm, and this sorts the recipes on the form by a variety of criterion. This is a merge sort of a tuple of recipes.
//Searching: I have searcing in the Nutrition, and this finds the desired nutrient. Ie; if I want to find the calorie nutrient from a deserialized response, I would search for it there. I use a linear search.
//Recursion: I have recusion in the ApiKeyQueue, where I recursovly check if the apiKey should be dequeued upon starting the program.
//          I also have recurision in the MealPlanSelectionForm, in the "RecipesApiCallHelper", and this has the abitility to call for more recipes recoursivly if not enough were found to fill the meal plan.
//          I also have recursion in my sorting, as I have a merge sort in effect
//Lists: I use lists pretty much everywhere. They house my stacks, queue, hold recipes, are used extensivly in file io.
//OOP: I use OOP consistetnly, and implement inheritance, encapsulation, etc... I have around 35 classes.
//FileIO: I use file io in the MealsIO, Utils, RecipesIO, and UsersIo. I use them to save and load users, saved recipes (both manual and spoon), and load and save mealPlans.

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
    public partial class MainMenuForm : Form
    {
        //side bar constants
        const int OPEN_SPEED = 70;
        const int CLOSE_SPEED = 10;

        // Attributes of the MainMenuForm class
        User curUser;
        RecipesIO recipesIO;
        MealsIO mealsIO;

        //sidebar bool
        private bool sideBarExpand;

        // Pre: curUser - The current user using the application.
        // Post: None.
        // Description: Constructor for the MainMenuForm class that initializes the current user and sets up the recipes and meals input/output operations.
        public MainMenuForm(User curUser)
        {
            //init class attributes and user attributes
            InitializeComponent();
            this.recipesIO = new RecipesIO();
            this.mealsIO = new MealsIO();
            this.curUser = curUser;
            InitUserAttributes();
        }

        // Pre: None
        // Post: Returns the current user attribute.
        // Description: Gets the current user using the application.
        public User GetCurUser()
        {
            return curUser;
        }

        // Pre: None
        // Post: Returns the recipes input/output operations attribute.
        // Description: Gets the recipes input/output operations for the application.
        public RecipesIO GetRecipesIO()
        {
            return recipesIO;
        }

        // Pre: None
        // Post: None.
        // Description: Asynchronously initializes the user's attributes by loading saved recipes and meal plans, and setting up the API key queue.
        private async Task InitUserAttributes()
        {
            //set the user lists and meal plans by calling the loading methods
            curUser.SetSavedRecipesList(recipesIO.LoadUserSavedRecipes(curUser));
            curUser.SetMealPlansList(mealsIO.LoadUserMealPlans(curUser));

            //init current apikey
            await ApiKeyQueue.InitQueueKey();
        }

        // Pre: None
        // Post: None.
        // Description: Saves the current user's recipes list and meal plans to persistent storage.
        private void SaveUserAttributes()
        {
            //call the save methods
            recipesIO.SaveUserRecipesLists(curUser);
            mealsIO.SaveMeals(curUser);
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the Tick event of the sideBarTimer control to animate the sidebar expansion or collapse.
        private void sideBarTimer_Tick(object sender, EventArgs e)
        {
            //check the sidebar condition (open or closed)
            if (sideBarExpand)
            {
                //subtracts from width constant
                sideBar.Width -= CLOSE_SPEED;

                //stop when reached max size
                if (sideBar.Width == sideBar.MinimumSize.Width)
                {
                    sideBarExpand = false;
                    sideBarTimer.Stop();
                }
            }
            else
            {
                //expand width
                sideBar.Width += OPEN_SPEED;

                //stop when max size
                if (sideBar.Width == sideBar.MaximumSize.Width)
                {
                    sideBarExpand = true;
                    sideBarTimer.Stop();
                }
            }
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the Click event of the discoverButton control to load the RecipesDisplayForm.
        private void discoverButton_Click(object sender, EventArgs e)
        {
            //load the discover form and start timer
            LoadNextForm(new RecipesDisplayForm(this, true));
            sideBarTimer.Start();
        }

        // Pre: nextForm - The form to be loaded next.
        // Post: None.
        // Description: Removes the current form from the main panel and loads the specified form in its place.
        public void LoadNextForm(object nextForm)
        {
            //check if the nextform isn't null
            if (nextForm != null)
            {
                //if there is already a form in panel, remove
                if (this.mainPanel.Controls.Count > 0)
                {
                    this.mainPanel.Controls.RemoveAt(0);
                }

                //initialize the new form, and set necessary properties
                Form newForm = nextForm as Form;
                newForm.TopLevel = false;
                newForm.Dock = DockStyle.Fill;
                newForm.ControlBox = false;
                newForm.FormBorderStyle = FormBorderStyle.None;
                mainPanel.Controls.Add(newForm);
                this.mainPanel.Tag = newForm;

                //show the newform
                newForm.Show();
            }
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the Click event of the menuBtn control to start the sidebar timer.
        private void menuBtn_Click(object sender, EventArgs e)
        {
            //start the sidebar timer
            sideBarTimer.Start();
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the Load event of the MainMenuForm to load the RecipesDisplayForm.
        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            //load the recipes display form
            LoadNextForm(new RecipesDisplayForm(this, true));
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the Click event of the mealPlanButton control to load the ingredientCheckBox form.
        private void mealPlanButton_Click(object sender, EventArgs e)
        {
            //load the meal plan configurator form and start the side bar timer
            LoadNextForm(new MealPlanSelectionForm(this, curUser));
            sideBarTimer.Start();
        }

        // Pre: sender - The source of the event.
        //      e - A FormClosedEventArgs that contains the event data.
        // Post: None.
        // Description: Handles the FormClosed event of the MainMenuForm to save user attributes and exit the application.
        private void MainMenuForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Save the user attributes, such as saved lists and meal plans, and exit the program
            SaveUserAttributes();
            Environment.Exit(0);
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the Click event of the discoverImageButton control to load the RecipesDisplayForm.
        private void discoverImageButton_Click(object sender, EventArgs e)
        {
            //Load the recipes display form and start the side bar timer
            LoadNextForm(new RecipesDisplayForm(this, true));
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the Click event of the menuImageButton control to start the sidebar timer.
        private void menuImageButton_Click(object sender, EventArgs e)
        {
            //start the side bar timer
            sideBarTimer.Start();
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the Click event of the searchImageButton control to load the SearchCriterionForm.
        private void searchImageButton_Click(object sender, EventArgs e)
        {
            //load the search criterion configurator form 
            LoadNextForm(new SearchCriterionForm(this));
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the Click event of the mealImageButton control to load the ingredientCheckBox form.
        private void mealImageButton_Click(object sender, EventArgs e)
        {
            //load the meal plan configurator form 
            LoadNextForm(new MealPlanSelectionForm(this, curUser));
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the Click event of the powerImageButton control to save user attributes and exit the application.
        private void powerImageButton_Click(object sender, EventArgs e)
        {
            //save user attributes and close the program
            SaveUserAttributes();
            Environment.Exit(0);
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the Click event of the powerDownButton
        private void powerDownButton_Click(object sender, EventArgs e)
        {
            //save user attributes and close the program
            SaveUserAttributes();
            Environment.Exit(0);
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the Click event of the savedImageButton control to load the SavedListsViewForm.
        private void savedImageButton_Click(object sender, EventArgs e)
        {
            //load next saved lists view form
            LoadNextForm(new SavedListsViewForm(this, curUser));
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the Click event of the manualInputButton control to load the ManualInputForm.
        private void manualInputButton_Click(object sender, EventArgs e)
        {
            //load next manual recipe input form, and start the side bar timer
            LoadNextForm(new ManualInputForm(this, curUser));
            sideBarTimer.Start();
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the Click event of the manualImageButton control to load the ManualInputForm.
        private void manualImageButton_Click(object sender, EventArgs e)
        {
            //load the next manual recipe input form
            LoadNextForm(new ManualInputForm(this, curUser));
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the Click event of the savedRecipesButton control to load the SavedListsViewForm.
        private void savedRecipesButton_Click(object sender, EventArgs e)
        {
            //load next saved lists view form form, and start the side bar timer
            LoadNextForm(new SavedListsViewForm(this, curUser));
            sideBarTimer.Start();
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the Click event of the searchButton control to load the SearchCriterionForm.
        private void searchButton_Click(object sender, EventArgs e)
        {
            //load next search criterion form, and start the side bar timer
            LoadNextForm(new SearchCriterionForm(this));
            sideBarTimer.Start();
        }        
    }
}
