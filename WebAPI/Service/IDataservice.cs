using WebAPI.Data;

namespace WebAPI.Service;

public interface IDataservice
{
    List<Project> Projects { get; }
    Task<Project> CreateProjectAsync(Project project);
    Task<UserStory> AddUserStoryAsync(int projectId, UserStory userStory);
    Task<Project> GetProjectByIdAsync(int id);
    Task<List<Project>> GetAllProjectsAsync(string status = null, string responsible = null);
}