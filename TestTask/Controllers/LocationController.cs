namespace TestTask.Api.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using TestTask.Infrastructure.Dto.Support;
    using TestTask.Infrastructure.Interfaces.Repositories;
    using TestTask.Infrastructure.Interfaces.Services;

    /// <summary>
    /// The SupportController.
    /// </summary>
    /// <seealso cref="TestTask.Api.Controllers.BaseController" />
    [ApiController]
    [Route("[controller]")]
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
        [HttpGet("country/list")]
        public async Task<IEnumerable<CountryDto>> GetCountriesByName(string name)
        {
            var countries = await _locationService.GetCountriesAsync(name);
            return Mapper.Map<IEnumerable<CountryDto>>(countries);
        }

        /// <summary>
        /// Gets the name of the provincies by.
        /// </summary>
        /// <param name="countryId">The country identifier.</param>
        /// <param name="name">The name.</param>
        /// <returns>IEnumerable ProvinceDto.</returns>
        [HttpGet("province/list")]
        public async Task<IEnumerable<ProvinceDto>> GetProvinciesByName(int countryId, string name)
        {
            var provincies = await _locationService.GetProvinciesByCountryIdAsync(countryId, name);
            return Mapper.Map<IEnumerable<ProvinceDto>>(provincies);
        }
    }
}