// Author: Liron Katsif
// File Name: OriginalIngredient.cs
// Project Name: RecipeManager
// Creation Date: Dec 27, 2024
// Modified Date: Jan 10, 2025
// Description: Class used to deserialize a response from the API. The Deserialized holds TODO

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManager
{
    public class OriginalIngredient
    {
        //Attribute populated by Spoon fetching api response, used for TODO
        [JsonProperty("original")]
        public string Original { get; set; }
    }
}
