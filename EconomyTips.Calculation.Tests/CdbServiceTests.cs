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
        private CdbService _cdbService;
        private Mock<ILogger<CdbService>> _loggerMock;
        private Mock<ICdb> _cdbMock;

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
            // Arrange
            var expectedResult = new Result<ICdb>().OK(_cdbMock.Object);

            // Act
            var result = _cdbService.GetCalculation(_cdbMock.Object);

            // Assert
            Assert.AreEqual(expectedResult.Sucess, result.Sucess);
            Assert.AreEqual(expectedResult.Value, result.Value);
            Assert.AreEqual(expectedResult.ErrorMessage, string.Empty);
        }

        [Test]
        public void GetCalculation_Exception()
        {
            // Arrange
            _cdbMock.Setup(c => c.Calculation(It.IsAny<ICdb>())).Throws(new Exception("Test exception"));

            // Act + Assert
            Assert.ThrowsException<Exception>(() => _cdbService.GetCalculation(_cdbMock.Object));
            _loggerMock.Verify(x => x.LogError(It.IsAny<string>(), It.IsAny<Exception>()), Times.Once);
        }
    }
}
