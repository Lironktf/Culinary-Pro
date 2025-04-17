// Author: Liron Katsif
// File Name: ApiKeyQueue.cs
// Project Name: RecipeManager
// Creation Date: Jan 4, 2025
// Modified Date: Jan 11, 2025
// Description:  User class represents a user with an userName, password, saved recipes, and meal plans.
//               It includes attributes for the userName, password, saved recipes list, and meal plans list, and provides methods to get and set these attributes.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManager
{
    public class User
    {

        // Attributes of the User 
        private string userName;
        private string password;
        private List<SavedRecipes> savedRecipesList;
        private List<MealPlan> mealPlansList;

        // Pre: userName - The userName of the user.
        //      password - The password of the user.
        // Post: Initializes a new instance of the User class with the provided userName and password.
        // Description: Constructor for the User class that initializes the userName and password, and creates empty lists for saved recipes and meal plans.
        public User(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
            this.savedRecipesList = new List<SavedRecipes>();
            this.mealPlansList = new List<MealPlan>();
        }

        // Pre: userName - The userName of the user.
        //      password - The password of the user.
        //      savedRecipesList - A list of saved recipes.
        //      mealPlansList - A list of meal plans.
        // Post: Initializes a new instance of the User class with the provided userName, password, saved recipes list, and meal plans list.
        // Description: Constructor for the User class that initializes the userName, password, saved recipes list, and meal plans list.
        public User(string userName, string password, List<SavedRecipes> savedRecipesList, List<MealPlan> mealPlansList)
        {
            this.userName = userName;
            this.password = password;
            this.savedRecipesList = savedRecipesList;
            this.mealPlansList = mealPlansList;
        }

        // Pre: None
        // Post: Returns the userName attribute.
        // Description: Gets the userName of the user.
        public string GetUserName()
        {
            return this.userName;
        }

        // Pre: None
        // Post: Returns the password attribute.
        // Description: Gets the password of the user.
        public string GetPassword()
        {
            return this.password;
        }

        // Pre: None
        // Post: Returns the saved recipes list attribute.
        // Description: Gets the list of saved recipes.
        public List<SavedRecipes> GetSavedRecipesList()
        {
            return this.savedRecipesList;
        }

        // Pre: None
        // Post: Returns the meal plans list attribute.
        // Description: Gets the list of meal plans.
        public List<MealPlan> GetMealPlansList()
        {
            return this.mealPlansList;
        }

        // Pre: userName - The userName to be set.
        // Post: None.
        // Description: Allows modification of the userName.
        public void SetUserName(string userName)
        {
            this.userName = userName;
        }

        // Pre: passwordkey - The password to be set.
        // Post: None.
        // Description: Allows modification of the password.
        public void SetPassword(string passwordkey)
        {
            this.password = passwordkey;
        }

        // Pre: savedRecipesList - The list of saved recipes to be set.
        // Post: None.
        // Description: Allows modification of the saved recipes list.
        public void SetSavedRecipesList(List<SavedRecipes> savedRecipesList)
        {
            this.savedRecipesList = savedRecipesList;
        }

        // Pre: mealPlansList - The list of meal plans to be set.
        // Post: None.
        // Description: Allows modification of the meal plans list.
        public void SetMealPlansList(List<MealPlan> mealPlansList)
        {
            this.mealPlansList = mealPlansList;
        }
    }
}
