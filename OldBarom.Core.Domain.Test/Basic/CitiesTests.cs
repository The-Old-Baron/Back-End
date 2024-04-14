using Xunit;
using OldBarom.Core.Domain.Entities.Basic;
using System;
using OldBarom.Core.Domain.Validation;

namespace OldBarom.Core.Domain.Entities.Basic.Tests
{
    public class CitiesTests
    {

        [Fact]
        public void Cities_Constructor_SetsPropertiesAndDates()
        {
            // Arrange
            var name = "Test City";
            var stateId = 1;

            // Act
            var city = new Cities(name, stateId);

            // Assert
            Assert.Equal(name, city.Name);
            Assert.Equal(stateId, city.StateId);
            Assert.Equal(DateTime.Now.Date, city.CreatedAt.Date);
            Assert.Equal(DateTime.Now.Date, city.UpdatedAt.Date);
        }

        [Theory]
        [InlineData(null, 1)]
        [InlineData("", 1)]
        [InlineData("Test City", 0)]
        public void DomainValidation_InvalidParameters_ThrowsException(string name, int stateId)
        {
            // Act & Assert
            Assert.Throws<DomainExceptionValidation>(() => new Cities(name, stateId));
        }
    }
}