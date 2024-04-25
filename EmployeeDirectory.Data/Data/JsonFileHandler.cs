using EmployeeDirectory.Models;
using System.Text.Json;

namespace EmployeeDirectory.Data
{
    public class JsonFileHandler
    {
        public static readonly string employeeFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "employee.json");
        public static readonly string roleFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "role.json");

        public static List<T> GetData<T>()
        {
            var type=typeof(T);
            string jsonData;
            if (type == typeof(Role))
            {
                jsonData = File.ReadAllText(roleFilePath);
            }
            else
            {
                jsonData = File.ReadAllText(employeeFilePath);
            }
            List<T> dataList = JsonSerializer.Deserialize<List<T>>(jsonData)!;
            return dataList;
        }
        public static void AddDataToJson<T>(List<T> dataList)
        {
            var type = typeof(T);
            string jsonToString = JsonSerializer.Serialize(dataList);
            if (type == typeof(Role))
            {
                File.WriteAllText(roleFilePath, jsonToString);
            }
            else
            {
                File.WriteAllText(employeeFilePath, jsonToString);
            }
        }
    }
}
