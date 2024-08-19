using Microsoft.AspNetCore.Mvc;

namespace IssueTrackerApi.Controllers;

// GET /status
public class StatusController : ControllerBase
{
    [HttpGet("/status")]
    public async Task<ActionResult> GetTheStatus()
    {
        // do some work here -
        var response = new StatusResponseModel
        {
            Message = "Looks Good Here, Boss",
            WhenChecked = DateTimeOffset.Now
        };
        return Ok(response);
    }
}


public record StatusResponseModel
{
    public string Message { get; set; } = string.Empty;
    public DateTimeOffset WhenChecked { get; set; }
}