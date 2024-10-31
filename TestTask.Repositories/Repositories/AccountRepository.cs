namespace TestTask.Repositories.Repositories
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using TestTask.Domain.Entities;
    using TestTask.Infrastructure.Extensions;
    using TestTask.Domain.Models;
    using TestTask.Infrastructure.Interfaces.Repositories;
    using TestTask.Domain.Models.Account;
    using Serilog;
    using TestTask.Infrastructure.Interfaces.Services;

    /// <summary>
    /// The AccountRepository.
    /// </summary>
    /// <seealso cref="TestTask.Repositories.Repositories.BaseRepository&lt;TestTask.Domain.Entities.AccountEntity&gt;" />
    /// <seealso cref="TestTask.Infrastructure.Interfaces.Repositories.IAccountRepository" />
    public class AccountRepository : BaseRepository<AccountEntity>, IAccountRepository
    {
        private readonly ILocationRepository _locationRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountRepository" /> class.
        /// </summary>
        /// <param name="storeEntities">The store entities.</param>
        /// <param name="locationRepository">The location repository.</param>
        /// <param name="mapper">The mapper.</param>
        public AccountRepository(StoreEntities storeEntities,
                                 ILocationRepository locationRepository,
                                 IMapper mapper) : base(storeEntities, mapper)
        {
            _locationRepository = locationRepository;
        }

        /// <inheritdoc/>
        public async Task<AccountModel> CreateAccount(CreateAccountModel createAccount)
        {
            using var transaction = _storeEntities.Database.BeginTransaction();
            try
            {
                var country = await _locationRepository.GetCountryByProvinceIdAsync(createAccount.ProvinceId);
                var newAccount = new AccountEntity
                {
                    Email = createAccount.Email,
                    CreatedAt = DateTimeOffset.UtcNow,
                    Password = createAccount.Password.EncryptSha512(),
                    CountryId = country.Id,
                    ProvinceId = createAccount.ProvinceId,
                };

                await Create(newAccount);

                transaction.Commit();

                return _mapper.Map<AccountModel>(newAccount);
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                transaction.Rollback();
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<AccountModel> GetAccountByEmailAsync(string email)
        {
            var account = await GetBy(x => x.Email == email)
                .Include(x => x.Country)
                .FirstOrDefaultAsync();

            return _mapper.Map<AccountModel>(account);
        }

        /// <inheritdoc/>
        public async Task<bool> IsEmailAvailable(string email)
        {
            var account = await GetAccountByEmailAsync(email);
            return account == null;
        }

        /// <inheritdoc/>
        public async Task<AccountModel> UserVerification(string email, string password)
        {
            string encryptPassword = password.EncryptSha512();
            var user = await GetBy(x => x.Email == email && x.Password == encryptPassword)
                .FirstOrDefaultAsync();

            return _mapper.Map<AccountModel>(user);
        }
    }
}