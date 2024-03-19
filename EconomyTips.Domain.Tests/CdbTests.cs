using NUnit.Framework;
using System;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace EconomyTips.Domain.Tests
{
    [TestFixture]
    public class CdbTests
    {
        [Test]
        public void Calculation_ValidInput_CalculatesCorrectly()
        {
            // Arrange
            var cdb = new Cdb();
            var input = new Cdb { StartValue = 1000, Months = 12 }; // Example input

            // Act
            var result = cdb.Calculation(input);

            // Assert
            Assert.AreEqual(1123.08, result.FinalValue); // Final value without taxes
            Assert.AreEqual(1098.46, result.FinalValueWithTaxes); // Final value with taxes
        }

        [Test]
        public void Calculation_InvalidStartValue_ThrowsArgumentException()
        {
            // Arrange
            var cdb = new Cdb();
            var input = new Cdb { StartValue = -1000, Months = 12 }; // Invalid start value

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => cdb.Calculation(input));
        }

        [Test]
        public void Calculation_InvalidMonths_ThrowsArgumentException()
        {
            // Arrange
            var cdb = new Cdb();
            var input = new Cdb { StartValue = 1000, Months = 0 }; // Invalid months

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => cdb.Calculation(input));
        }
    }
}
