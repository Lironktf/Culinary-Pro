// Author: Liron Katsif
// File Name: Nutrient.cs
// Project Name: RecipeManager
// Creation Date: Dec 27, 2024
// Modified Date: Jan 8, 2025
// Description:  Class used to deserialize a response from the API. The Deserialized holds nutrients name and amount

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManager
{
    public class Nutrient
    {
        //Attribute populated by Spoon fetching api response, used for name and amount of a nutrient
        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("amount")]
        public double Amount { get; set; }
    }
}
