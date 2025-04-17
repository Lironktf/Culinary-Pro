// Author: Liron Katsif
// File Name: Program.cs
// Project Name: RecipeManager
// Creation Date: Dec 10, 2024
// Modified Date: Jan 3, 2025
// Description: Initializes the first form to view, the login form

namespace RecipeManager
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //run the first form, which is the loginform
            Application.Run(new LoginForm());
        }
    }
}