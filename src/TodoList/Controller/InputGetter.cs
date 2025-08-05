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
                isValidChoice = int.TryParse(userChoice, out index) && index > 0 && index <= maxIndex;
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

        /// <summary>
        /// Gets date from the user
        /// </summary>
        /// <returns>Date of the task</returns>
        public static DateOnly GetDate()
        {
            string date;
            bool isValidDate = false;
            do
            {
                date = GetInput();
                isValidDate = InputValidator.ValidateDate(date);

                if (!isValidDate)
                {
                    Utility.DisplayMessage("Invalid Input!!...Try Again!!...\nDate Should be in given format(YYYY-MM-DD) and should not be greater than current date.", ConsoleColor.Red);
                    Utility.DisplayMessage("Enter Date again : ", endLine: " ");
                    continue;
                }
            }
            while (!isValidDate);

            return DateOnly.Parse(date);
        }

        /// <summary>
        /// Gets task Id from user
        /// </summary>
        /// <param name="userId">Id of the user</param>
        /// <returns>Id of the task</returns>
        public static string GetTaskID(string userId)
        {
            string taskID;
            bool isValidTaskID;
            do
            {
                taskID = GetInput();
                isValidTaskID = InputValidator.ValidateTaskId(taskID, userId);
                if (!isValidTaskID)
                {
                    Utility.DisplayMessage($"Invalid Task ID... Task Id {taskID} doesn't exist...", ConsoleColor.Red);
                    Utility.DisplayMessage("Enter Task Id again :", endLine: " ");
                }
            }
            while (!isValidTaskID);

            return taskID;
        }

        /// <summary>
        /// Gets recurrence of the task
        /// </summary>
        /// <returns>Recurrence of the task</returns>
        public static Utility.Recurrence GetRecurrence()
        {
            Utility.DisplayMessage(
                "[1]. Daily\n" +
                "[2]. Weekly\n" +
                "[3]. Yearly\n" +
                "[4]. Never repeat\n" +
                "Enter your choice of recurrence of the task : ",
                endLine: " ");
            return (Utility.Recurrence)GetIndex(4);
        }

        /// <summary>
        /// Gets the status of the task from user
        /// </summary>
        /// <returns>Status of the task</returns>
        public static Utility.TaskStatus GetStatus()
        {
            Utility.DisplayMessage(
                "[1]. Completed\n" +
                "[2]. Pending\n" +
                "[3]. Yet to start\n" +
                "Enter your choice of status of the task : ",
                endLine: " ");
            return (Utility.TaskStatus)GetIndex(3);
        }

        /// <summary>
        /// Gets password from user
        /// </summary>
        /// <returns>Returns password of the user</returns>
        public static string GetPassword()
        {
            string password = string.Empty;
            while (true)
            {
                var key = System.Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    if (password.Length == 0)
                    {
                        continue;
                    }

                    Utility.DisplayMessage("\b \b", endLine: "");
                    password = password.Substring(0, password.Length - 1);
                    continue;
                }
                else if (Convert.ToInt32(key.Key) < 48 || (Convert.ToInt32(key.Key) > 111 && Convert.ToInt32(key.Key) < 124) || (Convert.ToInt32(key.Key) > 172 && Convert.ToInt32(key.Key) < 180))
                {
                    continue;
                }

                Console.Write("*");
                password += key.KeyChar;
            }

            return password;
        }
    }
}
