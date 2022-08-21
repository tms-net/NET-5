var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseStaticFiles(); //я его сюда не ставил, но без него не работает

app.MapGet("/", async context =>
{
    var fileContent = File.ReadAllText("wwwroot/ajax.html");
    //var fileContent = File.ReadAllText("wwwroot\ajax.html");

    context.Response.Headers.ContentType = "text/html"; // mime type
    context.Response.StatusCode = 200;
    await context.Response.WriteAsync(fileContent);
});
app.MapGet("/Text/file", (string file) => File.ReadAllText($"Text/{file}")); // работает без этого, можно отключить

app.Run();