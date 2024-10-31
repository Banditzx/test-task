namespace TestTask.Infrastructure.Interfaces.Services
{
    using TestTask.Infrastructure.Config;

    /// <summary>
    /// The IConfigurationService.
    /// </summary>
    public interface IConfigurationService
    {
        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <returns>AppConfiguration.</returns>
        AppConfiguration GetConfig();
    }
}
