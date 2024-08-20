using Microsoft.AspNetCore.Mvc;

namespace IssueTrackerApi.Controllers;

// GET /status
public class StatusController : ControllerBase
{
    private ILookupSupportInfo supportLookup;


    public StatusController(ILookupSupportInfo supportLookup)
    {
        this.supportLookup = supportLookup;

    }

    [HttpGet("/status")]
    public async Task<ActionResult> GetTheStatus()
    {
        // do some work here -

        SupportContactResponseModel supportInfo = await supportLookup.GetCurrentSupportInfoAsync();
        var response = new StatusResponseModel
        {
            Message = "Looks Good Here, Boss!",
            SupportContact = supportInfo

        };
        return Ok(response);
    }
}


public record StatusResponseModel
{
    public string Message { get; set; } = string.Empty;

    public SupportContactResponseModel SupportContact { get; set; } = new();

}
