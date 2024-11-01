namespace TestTask.Tests
{
    using Moq;
    using NUnit.Framework;
    using TestTask.Domain.Models.Account;
    using TestTask.Domain.Models;
    using TestTask.Infrastructure.Interfaces.Repositories;
    using TestTask.Services.Services;
    using NUnit.Framework.Legacy;

    /// <summary>
    /// The AccountTests.
    /// </summary>
    [TestFixture]
    public class AccountServiceTests
    {
        private Mock<IAccountRepository> _accountRepositoryMock;
        private AccountService _accountService;

        [SetUp]
        public void Setup()
        {
            _accountRepositoryMock = new Mock<IAccountRepository>();
            _accountService = new AccountService(_accountRepositoryMock.Object);
        }

        /// <summary>
        /// Creates the user should return account model when email is available.
        /// </summary>
        [Test]
        public async Task CreateUser_ShouldReturnAccountModel_WhenEmailIsAvailable()
        {
            // Arrange
            var createAccountModel = new CreateAccountModel { Email = "test@example.com" };
            var expectedAccount = new AccountModel { Id = 1, Email = "test@example.com" };

            _accountRepositoryMock
                .Setup(repo => repo.IsEmailAvailable(createAccountModel.Email))
                .ReturnsAsync(true);

            _accountRepositoryMock
                .Setup(repo => repo.CreateAccount(createAccountModel))
                .ReturnsAsync(expectedAccount);

            // Act
            var result = await _accountService.CreateUser(createAccountModel);

            // Assert
            Assert.That(result, Is.Not.Null);
            ClassicAssert.AreEqual(expectedAccount, result);
            _accountRepositoryMock.Verify(repo => repo.IsEmailAvailable(createAccountModel.Email), Times.Once);
            _accountRepositoryMock.Verify(repo => repo.CreateAccount(createAccountModel), Times.Once);
        }

        /// <summary>
        /// Creates the user should return null when email is not available.
        /// </summary>
        [Test]
        public async Task CreateUser_ShouldReturnNull_WhenEmailIsNotAvailable()
        {
            // Arrange
            var createAccountModel = new CreateAccountModel { Email = "test@example.com" };

            _accountRepositoryMock
                .Setup(repo => repo.IsEmailAvailable(createAccountModel.Email))
                .ReturnsAsync(false);

            // Act
            var result = await _accountService.CreateUser(createAccountModel);

            // Assert
            Assert.That(result, Is.Null);
            _accountRepositoryMock.Verify(repo => repo.IsEmailAvailable(createAccountModel.Email), Times.Once);
            _accountRepositoryMock.Verify(repo => repo.CreateAccount(It.IsAny<CreateAccountModel>()), Times.Never);
        }

        /// <summary>
        /// Users the validation should return account model when credentials are correct.
        /// </summary>
        [Test]
        public async Task UserValidation_ShouldReturnAccountModel_WhenCredentialsAreCorrect()
        {
            // Arrange
            var email = "test@example.com";
            var password = "password123";
            var expectedAccount = new AccountModel { Id = 1, Email = email };

            _accountRepositoryMock
                .Setup(repo => repo.UserVerification(email, password))
                .ReturnsAsync(expectedAccount);

            // Act
            var result = await _accountService.UserValidation(email, password);

            // Assert
            Assert.That(result, Is.Not.Null);
            ClassicAssert.AreEqual(expectedAccount, result);
            _accountRepositoryMock.Verify(repo => repo.UserVerification(email, password), Times.Once);
        }

        /// <summary>
        /// Users the validation should return null when credentials are incorrect.
        /// </summary>
        [Test]
        public async Task UserValidation_ShouldReturnNull_WhenCredentialsAreIncorrect()
        {
            // Arrange
            var email = "test@example.com";
            var password = "wrongpassword";

            _accountRepositoryMock
                .Setup(repo => repo.UserVerification(email, password))
                .ReturnsAsync((AccountModel)null);

            // Act
            var result = await _accountService.UserValidation(email, password);

            // Assert
            Assert.That(result, Is.Null);
            _accountRepositoryMock.Verify(repo => repo.UserVerification(email, password), Times.Once);
        }

        /// <summary>
        /// Gets the user by email asynchronous should return account model when email exists.
        /// </summary>
        [Test]
        public async Task GetUserByEmailAsync_ShouldReturnAccountModel_WhenEmailExists()
        {
            // Arrange
            var email = "test@example.com";
            var expectedAccount = new AccountModel { Id = 1, Email = email };

            _accountRepositoryMock
                .Setup(repo => repo.GetAccountByEmailAsync(email))
                .ReturnsAsync(expectedAccount);

            // Act
            var result = await _accountService.GetUserByEmailAsync(email);

            // Assert
            Assert.That(result, Is.Not.Null);
            ClassicAssert.AreEqual(expectedAccount, result);
            _accountRepositoryMock.Verify(repo => repo.GetAccountByEmailAsync(email), Times.Once);
        }

        /// <summary>
        /// Gets the user by email asynchronous should return null when email does not exist.
        /// </summary>
        [Test]
        public async Task GetUserByEmailAsync_ShouldReturnNull_WhenEmailDoesNotExist()
        {
            // Arrange
            var email = "nonexistent@example.com";

            _accountRepositoryMock
                .Setup(repo => repo.GetAccountByEmailAsync(email))
                .ReturnsAsync((AccountModel)null);

            // Act
            var result = await _accountService.GetUserByEmailAsync(email);

            // Assert
            Assert.That(result, Is.Null);
            _accountRepositoryMock.Verify(repo => repo.GetAccountByEmailAsync(email), Times.Once);
        }
    }
}
