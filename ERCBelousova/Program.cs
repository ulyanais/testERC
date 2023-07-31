using ERCBelousova.DataBase;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ��������� ������ ����������� �� ����� ������������
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

// ���������� ��������� ���� ������ � ������� ����������
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
// ���������� �������� ��� ������������
//app.MapDefaultControllerRoute();

app.Run();