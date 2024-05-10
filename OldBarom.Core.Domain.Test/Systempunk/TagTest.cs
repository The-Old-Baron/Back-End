using Xunit;
using OldBarom.Core.Domain.Entities.Systempunk;
using OldBarom.Core.Domain.Validation;

namespace OldBarom.Core.Domain.Tests
{
    public class TagTests
    {
        [Fact(DisplayName = "Tag - Valid Object")]
        public void Constructor_ShouldInitializeProperties()
        {
            // Arrange
            var id = 1;
            var name = "Test Name";
            var description = "Test Description";

            // Act
            var tag = new Tag(id, name, description);

            // Assert
            Assert.Equal(id, tag.Id);
            Assert.Equal(name, tag.Name);
            Assert.Equal(description, tag.Description);
        }

        [Theory(DisplayName = "Tag - Invalid Name")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("a")]
        public void ValidateDomain_ShouldThrowException_WhenNameIsInvalid(string name)
        {
            // Arrange
            var description = "Test Description";

            // Act & Assert
            Assert.Throws<DomainExceptionValidation>(() => new Tag(name, description));
        }

        [Theory(DisplayName = "Tag - Invalid Description")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("a")]
        public void ValidateDomain_ShouldThrowException_WhenDescriptionIsInvalid(string description)
        {
            // Arrange
            var name = "Test Name";

            // Act & Assert
            Assert.Throws<DomainExceptionValidation>(() => new Tag(name, description));
        }
    }
}