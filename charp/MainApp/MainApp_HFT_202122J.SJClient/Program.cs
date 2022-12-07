var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();

app.UseStaticFiles();

app.MapGet("/", () => "Hello World!");

app.Run();
