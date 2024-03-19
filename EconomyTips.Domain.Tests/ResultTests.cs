using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace EconomyTips.Domain.Tests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class ResultTests
    {
        [Test]
        public void OK_Result_Successful()
        {
            // Arrange
            var result = new Result<int>();

            // Act
            result.OK(10);

            // Assert
            Assert.AreEqual(10, result.Value);
            Assert.IsTrue(result.Sucess);
            Assert.IsTrue(string.IsNullOrEmpty(result.ErrorMessage));
        }

        [Test]
        public void BadRequest_Result_Unsuccessful()
        {
            // Arrange
            var result = new Result<string>();

            // Act
            result.BadRequest("Bad request error");

            // Assert
            Assert.IsNull(result.Value);
            Assert.IsFalse(result.Sucess);
            Assert.AreEqual("Bad request error", result.ErrorMessage);
        }
    }
}
