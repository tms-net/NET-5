var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseStaticFiles();

app.MapGet("/", async context =>
{
    var fileContent = File.ReadAllText("wwwroot/ajax.html");
    //var fileContent = File.ReadAllText("wwwroot\ajax.html");

    context.Response.Headers.ContentType = "text/html"; // mime type
    context.Response.StatusCode = 200;
    await context.Response.WriteAsync(fileContent);
});
app.MapGet("/content/file", (string file) => File.ReadAllText($"content/{file}"));

app.Run();