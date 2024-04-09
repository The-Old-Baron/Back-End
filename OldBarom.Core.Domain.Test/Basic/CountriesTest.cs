using OldBarom.Core.Domain.Entities.Basic;
using OldBarom.Core.Domain.Validation;

namespace OldBarom.Core.Domain.Test.Basic
{
    public class CountriesTest
    {
        [Fact]
        public void CreateCountries_WithValidParameters_ShouldNotThrowException()
        {
            // Arrange
            string name = "Test Country";
            string iso3 = "TST";
            string numeric_code = "123";
            string iso2 = "TS";
            string currency = "TSC";
            string currency_name = "Test Currency";
            int region_id = 1;

            // Act
            var country = new Countries(name, iso3, numeric_code, iso2, currency, currency_name, region_id);

            // Assert
            Assert.Equal(name, country.Name);
            Assert.Equal(iso3, country.ISO3);
            Assert.Equal(numeric_code, country.NumericCode);
            Assert.Equal(iso2, country.ISO2);
            Assert.Equal(currency, country.Currency);
            Assert.Equal(currency_name, country.CurrencyName);
            Assert.Equal(region_id, country.RegionId);
        }

        [Theory]
        [InlineData(null, "TST", "123", "TS", "TSC", "Test Currency", 1)] // Null name
        [InlineData("", "TST", "123", "TS", "TSC", "Test Currency", 1)] // Empty name
        [InlineData("Test Country", null, "123", "TS", "TSC", "Test Currency", 1)] // Null iso3
        [InlineData("Test Country", "", "123", "TS", "TSC", "Test Currency", 1)] // Empty iso3
        [InlineData("Test Country", "TST", null, "TS", "TSC", "Test Currency", 1)] // Null numeric_code
        [InlineData("Test Country", "TST", "", "TS", "TSC", "Test Currency", 1)] // Empty numeric_code
        [InlineData("Test Country", "TST", "123", null, "TSC", "Test Currency", 1)] // Null iso2
        [InlineData("Test Country", "TST", "123", "", "TSC", "Test Currency", 1)] // Empty iso2
        [InlineData("Test Country", "TST", "123", "TS", null, "Test Currency", 1)] // Null currency
        [InlineData("Test Country", "TST", "123", "TS", "", "Test Currency", 1)] // Empty currency
        [InlineData("Test Country", "TST", "123", "TS", "TSC", null, 1)] // Null currency_name
        [InlineData("Test Country", "TST", "123", "TS", "TSC", "", 1)] // Empty currency_name
        [InlineData("Test Country", "TST", "123", "TS", "TSC", "Test Currency", 0)] // Invalid region_id
        public void CreateCountries_WithInvalidParameters_ShouldThrowException(string name, string iso3, string numeric_code, string iso2, string currency, string currency_name, int region_id)
        {
            // Act & Assert
            Assert.Throws<DomainExceptionValidation>(() => new Countries(name, iso3, numeric_code, iso2, currency, currency_name, region_id));
        }
    }
}