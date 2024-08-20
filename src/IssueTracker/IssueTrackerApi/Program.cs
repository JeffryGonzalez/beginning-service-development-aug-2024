using IssueTrackerApi.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Above this line is configuring the "services" for our API.
builder.Services.AddScoped<ILookupSupportInfo, TemporarySupportLookup>();
builder.Services.AddSingleton<HitCounter>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers(); // looks for all the classes that are controllers (public, controllbase, etc.) and reads those "route" attributes. and creates a "route table"

app.Run(); // kestrel is up and running listening for requests.

public partial class Program { }