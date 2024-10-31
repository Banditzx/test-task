﻿namespace TestTask.Repositories.Repositories
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using TestTask.Domain.Entities;
    using TestTask.Domain.Models;
    using TestTask.Infrastructure.Interfaces.Services;

    /// <summary>
    /// The LocationRepository.
    /// </summary>
    /// <seealso cref="TestTask.Repositories.Repositories.BaseRepository&lt;TestTask.Domain.Entities.CountryEntity&gt;" />
    /// <seealso cref="TestTask.Infrastructure.Interfaces.Services.ILocationRepository" />
    public class LocationRepository : BaseRepository<CountryEntity>, ILocationRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocationRepository"/> class.
        /// </summary>
        /// <param name="storeEntities">The store entities.</param>
        /// <param name="mapper"></param>
        public LocationRepository(StoreEntities storeEntities, IMapper mapper) : base(storeEntities, mapper)
        {
        }

        /// <inheritdoc/>
        public async Task<CountryModel> GetCountryByProvinceIdAsync(int provinceId)
        {
            var province = await _storeEntities.Provinces
                .Where(x => x.Id == provinceId)
                .Include(x => x.Country)
                .FirstOrDefaultAsync();

            return _mapper.Map<CountryModel>(province.Country);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<CountryModel>> GetCountriesAsync(string countryName)
        {
            var countries = await GetBy(x => x.Name.Contains(countryName)).ToListAsync();
            return _mapper.Map<IEnumerable<CountryModel>>(countries);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ProvinceModel>> GetProvinciesByCountryIdAsync(int countryId, string name)
        {
            var country = await GetBy(x => x.Id == countryId && x.Name.Contains(name)).Include(x => x.Provinces).FirstOrDefaultAsync();
            return _mapper.Map<IEnumerable<ProvinceModel>>(country.Provinces);
        }
    }
}