namespace TestTask.Infrastructure.Interfaces.Repositories
{
    using TestTask.Domain.Models;

    /// <summary>
    /// The ILocationService.
    /// </summary>
    public interface ILocationService
    {
        /// <summary>
        /// Gets the countries asynchronous.
        /// </summary>
        /// <param name="countryName">Name of the country.</param>
        /// <returns>IEnumerable CountryModel.</returns>
        Task<IEnumerable<CountryModel>> GetCountriesAsync(string countryName);

        /// <summary>
        /// Gets the provincies by country identifier.
        /// </summary>
        /// <param name="countryId">The country identifier.</param>
        /// <param name="name">The name.</param>
        /// <returns>
        /// IEnumerable ProvinceModel.
        /// </returns>
        Task<IEnumerable<ProvinceModel>> GetProvinciesByCountryIdAsync(int countryId, string name);
    }
}
