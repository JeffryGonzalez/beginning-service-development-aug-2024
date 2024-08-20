using System.Net;

namespace IssueTrackerApi.Tests;
public class BadCode
{
    [Fact]
    public async Task CanGetStatus()
    {

        using var client = new HttpClient();

        client.BaseAddress = new Uri("http://localhost:1337");

        var response = await client.GetAsync("/status");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

    }
}
