namespace TestTask.Services.Services
{
    using TestTask.Domain.Models;
    using TestTask.Domain.Models.Account;
    using TestTask.Infrastructure.Interfaces.Repositories;
    using TestTask.Infrastructure.Interfaces.Services;

    /// <summary>
    /// The AccountService.
    /// </summary>
    /// <seealso cref="TestTask.Infrastructure.Interfaces.Services.IAccountService" />
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountService" /> class.
        /// </summary>
        /// <param name="accountRepository">The account repository.</param>
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        /// <inheritdoc/>
        public async Task<AccountModel> CreateUser(CreateAccountModel createUser)
        {
            var checkUser = await _accountRepository.IsEmailAvailable(createUser.Email);
            if (checkUser)
            {
                return await _accountRepository.CreateAccount(createUser);
            }

            return null;
        }

        /// <inheritdoc/>
        public async Task<AccountModel> UserValidation(string email, string password)
        {
            return await _accountRepository.UserVerification(email, password);
        }

        /// <inheritdoc/>
        public async Task<AccountModel> GetUserByEmailAsync(string email)
        {
            return await _accountRepository.GetAccountByEmailAsync(email);
        }
    }
}
