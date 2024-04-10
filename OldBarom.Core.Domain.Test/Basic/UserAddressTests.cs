using Xunit;
using OldBarom.Core.Domain.Entities.Basic;
using System;
using OldBarom.Core.Domain.Validation;
namespace OldBarom.Core.Domain.Entities.Basic.Tests
{
    public class UserAddressTests
    {
        [Fact]
        public void UserAddress_Constructor_ShouldInitializeCorrectly()
        {
            // Arrange
            string userID = "testUser";
            Guid addressID = Guid.NewGuid();

            // Act
            var userAddress = new UserAddress(userID, addressID);

            // Assert
            Assert.Equal(userID, userAddress.UserID);
            Assert.Equal(addressID, userAddress.AddressID);
        }

        [Fact]
        public void UserAddress_Constructor_ShouldThrowException_WhenUserIDIsEmpty()
        {
            // Arrange
            string userID = string.Empty;
            Guid addressID = Guid.NewGuid();

            // Act & Assert
            Assert.Throws<DomainExceptionValidation>(() => new UserAddress(userID, addressID));
        }

        [Fact]
        public void UserAddress_Constructor_ShouldThrowException_WhenAddressIDIsEmpty()
        {
            // Arrange
            string userID = "testUser";
            Guid addressID = Guid.Empty;

            // Act & Assert
            Assert.Throws<DomainExceptionValidation>(() => new UserAddress(userID, addressID));
        }
    }
}