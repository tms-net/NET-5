using FileServer.Data;

namespace FileServer
{
    // Container -> Interface: Implemention

    // Register()

    // Resolve<Interface>()

    // IC/DI

    // Dependency Injection with Container

    public class MyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IDatabase _db;

        public MyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //context.User

            var data = await context.RequestServices.GetService<IDatabase>().GetDataAsync();

            // process data

            await context.Response.WriteAsync($"Hello {nameof(MyMiddleware)}!");
            await _next(context);
        }
    }
}
