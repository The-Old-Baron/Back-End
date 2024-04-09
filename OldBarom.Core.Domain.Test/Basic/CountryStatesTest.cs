using OldBarom.Core.Domain.Entities.Basic;
using OldBarom.Core.Domain.Validation;

namespace OldBarom.Core.Domain.Test.Basic
{
    public class CountryStatesTest
    {
        [Fact]
        public void CreateCountryState_WithValidParameters_ShouldNotThrowException()
        {
            // Arrange
            string name = "Test State";
            int country_id = 1;

            // Act
            var state = new CountryStates(name, country_id);

            // Assert
            Assert.Equal(name, state.Name);
            Assert.Equal(country_id, state.CountryId);
        }

        [Fact]
        public void CreateCountryState_WithInvalidName_ShouldThrowException()
        {
            // Arrange
            string name = "";
            int country_id = 1;

            // Act & Assert
            Assert.Throws<DomainExceptionValidation>(() => new CountryStates(name, country_id));
        }

        [Fact]
        public void CreateCountryState_WithInvalidCountryId_ShouldThrowException()
        {
            // Arrange
            string name = "Test State";
            int country_id = 0;

            // Act & Assert
            Assert.Throws<DomainExceptionValidation>(() => new CountryStates(name, country_id));
        }
    }
}