using WebAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

object value = builder.Services.AddControllers();
object value1 = builder.Services.AddControllersWithViews();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FreeAzureSqlContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

internal class WebApplication
{
    internal static object CreateBuilder(string[] args)
    {
        throw new NotImplementedException();
    }
}