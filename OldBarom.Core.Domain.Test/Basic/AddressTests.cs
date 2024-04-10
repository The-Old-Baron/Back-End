using OldBarom.Core.Domain.Validation;

namespace OldBarom.Core.Domain.Entities.Basic.Tests
{
    public class AddressTests
    {
        [Fact(DisplayName = "With Empty Street")]
        public void DomainValidation_WithEmptyStreet_ShouldThrowException()
        {
            // Assert
            Assert.Throws<DomainExceptionValidation>(() => new Address("", 1, "12345"));
        }

        [Fact(DisplayName = "With Invalid City ID")]
        public void DomainValidation_WithInvalidCityId_ShouldThrowException()
        {
            // Assert
            Assert.Throws<DomainExceptionValidation>(() => new Address("Street", 0, "12345"));
        }

        [Fact(DisplayName = "With Empty ZIP Code")]
        public void DomainValidation_WithEmptyZipCode_ShouldThrowException()
        {
            // Assert
            Assert.Throws<DomainExceptionValidation>(() => new Address("Street", 1, ""));
        }

        [Fact(DisplayName = "With Valid Data")]
        public void DomainValidation_WithValidData_ShouldNotThrowException()
        {
            // Act & Assert
            Exception ex = Record.Exception(() => new Address("Street", 1, "12345"));
            Assert.Null(ex);
        }

        [Fact(DisplayName = "With Valid Data Check Properties")]
        public void DomainValidation_WithValidData_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            var address = new Address("Street", 1, "12345");

            // Assert
            Assert.Equal("Street", address.Street);
            Assert.Equal(1, address.CityId);
            Assert.Equal("12345", address.ZipCode);
        }
    }
}