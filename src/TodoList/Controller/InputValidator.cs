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
    }
}
