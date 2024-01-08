using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Service;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]

public class ProjectsController:ControllerBase
{
    private IDataservice _dataservice;
    public ProjectsController(IDataservice dataservice)
    {
        _dataservice = dataservice;
    }
    [HttpPost]
    public async Task<ActionResult<Project>> CreateAsync([FromBody]Project project)
    {
        try
        {
            Project created = await _dataservice.CreateProjectAsync(project);
            return Created($"/users/{project.Id}", project);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);

        }
    }
    [HttpPost("{projectId}/userstories")]
    public async Task<ActionResult<UserStory>> AddUserStoryAsync(int projectId, [FromBody]UserStory userStory)
    {
        try
        {
            UserStory created = await _dataservice.AddUserStoryAsync(projectId, userStory);
            return Created($"/projects/{projectId}/userstories/{created.Id}", created);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    [HttpGet("{projectId}")]
    public async Task<ActionResult<Project>> GetProjectByIdAsync(int projectId)
    {
        try
        {
            Project project = await _dataservice.GetProjectByIdAsync(projectId);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    [HttpGet]
    public async Task<ActionResult<List<Project>>> GetAllProjectsAsync(string status = null, string responsible = null)
    {
        try
        {
            List<Project> projects = await _dataservice.GetAllProjectsAsync(status, responsible);
            if (projects == null)
            {
                return NotFound();
            }
            return Ok(projects);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}
