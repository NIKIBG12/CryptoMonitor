using CryptoMonitor.Domain.Models;
using CryptoMonitor.Domain.Services;
using Microsoft.AspNet.Identity;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using static CryptoMonitor.Domain.Services.IAuthenticationService;

namespace CryptoMonitor.Domain.Tests.AuthenticationTests
{
    [TestFixture]
    public class Tests
    {
        private Mock<IPasswordHasher> _passHasher;
        private Mock<IAccountService> _accountService;
        private AuthenticationService _authentication;

        [SetUp]
        public void Setup()
        {
            _passHasher = new Mock<IPasswordHasher>();
            _accountService = new Mock<IAccountService>();
            _authentication = new AuthenticationService(_accountService.Object, _passHasher.Object);
        }

        [Test]
        public async Task Login_CorrectPass_()
        {

            string username = "uniTest";
            string password = "unispassword";
            _accountService.Setup(a => a.GetByUsername(username)).ReturnsAsync(new Account { AccountOwner = new User() { Username = username } }) ;
            _passHasher.Setup(a => a.VerifyHashedPassword(It.IsAny<string>() , password)).Returns(PasswordVerificationResult.Success);           
            
            Account account = await _authentication.Login(username, password);

            string realUsername = account.AccountOwner.Username;
            Assert.AreEqual(username, realUsername);
        }

        [Test]
        public void Login_IncorrectPass_()
        {
            string username = "uniTest";
            string password = "unispassword";
            _accountService.Setup(a => a.GetByUsername(username)).ReturnsAsync(new Account { AccountOwner = new User() { Username = username } });
            _passHasher.Setup(a => a.VerifyHashedPassword(It.IsAny<string>(), password)).Returns(PasswordVerificationResult.Failed);

            InvalidPasswordException exception = Assert.ThrowsAsync<InvalidPasswordException>(() => _authentication.Login(username, password));

            string realUsername = exception.Username;
            Assert.AreEqual(username, realUsername);
        }

        [Test]
        public void Login_NewUser_IncorrrectPass()
        {

            string username = "uniTest";
            string password = "unispassword";
            _passHasher.Setup(a => a.VerifyHashedPassword(It.IsAny<string>(), password)).Returns(PasswordVerificationResult.Failed);


            MissingUserException exception = Assert.ThrowsAsync<MissingUserException>(() => _authentication.Login(username, password));


            string realUsername = exception.Username;
            Assert.AreEqual(username, realUsername);
        }

        [Test]
        public async Task Register_NotMatchingPassword()
        {
            string password = "testpass";
            string confirmPassword = "testpasss";
            RegistrationResult expected = RegistrationResult.PasswordsNotMatch;

            RegistrationResult real = await _authentication.Register(It.IsAny<string>(), It.IsAny<string>(), password, confirmPassword);

            Assert.AreEqual(expected, real);
        }

        [Test]
        public async Task Register_AlreadyExistingEmail()
        {
            string email = "test@abv.bg";
            _accountService.Setup(a => a.GetByEmail(email)).ReturnsAsync(new Account());
            RegistrationResult expected = RegistrationResult.EmailAlreadyExists;

            RegistrationResult real = await _authentication.Register(email, It.IsAny<string>(), "testpass", "testpass");

            Assert.AreEqual(expected, real);
        }

        [Test]
        public async Task Register_AlreadyExistingUsername()
        {
            string username = "tester";
            _accountService.Setup(a => a.GetByUsername(username)).ReturnsAsync(new Account());
            RegistrationResult expected = RegistrationResult.UsernameAlreadyExists;

            RegistrationResult real = await _authentication.Register(It.IsAny<string>(), username, "testpass", "testpass");

            Assert.AreEqual(expected, real);
        }

        [Test]
        public async Task Register_NewUserAndMatchingPasswords()
        {
            RegistrationResult expected = RegistrationResult.Success;

            RegistrationResult real = await _authentication.Register(It.IsAny<string>(), It.IsAny<string>(), "testpass", "testpass");

            Assert.AreEqual(expected, real);
        }
    }
}
