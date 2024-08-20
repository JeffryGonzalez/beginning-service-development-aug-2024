using Microsoft.AspNetCore.Mvc;

namespace IssueTrackerApi.Controllers;

// GET /status
public class StatusController : ControllerBase
{
    private ILookupSupportInfo supportLookup;

    private HitCounter counter;
    public StatusController(ILookupSupportInfo supportLookup, HitCounter counter)
    {
        this.supportLookup = supportLookup;
        this.counter = counter;
    }

    [HttpGet("/status")]
    public async Task<ActionResult> GetTheStatus()
    {
        // do some work here -
        counter.Increment();
        SupportContactResponseModel supportInfo = await supportLookup.GetCurrentSupportInfoAsync();
        var response = new StatusResponseModel
        {
            Message = "Looks Good Here, Boss! " + counter.GetHitCounter(),
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

public record SupportContactResponseModel
{
    public string EMail { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
}