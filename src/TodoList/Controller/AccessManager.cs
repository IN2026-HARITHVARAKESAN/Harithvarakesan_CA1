using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList.Controller
{
    /// <summary>
    /// Manage access of the user
    /// </summary>
    internal class AccessManager
    {
        /// <summary>
        /// Manage Login process of the user
        /// </summary>
        public static void Login()
        {
            Utility.DisplayMessage("Enter Id :", endLine: " ");
            string id = InputGetter.GetUserId();
            if (id == null)
            {
                Utility.DisplayMessage("User with this Id doesn't exist.. Try SignUp");
            }

            Utility.DisplayMessage("Enter Password :", endLine: " ");
            string password = InputGetter.GetPassword();

            if (!Utility.Users.Where(user => user.Id == id).First().Password.Equals(password))
            {
                Utility.DisplayMessage("\nIncorrect Password!!..Try Again", ConsoleColor.Red);
            }

            Utility.DisplayMessage("\nLogin Successful", ConsoleColor.Green);

            Utility.DisplayMessage("\nPress Any Key to continue...", ConsoleColor.Yellow);
            Console.ReadKey();
            Console.Clear();

            TaskManager.DisplayTaskMenu(id);
            return;
        }

        /// <summary>
        /// SignUp by creating new account
        /// </summary>
        public static void SignUp()
        {
            Utility.DisplayMessage("Enter user name :", endLine: " ");
            string name = InputGetter.GetInput();
            string password = Utility.SetPassword();
            string id = "U" + Utility.GenerateId<User>();

            Utility.Users.Add(new () { Id = id, Name = name, Password = password });

            Utility.DisplayMessage($"User Created Successfully\nYour User Id is {id}", ConsoleColor.Green);
            Utility.DisplayMessage("Keep a note of User Id to login", ConsoleColor.Yellow);
            JsonHandler.WriteJsonFile<User>(Utility.Users);

            Utility.DisplayMessage("\nPress Any Key to continue...", ConsoleColor.Yellow);
            Console.ReadKey();
            Console.Clear();
            return;
        }
    }
}
