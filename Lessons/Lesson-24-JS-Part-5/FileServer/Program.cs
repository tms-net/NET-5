

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/content/{file}", (string file) =>
{
    return File.ReadAllText($"content/{file}");
});

app.MapGet("/", async context =>
{
    var fileContent = File.ReadAllText("ajax.html");

    context.Response.Headers.ContentType = "text/html"; // mime type
    context.Response.StatusCode = 200;
    context.Response.Headers.Add("My-Header", "My-App");

    await context.Response.WriteAsync(fileContent);
});


app.Run();
