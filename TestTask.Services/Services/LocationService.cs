namespace TestTask.Services.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TestTask.Domain.Models;
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
        public async Task<IEnumerable<CountryModel>> GetCountriesAsync(string countryName)
        {
            return await _locationRepository.GetCountriesAsync(countryName);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ProvinceModel>> GetProvinciesByCountryIdAsync(int countryId, string name)
        {
            return await _locationRepository.GetProvinciesByCountryIdAsync(countryId, name);
        }
    }
}
