using HR.LeaveManagement.Api.Middleware;
using HR.LeaveManagement.Application;
using HR.LeaveManagement.Infrastructure;
using HR.LeaveManagement.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Called extension method from respective class libraries:
//HR.LeaveManagement.Application project
builder.Services.AddApplicationServices();

//HR.LeaveManagement.Infrastructure
builder.Services.AddInfrastructureServices(builder.Configuration);

//HR.LeaveManagement.Persistence
builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddControllers();

//Added CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("all", builder =>
    builder.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Global error handling middleware
app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("all");

app.UseAuthorization();

app.MapControllers();

app.Run();
