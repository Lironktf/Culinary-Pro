// Author: Liron Katsif
// File Name: RecipesDisplayForm.cs
// Project Name: RecipeManager
// Creation Date: Dec 18, 2024
// Modified Date: Jan 11, 2025
// Description: RecipesDisplayForm is built to display recipes, and allow sorting of them, and have capability to go back in stack

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using System.Reflection;
using System.CodeDom;

namespace RecipeManager
{
    public partial class RecipesDisplayForm : Form
    {
        // Class constants 
        const int INVALID_INDEX = -1;
        const int MAX_DISTANCE_FROM_BOTTOM = 50;

        //constants for sorting
        const int CALORIES_INDEX = 0;
        const int PRICE_INDEX = 1;
        const int LIKES_INDEX = 2;
        const int HEALTH_SCORE_INDEX = 3;
        const int WEIGHT_WATCHERS_INDEX = 4;
        const int PROTEIN_INDEX = 5;
        const int SUGAR_INDEX = 6;
        const int FAT_INDEX = 7;

        //constants for attributes of recipes. These are the names of the methods in the Recipe classes to get the quantaty of these nutrients
        const string WEIGHT_WATCHERS_ATTRIBUTE = "WeightWatcherPoints";
        const string HEALTH_SCORE_ATTRIBUTE = "HealthScore";
        const string PRICE_ATTRIBUTE = "PricePerServing";
        const string LIKES_ATTRIBUTE = "Likes";
        const string PROTEIN_ATTRIBUTE = "GetProteinAmount";
        const string CALORIE_ATTRIBUTE = "GetCalorieAmount";
        const string SUGAR_ATTRIBUTE = "GetSugarAmount";
        const string FAT_ATTRIBUTE = "GetFatAmount";

        //Form attributes
        List<Recipe> recipesOnForm = new List<Recipe>();
        FormsStack recipesStack;
        RecipeCard test = new RecipeCard();
        MainMenuForm parentMenuForm;

        bool isCallingMore = false;
        bool inDiscoverPage = false;


        // Pre: parentForm - The parent form that instantiated this form.
        //      recipesStack - The stack of forms for navigation.
        // Post: Initializes a new instance of the RecipesDisplayForm class with the provided parent form and recipes stack.
        // Description: Constructor for the RecipesDisplayForm class that initializes the parent form and recipes stack.
        public RecipesDisplayForm(MainMenuForm parentForm, FormsStack recipesStack)
        {
            //init the form, and set the form attributes
            InitializeComponent();
            this.parentMenuForm = parentForm;
            this.recipesStack = recipesStack;
            List<SpoonRecipe> recipesOnForm = new List<SpoonRecipe>();
        }

        // Pre: parentForm - The parent form that instantiated this form.
        //      inDiscoverPage - A boolean indicating whether the form is in discover page mode.
        // Post: Initializes a new instance of the RecipesDisplayForm class with the provided parent form and discover page mode.
        // Description: Constructor for the RecipesDisplayForm class that initializes the parent form and discover page mode.
        public RecipesDisplayForm(MainMenuForm parentForm, bool inDiscoverPage)
        {
            //init the form, and the form attributes
            InitializeComponent();
            this.parentMenuForm = parentForm;
            this.inDiscoverPage = inDiscoverPage;
            List<SpoonRecipe> recipesOnForm = new List<SpoonRecipe>();
            recipesStack = new FormsStack();
        }

        // Pre: isVisible - A boolean indicating whether the no result label should be visible.
        // Post: Sets the visibility of the no result label based on the provided boolean value.
        // Description: Controls the visibility of the no result label on the form.
        public void SetNoResultLabel(bool isVisible)
        {
            noResultsLabel.Visible = isVisible;
        }

