// Author: Liron Katsif
// File Name: Recipe.cs
// Project Name: RecipeManager
// Creation Date: Dec 11, 2024
// Modified Date: Jan 4, 2025
// Description:  Recipe class represents a basic recipe, which is eventually extended by either SpoonRecipe or ManualRecipe.
//               It includes an attribute for the title and provides methods to get and set this attribute

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManager
{
    public class Recipe
    {
        //Title attributes populated by Spoon fetching api response, or by setting (if manual recipe)
        [Newtonsoft.Json.JsonProperty("title")]
        public string Title { get; set; }        
    }
}
