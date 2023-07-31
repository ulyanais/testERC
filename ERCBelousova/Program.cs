using ERCBelousova.DataBase;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Получение строки подключения из файла конфигурации
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

// Добавление контекста базы данных в сервисы приложения
builder.Services.AddDbContext<AuthDbContext>(options => options.UseSqlite(connection));
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.MapGet("/", async (AuthDbContext db) => await db.Accounts.ToListAsync());
app.MapGet("/t", () => "Hello World!");
//app.Run(async (context) =>
//{  
//    context.Response.ContentType = "text/html; charset=utf-8";
//    if (context.Request.Path == "/postuser")
//    {
//        var form = context.Request.Form;
//        string name = form["name"];
//        string age = form["age"];
//        await context.Response.WriteAsync($"<div><p>Name: {name}</p><p>Age: {age}</p></div>");
//    }
//    else
//    {
//        await context.Response.SendFileAsync("html/workPage.html");
//    }
//});
// Добавление маршрута для контроллеров
//app.MapDefaultControllerRoute();

app.Run();