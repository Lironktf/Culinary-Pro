// Author: Liron Katsif
// File Name: MealsIO.cs
// Project Name: RecipeManager
// Creation Date: Dec 10, 2024
// Modified Date: Jan 12, 2025
// Description: MealsIO class handles the input and output operations related to meal plans. 
//              It includes methods to save and load meal plans for a user, build file content for meal plans, and parse file content to reconstruct meal plans.
//              The class utilizes various helper methods to build and parse lines representing meal plans, and daily meals.

using System.Diagnostics;
using System.Text;
namespace RecipeManager
{
    public class MealsIO
    {
        //prefixes used to define meals.txt structure
        private const string MEAL_PLAN_PREFIX = "_weekly_plan_:";
        private const string DAY_PREFIX = "_day_plan_:";

        //weekly meal plan line indexes
        private const int MEAL_PLAN_LINE_INDX = 0;
        private const int FIRST_MEAL_MONDAY_BREAKFAST_INDX = 2; 
        private const int NR_OF_LINES_FOR_SINGLE_DAY = 4; 

        //day plan lines indexes
        private const int BREAKFAST_LINE_INDX = 0;
        private const int LUNCH_LINE_INDX = 1;
        private const int DINNER_LINE_INDX = 2;

        //meal plan line attributes indexes
        private const int PLAN_NAME_INDX = 0;
        private const int DAILY_CALORIES_INDX = 1;

        //meal attributes indexes, used to read/write from the file
        private const int RECIPE_INDX = 0;
        private const int CALORIES_INDX = 1;

        // Attribute of the MealsIO class
        private RecipesIO ioRecipes;

        // Pre: None
        // Post: None.
        // Description: Constructor for the MealsIO class that initializes the RecipesIO instance and sets up constants for meal plan file operations.
        public MealsIO()
        {
            ioRecipes = new RecipesIO();
        }

        // Pre: currentUser - The current user whose meal plans are to be saved.
        // Post: None.
        // Description: Iterates through the user's meal plans, builds the file content, and writes it to a file.
        public void SaveMeals(User currentUser)
        {
            //meals to be saved and initialize StringBuilder to construct file content.
            List<MealPlan> mealPlans = currentUser.GetMealPlansList();
            StringBuilder sb = new StringBuilder();

            //for each MealPlan, translates it content into string in predefined structure
            for (int i = 0; i < mealPlans.Count; i++)
            {
                //for first meal plan, no need to go down
                if (i > 0)
                {
                    sb.AppendLine();
                }
                MealPlan mealPlan = mealPlans[i];

                //build "header" line that represents the meal plan: MEAL_PLAN_PREFIX + plan name 
                BuilPlanLine(sb, mealPlan);                

                //for each day of week, build struture (multiple lines) that holds the details of that day's meals
                BuildWeekPlanLines(sb, mealPlan);
            }

            //meals are saved in Meals.txt file, located under io/currentUser.GetUserName() directory
            Utils.WriteToFile(sb, currentUser, Utils.MEALS_FILE_NAME, "Meal Plans");
        }

        // Pre: sb - The StringBuilder to which the meal plan line is to be added.
        //      mealPlan - The meal plan whose details are to be added.
        // Post: None.
        // Description: Builds a line representing the meal plan and appends it to the StringBuilder. 
        // Example of created line:
        //      _weekly_plan_:First Plan,,,2500,,,;;;
        // It replresents plan that is called "First Plan", with daily caliries set to 2500.
        private void BuilPlanLine(StringBuilder sb, MealPlan mealPlan)
        {
            //appends MEAL_PLAN_PREFIX followed by plan name and daily caliries
            sb.Append(MEAL_PLAN_PREFIX);
            string planBasicAttributes = Utils.BuildAttributes([mealPlan.GetPlanName(), mealPlan.GetDailyCalories()]);
            Utils.AddItem(sb, planBasicAttributes);
        }

