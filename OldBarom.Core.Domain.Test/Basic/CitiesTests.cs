using Xunit;
using OldBarom.Core.Domain.Entities.Basic;
using System;
using OldBarom.Core.Domain.Validation;
namespace OldBarom.Core.Domain.Entities.Basic.Tests
{
    public class CitiesTests
    {
        [Fact(DisplayName = "With Valid Parameters")]
        public void Cities_Constructor_ShouldCreateObject()
        {
            // Arrange
            string name = "Test City";
            int stateId = 1;

            // Act
            var city = new Cities(name, stateId);

            // Assert
            Assert.NotNull(city);
            Assert.Equal(name, city.Name);
            Assert.Equal(stateId, city.StateId);
        }

        [Fact(DisplayName = "With Empty Name")]
        public void Cities_Constructor_ShouldThrowException_WhenNameIsEmpty()
        {
            // Arrange
            string name = string.Empty;
            int stateId = 1;

            // Act & Assert
            Assert.Throws<DomainExceptionValidation>(() => new Cities(name, stateId));
        }

        [Fact(DisplayName = "With State ID Zero")]
        public void Cities_Constructor_ShouldThrowException_WhenStateIdIsZero()
        {
            // Arrange
            string name = "Test City";
            int stateId = 0;

            // Act & Assert
            Assert.Throws<DomainExceptionValidation>(() => new Cities(name, stateId));
        }
    }
}