using System.Text.Json;

namespace TodoList.Controller
{
    /// <summary>
    /// JSON file handling
    /// </summary>
    internal class JsonHandler
    {
        private const string UserPath = @"./../../../DataBase/User.json";
        private const string TaskPath = @"./../../../DataBase/Task.json";

        /// <summary>
        /// Reads data from the JSON file
        /// </summary>
        /// <typeparam name="T">Type the Data</typeparam>
        /// <returns>Returns list of datas from read from file</returns>
        public static List<T> ReadJSONFile<T>()
        {
            string filePath = typeof(T) == typeof(Models.Task) ? TaskPath : UserPath;
            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<T>>(jsonString);
        }

        /// <summary>
        /// Writes data into JSON file
        /// </summary>
        /// <typeparam name="T">Type of Data</typeparam>
        /// <param name="data">Contains List of data</param>
        public static void WriteJsonFile<T>(List<T> data)
        {
            string filePath = typeof(T) == typeof(Models.Task) ? TaskPath : UserPath;
            string jsonString = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonString);
        }
    }
}
