// Author: Liron Katsif
// File Name: FormsStack.cs
// Project Name: RecipeManager
// Creation Date: Jan 1, 2025
// Modified Date: Jan 11, 2025
// Description:  FormsStack class represents a stack data structure specifically for forms and used to navigate "back" on the screens.
//               It includes attributes for the stack and its size, and provides methods to push, pop, and access the top form, as well as check the size and if the stack is empty.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManager
{
    public class FormsStack
    {
        // Attribute of the FormsStack class - actual stack, and the size of the stack
        List<Form> stack;
        int size;

        // Pre: None
        // Post: None
        // Description: Constructor for the FormsStack class that initializes an empty stack and sets the size to zero.
        public FormsStack()
        {
            //init the form attributes
            stack = new List<Form>();
            size = 0;
        }

        // Pre: newForm - The form to be added to the stack.
        // Post: None
        // Description: Pushes a new form onto the stack.
        public void Push (Form newForm)
        {
            stack.Add(newForm);
            size++;
        }

        // Pre: None
        // Post: Returns the form at the top of the stack . Returns null if the stack is empty.
        // Description: Tops the form from the top of the stack.
        public Form Top()
        {
            //initate Form for return
            Form result = null;

            //check if form not empty, if not then return current last form
            if (!IsEmpty())
            {
                result = stack[size - 1];
            }

            //return the top form
            return result;
        }

        // Pre: None
        // Post: Returns the form at the top of the stack. Returns null if the stack is empty.
        // Description: Pops the form from the top of the stack.
        public Form Pop()
        {
            //initate Form for return
            Form result = null;

            //check if form not empty, if not then return current last form, and remove last item
            if (!IsEmpty())
            {
                result = stack[size - 1];
                stack.RemoveAt(size - 1);
                size--;
            }

            //return the top form
            return result;
        }

        // Pre: None
        // Post: Returns the current number of forms in the stack.
        // Description: This method returns the size of the stack, which is the number of forms currently in the stack.
        public int Size()
        {
            return stack.Count();
        }

        // Pre: None
        // Post: Returns true if the stack is empty, false otherwise.
        // Description: Checks if the stack is empty.
        public bool IsEmpty()
        {
            return size == 0;
        }
    }
}
