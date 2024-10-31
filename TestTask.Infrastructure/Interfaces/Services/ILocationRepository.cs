namespace TestTask.Infrastructure.Interfaces.Services
{
    using TestTask.Domain.Models;
    using TestTask.Domain.Models.Pagination;

    /// <summary>
    /// The ILocationRepository.
    /// </summary>
    public interface ILocationRepository
    {
        /// <summary>
        /// Gets the country by province identifier asynchronous.
        /// </summary>
        /// <param name="provinceId">The province identifier.</param>
        /// <returns>CountryModel.</returns>
        Task<CountryModel> GetCountryByProvinceIdAsync(int provinceId);

        /// <summary>
        /// Gets the countries asynchronous.
        /// </summary>
        /// <param name="pagination">The pagination.</param>
        /// <returns>
        /// IEnumerable CountryModel.
        /// </returns>
        Task<PaginatedResult<CountryModel>> GetCountriesAsync(PaginationParameters pagination);

        /// <summary>
        /// Gets the provincies by country identifier.
        /// </summary>
        /// <param name="countryId">The country identifier.</param>
        /// <param name="pagination">The pagination.</param>
        /// <returns>
        /// IEnumerable ProvinceModel.
        /// </returns>
        Task<PaginatedResult<ProvinceModel>> GetProvinciesByCountryIdAsync(int countryId, PaginationParameters pagination);
    }
}
