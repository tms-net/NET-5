

using FileServer;
using FileServer.Data;

// Создаем объект, ответственный за создание Web приложения asp.net
var builder = WebApplication.CreateBuilder(args);

// Регистрирем нужные компоненты (слассы) в соответствии с
// абстракциями (интрефейсами), которые они реализуют.
builder.Services.Add(new ServiceDescriptor(typeof(IDatabase), new FileDb()));

// Создаем само Web приложение
var app = builder.Build();

// Настраиваем Web приложение

// на данном этапе мы можем получить нужную реализацию,
// которую мы регистрировали предже
var db = app.Services.GetService<IDatabase>();

// Добавляем ПО промежуточного уровня (Middleware)

// с помощью специфических методов расширения
// app.UseHealthChecks("/health"); 

// app.UseExceptionHandler();

// с помощью метода расширения, принимающего класс с нужной структурой (см. MyMiddleware)
// app.UseMiddleware<ExceptionHandlerMiddleware>(); 

// app.UseMiddleware<MyMiddleware>();

// С помощью метода, принимающего делегат, работающий как ПО промежуточного уровня
app.Use(async (context, next) => {
    try
    {
        await next();
    }
    catch(Exception ex)
    {
        await context.Response.WriteAsync(ex.Message);
    }

});

app.Use(async (context, next) => {

    var data = await context.RequestServices.GetService<IDatabase>().GetDataAsync();
    await context.Response.WriteAsync(data);
    await next();
    await context.Response.WriteAsync("Hello world 2!");
});


app.UseStaticFiles(new StaticFileOptions
{
    RequestPath = "/content"
});

app.MapGet("/content/{file}", (string file) =>
{
    return File.ReadAllText($"content/{file}");
});

app.MapGet("/", async context =>
{
    var fileContent = File.ReadAllText("ajax.html");

    //context.Response.Headers.ContentType = "text/html"; // mime type
    //context.Response.StatusCode = 200;
    //context.Response.Headers.Add("My-Header", "My-App");

    await context.Response.WriteAsync(fileContent);
});


app.Use(async (HttpContext context, RequestDelegate next) => {
    await context.Response.WriteAsync("Hello world 3!");
    // await next();
});

// Запускаем Web приложение
app.Run();


