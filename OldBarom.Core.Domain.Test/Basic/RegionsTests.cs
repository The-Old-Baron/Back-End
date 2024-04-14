using OldBarom.Core.Domain.Entities.Basic;
using OldBarom.Core.Domain.Validation;

namespace OldBarom.Core.Domain.Test{
    public class RegionsTests{
        [Fact(DisplayName = "With Null Name")]
        public void DomainValidation_WithNullName()
        {
            Assert.Throws<DomainExceptionValidation>(()=> new Regions("","ABC"));
        }
        [Fact(DisplayName = "With Null Code")]
        public void DomainValidation_WithNullCode()
        {
            Assert.Throws<DomainExceptionValidation>(()=>new Regions("Region Name", ""));
        }
        [Fact(DisplayName = "With Valid Data")]
        public void DomainValidation_WithValidData()
        {
            Exception ex = Record.Exception(()=> new Regions("Regions", "ABC"));
            Assert.Null(ex);
        }
        [Fact(DisplayName = "With Valid Data Ckeck Properties")]
        public void DomainValidation_WithValidData_ShouldSertPropertiesRegion()
        {
            var Regions = new Regions("ABC", "CBA");

            Assert.Equal("ABC", Regions.Name);
            Assert.Equal("CBA", Regions.Code);
        }
    }
}