        // Pre: recipesList - An optional list of recipes to display.
        //      recipesTuple - An optional list of tuples containing recipes and their associated values.
        //      clear - A boolean indicating whether to clear the current display before adding new recipes.
        // Post: Displays the provided recipes on the form.
        // Description: Adds the provided recipes to the form's layout panel for display.
        public void DisplayRecipes(List<Recipe> recipesList = null, List<(SpoonRecipe Recipe, double Value)> recipesTuple = null, bool shouldClear = false, bool addToFormList = true)
        {
            //if the shouldClear bool is true, clear the layoutpanel of any controls 
            if (shouldClear) layoutPanel.Controls.Clear();

            //if the passed recipe list isn't null (a recipe list is passed)
            if (recipesList != null)
            {
                //add to the recipesOnForm the recipesList passed, if specified to do so (not to do when viewing a list, as there the recipes don't change)
                if (addToFormList) recipesOnForm.AddRange(recipesList);

                //iterate through the recipes list
                foreach (var recipe in recipesList)
                {
                    //make a new recipe card control and add it to the display
                    RecipeCard curCard = new RecipeCard(recipe, parentMenuForm, this, recipesStack);
                    layoutPanel.Controls.Add(curCard);
                }
            }

            //if the recipesTuple isn't null (it was passed)
            if (recipesTuple != null)
            {
                //iterate through the recipes in the tuple
                foreach (var recipe in recipesTuple)
                {
                    //make a new recipe card control and add it to the display
                    RecipeCard curCard = new RecipeCard(recipe.Recipe, parentMenuForm, this, recipesStack);
                    layoutPanel.Controls.Add(curCard);
                }
            }
        }

