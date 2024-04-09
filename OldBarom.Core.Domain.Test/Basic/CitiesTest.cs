using OldBarom.Core.Domain.Entities.Basic;
using OldBarom.Core.Domain.Validation;
using System;
using Xunit;

namespace OldBarom.Core.Domain.Test.Basic
{
    public class CitiesTest
    {
        [Fact]
        public void CreateCity_WithValidParameters_ShouldNotThrowException()
        {
            // Arrange
            string name = "Test City";
            int state_id = 1;

            // Act
            var city = new Cities();

            // Assert
            Assert.Equal(name, city.Name);
            Assert.Equal(state_id, city.StateId);
        }

        [Fact]
        public void CreateCity_WithInvalidName_ShouldThrowException()
        {
            // Arrange
            string name = "";
            int state_id = 1;

            // Act & Assert
            Assert.Throws<DomainExceptionValidation>(() => new Cities(name, state_id));
        }

        [Fact]
        public void CreateCity_WithInvalidStateId_ShouldThrowException()
        {
            // Arrange
            string name = "Test City";
            int state_id = 0;

            // Act & Assert
            Assert.Throws<DomainExceptionValidation>(() => new Cities(name, state_id));
        }
    }
}
