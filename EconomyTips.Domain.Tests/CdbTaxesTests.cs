using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace EconomyTips.Domain.Tests
{
    [TestFixture]
    public class CdbTaxesTests
    {
        [TestCase(3, 0.225)] // Test for month <= 6
        [TestCase(6, 0.225)] // Test for month <= 6
        [TestCase(7, 0.20)]  // Test for month > 6 and <= 12
        [TestCase(12, 0.20)] // Test for month > 6 and <= 12
        [TestCase(15, 0.175)] // Test for month > 12 and <= 24
        [TestCase(24, 0.175)] // Test for month > 12 and <= 24
        [TestCase(25, 0.175)] // Test for month > 24
        public void Fee_ReturnsCorrectTax(int month, double expectedTax)
        {
            // Arrange
            var cdbTaxes = new CdbTaxes();

            // Act
            var result = cdbTaxes.Fee(month);

            // Assert
            Assert.AreEqual(expectedTax, result);
        }
    }
}
