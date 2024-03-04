using ALAYSchoolGest.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.AddConfiguration();
builder.AddDatabase();
//builder.AddJwtAuthentication();
builder.AddControllers();
builder.AddMemoryCache();
builder.AddCompression();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();





//builder.AddAccountContext();
//app.AddStoreEndpoints();
//app.AddBackOfficeEndpoints();


builder.AddMediatR();







var app = builder.Build();

app.UseHttpsRedirection();
//app.UseAuthentication();
//app.UseAuthorization();
app.UseResponseCompression();
app.MapControllers();
app.UseStaticFiles();
app.UseRouting();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}





//app.MapAccountEndpoints();
//app.MapStoreEndpoints();
//app.MapBackOfficeEndpoints();

app.Run();























//// Add services to the container.
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//var summaries = new[]
//{
//    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//};

//app.MapGet("/weatherforecast", () =>
//    {
//        var forecast = Enumerable.Range(1, 5).Select(index =>
//                new WeatherForecast
//                (
//                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//                    Random.Shared.Next(-20, 55),
//                    summaries[Random.Shared.Next(summaries.Length)]
//                ))
//            .ToArray();
//        return forecast;
//    })
//    .WithName("GetWeatherForecast")
//    .WithOpenApi();

//app.Run();

