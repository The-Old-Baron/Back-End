using OldBarom.Core.Domain.Validation;

namespace OldBarom.Core.Domain.Entities.LinkList.Tests{
    public class CategoriesTests{
        [Fact(DisplayName = "With Null Name")]
        public void DomainValidation_WithNullName()
        {
            Assert.Throws<DomainExceptionValidation>(()=>new Categories(string.Empty,"ABC","CBA"));
        }
        [Fact(DisplayName = " With Invalid Description")]
        public void DomainValidation_WithInvalidDescription()
        {
            Assert.Throws<DomainExceptionValidation>(() => new Categories("ABC","ABCDSFAGSHEKSYSTAGSHEIOPLKIUYTRSFGHJEUDKIOPLIJUYTGHJABCDSFAGSHEKSYSTAGSHEIOPLKIUYTRSFGHJEUDKIOPLIJUYTGHJ", "CBA"));
        }
        [Fact(DisplayName = "With Null User ID")]
        public void DomainValidation_WithNullUserID()
        {
            Assert.Throws<DomainExceptionValidation>(()=> new Categories("ABC", "CBA", string.Empty));
        }
        [Fact(DisplayName = "With Valid Data")]
        public void DomainValidation_WithValidData()
        {
            var guid = Guid.NewGuid();
            var Categories = new Categories("ABC", "ABC", guid.ToString());
            Assert.Equal("ABC", Categories.Name);
            Assert.Equal("ABC", Categories.Description);
            Assert.Equal(guid.ToString(), Categories.ApplicationUserId);
        }
        public void DomainValidation_WithValidDataParameter()
        {
            var guid = Guid.NewGuid();
            var Categories = new Categories("ABC", "ABC", guid.ToString());
            Assert.Equal("ABC", Categories.Name);
            Assert.Equal("ABC", Categories.Description);
            Assert.Equal(guid.ToString(), Categories.ApplicationUserId);
        }
    }
}