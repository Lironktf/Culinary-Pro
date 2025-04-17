// Author: Liron Katsif
// File Name: DayPlan.cs
// Project Name: RecipeManager
// Creation Date: Dec 17, 2024
// Modified Date: Jan 11, 2025
// Description: DayPlan class represents a plan for meals for a single day.
//              It includes attributes for breakfast, lunch, and dinner meals, and provides methods to get and set these meals.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManager
{
    public class DayPlan
    {
        // Attributes of the DayPlan class
        private Meal breakfast;
        private Meal lunch;
        private Meal dinner;

        // Pre: None
        // Post: None
        // Description: Default constructor for the DayPlan class.
        public DayPlan()
        {
        }

        // Pre: breakfast - The breakfast meal to be set.
        //      lunch - The lunch meal to be set.
        //      dinner - The dinner meal to be set.
        // Post: None
        // Description: Constructor for the DayPlan class that initializes the breakfast, lunch, and dinner meals.
        public DayPlan(Meal breakfast, Meal lunch, Meal dinner)
        {
            //inititate meal attributes with passed Meals
            this.breakfast = breakfast;
            this.lunch = lunch;
            this.dinner = dinner;
        }

        // Pre: None
        // Post: Returns the breakfast meal attribute.
        // Description: Gets the breakfast meal.
        public Meal GetBreakfast()
        {
            return this.breakfast;
        }

        // Pre: breakfast - The breakfast meal to be set.
        // Post: None
        // Description: Allows modification of the breakfast attribute.
        public void SetBreakfast(Meal breakfast)
        {
            this.breakfast = breakfast;
        }

        // Pre: None
        // Post: Returns the lunch meal attribute.
        // Description: Gets the lunch meal.
        public Meal GetLunch()
        {
            return this.lunch;
        }

        // Pre: lunch - The lunch meal to be set.
        // Post: None
        // Description: Allows modification of the lunch attribute.
        public void SetLunch(Meal lunch)
        {
            this.lunch = lunch;
        }

        // Pre: None
        // Post: Returns the dinner meal attribute.
        // Description: Gets the dinner meal.
        public Meal GetDinner()
        {
            return this.dinner;
        }

        // Pre: dinner - The dinner meal to be set.
        // Post: None
        // Description:  Allows modification of the dinner attribute.
        public void SetDinner(Meal dinner)
        {
            this.dinner = dinner;
        }
    }
}
