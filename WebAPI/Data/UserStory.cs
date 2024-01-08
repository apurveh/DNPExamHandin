namespace WebAPI.Data;

public class UserStory
{
    public int Id { get; set; }
    public string Description { get; set; }
    public int Estimate{get;set;}

    public UserStory(int id, string description, int estimate)
    {
        Description = description;
        Estimate = estimate;
    }
    public UserStory()
    {

    }
    public override string ToString()
    {
        return $"UserStory: Id = {Id}, Description = {Description}, Estimate = {Estimate}";
    }
}