        // Pre: sb - The StringBuilder to which the week plan lines are to be added.
        //      mealPlan - The meal plan whose week plan is to be added.
        // Post: None.
        // Description: Builds lines representing the week plan and appends them to the StringBuilder.
        private void BuildWeekPlanLines(StringBuilder sb, MealPlan mealPlan)
        {
            //iterate through day plans in week plan
            foreach (var item in mealPlan.GetWeekPlan())
            {
                //init variable relevent to day
                int dayOfWeek = item.Key;
                DayPlan dayPlan = item.Value;

                //for each day of week, build struture (multiple lines) that holds the details of that day's meals
                BuildDayPlanLines(sb, dayOfWeek, dayPlan);
            }
        }

        // Pre: sb - The StringBuilder to which the day plan lines are to be added.
        //      dayOfWeek - The day of the week for which the plan is to be added.
        //      dayPlan - The day plan whose details are to be added.
        // Post: None.
        // Description: Builds lines representing the day plan and appends them to the StringBuilder.
        // Example of a single Daily Plan as string: 
        //      _day_plan_:0
        //      _S:647201,,,750,,,;;;
        //      _S:660407,,,1000,,,;;;
        //      _S:640414,,,750,,,;;;
        // It represents daily plan for Monday (MealPlan.MONDAY_INDEX). 
        // Breakfast - recipe id 647201, calories: 750
        // Breakfast - recipe id 660407, calories: 1000
        // Breakfast - recipe id 640414, calories: 750
        private void BuildDayPlanLines(StringBuilder sb, int dayOfWeek, DayPlan dayPlan)
        {
            //append the stringbuilder with relevent information for day plan
            sb.AppendLine();
            sb.Append(DAY_PREFIX);
            sb.Append(dayOfWeek);

            //add the different meal details
            BuildMealLine(sb, dayPlan.GetBreakfast());
            BuildMealLine(sb, dayPlan.GetLunch());
            BuildMealLine(sb, dayPlan.GetDinner());
        }

        // Pre: sb - The StringBuilder to which the meal line is to be added.
        //      meal - The meal whose details are to be added.
        // Post: None.
        // Description: Builds a line representing the meal and appends it to the StringBuilder.
        private void BuildMealLine(StringBuilder sb, Meal meal)
        {
            sb.AppendLine();

            //meal plan is only combined from spoon recepies
            string recipe = ioRecipes.BuildSpoonRecipeItem((SpoonRecipe) meal.GetRecipe());

            // add spoon recipe and meal's calories to the buffer
            string mealItem = Utils.BuildAttributes([recipe, meal.GetCalories()]);
            Utils.AddItem(sb, mealItem);
        }

        // Pre: currentUser - The current user whose meal plans are to be loaded.
        // Post: Returns a list of meal plans for the user.
        // Description: Loads the user's meal plans from a file and returns them as a list.
        public List<MealPlan> LoadUserMealPlans(User currentUser)
        {
            //init new meal plan to load meal plans, and later return
            List<MealPlan> mealPlans = new List<MealPlan>();
            try
            {
                //load data from Meals.txt file - each user has its own meals file, located under io/currentUser.GetUserName() directory
                string fileContent = Utils.GetFileContent(currentUser, Utils.MEALS_FILE_NAME);

                //check that the file content isnt empty
                if (fileContent != "")
                {
                    //split the content by MEAL_PLAN_PREFIX, this way each meal plan (combined from multiple lines) can be handled separatelly
                    string[] mealPlansStr = fileContent.Split(MEAL_PLAN_PREFIX);

                    //iterate through each meal plan in the split meal plans string
                    for (int i = 0; i < mealPlansStr.Length; i++)
                    {
                        //string to hold current meal plan
                        string mealPlanStr = mealPlansStr[i];

                        //check if the string is empty
                        if (!mealPlanStr.Equals(""))
                        {
                            //for each meal plan, split it into separate lines and load the data into MealPlan object
                            string[] mealPlanLines = mealPlanStr.Split(new[] { Environment.NewLine }, StringSplitOptions.None); 
                            MealPlan mealPlan = LoadMealPlan(mealPlanLines);
                            mealPlans.Add(mealPlan);
                        }
                    }
                }
            }
            catch (FileNotFoundException fnfEx) 
            {
                MessageBox.Show($"File not found: {fnfEx.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}");
            }

            //return the newly loaded meal plan
            return mealPlans;
        }

