namespace AffigiveUIBalzor.api
{
    using AffiGive_API_V1.Models;
    using System.Net.Http.Json;

    public class TaskApiGateway : ITaskApiGateway
    {
        private readonly HttpClient _httpClient;

        private const string _endpoint = "Task";

        public TaskApiGateway(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<TaskMaster>> GetAllTasksAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<TaskMaster>>(_endpoint)
                   ?? Enumerable.Empty<TaskMaster>();
        }

        public async Task<TaskMaster?> GetTaskByIdAsync(int taskId)
        {
            return await _httpClient.GetFromJsonAsync<TaskMaster>($"{_endpoint}/{taskId}");
        }

        public async Task<int> CreateTaskAsync(TaskMaster task)
        {
            var response = await _httpClient.PostAsJsonAsync(_endpoint, task);

            if (!response.IsSuccessStatusCode)
                return 0;

            var createdTask = await response.Content.ReadFromJsonAsync<TaskMaster>();
            return createdTask?.TaskId ?? 0;
        }

        public async Task<bool> UpdateTaskAsync(TaskMaster task)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_endpoint}/{task.TaskId}", task);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteTaskAsync(int taskId)
        {
            var response = await _httpClient.DeleteAsync($"{_endpoint}/{taskId}");
            return response.IsSuccessStatusCode;
        }
    }
}
