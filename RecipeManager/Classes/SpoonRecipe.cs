// Author: Liron Katsif
// File Name: ApiKeyQueue.cs
// Project Name: RecipeManager
// Creation Date: Jan 1, 2025
// Modified Date: Jan 11, 2025
// Description:  SpoonRecipe class represents a recipe fetched from an external source (Spoon system) with additional attributes.
//               It includes attributes for the recipe ID, image, name, Weight Watcher points, health score, likes, price per serving, nutrition information, and servings, and provides methods to get specific nutrient amounts.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManager
{
    public class SpoonRecipe : Recipe
    {
        //invalid constant
        private int INVALID_VALUE = -1;

        // Pre: Id - The remote ID of the spoon recipe.
        // Post: Initializes a new instance of the SpoonRecipe class with the provided ID.
        // Description: Constructor for the SpoonRecipe class that initializes the ID.
        public SpoonRecipe(int Id)
        {
            this.Id = Id;
        }

        //Attributes populated by Spoon fetching api response
        [Newtonsoft.Json.JsonProperty("id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty("image")]
        public string Image { get; set; }

        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("weightWatcherSmartPoints")]
        public double WeightWatcherPoints { get; set; }

        [Newtonsoft.Json.JsonProperty("healthScore")]
        public double HealthScore { get; set; }

        [Newtonsoft.Json.JsonProperty("aggregateLikes")]
        public double Likes { get; set; }

        [Newtonsoft.Json.JsonProperty("pricePerServing")]
        public double PricePerServing { get; set; }

        [Newtonsoft.Json.JsonProperty("nutrition")]
        public Nutrition NutritionValue { get; set; }

        [Newtonsoft.Json.JsonProperty("servings")]
        public double Servings { get; set; }

        // Pre: None
        // Post: Returns the amount of protein in the recipe, if no value, returns by default -1.
        // Description: Gets the amount of protein from the nutrition information.
        public double GetProteinAmount()
        {
            return NutritionValue.GetProteinNutrient()?.Amount ?? INVALID_VALUE;
        }

        // Pre: None
        // Post: Returns the amount of calories in the recipe, if no value, returns by default -1.
        // Description: Gets the amount of calories from the nutrition information.
        public double GetCalorieAmount()
        {
            return NutritionValue.GetCalroieNutrient()?.Amount ?? INVALID_VALUE; 
        }

        // Pre: None
        // Post: Returns the amount of sugar in the recipe, if no value, returns by default -1.
        // Description: Gets the amount of sugar from the nutrition information.
        public double GetSugarAmount()
        {
            return NutritionValue.GetSugarNutrient()?.Amount ?? INVALID_VALUE;
        }

        // Pre: None
        // Post: Returns the amount of fat in the recipe, if no value, returns by default -1.
        // Description: Gets the amount of fat from the nutrition information.
        public double GetFatAmount()
        {
            return NutritionValue.GetFatNutrient()?.Amount ?? INVALID_VALUE;
        }        
    }
}
