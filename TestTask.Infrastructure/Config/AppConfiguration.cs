namespace TestTask.Infrastructure.Config
{
    /// <summary>
    /// The AppConfiguration.
    /// </summary>
    public class AppConfiguration
    {
        /// <summary>
        /// Gets or sets the encrypter salt.
        /// </summary>
        /// <value>
        /// The encrypter salt.
        /// </value>
        public string EncrypterSalt { get; set; }

        /// <summary>
        /// Gets or sets the authentication.
        /// </summary>
        /// <value>
        /// The authentication.
        /// </value>
        public AuthConfiguration Auth { get; set; }
    }
}