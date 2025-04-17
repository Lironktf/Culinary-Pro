// Author: Liron Katsif
// File Name: RecipeCard.cs
// Project Name: RecipeManager
// Creation Date: Dec 17, 2024
// Modified Date: Jan 11, 2025
// Description:  RecipeCard class represents a user control that displays a recipe card with detailed information.
//               It includes attributes for the current recipe, the parent menu form, the previous display form, and a stack of forms.
//               The class provides methods to load the recipe card, handle user interactions, and navigate to the recipe information form.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Security.Policy;


namespace RecipeManager
{
    public partial class RecipeCard : UserControl
    {
        // Class constants
        const string PREFFERED_RESOLUTION = "-240x150.jpg";
        const char SLASH_CHAR = '/';
        const char HYPHEN_CHAR = '-';

        // Attributes of the RecipeCard class
        private Recipe curRecipe;
        private MainMenuForm parentMenuForm;
        private Form previousDisplayForm;
        FormsStack recipesStack;

        //colour attributes, used for changing colour based on where the mouse is
        private Color originalBackColor;
        private Color darkColor = Color.FromArgb(50, 50, 50);

        // Pre: None
        // Post: None.
        // Description: Default constructor for the RecipeCard class.
        public RecipeCard()
        {
            //init the form
            InitializeComponent();
        }

        // Pre: curRecipe - The current recipe to display on the card.
        //      parentMenuForm - The parent menu form that contains this card.
        //      previousDisplayForm - The form that was displayed before this card.
        //      recipesStack - The stack of forms for navigation.
        // Post: None.
        // Description: Constructor for the RecipeCard class that initializes the card with the provided recipe and form references.
        public RecipeCard(Recipe curRecipe, MainMenuForm parentMenuForm, Form previousDisplayForm, FormsStack recipesStack)
        {
            //init the form and set the form's attributes
            InitializeComponent();
            this.curRecipe = curRecipe;
            this.previousDisplayForm = previousDisplayForm;
            this.recipesStack = recipesStack;
            this.parentMenuForm = parentMenuForm;

            //check if the current recipe is a SpoonRecie
            if (curRecipe is SpoonRecipe spoonRecipe)
            {
                //check if the image for this recipe isn't null
                if (spoonRecipe.Image != null)
                {
                    try
                    {
                        //load the image to pictureBox, and set the resoloution to reduced
                        recipeImage.Load(ReduceImageRes(spoonRecipe.Image)); 
                    }
                    catch
                    {
                        //if the try didn't work, than don't reduce the resolotion
                        recipeImage.Load(spoonRecipe.Image);
                    }
                }
            }

            //configure the drawing and display styles of the control
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);

            //set the name of the current recipe into the label
            recipeNameLabel.Text = curRecipe.Title; 
        }

