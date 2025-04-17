// Author: Liron Katsif
// File Name: FitnessGoalsForm.cs
// Project Name: RecipeManager
// Creation Date: Jan 4, 2025
// Modified Date: Jan 11, 2025
// Description: FitnessGoalsForm represents a form for setting fitness goals in the RecipeManager application.
//              It includes attributes for user inputs such as gender, weight, height, age, and activity level, and provides methods to calculate the daily caloric intake based on these inputs and set it in the previous form.

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
    public partial class FitnessGoalsForm : Form
    {

        // FitnessGoalsForm Class constants 
        const int INVALID_VALUE = -1;
        private static readonly double[] ACTIVITY_MULTIPLIER_LEVELS = { 1.2, 1.375, 1.55, 1.725, 1.9, 2.3 };

        //male calorie calculation constants
        private const double MALE_BASE_CALORIE = 66.5;
        private const double MALE_WEIGHT_MULTIPLIER = 13.75;
        private const double MALE_HEIGHT_MULTIPLIER = 5.003;
        private const double MALE_AGE_MULTIPLIER = 6.75;

        //female calorie calculation constants
        const double FEMALE_BASE_CALORIE = 655.1;
        const double FEMALE_WEIGHT_MULTIPLIER = 9.563;
        const double FEMALE_HEIGHT_MULTIPLIER = 1.850;
        const double FEMALE_AGE_MULTIPLIER = 4.676;

        // Attributes of the FitnessGoalsForm class
        MealPlanSelectionForm previousForm;

        // Pre: previousForm - The previous form to be returned to after setting fitness goals.
        // Post: None.
        // Description: Constructor for the FitnessGoalsForm class that initializes the form and sets the previous form.
        public FitnessGoalsForm(MealPlanSelectionForm previousForm)
        {
            //init form components, and set the previous form
            InitializeComponent();
            this.previousForm = previousForm;
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the click event for the calculate button, calculates the daily caloric intake based on user inputs, and sets it in the previous form.
        private void button1_Click(object sender, EventArgs e)
        {
            //check that all required fields are filled out
            if (genderBox.SelectedIndex != INVALID_VALUE && weightBox.Value != 0 && heightBox.Value != 0 && ageBox.Value != 0 || activityLevelBox.SelectedIndex != INVALID_VALUE)
            {
                //set the calories for previous form, hide current form, and set missing label to false
                missingFieldsLabel.Visible = false;
                previousForm.SetDailyCaloricIntake(CalculateDailyCalories());
                this.Hide();
            }
            else
            {
                //do nothing other than set missing label to on
                missingFieldsLabel.Visible = true;
            }
        }

        // Pre: None
        // Post: Returns the calculated daily caloric intake based on user inputs.
        // Description: Calculates the daily caloric intake using the Harris-Benedict equation and the selected activity level.
        private double CalculateDailyCalories()
        {
            //init calories variable
            double dailyCalorie;

            //check the gender of the user
            if (genderBox.Text == "Male")
            {
                //do male claorie calculation
                dailyCalorie = Math.Round(
                MALE_BASE_CALORIE +
                (MALE_WEIGHT_MULTIPLIER * Convert.ToDouble(weightBox.Value)) +
                (MALE_HEIGHT_MULTIPLIER * Convert.ToDouble(heightBox.Value)) -
                (MALE_AGE_MULTIPLIER * Convert.ToDouble(ageBox.Value)), 1);
            }
            else
            {
                //do female calorie calculations
                dailyCalorie = Math.Round(
                FEMALE_BASE_CALORIE +
                (FEMALE_WEIGHT_MULTIPLIER * Convert.ToDouble(weightBox.Value)) +
                (FEMALE_HEIGHT_MULTIPLIER * Convert.ToDouble(heightBox.Value)) -
                (FEMALE_AGE_MULTIPLIER * Convert.ToDouble(ageBox.Value)), 1);
            }

            //return calories multiplied by activity level
            return dailyCalorie * SelectActivityValue();
        }

        // Pre: None
        // Post: Returns the activity multiplier value based on the selected activity level.
        // Description: Retrieves the activity multiplier value from the predefined levels based on the selected index in the activity level combo box.
        private double SelectActivityValue()
        {
            //gets the selected index, and return this index from the readonly constant array
            int selectedIndex = activityLevelBox.SelectedIndex;
            return ACTIVITY_MULTIPLIER_LEVELS[selectedIndex];
        }
    }
}
