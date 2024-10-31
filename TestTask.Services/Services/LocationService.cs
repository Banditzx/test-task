namespace TestTask.Services.Services
{
    using System.Threading.Tasks;
    using TestTask.Domain.Models;
    using TestTask.Domain.Models.Pagination;
    using TestTask.Infrastructure.Interfaces.Repositories;
    using TestTask.Infrastructure.Interfaces.Services;

    /// <summary>
    /// The LocationService.
    /// </summary>
    /// <seealso cref="TestTask.Infrastructure.Interfaces.Repositories.ILocationService" />
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationService"/> class.
        /// </summary>
        /// <param name="locationRepository">The location repository.</param>
        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        /// <inheritdoc/>
        public async Task<PaginatedResult<CountryModel>> GetCountriesAsync(PaginationParameters pagination)
        {
            return await _locationRepository.GetCountriesAsync(pagination);
        }

        /// <inheritdoc/>
        public async Task<PaginatedResult<ProvinceModel>> GetProvinciesByCountryIdAsync(int countryId, PaginationParameters pagination)
        {
            return await _locationRepository.GetProvinciesByCountryIdAsync(countryId, pagination);
        }
    }
}
