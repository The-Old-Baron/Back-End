using OldBarom.Core.Domain.Entities.LinkList;

namespace OldBarom.Core.Domain.Tests.Entities.LinkList
{
    public class LinksTests
    {
        private Links _links;

        public LinksTests()
        {
            _links = new Links();
        }

        [Fact]
        public void TestIdProperty()
        {
            int id = 1;
            _links.Id = id;
            Assert.Equal(id, _links.Id);
        }

        [Fact]
        public void TestTitleProperty()
        {
            string title = "Test Title";
            _links.Title = title;
            Assert.Equal(title, _links.Title);
        }

        // Continue with similar tests for the rest of the properties...

        [Fact]
        public void TestCreatedAtProperty()
        {
            DateTime createdAt = DateTime.Now;
            _links.CreatedAt = createdAt;
            Assert.Equal(createdAt, _links.CreatedAt);
        }

        [Fact]
        public void TestUpdatedAtProperty()
        {
            DateTime updatedAt = DateTime.Now;
            _links.UpdatedAt = updatedAt;
            Assert.Equal(updatedAt, _links.UpdatedAt);
        }

        // If you have methods in your Links class, you can test them here...
    }
}