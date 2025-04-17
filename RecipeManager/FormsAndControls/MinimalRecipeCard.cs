// Author: Liron Katsif
// File Name: MinimalRecipeCard.cs
// Project Name: RecipeManager
// Creation Date: Jan 9, 2025
// Modified Date: Jan 13, 2025
// Description: MinimalRecipeCard class represents a recipe card with essential details.
//              It includes attributes for the recipe name, ingredients, and preparation steps, and provides methods to get and set these attributes.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeManager
{
    public partial class MinimalRecipeCard : UserControl
    {
        // Attributes of the MinimalRecipeCard class        
        private Recipe curRecipe;
        private MainMenuForm parentMenuForm;
        private Form previousDisplayForm;
        FormsStack recipesStack;

        //colour attributes, used for changing colour based on where the mouse is
        private Color originalBackColor;
        private Color darkColor = Color.FromArgb(50, 50, 50);

        // Pre: curRecipe - The current recipe to be displayed on the card.
        //      parentMenuForm - The parent form that contains the recipe card.
        //      previousDisplayForm - The form that was displayed before this one.
        //      recipesStack - The stack of forms for navigation.
        // Post: None.
        // Description: Sets up the MinimalRecipeCard with the provided recipe details and initializes the UI components.
        public MinimalRecipeCard(Recipe curRecipe, MainMenuForm parentMenuForm, Form previousDisplayForm, FormsStack recipesStack)
        {
            //init the form and set the form's attributes
            InitializeComponent();
            this.curRecipe = curRecipe;
            this.parentMenuForm = parentMenuForm;
            this.previousDisplayForm = previousDisplayForm;
            this.recipesStack = recipesStack;

            //set the name of the current recipe into the label
            recipeNameLabel.Text = curRecipe.Title;

            //configure the drawing and display styles of the control
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }

        // Pre: label - The Label control to be centered.
        // Post: None.
        // Description: Adjusts the label's position to be centered based on its preferred size and the parent container's width.
        private void CenterLabel(Label label)
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
        // Description: Handles the Load event of the MinimalRecipeCard control.
        private void MinimalRecipeCard_Load(object sender, EventArgs e)
        {
            //set the original color, and center the name label
            originalBackColor = this.BackColor;
            CenterLabel(recipeNameLabel);
        }

        // Pre: e - A PaintEventArgs that contains the event data.
        // Post: None.
        // Description: Overrides the OnPaint method to draw a custom rounded rectangle and text.
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
        // Description: Handles the MouseClick event of the MinimalRecipeCard control.
        private void MinimalRecipeCard_MouseClick(object sender, MouseEventArgs e)
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
        // Description: Handles the Click event of the recipeNameLabel control.
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
        // Description: Handles the MouseEnter event of the MinimalRecipeCard control.
        private void MinimalRecipeCard_MouseEnter(object sender, EventArgs e)
        {
            //changes the colours of the control to show the mouse has entered
            this.BackColor = darkColor;
            recipeNameLabel.BackColor = darkColor;
            recipeNameLabel.ForeColor = Color.White;
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the MouseLeave event of the MinimalRecipeCard control.
        private void MinimalRecipeCard_MouseLeave(object sender, EventArgs e)
        {
            //changes the colours of the control to show the mouse has left
            this.BackColor = originalBackColor;
            recipeNameLabel.BackColor = originalBackColor;
            recipeNameLabel.ForeColor = Color.Black;
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the MouseEnter event of the recipeNameLabel control and changes colour.
        private void recipeNameLabel_MouseEnter(object sender, EventArgs e)
        {
            //changes the colours of the control to show the mouse has entered
            this.BackColor = darkColor;
            recipeNameLabel.BackColor = darkColor;
            recipeNameLabel.ForeColor = Color.White;
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the MouseLeave event of the recipeNameLabel control.
        private void recipeNameLabel_MouseLeave(object sender, EventArgs e)
        {
            //changes the colours of the control to show the mouse has left
            this.BackColor = originalBackColor;
            recipeNameLabel.BackColor = originalBackColor;
            recipeNameLabel.ForeColor = Color.Black;
        }

        // Pre: sender - The source of the event.
        //      e - An EventArgs that contains the event data.
        // Post: None.
        // Description: Handles the Click event of the saveBtn control.
        private void saveBtn_Click(object sender, EventArgs e)
        {
            //creates and shows a new instance of the recipe save form
            SaveRecipeForm newForm = new SaveRecipeForm(parentMenuForm, curRecipe);
            newForm.Show();
        }
    }
}
