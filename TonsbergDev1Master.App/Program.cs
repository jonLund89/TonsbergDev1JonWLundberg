using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.WebRootPath!, "browser")),
    RequestPath = ""
});

// Optional but recommended if Angular uses default file loading (index.html)
app.UseDefaultFiles(new DefaultFilesOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.WebRootPath!, "browser"))
});

app.MapControllers();

app.MapFallbackToFile("browser/index.html");

app.Run();
