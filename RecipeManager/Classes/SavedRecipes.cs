// Author: Liron Katsif
// File Name: SavedRecipes.cs
// Project Name: RecipeManager
// Creation Date: Jan 2, 2025
// Modified Date: Jan 13, 2025
// Description:  SavedRecipes class represents a collection of recipes saved by a user.
//               It includes attributes for the list name and the list of recipes, and provides methods to get and set these attributes.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManager
{
    public class SavedRecipes
    {
        // Attributes of the SavedRecipes class
        private string listName;
        private List<Recipe> recipes;

        // Pre: listName - The name of the saved recipes list.
        // Post: None.
        // Description: Constructor for the SavedRecipes class that initializes the list name and creates an empty list of recipes.
        public SavedRecipes(string listName)
        {
            this.listName = listName;
            this.recipes = new List<Recipe>();
        }

        // Pre: listName - The name of the saved recipes list.
        //      recipes - A list of recipes to be saved.
        // Post: None.
        // Description: Constructor for the SavedRecipes class that initializes the list name and the list of recipes.
        public SavedRecipes(string listName, List<Recipe> recipes)
        {
            this.listName = listName;
            this.recipes = recipes;
        }

        // Pre: None
        // Post: Returns the list name attribute.
        // Description: Gets the name of the saved recipes list.
        public string GetListName()
        {  
            return this.listName; 
        }

        // Pre: None
        // Post: Returns the list of recipes attribute.
        // Description: Gets the list of saved recipes.
        public List<Recipe> GetRecipesList() 
        {
            return this.recipes; 
        }

        // Pre: listName - The name of the saved recipes list to be set.
        // Post: None.
        // Description: Allows modification of the list name.
        public void SetListName(string listName)
        {
            this.listName = listName;
        }

        // Pre: recipes - The list of recipes to be set.
        // Post: None.
        // Description: Allows modification of the list of recipes.
        public void SetRecipes(List<Recipe> recipes)
        {
            this.recipes = recipes;
        }
    }
}
