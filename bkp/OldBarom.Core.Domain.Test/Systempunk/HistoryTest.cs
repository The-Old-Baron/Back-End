using OldBarom.Core.Domain.Entities.Systempunk;
using OldBarom.Core.Domain.Validation;

namespace OldBarom.Core.Domain.Tests
{
    public class HistoryTest
    {
        [Fact(DisplayName = "History - Correct Object")]
        public void Constructor_ShouldInitializeProperties()
        {
            // Arrange
            var id = 1;
            var name = "Test Name";
            var description = "Test Description";
            var keywords = new List<Keyworkds> { new Keyworkds() { Id = 1, Name = "Nome" }, new Keyworkds() { Id = 2, Name = "Modelo" } };
            var userOwnerId = Guid.NewGuid();
            var lastEditorID = Guid.NewGuid();
            var publishDate = DateTime.Now;
            var editedTime = DateTime.Now;
            var content = "Test Content";
            var tags = new List<Tag> { new Tag("ABC","ABC") };

            // Act
            var history = new History(id, name, description, keywords, userOwnerId, lastEditorID, publishDate, editedTime, content, tags);

            // Assert
            Assert.Equal(id, history.Id);
            Assert.Equal(name, history.Name);
            Assert.Equal(description, history.Description);
            Assert.Equal(keywords, history.Keywords);
            Assert.Equal(userOwnerId, history.UserOwnerId);
            Assert.Equal(lastEditorID, history.LastEditorID);
            Assert.Equal(publishDate, history.PublishDate);
            Assert.Equal(editedTime, history.EditedTime);
            Assert.Equal(content, history.Content);
            Assert.Equal(tags, history.Tags);
        }

        [Theory(DisplayName= "Domain Error")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("a")]
        public void ValidateDomain_ShouldThrowException_WhenNameIsInvalid(string name)
        {
            // Arrange
            var description = "Test Description";
            var keywords = new List<Keyworkds> { new Keyworkds() { Id = 1, Name = "Nome"}, new Keyworkds() { Id = 2, Name = "Modelo" } };
            var userOwnerId = Guid.NewGuid();
            var lastEditorID = Guid.NewGuid();
            var content = "Test Content";
            var tags = new List<Tag> { new Tag("ABC","ABC") };

            // Act & Assert
            Assert.Throws<DomainExceptionValidation>(() => new History(1, name, description, keywords, userOwnerId, lastEditorID, DateTime.Now, DateTime.Now, content, tags));
        }

        // Repeat the above test for each validation rule in the ValidateDomain method
    }
}