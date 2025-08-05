namespace TodoList.Models
{
    /// <summary>
    /// Blueprint of user data
    /// </summary>
    internal class User
    {
        /// <summary>
        /// Gets or sets Id of the user
        /// </summary>
        /// <value>User Id</value>
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets name of the user
        /// </summary>
        /// <value>Name of the user</value>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets password of the user
        /// </summary>
        /// <value>User Account Password</value>
        public string? Password { get; set; }
    }
}
