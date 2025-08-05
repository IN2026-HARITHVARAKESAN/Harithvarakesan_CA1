using TodoList.Controller;

namespace TodoList.Models
{
    /// <summary>
    /// Blueprint of the task
    /// </summary>
    internal class Task
    {
        /// <summary>
        /// Gets or sets the Id of the task
        /// </summary>
        /// <value>Id of the task</value>
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the Heading of the task
        /// </summary>
        /// <value>Heading of the task</value>
        public string? Heading { get; set; }

        /// <summary>
        /// Gets or sets the Description of the task
        /// </summary>
        /// <value>Task Description</value>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the Status of the task
        /// </summary>
        /// <value>Status of the task</value>
        public Utility.TaskStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the Target Date for the task
        /// </summary>
        /// <value>Target Date of the task</value>
        public DateOnly TargetDate { get; set; }

        /// <summary>
        /// Gets or sets the Reccurance of the task
        /// </summary>
        /// <value>Reccurance of the task</value>
        public Utility.Reccurance Reccurance { get; set; }
    }
}
