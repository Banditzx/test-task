namespace TestTask.Tests
{
    using Moq;
    using NUnit.Framework;
    using NUnit.Framework.Legacy;
    using TestTask.Domain.Models;
    using TestTask.Domain.Models.Pagination;
    using TestTask.Infrastructure.Interfaces.Services;
    using TestTask.Services.Services;

    /// <summary>
    /// The LocationTests.
    /// </summary>
    [TestFixture]
    public class LocationServiceTests
    {
        private Mock<ILocationRepository> _locationRepositoryMock;
        private LocationService _locationService;

        [SetUp]
        public void Setup()
        {
            _locationRepositoryMock = new Mock<ILocationRepository>();
            _locationService = new LocationService(_locationRepositoryMock.Object);
        }

        /// <summary>
        /// Gets the countries asynchronous should return paginated result when called.
        /// </summary>
        [Test]
        public async Task GetCountriesAsync_ShouldReturnPaginatedResult_WhenCalled()
        {
            // Arrange
            var paginationParameters = new PaginationParameters { Page = 1, Size = 5 };
            var expectedCountries = new PaginatedResult<CountryModel>
            {
                Items = new List<CountryModel> {
                    new CountryModel { Id = 1, Name = "Австралия" },
                    new CountryModel { Id = 2, Name = "Австрия" },
                    new CountryModel { Id = 3, Name = "Азербайджан" },
                    new CountryModel { Id = 4, Name = "Албания" },
                    new CountryModel { Id = 5, Name = "Алжир" },
                },
                TotalItems = 5
            };

            _locationRepositoryMock
                .Setup(repo => repo.GetCountriesAsync(paginationParameters))
                .ReturnsAsync(expectedCountries);

            // Act
            var result = await _locationService.GetCountriesAsync(paginationParameters);

            // Assert
            Assert.That(result, Is.Not.Null);
            ClassicAssert.AreEqual(expectedCountries.TotalItems, result.TotalItems);
            ClassicAssert.AreEqual(expectedCountries.Items, result.Items);
            _locationRepositoryMock.Verify(repo => repo.GetCountriesAsync(paginationParameters), Times.Once);
        }

        /// <summary>
        /// Gets the provincies by country identifier asynchronous should return paginated result when called.
        /// </summary>
        [Test]
        public async Task GetProvinciesByCountryIdAsync_ShouldReturnPaginatedResult_WhenCalled()
        {
            // Arrange
            int countryId = 1;
            var paginationParameters = new PaginationParameters { Page = 1, Size = 3 };
            var expectedProvinces = new PaginatedResult<ProvinceModel>
            {
                Items = new List<ProvinceModel> {
                    new ProvinceModel { Id = 1, Name = "Новый Южный Уэльс" },
                    new ProvinceModel { Id = 2, Name = "Виктория" },
                    new ProvinceModel { Id = 3, Name = "Квинсленд" },
                },
                TotalItems = 3
            };

            _locationRepositoryMock
                .Setup(repo => repo.GetProvinciesByCountryIdAsync(countryId, paginationParameters))
                .ReturnsAsync(expectedProvinces);

            // Act
            var result = await _locationService.GetProvinciesByCountryIdAsync(countryId, paginationParameters);

            // Assert
            ClassicAssert.AreEqual(expectedProvinces.TotalItems, result.TotalItems);
            ClassicAssert.AreEqual(expectedProvinces.Items, result.Items);
            _locationRepositoryMock.Verify(repo => repo.GetProvinciesByCountryIdAsync(countryId, paginationParameters), Times.Once);
        }

        /// <summary>
        /// Gets the provincies by country identifier asynchronous should throw argument exception when country identifier is invalid.
        /// </summary>
        [Test]
        public async Task GetProvinciesByCountryIdAsync_ShouldThrowArgumentException_WhenCountryIdIsInvalid()
        {
            // Arrange
            int invalidCountryId = -1;
            var paginationParameters = new PaginationParameters { Page = 1, Size = 3 };

            // Act & Assert
            var result = await _locationService.GetProvinciesByCountryIdAsync(invalidCountryId, paginationParameters);

            Assert.That(result, Is.Null);
        }
    }
}