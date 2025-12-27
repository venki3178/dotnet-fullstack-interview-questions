using eCommerce.Infrastrure;
using eCommerce.Core;
using eCommerce.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);
//Add Infrastructure Services
builder.Services.AddInfrastructure();

//Add Core Services
builder.Services.AddCore();


//Add Controllers
builder.Services.AddControllers();
var app = builder.Build();

//
app.UseExceptionHandlingMiddleware();
//Routing
app.UseRouting();

//Auth
app.UseAuthentication();
app.UseAuthorization();

//Controller Routes
app.MapControllers();

app.Run();
