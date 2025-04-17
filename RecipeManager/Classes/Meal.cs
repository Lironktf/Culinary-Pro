// Author: Liron Katsif
// File Name: Meal.cs
// Project Name: RecipeManager
// Creation Date: Dec 20, 2024
// Modified Date: Jan 12, 2025
// Description: The Meal class represents a meal consisting of a recipe and its associated calorie count.
//              It includes attributes for the recipe and calories, and provides methods to get and set these attributes.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManager
{
    public class Meal
    {
        // Attributes of the Meal class
        private Recipe recipe;
        private int calories;

        // Pre: recipe - The recipe for the meal.
        //      calories - The number of calories in the meal.
        // Post: None
        // Description: Constructor for the Meal class that initializes the recipe and calorie count.
        public Meal(Recipe recipe, int calories)
        {
            this.recipe = recipe;
            this.calories = calories;
        }

        // Pre: None
        // Post: Returns the recipe attribute.
        // Description: Gets the recipe for the meal.
        public Recipe GetRecipe()
        {
            return this.recipe;
        }

        // Pre: None
        // Post: Returns the calories attribute.
        // Description: Gets the number of calories in the meal.
        public int GetCalories() 
        {     
            return this.calories;
        }

        // Pre: recipe - The recipe for the meal to be set.
        // Post: None
        // Description: Allows modification of the recipe attribute.
        public void SetRecipe(Recipe recipe)
        {
            this.recipe = recipe;
        }

        // Pre: calories - The number of calories to be set.
        // Post: None
        // Description: Allows modification of the calorie count
        public void SetCalories(int calories)
        {
            this.calories = calories;
        }
    }
}
