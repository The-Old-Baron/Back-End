using Xunit;
using OldBarom.Core.Domain.Entities.Basic;
using System;
using OldBarom.Core.Domain.Validation;

namespace OldBarom.Core.Domain.Entities.Basic.Tests
{
    public class CountriesTests
    {
        [Fact]
        public void Countries_Constructor_Should_Initialize_Correctly()
        {
            // Arrange
            string name = "Test Country";
            string iso3 = "TST";
            string numericCode = "123";
            string iso2 = "TS";
            string currency = "TST";
            string currencyName = "Test Currency";
            int regionId = 1;

            // Act
            var country = new Countries(name, iso3, numericCode, iso2, currency, currencyName, regionId);

            // Assert
            Assert.Equal(name, country.Name);
            Assert.Equal(iso3, country.ISO3);
            Assert.Equal(numericCode, country.NumericCode);
            Assert.Equal(iso2, country.ISO2);
            Assert.Equal(currency, country.Currency);
            Assert.Equal(currencyName, country.CurrencyName);
            Assert.Equal(regionId, country.RegionId);
        }

        [Fact]
        public void Countries_Constructor_Should_Throw_Exception_When_Name_Is_Null()
        {
            // Arrange
            string name = null;
            string iso3 = "TST";
            string numericCode = "123";
            string iso2 = "TS";
            string currency = "TST";
            string currencyName = "Test Currency";
            int regionId = 1;

            // Act & Assert
            Assert.Throws<DomainExceptionValidation>(() => new Countries(name, iso3, numericCode, iso2, currency, currencyName, regionId));
        }

        // Add more tests for other properties and methods...
    }
}