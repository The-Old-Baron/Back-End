using Xunit;
using OldBarom.Core.Domain.Entities.Basic;
using System;
using OldBarom.Core.Domain.Validation;

namespace OldBarom.Core.Domain.Entities.Basic.Tests
{
    public class CountryStatesTests
    {
        [Fact(DisplayName = "With Valid Parameters")]
        public void DomainValidation_WhenNameIsEmpty_ThrowsException()
        {
            // Arrange
            string name = string.Empty;
            int countryId = 1;

            // Act and Assert
            var exception = Assert.Throws<DomainExceptionValidation>(() => new CountryStates(name, countryId));
            Assert.Equal("Name is required", exception.Message);
        }

        [Fact(DisplayName = "With State ID Zero")]
        public void DomainValidation_WhenCountryIdIsZero_ThrowsException()
        {
            // Arrange
            string name = "Test";
            int countryId = 0;

            // Act and Assert
            var exception = Assert.Throws<DomainExceptionValidation>(() => new CountryStates(name, countryId));
            Assert.Equal("Country is required", exception.Message);
        }

        [Fact(DisplayName = "With Valid Parameters")]
        public void DomainValidation_WhenValidInputs_DoesNotThrowException()
        {
            // Arrange
            string name = "Test";
            int countryId = 1;

            // Act
            var countryStates = new CountryStates(name, countryId);

            // Assert
            Assert.NotNull(countryStates);
            Assert.Equal(name, countryStates.Name);
            Assert.Equal(countryId, countryStates.CountryId);
        }
    }
}