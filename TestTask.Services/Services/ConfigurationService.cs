namespace TestTask.Services.Services
{
    using Microsoft.Extensions.Options;
    using TestTask.Infrastructure.Config;
    using TestTask.Infrastructure.Interfaces.Services;

    /// <summary>
    /// The ConfigurationService.
    /// </summary>
    /// <seealso cref="TestTask.Infrastructure.Interfaces.Services.IConfigurationService" />
    public class ConfigurationService : IConfigurationService
    {
        private readonly AppConfiguration _appConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationService"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public ConfigurationService(IOptions<AppConfiguration> options)
        {
            _appConfiguration = options.Value;
        }

        /// <inheritdoc/>
        public AppConfiguration GetConfig()
        {
            return _appConfiguration;
        }
    }
}
