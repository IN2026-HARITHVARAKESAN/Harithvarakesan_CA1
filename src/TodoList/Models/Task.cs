using TodoList.Controller;

namespace TodoList.Models
{
    /// <summary>
    /// Blueprint of the task
    /// </summary>
    internal class Task
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Task"/> class.
        /// </summary>
        /// <param name="id">Id of the task</param>
        /// <param name="heading">Heading of the task</param>
        /// <param name="description">Description of the task</param>
        /// <param name="date">Target Date of the task</param>
        /// <param name="recurrence">Recurrence of the task</param>
        /// <param name="userId">Id of the user</param>
        public Task(string id, string heading, string description, DateOnly date, Utility.Recurrence recurrence, string userId)
        {
            this.Id = id;
            this.Heading = heading;
            this.Description = description;
            this.TargetDate = date.ToDateTime(new TimeOnly(00, 00));
            this.Recurrence = recurrence;
            this.Status = Utility.TaskStatus.NotYetStarted;
            this.UserId = userId;
        }

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
        public DateTime TargetDate { get; set; }

        /// <summary>
        /// Gets or sets the Recurrence of the task
        /// </summary>
        /// <value>Recurrence of the task</value>
        public Utility.Recurrence Recurrence { get; set; }

        /// <summary>
        /// Gets or sets the Id of the user
        /// </summary>
        /// <value>Id of the user</value>
        public string? UserId { get; set; }
    }
}
