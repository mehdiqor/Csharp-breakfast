using BuberBreakfast.Middleware;
using BuberBreakfast.Services.Breakfasts;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddScoped<IBreakfastService, BreakfastService>();
}

var app = builder.Build();

{
    // app.Use(async (ctx, next) =>
    // {
    //     app.Logger.LogWarning("in middleware");

    //     await next.Invoke(ctx);
    // });

    // app.Use((HttpContext ctx, Func<Task> next) =>
    // {
    //     app.Logger.LogWarning("in middleware");

    //     return Task.CompletedTask;
    // });

    app.UseTiming();

    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