        // Pre: imageUrl - The URL of the image to reduce the resolution of.
        // Post: Returns a new URL with the preferred resolution.
        // Description: Modifies the provided image URL to use a lower resolution.
        private string ReduceImageRes(string imageUrl)
        {
            // Find the indices of the chars
            int lastSlashIndex = imageUrl.LastIndexOf(SLASH_CHAR);
            int firstHyphenIndex = imageUrl.IndexOf(HYPHEN_CHAR, lastSlashIndex);

            //remove after the index of the firstHyphen
            imageUrl = imageUrl.Remove(firstHyphenIndex);

            //update the image resoloution with the preffered one
            imageUrl += PREFFERED_RESOLUTION;

            //return the new image url
            return imageUrl;
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the load event for the RecipeCard control.
        private void RecipeCard_Load_1(object sender, EventArgs e)
        {
            //set the original back color, and center the name label
            originalBackColor = this.BackColor;
            CenterLabel(recipeNameLabel);
        }

        // Pre: e - A PaintEventArgs that contains the event data.
        // Post: None.
        // Description: Handles the paint event for the RecipeCard control and draws a rounded rectangle.
        protected override void OnPaint(PaintEventArgs e)
        {
            // Call the base class OnPaint method
            base.OnPaint(e);

            // Create a new GraphicsPath object to define the rounded rectangle
            using (GraphicsPath path = new GraphicsPath())
            {
                //set the required corner radius of the MinimalRecipeCard control 
                int radius = 40;

                //apend the 4 courners of the control
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(Width - radius, Height - radius, radius, radius, 0, 90);
                path.AddArc(0, Height - radius, radius, radius, 90, 90);

                // Close the path to form a complete shape
                path.CloseAllFigures();

                // Set the region of the control to the rounded rectangle
                this.Region = new Region(path);
            }

            // Create a SolidBrush object for drawing the text
            SolidBrush drawBrush = new SolidBrush(ForeColor);

            // Draw the text on the control
            e.Graphics.DrawString(Text, Font, drawBrush, 0f, 0f);
        }

        // Pre: sender - The source of the event.
        //      e - A MouseEventArgs that contains the event data.
        // Post: None.
        // Description: Handles the mouse click event for the RecipeCard control and navigates to the RecipeInfoForm.
        private void RecipeCard_MouseClick(object sender, MouseEventArgs e)
        {
            // creates a new instance of the recipe information form
            RecipeInfoForm newForm = new RecipeInfoForm(curRecipe, previousDisplayForm, parentMenuForm);

            //pushes it on stack, and loads the next form
            recipesStack.Push(newForm);
            parentMenuForm.LoadNextForm(newForm);
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the click event for the recipe image and navigates to the RecipeInfoForm.
        private void recipeImage_Click(object sender, EventArgs e)
        {
            // creates a new instance of the recipe information form
            RecipeInfoForm newForm = new RecipeInfoForm(curRecipe, previousDisplayForm, parentMenuForm);

            //pushes it on stack, and loads the next form
            recipesStack.Push(newForm);
            parentMenuForm.LoadNextForm(newForm);
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the click event for the recipe name label and navigates to the RecipeInfoForm.
        private void recipeNameLabel_Click(object sender, EventArgs e)
        {
            // creates a new instance of the recipe information form
            RecipeInfoForm newForm = new RecipeInfoForm(curRecipe, previousDisplayForm, parentMenuForm);

            //pushes it on stack, and loads the next form
            recipesStack.Push(newForm);
            parentMenuForm.LoadNextForm(newForm);
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the mouse enter event for the RecipeCard control and changes the background color.
        private void RecipeCard_MouseEnter(object sender, EventArgs e)
        {
            //changes the colour of the controls in the card to indicate mouse enter
            this.BackColor = darkColor;
            recipeNameLabel.BackColor = darkColor;
            recipeNameLabel.ForeColor = Color.White;
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the mouse leave event for the RecipeCard control and restores the original background color.
        private void RecipeCard_MouseLeave(object sender, EventArgs e)
        {
            //changes the colour of the controls in the card to indicate mouse leave
            this.BackColor = originalBackColor;
            recipeNameLabel.BackColor = originalBackColor;
            recipeNameLabel.ForeColor = Color.Black;
        }

        // Pre: label - The Label control to center.
        // Post: None.
        // Description: Centers the provided label horizontally within its parent control.
        private void CenterLabel(System.Windows.Forms.Label label)
        {
            // Get the preferred size based on the text and font
            Size preferredSize = label.PreferredSize;

            // Set the label's size to match the preferred size
            label.Size = preferredSize;

            // Calculate the center position relative to the parent
            int x = (label.Parent.ClientSize.Width - label.Width) / 2;
            int y = label.Location.Y;

            // Update the label's position
            label.Location = new Point(x, y);
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the mouse enter event for the recipe image and changes the background color.
        private void recipeImage_MouseEnter(object sender, EventArgs e)
        {
            //changes the colour of the controls in the card to indicate mouse enter
            this.BackColor = darkColor;
            recipeNameLabel.BackColor = darkColor;
            recipeNameLabel.ForeColor = Color.White;
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the mouse leave event for the recipe image and restores the original background color.
        private void recipeImage_MouseLeave(object sender, EventArgs e)
        {
            //changes the colour of the controls in the card to indicate mouse leave
            this.BackColor = originalBackColor;
            recipeNameLabel.BackColor = originalBackColor;
            recipeNameLabel.ForeColor = Color.Black;
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the mouse enter event for the recipe name label and changes the background color.
        private void recipeNameLabel_MouseEnter(object sender, EventArgs e)
        {
            //changes the colour of the controls in the card to indicate mouse enter
            this.BackColor = darkColor;
            recipeNameLabel.BackColor = darkColor;
            recipeNameLabel.ForeColor = Color.White;
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the mouse leave event for the recipe name label and restores the original background color.
        private void recipeNameLabel_MouseLeave(object sender, EventArgs e)
        {
            //changes the colour of the controls in the card to indicate mouse leave
            this.BackColor = originalBackColor;
            recipeNameLabel.BackColor = originalBackColor;
            recipeNameLabel.ForeColor = Color.Black;
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the click event for the save button and opens the SaveRecipeForm.
        private void saveBtn_Click(object sender, EventArgs e)
        {
            //creates and shows a new instance of the save recipe form
            SaveRecipeForm newForm = new SaveRecipeForm(parentMenuForm, curRecipe);
            newForm.Show();
        }        
    }
}
