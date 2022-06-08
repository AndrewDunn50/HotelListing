using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

builder.Host
    .UseSerilog((ctx, lc) => 
        lc.WriteTo.File(
            path: @"C:\hotellistings\logs\log-.txt",
            outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
            rollingInterval: RollingInterval.Day,
            restrictedToMinimumLevel: LogEventLevel.Information));

Log.Information("Application is starting");

builder.Services.AddControllers();

builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{

}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
