// Author: Liron Katsif
// File Name: IngredientResponse.cs
// Project Name: RecipeManager
// Creation Date: Dec 15, 2024
// Modified Date: Jan 3, 2025
// Description: Class used to deserialize a response from the API. The Deserialized holds the Ingredients for a recipe

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManager
{
    public class IngredientResponse
    {
        //Attribute populated by Spoon fetching api response, used for ingredients
        [Newtonsoft.Json.JsonProperty("extendedIngredients")]
        public List<OriginalIngredient> Ingredients { get; set; }
    }
}
