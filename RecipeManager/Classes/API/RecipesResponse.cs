// Author: Liron Katsif
// File Name: RecipesResponse.cs
// Project Name: RecipeManager
// Creation Date: Dec 27, 2024
// Modified Date: Jan 11, 2025
// Description: Class used to deserialize a response from the API. The Deserialized holds a list of recipes

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManager
{
    public class RecipesResponse
    {

        //Attribute populated by Spoon fetching api response, used for TODO
        [Newtonsoft.Json.JsonProperty("results")]
        public List<SpoonRecipe> Recipes { get; set; }
    }
}
