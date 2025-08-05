using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Controller
{
    /// <summary>
    /// Helper functions
    /// </summary>
    internal class Utility
    {
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
        /// Reccurance of the task
        /// </summary>
        public enum Reccurance
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
    }
}
