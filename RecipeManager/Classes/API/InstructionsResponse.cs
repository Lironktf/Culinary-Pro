// Author: Liron Katsif
// File Name: InstructionsResponse.cs
// Project Name: RecipeManager
// Creation Date: Dec 15, 2024
// Modified Date: Jan 2, 2025
// Description: Class used to deserialize a response from the API. The Deserialized holds the instructions for a recipe, which is later used in RecipeInfoForm

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManager
{
    public class InstructionsResponse
    {
        //Attribute populated by Spoon fetching api response, used for instructions
        [Newtonsoft.Json.JsonProperty("steps")]
        public List<WholeStep> Instructions { get; set; }
    }
}
