using EconomyTips.Domain;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace EconomyTips.Tests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class CdbTaxesTests
    {
        [Test]
        public void Fee_ReturnsCorrectTaxForSixMonths()
        {
            // Arrange
            var cdbTaxes = new CdbTaxes();

            // Act
            var tax = cdbTaxes.Fee(6);

            // Assert
            Assert.AreEqual(0.225, tax);
        }

        [Test]
        public void Fee_ReturnsCorrectTaxForOneYear()
        {
            // Arrange
            var cdbTaxes = new CdbTaxes();

            // Act
            var tax = cdbTaxes.Fee(12);

            // Assert
            Assert.AreEqual(0.20, tax);
        }

        [Test]
        public void Fee_ReturnsCorrectTaxForTwoYears()
        {
            // Arrange
            var cdbTaxes = new CdbTaxes();

            // Act
            var tax = cdbTaxes.Fee(24); // Two years

            // Assert
            Assert.AreEqual(0.175, tax);
        }

        [Test]
        public void Fee_ReturnsCorrectTaxForAboveTwoYears()
        {
            // Arrange
            var cdbTaxes = new CdbTaxes();

            // Act
            var tax = cdbTaxes.Fee(25); // Above two years

            // Assert
            Assert.AreEqual(0.175, tax);
        }
    }
}
