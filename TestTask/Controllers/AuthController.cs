namespace TestTask.Api.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Net;
    using System.Security.Claims;
    using System.Text;
    using TestTask.Domain.Models.Account;
    using TestTask.Infrastructure.Dto.Account;
    using TestTask.Infrastructure.Dto.Support;
    using TestTask.Infrastructure.Interfaces.Services;

    /// <summary>
    /// The AuthController.
    /// </summary>
    /// <seealso cref="TestTask.Api.Controllers.BaseController" />
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : BaseController
    {
        private readonly IAccountService _accountService;
        private readonly IConfigurationService _configurationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController" /> class.
        /// </summary>
        /// <param name="accountService">The account service.</param>
        /// <param name="configurationService">The configuration service.</param>
        /// <param name="mapper">The mapper.</param>
        public AuthController(IAccountService accountService,
                              IConfigurationService configurationService,
                              IMapper mapper) : base(accountService, mapper)
        {
            _accountService = accountService;
            _configurationService = configurationService;
        }

        /// <summary>
        /// Sing in.
        /// </summary>
        /// <param name="signInDto">The sign in dto.</param>
        /// <returns>
        /// AccessModel.
        /// </returns>
        [HttpPost("sign-in")]
        public async Task<AccessDto> SingInAsync(SignInDto signIn)
        {
            var user = await _accountService.UserValidation(signIn.Email, signIn.Password);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                };

                var identity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                var timeNow = DateTime.UtcNow;
                var configs = _configurationService.GetConfig();
                var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configs.Auth.Key));

                var jwt = new JwtSecurityToken(
                    issuer: configs.Auth.Issuer,
                    audience: configs.Auth.Audience,
                    notBefore: timeNow,
                    claims: identity.Claims,
                    expires: timeNow.Add(TimeSpan.FromMinutes(configs.Auth.Lifetime)),
                    signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512));

                return new AccessDto
                {
                    StatusCode = HttpStatusCode.OK,
                    AccessToken = new JwtSecurityTokenHandler().WriteToken(jwt),
                    Message = string.Empty,
                };
            }

            return new AccessDto
            {
                AccessToken = string.Empty,
                StatusCode = HttpStatusCode.NotFound,
                Message = "Invalid username or password!"
            };
        }

        /// <summary>
        /// Sing up
        /// </summary>
        /// <param name="signUpDto">The sign up dto.</param>
        /// <returns>
        /// UserModel.
        /// </returns>
        [HttpPost("sign-up")]
        public async Task<AccountDto> SingUpAsync(SignUpDto signUp)
        {
            var account = await _accountService.CreateUser(new CreateAccountModel
            {
                Email = signUp.Email.Trim().ToLower(),
                Password = signUp.Password,
                ProvinceId = signUp.ProvinceId,
            });

            return Mapper.Map<AccountDto>(account);
        }
    }
}
