using EconomyTips.Domain;
using EconomyTips.Domain.Abstractions.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace EconomyTips.Calculation.Services.Tests
{
    [TestFixture]
    public class CdbServiceTests
    {

        private Mock<ILogger<CdbService>>? _loggerMock;
        private Mock<ICdb>? _cdbMock;
        private CdbService? _cdbService;
        

        [SetUp]
        public void SetUp()
        {
            _loggerMock = new Mock<ILogger<CdbService>>();
            _cdbMock = new Mock<ICdb>();
            _cdbService = new CdbService(_loggerMock.Object);
        }

        [Test]
        public void GetCalculation_Successful()
        {
            if (_cdbMock is not null)
            {
                // Arrange
                var expectedResult = new Result<ICdb>().OK(_cdbMock.Object);

                // Act
                var result = _cdbService?.GetCalculation(_cdbMock.Object);

                // Assert
                Assert.AreEqual(expectedResult.Sucess, result?.Sucess);
                Assert.AreEqual(expectedResult.ErrorMessage, string.Empty);
            }
            else
                Assert.AreEqual("", "error");
        }

        [Test]
        public void GetCalculation_Exception()
        {
            if (_cdbMock is not null)
            {
                // Arrange
                _cdbMock.Setup(c => c.Calculation(It.IsAny<ICdb>())).Throws(new Exception("Test exception"));

                // Act + Assert
                Assert.ThrowsException<Exception>(() => _cdbService?.GetCalculation(_cdbMock.Object), "Test exception");
            }
            else
                Assert.AreEqual("", "error");
        }
    }
}