        // Pre: mealPlanLines - The lines representing the meal plan.
        // Post: Returns a MealPlan object constructed from the provided lines.
        // Description: Parses lines representing a meal plan and constructs a MealPlan object.
        private MealPlan LoadMealPlan(string[] mealPlanLines)
        {
            //store current meal plan
            string planLine = mealPlanLines[MEAL_PLAN_LINE_INDX];

            //load plan header, that looks like that: _weekly_plan_:First Plan,,,2500,,,;;;
            MealPlan mealPlan = LoadMealPlanLine(planLine);

            int currentLine = FIRST_MEAL_MONDAY_BREAKFAST_INDX; //first meal's monday's breakfast start at third line, immediatelly after plan name and day header 

            //iterate through days of week
            for (int i = 0; i < 7; i++)
            {
                //create the lines for each meal
                string breakfastLine = mealPlanLines[currentLine + BREAKFAST_LINE_INDX];
                string lunchLine = mealPlanLines[currentLine + LUNCH_LINE_INDX];
                string dinnerLine = mealPlanLines[currentLine + DINNER_LINE_INDX];

                //load the currentl day plan, and increment current line
                LoadDayPlan(breakfastLine, lunchLine, dinnerLine, i, mealPlan);
                currentLine = currentLine + NR_OF_LINES_FOR_SINGLE_DAY; //each day is 4 lines, next day is in 4 lines
            }
            return mealPlan;
        }

        // Pre: breakfastLine - The line representing the breakfast meal.
        //      lunchLine - The line representing the lunch meal.
        //      dinnerLine - The line representing the dinner meal.
        //      dayIndex - The index of the day in the week plan.
        //      mealPlan - The meal plan to which the day plan is to be added.
        // Post: None.
        // Description: Parses lines representing meals and constructs a DayPlan object, then adds it to the meal plan's week plan.
        private void LoadDayPlan(string breakfastLine, string lunchLine, string dinnerLine, int dayIndex, MealPlan mealPlan)
        {
            //build the different Meals based on recived string line
            Meal breakfast = LoadMeal(breakfastLine);            
            Meal lunch = LoadMeal(lunchLine);
            Meal dinner = LoadMeal(dinnerLine);

            //make a new day plan, and pass the meals. then update the week plan with this object
            DayPlan dayPlan = new DayPlan(breakfast, lunch, dinner);
            mealPlan.GetWeekPlan()[dayIndex] = dayPlan;
        }

        // Pre: mealStr - The string representing the meal.
        // Post: Returns a Meal object constructed from the provided string.
        // Description: Parses a string representing a meal and constructs a Meal object.
        private Meal LoadMeal(string mealStr)
        {
            //split the meal string passed, which is a string representing the meal
            string[] attributes = mealStr.Split(Utils.ATTRIBUTES_SEPARATOR);

            //split meal line into recipe id and calories
            string recipeStr = attributes[RECIPE_INDX];
            int calories = Convert.ToInt32(attributes[CALORIES_INDX]);

            //go to RecipesIO and load recipe
            Recipe recipe = ioRecipes.LoadRecipe(recipeStr);
            Meal meal = new Meal(recipe, calories);

            //return the new meal
            return meal;
        }

        // Pre: planLine - The line representing the "header" of the meal plan - holds plan name anddaily calirties without actual daily plan).
        // Post: Returns a MealPlan object constructed from the provided line.
        // Description: Parses the first line of the meal plan and constructs a MealPlan object.
        private MealPlan LoadMealPlanLine(string planLine)
        {
            //remove and seperating things
            string simpleAttributes = Utils.RemovePrefixAndSufix(planLine, null, Utils.ATTRIBUTES_AND_ITEM_SEPARATOR_LENGTH);

            //split meal line into plan name and calories
            string[] attributes = simpleAttributes.Split(Utils.ATTRIBUTES_SEPARATOR);

            //load plane name and calories
            string planName = attributes[PLAN_NAME_INDX];
            int dailyCalories = Convert.ToInt32(attributes[DAILY_CALORIES_INDX]);

            //build plan based on the attributes extracted from the line, and return it
            MealPlan plan = new MealPlan(planName, dailyCalories);
            return plan;
        }
    }
}
