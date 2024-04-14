using Xunit;
using OldBarom.Core.Domain.Entities.Basic;
using System;
using OldBarom.Core.Domain.Validation;

namespace OldBarom.Core.Domain.Entities.Basic.Tests
{
    public class CountriesTests
    {
        [Fact]
        public void Countries_Constructor_Assigns_Values_Correctly()
        {
            // Arrange
            string name = "Test Country";
            string iSO3 = "TST";
            string numericCode = "123";
            string iSO2 = "TS";
            string currency = "TSC";
            string currencyName = "Test Currency";
            int regionId = 1;

            // Act
            var country = new Countries(name, iSO3, numericCode, iSO2, currency, currencyName, regionId);

            // Assert
            Assert.Equal(name, country.Name);
            Assert.Equal(iSO3, country.ISO3);
            Assert.Equal(numericCode, country.NumericCode);
            Assert.Equal(iSO2, country.ISO2);
            Assert.Equal(currency, country.Currency);
            Assert.Equal(currencyName, country.CurrencyName);
            Assert.Equal(regionId, country.RegionId);
        }

        [Fact]
        public void ValidateDomain_Throws_Exception_When_Name_Is_Null()
        {
            // Arrange
            var ex = Assert.Throws<DomainExceptionValidation>(() => new Countries(null, "TST", "123", "TS", "TSC", "Test Currency", 1));
            Assert.Equal("Name is required", ex.Message);
        }

        // Add similar tests for ISO3, NumericCode, ISO2, Currency, CurrencyName, and RegionId
    }
}