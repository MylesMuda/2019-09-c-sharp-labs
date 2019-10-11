using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using lab_50_api_todo_list_core;
using Newtonsoft.Json;

namespace lab_50_read_api_core
{
    class Program
    {
        static string url = "https://localhost:44391/api/TaskItems";
        static HttpClient client = new HttpClient();
        static TaskItem taskItem = null;
        static List<TaskItem> taskItems = new List<TaskItem>();
        static void Main(string[] args)
        {
            GetUserAsync().Wait();
            //DisplayTaskItems();
            // get task with set ID
            GetTaskItemAsync(1).Wait();

            var t = new TaskItem()
            {
                Description = "New Task",
                TaskDone = false,
                DateDue = DateTime.Parse("10/10/2019"),
                UserID = 2,
            };
            Console.WriteLine(PostNewTaskItemAsync(t).Result);

            GetTaskItemAsync(4).Wait();

            RemoveTaskItemAsync(4).Wait();

            DisplayTaskItems();
        }

        static async Task GetUserAsync()
        {
            Console.WriteLine("Getting task items");
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                // USES NEWTONSOFT TO DESERIALISE A STRING INTO A LIST OF TASKITEMS
                taskItems = JsonConvert.DeserializeObject<List<TaskItem>>(responseString);
            }
            DisplayTaskItems();
        }

        static async Task GetTaskItemAsync(int taskItemID)
        {
            Console.WriteLine($"Getting task item {taskItemID}");
            var response = await client.GetAsync(url + taskItemID);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                // USES NEWTONSOFT TO DESERIALISE A STRING INTO A LIST OF TASKITEMS
                taskItems = JsonConvert.DeserializeObject<List<TaskItem>>(responseString);
            }
            DisplayTaskItem(taskItemID);
        }

        static async Task RemoveTaskItemAsync(int taskItemID)
        {
            HttpResponseMessage response = await client.DeleteAsync(taskItemID.ToString());
            DisplayTaskItem(taskItemID);
        }

        static async Task<TaskItem> PostNewTaskItemAsync(TaskItem t)
        {
            var taskItemString = JsonConvert.SerializeObject(t);
            var taskItemHttp = new StringContent(taskItemString);
            taskItemHttp.Headers.ContentType.MediaType = "application/json";
            HttpResponseMessage response = await client.PostAsync(url, taskItemHttp);
            Console.WriteLine(response.Content);
            //convert response to json
            var newItemJson = response.Content.ReadAsStringAsync();
            //serialise object to <taskItem> type
            var newItemTask = JsonConvert.DeserializeObject<TaskItem>(newItemJson.Result);
            Console.WriteLine(newItemTask.TaskItemID);
            //return new taskItem
            return newItemTask;
        }

        static void DisplayTaskItems()
        {
            taskItems.ForEach(t =>
            {
                Console.WriteLine($"{t.TaskItemID,-10}{t.Description,-30}{t.TaskDone,-30}{t.DateDue}");
            });
        }
        static void DisplayTaskItem(int taskItemID)
        {
            Console.WriteLine($"{taskItem.TaskItemID,-10}{taskItem.Description,-30}{taskItem.TaskDone,-30}{taskItem.DateDue}");
        }
    }
}
