using Geo.Api;
using Geo.Api.DataAccess;
using Geo.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigureDependencyInjections(builder.Configuration);


var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
    await Initialize.SeedAsync(context).ConfigureAwait(false);
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCustomExceptionHandler();

app.MapControllers();

app.MapGet("/", a => Task.Run(() =>
{
    a.Response.Redirect("/swagger/index.html");
}));


app.Run();