namespace WebAPI.Data;

public class Project
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Status { get; set; }
    public string Responsible { get; set; }
    public List<UserStory> UserStories { get; set; }

    public Project(string title, string status, string responsible)
    {
        Title = title;
        Status = status;
        Responsible = responsible;
        UserStories = new List<UserStory>();
    }
    public Project()
    {
        UserStories = new List<UserStory>();
    }
    public override string ToString()
    {
        return $"Project: Id = {Id}, Title = {Title}, Status = {Status}, Responsible = {Responsible}, UserStories = {UserStories.Count}";
    }
}