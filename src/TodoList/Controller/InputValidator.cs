using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TodoList.Controller
{
    /// <summary>
    /// Validates the inputs given by user
    /// </summary>
    internal class InputValidator
    {
        /// <summary>
        /// Validates User Id
        /// </summary>
        /// <param name="userId">Id of the User</param>
        /// <returns>Return true if Id is valid, else return false</returns>
        public static bool ValidateUserId(string userId)
        {
            if (Utility.Users.Any(user => user.Id.Equals(userId)))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Validate Password given by user
        /// </summary>
        /// <param name="password">Password of the user</param>
        /// <returns>Returns true if password is valid, else return false</returns>
        public static bool ValidatePassword(string password)
        {
            bool isValidPassword = false;
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
            if (Regex.IsMatch(password, pattern))
            {
                isValidPassword = true;
            }

            return isValidPassword;
        }

        /// <summary>
        /// Validate the given date and check the date is not greater than current date
        /// </summary>
        /// <param name="date">Date of the task</param>
        /// <returns>Return true if the date is valid, else returns false</returns>
        public static bool ValidateDate(string date)
        {
            return DateOnly.TryParse(date, out DateOnly parsedDate) && parsedDate.CompareTo(DateOnly.FromDateTime(DateTime.Now)) > 0;
        }

        /// <summary>
        /// Validate the task Id given
        /// </summary>
        /// <param name="taskId">Id of the task</param>
        /// <param name="userId">Id of the User</param>
        /// <returns>Returns true if the task already exist, else return false</returns>
        public static bool ValidateTaskId(string taskId, string userId)
        {
            return Utility.Tasks.Any(task => task.Id.Equals(taskId, StringComparison.OrdinalIgnoreCase) && task.UserId.Equals(userId, StringComparison.OrdinalIgnoreCase));
        }
    }
}
