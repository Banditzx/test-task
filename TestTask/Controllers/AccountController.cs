namespace TestTask.Api.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TestTask.Infrastructure.Dto.Account;
    using TestTask.Infrastructure.Interfaces.Services;

    /// <summary>
    /// The AccountController.
    /// </summary>
    /// <seealso cref="TestTask.Api.Controllers.BaseController" />
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController" /> class.
        /// </summary>
        /// <param name="accountService">The account service.</param>
        /// <param name="mapper">The mapper.</param>
        public AccountController(IAccountService accountService, IMapper mapper) : base(accountService, mapper)
        {
            _accountService = accountService;
        }

        /// <summary>
        /// Gets me.
        /// </summary>
        /// <returns>AccountDto.</returns>
        [HttpGet("get/me")]
        public async Task<AccountDto> GetMe()
        {
            var account = await GetCurrentProfile();
            return Mapper.Map<AccountDto>(account);
        }
    }
}
