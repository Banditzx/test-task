namespace TestTask.Api.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using TestTask.Domain.Models.Pagination;
    using TestTask.Infrastructure.Dto.Support;
    using TestTask.Infrastructure.Interfaces.Repositories;
    using TestTask.Infrastructure.Interfaces.Services;

    /// <summary>
    /// The SupportController.
    /// </summary>
    /// <seealso cref="TestTask.Api.Controllers.BaseController" />
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : BaseController
    {
        private readonly ILocationService _locationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationController" /> class.
        /// </summary>
        /// <param name="accountService">The account service.</param>
        /// <param name="locationService">The location service.</param>
        /// <param name="mapper">The mapper.</param>
        public LocationController(IAccountService accountService,
                                  ILocationService locationService,
                                  IMapper mapper) : base(accountService, mapper)
        {
            _locationService = locationService;
        }

        /// <summary>
        /// Gets the name of the countries by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>IEnumerable CountryDto.</returns>
        [HttpPost("get/country/list")]
        public async Task<PaginatedResult<CountryDto>> GetCountriesByName([FromBody] PaginationParameters pagination)
        {
            var countries = await _locationService.GetCountriesAsync(pagination);
            return Mapper.Map<PaginatedResult<CountryDto>>(countries);
        }

        /// <summary>
        /// Gets the name of the provincies by.
        /// </summary>
        /// <param name="countryId">The country identifier.</param>
        /// <param name="name">The name.</param>
        /// <returns>IEnumerable ProvinceDto.</returns>
        [HttpPost("get/province/list")]
        public async Task<PaginatedResult<ProvinceDto>> GetProvinciesByName(int countryId, [FromBody] PaginationParameters pagination)
        {
            var provincies = await _locationService.GetProvinciesByCountryIdAsync(countryId, pagination);
            return Mapper.Map<PaginatedResult<ProvinceDto>>(provincies);
        }
    }
}