using Xunit;
using OldBarom.Core.Domain.Entities.Basic;
using System;
using OldBarom.Core.Domain.Validation;
namespace OldBarom.Core.Domain.Entities.Basic.Tests
{
    public class RegionsTests
    {
        [Theory]
        [InlineData(null, "Code")]
        [InlineData("Name", null)]
        [InlineData("", "Code")]
        [InlineData("Name", "")]
        public void DomainValidation_ShouldThrowException_WhenNameOrCodeIsNullOrEmpty(string name, string code)
        {
            // Act & Assert
            var ex = Assert.Throws<DomainExceptionValidation>(() => new Regions(name, code));
            Assert.True(ex.Message == "Name is required" || ex.Message == "Code is required");
        }

        [Fact]
        public void DomainValidation_ShouldNotThrowException_WhenNameAndCodeAreNotNullOrEmpty()
        {
            var ex = Record.Exception(() => new Regions("Name", "Code"));
            Assert.Null(ex);
        }
    }
}