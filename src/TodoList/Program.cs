using TodoList.Controller;

namespace Assignments
{
    /// <summary>
    /// Entry Point of the Todo Application
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Login Page for the ToDo Application
        /// </summary>
        public static void Main()
        {
            Utility.DisplayMessage("Hello!!...");
            int userChoice;
            do
            {
                Utility.DisplayMessage("Login or SignUp to Access your Todos", ConsoleColor.Blue);
                Utility.DisplayMessage(
                    "[1]. Login\n" +
                    "[2]. SignUp\n" +
                    "[3]. Exit\n" +
                    "Enter your choice of index :");

                userChoice = InputGetter.GetIndex(3);

                switch (userChoice)
                {
                    case 1:
                        AccessManager.Login();
                        break;
                    case 2:
                        AccessManager.SignUp();
                        break;
                    case 3:
                        return;
                }
            }
            while (userChoice != 3);
        }
    }
}