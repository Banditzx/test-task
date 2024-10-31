namespace TestTask.Domain.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The AccountEntity.
    /// </summary>
    /// <seealso cref="TestTask.Domain.Entities.BaseEntity" />
    public class AccountEntity : BaseEntity
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the country identifier.
        /// </summary>
        /// <value>
        /// The country identifier.
        /// </value>
        public int CountryId { get; set; }

        /// <summary>
        /// Gets or sets the province identifier.
        /// </summary>
        /// <value>
        /// The province identifier.
        /// </value>
        public int ProvinceId { get; set; }

        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>
        /// The created at.
        /// </value>
        public DateTimeOffset CreatedAt { get; set; }

        [ForeignKey("CountryId")]
        public virtual CountryEntity Country { get; set; }

        [ForeignKey("ProvinceId")]
        public virtual ProvinceEntity Province { get; set; }
    }
}