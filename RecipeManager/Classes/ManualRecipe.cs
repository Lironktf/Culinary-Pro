// Author: Liron Katsif
// File Name: ManualRecipe.cs
// Project Name: RecipeManager
// Creation Date: Dec 11, 2025
// Modified Date: Jan 12, 2025
// Description:  ManualRecipe class represents a recipe that is manually created by the user.
//               It includes attributes for the recipe title, ingredients, and instructions, and provides methods to get and set these attributes.

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManager
{
    public class ManualRecipe : Recipe
    {

        // Attributes of the ManualRecipe class
        private List<string> ingredients;
        private List<string> instructions;

        // Pre: title - The title of the recipe.
        // Post: None
        // Description: Constructor for the ManualRecipe class that initializes the title and creates empty lists for ingredients and instructions.
        public ManualRecipe(string title)
        {
            //init recipe attributes 
            this.Title = title;
            this.ingredients = new List<string>();
            this.instructions = new List<string>();
        }

        // Pre: title - The title of the recipe.
        //      ingredients - The list of ingredients for the recipe.
        //      instructions - The list of instructions for the recipe.
        // Post: None
        // Description: Constructor for the ManualRecipe class that initializes the title, ingredients, and instructions.
        public ManualRecipe(string title, List<string> ingredients, List<string> instructions)
        {
            //init recipe attributes in loaded constructor
            this.Title = title;
            this.ingredients = ingredients;
            this.instructions = instructions;
        }

        // Pre: None
        // Post: Returns the list of ingredients.
        // Description: Gets the list of ingredients.
        public List<string> GetIngredients()
        {
            return ingredients;
        }

        // Pre: None
        // Post: Returns the list of instructions.
        // Description: Gets the list of instructions.
        public List<string> GetInstructions()
        {
            return instructions;
        }

        // Pre: ingredients - The list of ingredients to be set.
        // Post: None
        // Description: Allows modification of the ingredients list.
        public void SetIngredients(List<string> ingredients)
        {
            //set the ingredients
            this.ingredients = ingredients;
        }

        // Pre: instructions - The list of instructions to be set.
        // Post: None
        // Description: Allows modification of the instructions list.
        public void SetInstructions(List<string> instructions)
        {
            //set the instrucitons
            this.instructions = instructions;
        } 
    }
}
