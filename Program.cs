using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApplication3.Models;
using System.Threading.Tasks;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddScoped<DatabaseOperations>();

        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddDbContext<DatabaseContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.MapRazorPages();
        app.MapControllers();

        // Start the web application
        var webAppTask = app.RunAsync();

        // Perform database operations
        var databaseOperationsTask = Task.Run(async () =>
        {
            await PerformDatabaseOperationsAsync(app.Services);
        });

        // Wait for both the web application and database operations to complete
        await Task.WhenAll(webAppTask, databaseOperationsTask);
    }

    private static async Task PerformDatabaseOperationsAsync(IServiceProvider services)
    {
        using (var scope = services.CreateScope())
        {
            // Resolve DatabaseOperations from the scope's ServiceProvider
            var databaseOperations = scope.ServiceProvider.GetRequiredService<DatabaseOperations>();

            // Read files from the folder
            var folder = "/app/DataFiles";
            List<InputFile> inputFiles = await IOOperations.ReadFolderAsync(folder);

            // Process each inputFile
            foreach (InputFile inputFile in inputFiles)
            {
                Match match = IOOperations.inputFileToMatch(inputFile);
                await databaseOperations.AddToDbAsync(match);
            }
        }
    }
}