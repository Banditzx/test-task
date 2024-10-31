namespace TestTask.Infrastructure.Interfaces.Repositories
{
    using System.Threading.Tasks;
    using TestTask.Domain.Models;
    using TestTask.Domain.Models.Account;

    /// <summary>
    /// The IAccountRepository.
    /// </summary>
    public interface IAccountRepository
    {
        /// <summary>
        /// Creates the account.
        /// </summary>
        /// <param name="createAccount">The create account.</param>
        /// <returns>AccountModel.</returns>
        Task<AccountModel> CreateAccount(CreateAccountModel createAccount);

        /// <summary>
        /// Gets the account by email asynchronous.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>
        /// AccountModel.
        /// </returns>
        Task<AccountModel> GetAccountByEmailAsync(string email);

        /// <summary>
        /// Determines whether [is email available] [the specified email].
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>bool</returns>
        Task<bool> IsEmailAvailable(string email);

        /// <summary>
        /// Users the verification.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns>AccountModel.</returns>
        Task<AccountModel> UserVerification(string email, string password);
    }
}
