namespace TestTask.Infrastructure.Dto.Account
{
    using TestTask.Infrastructure.Dto.Base;
    using TestTask.Infrastructure.Dto.Support;

    /// <summary>
    /// The AccountDto.
    /// </summary>
    /// <seealso cref="BaseDto" />
    public class AccountDto : BaseDto
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public CountryDto Country { get; set; }

        /// <summary>
        /// Gets or sets the province.
        /// </summary>
        /// <value>
        /// The province.
        /// </value>
        public ProvinceDto Province { get; set; }

        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>
        /// The created at.
        /// </value>
        public DateTimeOffset CreatedAt { get; set; }
    }
}
