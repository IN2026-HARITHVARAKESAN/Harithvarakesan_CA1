using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Controller
{
    /// <summary>
    /// Gets Inputs from the user
    /// </summary>
    internal class InputGetter
    {
        /// <summary>
        /// Reads Input from the user.
        /// </summary>
        /// <returns>Returns user input</returns>
        public static string GetInput()
        {
            string? userInput;
            do
            {
                userInput = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Utility.DisplayMessage("Invalid Input!!...Try Again!!...\nInput cannot be null or WhiteSpaces", ConsoleColor.Red);
                    Utility.DisplayMessage("Enter your input again :", endLine: " ");
                }
            }
            while (string.IsNullOrWhiteSpace(userInput));

            return userInput;
        }

        /// <summary>
        /// Gets Input of index from the user
        /// </summary>
        /// <param name="maxIndex">Maximum Valid Index</param>
        /// <returns>Index that user inputs</returns>
        public static int GetIndex(int maxIndex)
        {
            bool isValidChoice;
            int index;
            do
            {
                string userChoice = GetInput();
                isValidChoice = int.TryParse(userChoice, out index) && index > 0 && index < maxIndex;
                if (!isValidChoice)
                {
                    Utility.DisplayMessage(
                        "Invalid Index Try Again!!...\n" +
                        $"Index should be of range 0 - {maxIndex}",
                        ConsoleColor.Red);
                    continue;
                }
            }
            while (!isValidChoice);
            return index;
        }

        /// <summary>
        /// Gets input for user Id
        /// </summary>
        /// <returns>Returns the Id of the user</returns>
        public static string GetUserId()
        {
            string userId;
            bool isValidUser;
            do
            {
                userId = GetInput();
                isValidUser = InputValidator.ValidateUserId(userId);
                if (!isValidUser)
                {
                    Utility.DisplayMessage("This User Id Doesn't exist!! Try SignUp...", ConsoleColor.Red);
                    return null;
                }
            }
            while (!isValidUser);

            return userId;
        }

    }
}