        // Pre: shouldClear - A boolean indicating whether to clear the current display before fetching new recipes.
        // Post: Asynchronously fetches and displays recipes from the API.
        // Description: Sends a request to the API to fetch recipes and displays them on the form.
        private async Task FetchAndDisplayRecipesAsync(bool shouldClear)
        {
            //peek the current api key from the queue, and init the url
            string apiKey = ApiKeyQueue.Peek();
            string url = $"https://api.spoonacular.com/recipes/complexSearch?apiKey={apiKey}&sort=Random&number=10&addRecipeInformation=true&addRecipeNutrition=true";

            try
            {
                //using the http api client to make the call
                using (HttpClient client = new HttpClient())
                {
                    //make the request, and check if current key should be dequed
                    HttpResponseMessage response = await client.GetAsync(url);
                    ApiKeyQueue.DequeueIfFullyUsed(response);

                    //if the request was succesfull
                    if (response.IsSuccessStatusCode)
                    {
                        //deserialize the response
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        var result = Newtonsoft.Json.JsonConvert.DeserializeObject<RecipesResponse>(jsonResponse);

                        //if the result isn't null, and recipes list from the result aren't empty
                        if (result != null && result.Recipes.Count > 0)
                        {
                            //make a list of recipes (do this to cast the recipes to Recipe from SpoonRecipe), and display them
                            List<Recipe> recipesFromApi = result.Recipes.Cast<Recipe>().ToList();
                            DisplayRecipes(recipesFromApi, null, shouldClear);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        // Pre: sender - The source of the event.
        //      e - The MouseEventArgs containing event data.
        // Post: Asynchronously fetches and displays more recipes when the user scrolls near the bottom of the layout panel.
        // Description: Handles the MouseWheel event to load more recipes when the user scrolls near the bottom of the layout panel.
        private async void layoutPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            bool isAtBottomForm;
            Stopwatch stopWatch = new Stopwatch();

            //check if is in discover page (should only call more if thats the case)
            if (inDiscoverPage)
            {
                //init a VScrollProperties variable to later check how much have scrolled
                VScrollProperties vs = layoutPanel.VerticalScroll;

                //check if the distance from the bottom is small enough to recall more, and if isn't calling more (so doesn't trap the user in a recalling phase)
                if ((vs.Maximum - (vs.Value + vs.LargeChange) <= MAX_DISTANCE_FROM_BOTTOM) && !isCallingMore)
                {
                    //make the coverpanel visible, so it wouldn't appear like it's already sorted
                    coverPanel.Visible = true;

                    //set is calling more to true to signify that it is performing a call, and wouldn't do it again. Then call more recipes and set the isCallingMore to false later
                    isCallingMore = true;
                    await FetchAndDisplayRecipesAsync(false);
                    isCallingMore = false;
                }
            }
        }

        // Pre: sender - The source of the event.
        //      e - The EventArgs containing event data.
        // Post: Asynchronously fetches and displays recipes when the form loads.
        // Description: Handles the Load event to fetch and display recipes when the form is loaded.
        private async void RecipeDisplayForm_Load_1(object sender, EventArgs e)
        {
            //if in discover page, make the api call for the recipes
            if (inDiscoverPage)
            {
                await FetchAndDisplayRecipesAsync(true);
            }
        }

        // Pre: sender - The source of the event.
        //      e - The ScrollEventArgs containing event data.
        // Post: Asynchronously fetches and displays more recipes when the user scrolls near the bottom of the layout panel.
        // Description: Handles the Scroll event to load more recipes when the user scrolls near the bottom of the layout panel.
        private async void layoutPanel_Scroll(object sender, ScrollEventArgs e)
        {
            //check if is in discover page (should only call more if thats the case)
            if (inDiscoverPage)
            {
                //init a VScrollProperties variable to later check how much have scrolled
                VScrollProperties vs = layoutPanel.VerticalScroll;

                //check if the distance from the bottom is small enough to recall more, and if isn't calling more (so doesn't trap the user in a recalling phase)
                if ((vs.Maximum - (e.NewValue + vs.LargeChange) <= MAX_DISTANCE_FROM_BOTTOM) && !isCallingMore)
                {
                    //make the coverpanel visible, so it wouldn't appear like it's already sorted (there wouldn't be any sort criterion shown)
                    coverPanel.Visible = true;

                    //set is calling more to true to signify that it is performing a call, and wouldn't do it again. Then call more recipes and set the isCallingMore to false later
                    isCallingMore = true;
                    await FetchAndDisplayRecipesAsync(false);
                    isCallingMore = false;
                }
            }
        }

        // Pre: sender - The source of the event.
        //      e - The EventArgs containing event data.
        // Post: Sorts and displays recipes based on the selected criterion.
        // Description: Handles the SelectedIndexChanged event to sort and display recipes based on the selected criterion in the combo box.
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //init an empty string to later hold the selected criteria
            string sortByCriterion = "";

            //check if the selected index to sort is equivellent to which of the criteria. set the sortByCriterion string to this method name from the constants above
            if (sortByBox.SelectedIndex == CALORIES_INDEX)
            {
                sortByCriterion = CALORIE_ATTRIBUTE;
            }
            else if (sortByBox.SelectedIndex == PRICE_INDEX)
            {
                sortByCriterion = PRICE_ATTRIBUTE;
            }
            else if (sortByBox.SelectedIndex == LIKES_INDEX)
            {
                sortByCriterion = LIKES_ATTRIBUTE;
            }
            else if (sortByBox.SelectedIndex == HEALTH_SCORE_INDEX)
            {
                sortByCriterion = HEALTH_SCORE_ATTRIBUTE;
            }
            else if (sortByBox.SelectedIndex == WEIGHT_WATCHERS_INDEX)
            {
                sortByCriterion = WEIGHT_WATCHERS_ATTRIBUTE;
            }
            else if (sortByBox.SelectedIndex == PROTEIN_INDEX)
            {
                sortByCriterion = PROTEIN_ATTRIBUTE;
            }
            else if (sortByBox.SelectedIndex == SUGAR_INDEX)
            {
                sortByCriterion = SUGAR_ATTRIBUTE;
            }
            else if (sortByBox.SelectedIndex == FAT_INDEX)
            {
                sortByCriterion = FAT_ATTRIBUTE;
            }

            //init tuples (one to hold the unsorted values, and the other to hold the sorted) and a list (one that holds the manual recipes to seperate the spoon and manual recipes) to hold the sorted results
            List<(SpoonRecipe Recipe, double Value)> valueRecipeTuple = new List<(SpoonRecipe Recipe, double Value)>();
            List<(SpoonRecipe Recipe, double Value)> result = new List<(SpoonRecipe Recipe, double Value)>();
            List<Recipe> manualRecipes = new List<Recipe>();

            //init a type variable to enable reflection later on, and set it with the value of a SpoonRecipe
            Type type = typeof(SpoonRecipe);

            //iterate through the recipes on form currently
            for (int i = 0; i < recipesOnForm.Count; i++)
            {
                //check the type of recipe the current recipe is
                if (recipesOnForm[i] is SpoonRecipe spoonRecipe)
                {
                    //init a MemberInfo variable to figure out the type of member (a property or a method) of the sort criterion selected
                    MemberInfo memberInfo = type.GetMember(sortByCriterion).FirstOrDefault();

                    //init a null object to later hold the value from the response
                    object value = null;

                    //check if the sortbycriterion selected is a property or method in the SpoonRecipe class
                    if (memberInfo is PropertyInfo propertyInfo)
                    {
                        // It's a property, so use GetValue to retrieve the property value
                        value = propertyInfo.GetValue(spoonRecipe);
                    }
                    else if (memberInfo is MethodInfo methodInfo)
                    {
                        // It's a method, so invoke it to retrieve the method value
                        value = methodInfo.Invoke(spoonRecipe, new object[0]);
                    }

                    //add to the unsorted tuple the spoonrecipe and the value acquired through the reflection above
                    valueRecipeTuple.Add((spoonRecipe, Convert.ToDouble(value)));
                }
                else
                {
                    //add it to manual recipes list
                    manualRecipes.Add(recipesOnForm[i]);
                }
            }

            //store the sort results in the sorted tuple, and then display the recipes
            result = MergeSort(valueRecipeTuple, 0, valueRecipeTuple.Count - 1);
            DisplayRecipes(manualRecipes, result, true, false);

        }

        // Pre: vals - A tuples of SpoonRecipe and a double value containing recipes and their associated values.
        //      left - The starting index of the tuple to sort.
        //      right - The ending index of the tuple to sort.
        // Post: Returns a sorted tuple of SpoonRecipe and a double value, which means containing recipes and their associated values.
        // Description: Performs a merge sort on the provided tuple to sort them in ascending order based on their values.
        private List<(SpoonRecipe Recipe, double Value)> MergeSort(List<(SpoonRecipe Recipe, double Value)> vals, int left, int right)
        {
            int mid;

            //Base Cases of 0 or 1 elements
            if (left > right)
            {
                //No element so return a null result
                return null;
            }
            else if (left == right)
            {
                //Return the 1 element as a tuple of 1
                return new List<(SpoonRecipe Recipe, double Value)> { (vals[left].Recipe, vals[left].Value) };
            }

            //Calculated the midpoint between the two given end points
            mid = (left + right) / 2;

            //Merge the two sorted halves
            return Merge(MergeSort(vals, left, mid), MergeSort(vals, mid + 1, right));
        }

        // Pre: left - A sorted tuple containing recipes and their associated values.
        //      right - A sorted tuple containing recipes and their associated values.
        // Post: Returns a merged and sorted tuple containing recipes and their associated values.
        // Description: Merges two sorted tuples into a single sorted list.
        private List<(SpoonRecipe Recipe, double Value)> Merge(List<(SpoonRecipe Recipe, double Value)> left, List<(SpoonRecipe Recipe, double Value)> right)
        {
            //Base Case 0: the left array has no elements, return the right array automatically
            //Similarly for the right array
            if (left == null)
            {
                return right;
            }
            else if (right == null)
            {
                return left;
            }

            //calculate the total length
            int totalLength = left.Count + right.Count;

            //Create a new tuple of size equal to the sum of the lengths of the two given arrays
            List<(SpoonRecipe Recipe, double Value)> result = new List<(SpoonRecipe Recipe, double Value)>(totalLength);

            //integers pointing to the currently considered element of each given tuple
            int idx1 = 0;
            int idx2 = 0;

            //For each element in the merged tuple, get the next 
            //smallest element between the two given tuples
            for (int i = 0; i < totalLength; i++)
            {
                if (idx1 == left.Count)              //The left tuple is already merged
                {
                    result.Add(right[idx2]);
                    idx2++;
                }
                else if (idx2 == right.Count)        //The right tuple is already merged
                {
                    result.Add(left[idx1]);
                    idx1++;
                }
                else if (left[idx1].Value <= right[idx2].Value)   //The left element is smaller than the right
                {
                    result.Add(left[idx1]);
                    idx1++;
                }
                else                                  //The right element is smaller than the right
                {
                    result.Add(right[idx2]);
                    idx2++;
                }
            }

            //Return the merged and sorted array
            return result;
        }

        // Pre: sender - The source of the event.
        //      e - The EventArgs containing event data.
        // Post: Navigates back to the previous form.
        // Description: Handles the Click event to navigate back to the previous form in the stack.
        private void backImageButton_Click(object sender, EventArgs e)
        {
            //load the previous form from the stack
            parentMenuForm.LoadNextForm(recipesStack.Pop());
        }

        // Pre: sender - The source of the event.
        //      e - The MouseEventArgs containing event data.
        // Post: Changes the text color of the sort by combo box when clicked.
        // Description: Handles the MouseClick event to change the text color of the sort by combo box when it is clicked.
        private void sortByBox_MouseClick(object sender, MouseEventArgs e)
        {
            //make the coverPanel visiblity off, as the user is now focused on it
            coverPanel.Visible = false;
        }

        // Pre: sender - The source of the event.
        //      e - The MouseEventArgs containing event data.
        // Post: sets focus on the combo box
        // Description: Handles the MouseClick event to change the focus on the screen to the combo box
        private void coverPanel_MouseClick(object sender, MouseEventArgs e)
        {
            //make it appear that the user has pressed on the combobox and not a panel
            coverPanel.Visible = false;
            sortByBox.Focus();
            sortByBox.DroppedDown = true;
        }
    }
}
