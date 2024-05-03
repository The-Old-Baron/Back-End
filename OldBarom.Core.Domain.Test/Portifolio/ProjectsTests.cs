using OldBarom.Core.Domain.Entities.Portifolio;

namespace OldBarom.Core.Domain.Tests.Entities.Portifolio
{
    public class ProjectsTests
    {
        private Projects _projects;

        public ProjectsTests()
        {
            _projects = new Projects();
        }

        [Fact]
        public void TestIDProperty()
        {
            Guid id = Guid.NewGuid();
            _projects.ID = id;
            Assert.Equal(id, _projects.ID);
        }

        [Fact]
        public void TestTitleProperty()
        {
            string title = "Test Title";
            _projects.Title = title;
            Assert.Equal(title, _projects.Title);
        }

        // Continue with similar tests for the rest of the properties...

        [Fact]
        public void TestCreatedAtProperty()
        {
            DateTime createdAt = DateTime.Now;
            _projects.CreatedAt = createdAt;
            Assert.Equal(createdAt, _projects.CreatedAt);
        }

        [Fact]
        public void TestUpdatedAtProperty()
        {
            DateTime updatedAt = DateTime.Now;
            _projects.UpdatedAt = updatedAt;
            Assert.Equal(updatedAt, _projects.UpdatedAt);
        }

        // If you have methods in your Projects class, you can test them here...
    }
}