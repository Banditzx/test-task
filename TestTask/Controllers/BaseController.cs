namespace TestTask.Api.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using TestTask.Domain.Models;
    using TestTask.Infrastructure.Interfaces.Services;

    /// <summary>
    /// The base controller
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController" /> class.
        /// </summary>
        /// <param name="accountService">The account service.</param>
        /// <param name="mapper">The mapper.</param>
        public BaseController(IAccountService accountService, IMapper mapper)
        {
            AccountService = accountService;
            Mapper = mapper;
        }

        /// <summary>
        /// Gets the account service.
        /// </summary>
        /// <value>
        /// The account service.
        /// </value>
        protected IAccountService AccountService { get; }

        /// <summary>
        /// The mapper.
        /// </summary>
        protected IMapper Mapper;

        /// <summary>
        /// Gets the current profile.
        /// </summary>
        /// <returns>Profile.</returns>
        [NonAction]
        public async Task<AccountModel> GetCurrentProfile()
        {
            if (User.Identity == null || !User.Identity.IsAuthenticated || User.Identity.Name == null)
            {
                return null;
            }

            return await AccountService.GetUserByEmailAsync(User.Identity.Name);
        }
    }
}