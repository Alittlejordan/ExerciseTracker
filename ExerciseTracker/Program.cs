using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace ExerciseTracker
{
    internal class Program
    {
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        static void Main(string[] args)
        {
           // Create a service collection and configure our dependencies
            var serviceProvider = new ServiceCollection()
                 .AddDbContext<ExerciseDbContext>(options =>
                 {
                     options.UseSqlServer(ConnectionString);
                 })
            .AddScoped<IExerciseRepository, ExerciseRepository>()
            .AddScoped<ExerciseService>()
            .AddScoped<ExerciseController>()
            .BuildServiceProvider();

            // Resolve the controller and run your application logic
            var exerciseController = serviceProvider.GetRequiredService<ExerciseController>();
            exerciseController.Run();

            // Dispose of the service provider if necessary
            if (serviceProvider is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
    }
}