using OldBarom.Core.Domain.Entities.LinkList;
using OldBarom.Core.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBarom.Core.Domain.Test.MyLinkList
{
    public class CategoryTest
    {
        [Fact]
        public void CreateCategory_WithValidParameters_ShouldNotThrowException()
        {
            // Arrange
            string name = "Test Category";
            string description = "This is a test category";
            string applicationUserId = "123";

            // Act
            var category = new Categories(name, description,applicationUserId);

            // Assert
            Assert.Equal(name, category.Name);
            Assert.Equal(description, category.Description);
            Assert.Equal(applicationUserId, category.ApplicationUserId);
        }

        [Fact]
        public void CreateCategory_WithInvalidName_ShouldThrowException()
        {
            // Arrange
            string name = "Te";
            string description = "This is a test category";
            string applicationUserId = "123";

            // Act & Assert
            Assert.Throws<DomainExceptionValidation>(() => new Categories(name, description, applicationUserId));
        }

        [Fact]
        public void CreateCategory_WithInvalidDescription_ShouldThrowException()
        {
            // Arrange
            string name = "Test Category";
            string description = new string('a', 101);
            string applicationUserId = "123";

            // Act & Assert
            Assert.Throws<DomainExceptionValidation>(() => new Categories(name, description, applicationUserId));
        }
    }
}
