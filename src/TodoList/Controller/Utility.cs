using TodoList.Models;

namespace TodoList.Controller
{
    /// <summary>
    /// Helper functions
    /// </summary>
    internal class Utility
    {
        /// <summary>
        /// Gets or sets the list of task
        /// </summary>
        public static List<Models.Task> Tasks = new List<Models.Task>();

        /// <summary>
        /// Gets or sets the list of User
        /// </summary>
        public static List<User> Users = new List<User>() { new User() { Id = "U0001", Name = "Hello", Password = "password" } };

        /// <summary>
        /// Status of the task
        /// </summary>
        public enum TaskStatus
        {
            /// <summary>
            /// Task have not yet started
            /// </summary>
            NotYetStarted,

            /// <summary>
            /// Task have been started but Not finished
            /// </summary>
            Pending,

            /// <summary>
            /// Task have been Completed
            /// </summary>
            Completed,
        }

        /// <summary>
        /// Recurrence of the task
        /// </summary>
        public enum Recurrence
        {
            /// <summary>
            /// Task is repeated daily
            /// </summary>
            Daily,

            /// <summary>
            /// Task is repeated monthly
            /// </summary>
            Monthly,

            /// <summary>
            /// Task is repeated yearly
            /// </summary>
            Annually,

            /// <summary>
            /// Task will never repeat
            /// </summary>
            None,
        }

        /// <summary>
        /// Display the message to console
        /// </summary>
        /// <param name="message">Message to be displayed</param>
        /// <param name="color">Color of the message in console</param>
        /// <param name="endLine">Denotes how to end the line for the message</param>
        public static void DisplayMessage(string message, ConsoleColor color = ConsoleColor.White, string endLine = "\n")
        {
            Console.ForegroundColor = color;
            Console.Write(message + endLine);
            Console.ResetColor();
        }

        /// <summary>
        /// Gets new password and validate them
        /// </summary>
        /// <returns>Password of the account</returns>
        public static string SetPassword()
        {
            string password1;
            string? password2 = null;

            do
            {
                Utility.DisplayMessage("Enter Password :", endLine: " ");
                password1 = InputGetter.GetPassword();
                bool isValidPassword = InputValidator.ValidatePassword(password1);
                if (!isValidPassword)
                {
                    Utility.DisplayMessage("\nInvalid Password!!... Password must contain atleast 8 character, 1 Upper case, 1 Lower case, 1 digit and 1 special character.", ConsoleColor.Red);
                    continue;
                }

                Utility.DisplayMessage("\nRe-Enter Password :", endLine: " ");
                password2 = InputGetter.GetPassword();
                isValidPassword = InputValidator.ValidatePassword(password2);
                if (!isValidPassword)
                {
                    Utility.DisplayMessage("\nInvalid Password!!... Password must contain atleast 8 character, 1 Upper case, 1 Lower case, 1 digit and 1 special character.", ConsoleColor.Red);
                    continue;
                }

                if (!password1.Equals(password2))
                {
                    Utility.DisplayMessage("\nPassword Does not match. Try Again!!...", ConsoleColor.Red);
                }
            }
            while (!password1.Equals(password2));

            return password1;
        }

        /// <summary>
        /// Generate new user/Task Id
        /// </summary>
        /// <typeparam name="T">Type of the class to generate Id</typeparam>
        /// <returns>Returns generated Id</returns>
        public static string GenerateId<T>()
        {
            if (typeof(T) == typeof(User) && Users.Count() == 0)
            {
                return "0001";
            }
            else if (typeof(T) == typeof(Models.Task) && Tasks.Count() == 0)
            {
                return "0001";
            }

            string? lastId = typeof(T) == typeof(Models.Task) ? Tasks.Last().Id : Users.Last().Id;
            int lastIdInt = int.Parse(lastId.Substring(1));
            Console.WriteLine(lastId);
            return $"{(lastIdInt + 1):D4}";
        }
    }
}
