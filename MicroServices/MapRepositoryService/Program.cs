using MapRepositoryService.Core.Configuration;
using MapRepositoryService.Infrastructure.IocContainer;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var settings = builder.Configuration.GetSection(("MessageBrokerSettings")).Get<ValidationSettings>();
builder.Services.AddMapsInfrastructureLibrary(settings);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region CORS

//Move to API Gatway
builder.Services.AddCors(options =>
{
    options.AddPolicy("corsPolicy", builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

#endregion

#region Logger

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}   

app.UseCors("corsPolicy");

app.UseAuthorization();
app.MapControllers();

app.Run();
