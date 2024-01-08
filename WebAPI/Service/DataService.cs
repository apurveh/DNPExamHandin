using WebAPI.Data;

namespace WebAPI.Service;

public class DataService:IDataservice
{
    private int _nextProjectId = 1;
    private int _nextUserStoryId = 1;
    public List<Project> Projects { get; private set; }
    public DataService()
    {
        Projects = new List<Project>();
        SeedData();
    }

    public async Task<Project> CreateProjectAsync(Project project)
    {
        project.Id = _nextProjectId++;
        Projects.Add(project);
        await Task.CompletedTask;
        return project;
    }

    public async Task<UserStory> AddUserStoryAsync(int projectId, UserStory userStory)
    {
        var project = Projects.FirstOrDefault(p => p.Id == projectId);
        if (project != null)
        {
            userStory.Id = _nextUserStoryId++;
            project.UserStories.Add(userStory);
        }
        await Task.CompletedTask;
        return userStory;
    }

    public async Task<Project> GetProjectByIdAsync(int id)
    {
        var project = Projects.FirstOrDefault(p => p.Id == id);
        await Task.CompletedTask;
        return project;
    }

    public async Task<List<Project>> GetAllProjectsAsync(string status = null, string responsible = null)
    {
        var projects = Projects.AsQueryable();
        if (!string.IsNullOrEmpty(status))
        {
            projects = projects.Where(p => p.Status == status);
        }
        if (!string.IsNullOrEmpty(responsible))
        {
            projects = projects.Where(p => p.Responsible == responsible);
        }
        await Task.CompletedTask;
        return projects.ToList();
    }
    private void SeedData()
    {
        Projects.AddRange(new List<Project>
        {
            new Project
            {
                Id = 1,
                Title = "Project Apurva",
                Status = "Active",
                Responsible = "Jakob",
                UserStories = new List<UserStory>
                {
                    new UserStory { Id = 1, Description = "Get 12 In DNP", Estimate = 5 },
                    new UserStory { Id = 2, Description = "Thanks Jakob", Estimate = 3 }
                }
            },
            new Project
            {
                Id = 2,
                Title = "Project Apurveh",
                Status = "Active",
                Responsible = "Troels",
                UserStories = new List<UserStory>
                {
                    new UserStory { Id = 3, Description = "Get 12 in DNP", Estimate = 8 },
                    new UserStory { Id = 4, Description = "Thanks Troels", Estimate = 2 }
                }
            }
        });
    }

}