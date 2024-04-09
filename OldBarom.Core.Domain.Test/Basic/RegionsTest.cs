using OldBarom.Core.Domain.Entities.Basic;
using OldBarom.Core.Domain.Validation;

namespace OldBarom.Core.Domain.Test.Basic
{
    public class RegionsTest
    {
        [Fact]
        public void CreateRegion_WithValidParameters_ShouldNotThrowException()
        {
            // Arrange
            string name = "Test Region";
            string code = "TR";

            // Act
            var region = new Regions(name, code);

            // Assert
            Assert.Equal(name, region.Name);
            Assert.Equal(code, region.Code);
        }

        [Fact]
        public void CreateRegion_WithInvalidName_ShouldThrowException()
        {
            // Arrange
            string name = "";
            string code = "TR";

            // Act & Assert
            Assert.Throws<DomainExceptionValidation>(() => new Regions(name, code));
        }

        [Fact]
        public void CreateRegion_WithInvalidCode_ShouldThrowException()
        {
            // Arrange
            string name = "Test Region";
            string code = "";

            // Act & Assert
            Assert.Throws<DomainExceptionValidation>(() => new Regions(name, code));
        }
    }
}
