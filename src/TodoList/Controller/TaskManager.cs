using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;

namespace TodoList.Controller
{
    /// <summary>
    /// Manages CRUD operation of the task
    /// </summary>
    internal class TaskManager
    {
        /// <summary>
        /// Displays task menu that user can perform
        /// </summary>
        /// <param name="userId">Id of the user</param>
        public static void DisplayTaskMenu(string userId)
        {
            int userChoice = 0;
            do
            {
                Utility.DisplayMessage(
                    "[1]. Add new task\n" +
                    "[2]. View all task\n" +
                    "[3]. Edit existing task\n" +
                    "[4]. Remove existing task\n" +
                    "[5]. View Upcoming task\n" +
                    "[6]. Exit\n" +
                    "Enter index of your choice : ",
                    endLine: " ");

                userChoice = InputGetter.GetIndex(5);

                switch (userChoice)
                {
                    case 1:
                        AddTask(userId);
                        break;
                    case 2:
                        ViewAllTask(userId);
                        break;
                    case 3:
                        EditTask(userId);
                        break;
                    case 4:
                        RemoveTask(userId);
                        break;
                    case 5:
                        ViewUpcomingTask(userId);
                        break;
                    case 6:
                        return;
                }
            }
            while (userChoice != 6);
        }

        /// <summary>
        /// Add new task to the list
        /// </summary>
        /// <param name="userId">Id of the user</param>
        public static void AddTask(string userId)
        {
            string taskId = "T" + Utility.GenerateId<Models.Task>();
            Console.WriteLine(taskId);

            Utility.DisplayMessage("Enter new task heading : ", endLine: " ");
            string heading = InputGetter.GetInput();
            Utility.DisplayMessage("Enter new task Description : ", endLine: " ");
            string description = InputGetter.GetInput();
            Utility.DisplayMessage("Enter the target date of the task in the given format (YYYY-MM-DD) : ", endLine: " ");
            DateOnly targetDate = InputGetter.GetDate();
            Utility.Recurrence recurrence = InputGetter.GetRecurrence();

            Utility.Tasks.Add(new Models.Task(taskId, heading, description, targetDate, recurrence, userId));

            Utility.DisplayMessage("Task Added Successfully.", ConsoleColor.Green);
            Utility.DisplayMessage("\nPress Any Key to continue...", ConsoleColor.Yellow);
            Console.ReadKey();
            Console.Clear();
            return;
        }

        /// <summary>
        /// Lists all the existing task of the user
        /// </summary>
        /// <param name="userId">Id of the user</param>
        public static void ViewAllTask(string userId)
        {
            List<Models.Task> tasks = Utility.Tasks.Where(task => userId.Equals(userId)).ToList();
            if (tasks.Count == 0)
            {
                Utility.DisplayMessage("There is no existing task....", ConsoleColor.Red);
                return;
            }

            ConsoleTable table = new ConsoleTable("Task Id", "Heading", "Description", "Target Date", "Status", "Recurrence");
            foreach (var task in tasks)
            {
                table.AddRow(task.Id, task.Heading, task.Description, task.TargetDate, task.Status.ToString(), task.Recurrence.ToString());
            }

            table.Write();
        }

        /// <summary>
        /// Edits the existing task
        /// </summary>
        /// <param name="userId">Id of the user</param>
        public static void EditTask(string userId)
        {
            List<Models.Task> tasks = Utility.Tasks.Where(task => userId.Equals(userId)).ToList();
            if (tasks.Count == 0)
            {
                Utility.DisplayMessage("There is no existing task....", ConsoleColor.Red);
                return;
            }

            ViewAllTask(userId);

            Utility.DisplayMessage("Enter the Id of the task to edit :", endLine: " ");
            string taskId = InputGetter.GetTaskID(userId);

            Utility.DisplayMessage(
                "\n[1]. Heading\n" +
                "[2]. Description\n" +
                "[3]. Target Date\n" +
                "[4]. Status\n" +
                "[5]. Recurrence\n" +
                "Enter the index of field that need to be edited :", endLine: " ");

            int userChoice = InputGetter.GetIndex(5);

            Models.Task task = Utility.Tasks.Where(task => task.Id == taskId).FirstOrDefault();

            switch (userChoice)
            {
                case 1:
                    task.Heading = InputGetter.GetInput();
                    break;
                case 2:
                    task.Description = InputGetter.GetInput();
                    break;
                case 3:
                    task.TargetDate = InputGetter.GetDate();
                    break;
                case 4:
                    task.Status = InputGetter.GetStatus();
                    break;
                case 5:
                    task.Recurrence = InputGetter.GetRecurrence();
                    break;
            }

            Utility.DisplayMessage("Successfully edited the task....", ConsoleColor.Green);

            Utility.DisplayMessage("Press any key to continue....", ConsoleColor.Yellow);
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Removes existing task from list
        /// </summary>
        /// <param name="userId">Id of the user</param>
        public static void RemoveTask(string userId)
        {
            List<Models.Task> tasks = Utility.Tasks.Where(task => userId.Equals(userId)).ToList();
            if (tasks.Count == 0)
            {
                Utility.DisplayMessage("There is no existing task....", ConsoleColor.Red);
                return;
            }

            ViewAllTask(userId);

            Utility.DisplayMessage("Enter the Id of the task to delete :", endLine: " ");
            string taskId = InputGetter.GetTaskID(userId);

            Utility.Tasks.Remove(Utility.Tasks.Where(task => task.Id.Equals(taskId)).FirstOrDefault());

            Utility.DisplayMessage($"Task {taskId} deleted successfully", ConsoleColor.Green);

            Utility.DisplayMessage("Press any key to continue....", ConsoleColor.Yellow);
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// View Upcoming Task 
        /// </summary>
        /// <param name="userId">Id of the user</param>
        public static void ViewUpcomingTask(string userId)
        {
            List<Models.Task> tasks = Utility.Tasks.Where(task => userId.Equals(userId) &&
                                            task.TargetDate.CompareTo(DateOnly.FromDateTime(DateTime.Now)) > 0 &&
                                            task.Status != Utility.TaskStatus.Completed)
                                                    .OrderBy(task => task.TargetDate)
                                                    .ToList();
            if (tasks.Count == 0)
            {
                Utility.DisplayMessage("There is no upcoming task exist....", ConsoleColor.Red);
                return;
            }

            ConsoleTable table = new ConsoleTable("Task Id", "Heading", "Description", "Target Date", "Status", "Recurrence");
            foreach (var task in tasks)
            {
                table.AddRow(task.Id, task.Heading, task.Description, task.TargetDate, task.Status.ToString(), task.Recurrence.ToString());
            }

            table.Write();
        }
    }
}
