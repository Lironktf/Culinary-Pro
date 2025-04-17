// Author: Liron Katsif
// File Name: MealPlanForm.cs
// Project Name: RecipeManager
// Creation Date: Jan 2, 2025
// Modified Date: Jan 10 2025
// Description: Represents a form that displays and manages a meal plan for a user.
//              It includes attributes for the parent menu form, the current meal plan, and a stack of forms for navigation.
//              The class provides methods to load the meal plan, populate the table layout with meal details, handle form events, and manage the loading status.

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
    public partial class MealPlanForm : Form
    {
        // Class constants 
        const int LOAD_LABEL_MAX_LENGTH = 9;
        const int LABEL_DOT_BEGIN_INDEX = 7;
        const string DOT_STRING = ".";

        //Meal indices on table constants
        const int BREAKFAST_ROW_INDEX = 1;
        const int LUNCH_ROW_INDEX = 2;
        const int DINNER_ROW_INDEX = 3;

        // Attributes of the MealPlanForm class
        MainMenuForm parentMenuForm;
        MealPlan curPlan;
        FormsStack formStack;
        User curUser;

        // Pre: parentMenuForm - The parent form that contains the meal plan form.
        //      curPlan - The current meal plan to be displayed.
        //      formStack - The stack of forms for navigation.
        //      curUser - the current user and their attributes
        // Post: None.
        // Description: Constructor for the MealPlanForm class that initializes the parent form, current meal plan, and form stack.
        public MealPlanForm(MainMenuForm parentMenuForm, MealPlan curPlan, FormsStack formStack, User curUser)
        {
            //init form properties and set attributes with passed paramameters
            InitializeComponent();
            this.parentMenuForm = parentMenuForm;
            this.curPlan = curPlan;
            this.formStack = formStack;
            this.curUser = curUser;
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the Load event of the MealPlanForm control.
        private void MealPlanForm_Load(object sender, EventArgs e)
        {
            //call populate table method, and set the plan name
            PopulateTableLayout();
            planNameLabel.Text = curPlan.GetPlanName();
        }

        // Pre: None
        // Post: None.
        // Description: Populates the table layout with breakfast, lunch, and dinner recipes for each day of the week.
        public void PopulateTableLayout()
        {
            //iterate through days of week
            for (int i = 0; i < MealPlan.DAYS_PER_WEEK; i++)
            {
                //add to table layout the recipe for the corresponding day and meal type
                tableLayout.Controls.Add(new MinimalRecipeCard(curPlan.GetWeekPlan()[i].GetBreakfast().GetRecipe(), parentMenuForm, this, formStack), i + 1, BREAKFAST_ROW_INDEX);
                tableLayout.Controls.Add(new MinimalRecipeCard(curPlan.GetWeekPlan()[i].GetLunch().GetRecipe(), parentMenuForm, this, formStack), i + 1, LUNCH_ROW_INDEX);
                tableLayout.Controls.Add(new MinimalRecipeCard(curPlan.GetWeekPlan()[i].GetDinner().GetRecipe(), parentMenuForm, this, formStack), i + 1, DINNER_ROW_INDEX);

                //set the timer to true, to hide the table loading
                loadingTimer.Start();
            }
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the Click event of the backImageButton control.
        private void backImageButton_Click(object sender, EventArgs e)
        {

            //check if the size of the stack is one, meaning only form on it is the MealPlanSelectForm
            if (formStack.Size() == 1)
            {
                //load a blank Meal Plan Selection form
                parentMenuForm.LoadNextForm(new MealPlanSelectionForm(parentMenuForm, curUser));
            }
            else
            {
                //pop the top most form from the formstack and load it
                parentMenuForm.LoadNextForm(formStack.Pop());
            }            
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the Tick event of the loadingTimer control. 
        //              This method makes the tableLayout visible when the timer ticks.
        private void loadingTimer_Tick(object sender, EventArgs e)
        {
            //make the table layout visible for display
            tableLayout.Visible = true;
        }
    }
}
