// Author: Liron Katsif
// File Name: ApiKeyQueue.cs
// Project Name: RecipeManager
// Creation Date: Dec 11, 2024
// Modified Date: Jan 14, 2025
// Description:  MealPlan class represents a plan for meals over a week.
//               It includes attributes for the plan name, daily calories, a weekly plan of meals, and provides methods to get and set these attributes.

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Json.Net;

namespace RecipeManager
{
    public class MealPlan
    {
        // Week days order constants
        public const int MONDAY_INDEX = 0;
        public const int TUESDAY_INDEX = 1;
        public const int WEDNESDAY_INDEX = 2;
        public const int THURSDAY_INDEX = 3;
        public const int FRIDAY_INDEX = 4;
        public const int SATURDAY_INDEX = 5;
        public const int SUNDAY_INDEX = 6;

        // Meal type constants
        public const int BREAKFAST_INDICATOR = 1;
        public const int LUNCH_INDICATOR = 2;
        public const int DINNER_INDICATOR = 3;

        // Generic constants
        public const int DAYS_PER_WEEK = 7;
        public const int MEALS_PER_DAY = 3;

        // Attributes of the MealPlan class
        private string planName;
        private int dailyCalories;      
        private Dictionary<int, DayPlan> weekPlan; //holds DayPlan for each day of week (sunday, monday, etc.,)

        // Pre: planName - The name of the meal plan.
        //      dailyCalories - The daily calorie limit for the meal plan.
        // Post: None
        // Description: Constructor for the MealPlan class that initializes the plan name, daily calories, and builds an empty weekly plan.
        public MealPlan(string planName, int dailyCalories) 
        {
            //set the mealplan attributes
            this.planName = planName;
            this.dailyCalories = dailyCalories;

            //call the build empty plan method to initizlize the dictionary
            BuildEmptyWeekPlan();
        }

        // Pre: None
        // Post: Returns the plan name attribute.
        // Description: Gets the name of the meal plan
        public string GetPlanName()
        {
            return this.planName;
        }

        // Pre: None
        // Post: Returns the daily calories attribute.
        // Description: Gets the daily calorie limit for the meal plan.
        public int GetDailyCalories()
        {
            return this.dailyCalories;
        }

        // Pre: None
        // Post: Returns the weekly plan attribute.
        // Description: Gets the weekly plan of meals.
        public Dictionary<int, DayPlan> GetWeekPlan()
        {
            return this.weekPlan;
        }

        // Pre: planName - The name of the meal plan to be set.
        // Post: None.
        // Description: Allows modification of the plan name.
        public void SetPlanName(string planName)
        {
            this.planName = planName;
        }

        // Pre: dailyCalories - The daily calorie limit to be set.
        // Post: None.
        // Description: Allows modification of the daily calorie limit.
        public void SetDailyCalories(int dailyCalories)
        {
            this.dailyCalories = dailyCalories;
        }

        // Pre: weekPlan - The weekly plan of meals to be set.
        // Post: None.
        // Description: Allows modification of the weekly plan of meals.
        public void SetWeekPlan(Dictionary<int, DayPlan> weekPlan)
        {
            this.weekPlan = weekPlan;
        }

        // Pre: None
        // Post: None.
        // Description: Builds an empty weekly plan with placeholders for each day of the week.
        private void BuildEmptyWeekPlan()
        {
            //init the weeklyplan dictionary
            Dictionary<int, DayPlan> weeklyPlan = new Dictionary<int, DayPlan>();

            //add a key and value for each day of the week
            weeklyPlan.Add(MONDAY_INDEX, new DayPlan());
            weeklyPlan.Add(TUESDAY_INDEX, new DayPlan());
            weeklyPlan.Add(WEDNESDAY_INDEX, new DayPlan());
            weeklyPlan.Add(THURSDAY_INDEX, new DayPlan());
            weeklyPlan.Add(FRIDAY_INDEX, new DayPlan());
            weeklyPlan.Add(SATURDAY_INDEX, new DayPlan());
            weeklyPlan.Add(SUNDAY_INDEX, new DayPlan());

            //set weekplan
            this.weekPlan = weeklyPlan;
        }

        // Pre: recipesList - A list of SpoonRecipe objects representing the recipes for the meals.
        //      mealIndicator - An integer indicating whether the meal is breakfast, lunch, or dinner.
        // Post: None.
        // Description: Iterates through the days of the week and assigns meals to each day based on the meal indicator.
        public void PopulateMeal(List<SpoonRecipe> recipesList, int mealIndicator)
        {
            //meal attributes
            DayPlan dayPlan;
            Meal meal;

            //iterate through days of week
            for (int i = 0; i < DAYS_PER_WEEK; i++)
            {
                //create the meal plan and update the dayplan based on the form attribute "weekPlan"
                dayPlan = weekPlan[i];
                meal = new Meal(recipesList[i], Convert.ToInt32(recipesList[i].GetCalorieAmount())); 

                //set the meal into the proper attribute - breakfast/lunch/dinner, based on the provided mealIndicator
                if (mealIndicator == BREAKFAST_INDICATOR)
                {
                    dayPlan.SetBreakfast(meal);
                } 
                else if (mealIndicator == LUNCH_INDICATOR)
                {
                    dayPlan.SetLunch(meal);
                }
                else
                {
                    dayPlan.SetDinner(meal);
                }                
            }
        }        
    }
}