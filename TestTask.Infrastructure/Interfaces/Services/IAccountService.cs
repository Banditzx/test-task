namespace TestTask.Infrastructure.Interfaces.Services
{
    using TestTask.Domain.Models;
    using TestTask.Domain.Models.Account;

    /// <summary>
    /// The IAccountService.
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="createUser">The create user.</param>
        /// <returns>AccountModel.</returns>
        Task<AccountModel> CreateUser(CreateAccountModel createUser);

        /// <summary>
        /// Users the validation.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns>AccountModel.</returns>
        Task<AccountModel> UserValidation(string email, string password);

        /// <summary>
        /// Gets the user by email asynchronous.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        Task<AccountModel> GetUserByEmailAsync(string email);
    }
}