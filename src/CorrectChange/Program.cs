using CorrectChange.Domain.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace CorrectChange
{
    /// <summary>
    ///     Main program
    /// </summary>
    public static class Program
    {
        // Name of an environment variable denoting the deployment type. 
        private const string EnvVar = "env";
        private static IConfiguration? _sConfiguration;
        private static IServiceCollection? _sServiceCollection;
        private static IServiceProvider? _sServiceProvider;

        /// <summary>
        ///     Entry point
        /// </summary>
        public static void Main(string[] args)
        {
        }

        /// <summary>
        ///     Load a configuration
        /// </summary>
        /// <remarks>
        ///     In order:
        ///     1) Loads a base appsettings.json
        ///     2) Loads an environment specific appsettings.json (different logging config perhaps)
        ///     3) Loads any environment variables
        ///     In a deployed environment (K8, AppService, etc) we can have the wider environment be
        ///     provided by infrastructure to tailor this specific deployment: Secrets, dependent
        ///     service names, etc
        /// </remarks>
        private static void BuildConfiguration()
        {
            ConfigurationBuilder configuration = new();
            var environmentName = GetEnvironmentName();

            _sConfiguration = configuration.AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{environmentName}.json", true, true)
                .AddEnvironmentVariables()
                .Build();
        }

        private static string GetEnvironmentName()
        {
            var environmentName = GetRawEnvironmentName();
            return environmentName switch
            {
                "prod" => "Production",
                "production" => "Production",
                _ => "Development"
            };
        }

        /// <summary>
        ///     Get the normalised environment variable contents
        /// </summary>
        /// <returns></returns>
        private static string GetRawEnvironmentName()
        {
            var envVar = Environment.GetEnvironmentVariable(EnvVar) ?? "Local";
            return envVar.Trim().ToLower();
        }

        /// <summary>
        ///     Populate DI container
        /// </summary>
        private static void ConfigureServices()
        {
            _sServiceCollection = new ServiceCollection();

            var appSettings = new AppSettings();
            _sConfiguration!.Bind("Settings", appSettings);

            _sServiceCollection.AddLogging(configure => configure.AddSerilog());

            #region Verbs

            // _sServiceCollection
            //     .AddTransient<>;

            #endregion

            _sServiceProvider = _sServiceCollection.BuildServiceProvider();
        }
    }
}