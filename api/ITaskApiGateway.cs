using AffiGive_API_V1.Models;

namespace AffigiveUIBalzor.api
{
    public interface ITaskApiGateway
    {
        Task<IEnumerable<TaskMaster>> GetAllTasksAsync();
        Task<TaskMaster?> GetTaskByIdAsync(int taskId);
        Task<int> CreateTaskAsync(TaskMaster task);
        Task<bool> UpdateTaskAsync(TaskMaster task);
        Task<bool> DeleteTaskAsync(int taskId);
    }
}
