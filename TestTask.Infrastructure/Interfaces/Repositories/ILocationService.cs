namespace TestTask.Infrastructure.Interfaces.Repositories
{
    using TestTask.Domain.Models;
    using TestTask.Domain.Models.Pagination;

    /// <summary>
    /// The ILocationService.
    /// </summary>
    public interface ILocationService
    {
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
