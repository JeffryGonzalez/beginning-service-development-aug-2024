using IssueTracker.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/support-info", () =>
{
    var response = new SupportContactResponseModel
    {
        EMail = "bob@company.com",
        Phone = "800 123-1234"
    };
    return Results.Ok(response);
});

app.Run();


