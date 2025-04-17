// Author: Liron Katsif
// File Name: Nutrition.cs
// Project Name: RecipeManager
// Creation Date: Dec 27, 2024
// Modified Date: Jan 8, 2025
// Description: Class used to deserialize a response from the API. The Deserialized holds nutrients such as calories, protein, etc...

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManager
{
    public class Nutrition
    {
        //constants used for nutrient types. these are how these are called in the api deserialized response
        const string PROTEIN_ATTRIBUTE_NAME = "Protein";
        const string CALORIE_ATTRIBUTE_NAME = "Calories";
        const string SUGAR_ATTRIBUTE_NAME = "Sugar";
        const string FAT_ATTRIBUTE_NAME = "Fat";

        //Nutrients related attributes, populated by Spoon fetching api response
        [Newtonsoft.Json.JsonProperty("nutrients")]
        public List<Nutrient> Nutrients { get; set; }

        // Pre: None.
        // Post: Returns the Nutrient object representing protein if found, otherwise null.
        // Description: Searches the Nutrients list for a nutrient with the name "Protein" and returns the corresponding Nutrient object if found.
        public Nutrient? GetProteinNutrient()
        {
            return NutrientSearchHelper(PROTEIN_ATTRIBUTE_NAME);
        }

        // Pre: None.
        // Post: Returns the Nutrient object representing calories if found, otherwise null.
        // Description: Searches the Nutrients list for a nutrient with the name "Calories" and returns the corresponding Nutrient object if found.
        public Nutrient? GetCalroieNutrient()
        {
            return NutrientSearchHelper(CALORIE_ATTRIBUTE_NAME);
        }

        // Pre: None.
        // Post: Returns the Nutrient object representing sugar if found, otherwise null.
        // Description: Searches the Nutrients list for a nutrient with the name "Sugar" and returns the corresponding Nutrient object if found.
        public Nutrient? GetSugarNutrient()
        {
            return NutrientSearchHelper(SUGAR_ATTRIBUTE_NAME);
        }
        // Pre: None.
        // Post: Returns the Nutrient object representing fat if found, otherwise null.
        // Description: Searches the Nutrients list for a nutrient with the name "Fat" and returns the corresponding Nutrient object if found.
        public Nutrient? GetFatNutrient()
        {
            return NutrientSearchHelper(FAT_ATTRIBUTE_NAME);
        }

        // Pre: desiredNutrient - The name of the nutrient to search for in the Nutrients list.
        // Post: Returns the nullable Nutrient object if found, otherwise null.
        // Description: Searches the Nutrients list for a nutrient with the specified name and returns the corresponding Nutrient object if found.
        private Nutrient? NutrientSearchHelper(string desiredNutrient)
        {
            //iterate through number of nutrients attribute
            for (int i = 0; i < Nutrients.Count; i++)
            {
                //if the nutrient at the i'th position is equal to the desired one, return it
                if (Nutrients[i].Name == desiredNutrient)
                {
                    return Nutrients[i];
                }
            }
            //return base case of null (non found)
            return null;
        }
    }
}
