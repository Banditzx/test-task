namespace TestTask.Infrastructure.Dto.Account
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The SignUpDto.
    /// </summary>
    public class SignUpDto
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 100 characters.")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the province identifier.
        /// </summary>
        /// <value>
        /// The province identifier.
        /// </value>
        [Required(ErrorMessage = "Province ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Province ID must be a positive number.")]
        public int ProvinceId { get; set; }
    }
}
