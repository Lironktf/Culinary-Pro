// Author: Liron Katsif
// File Name: WholeStep.cs
// Project Name: RecipeManager
// Creation Date: Dec 28, 2024
// Modified Date: Jan 11, 2025
// Description: Class used to deserialize a response from the API. The Deserialized holds TODO

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManager
{
    public class WholeStep
    {
        //Attribute populated by Spoon fetching api response, used for TODO
        [JsonProperty("step")]
        public string Step { get; set; }
    }
}
