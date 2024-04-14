using OldBarom.Core.Domain.Entities.Basic;
using OldBarom.Core.Domain.Validation;

namespace OldBarom.Core.Domain.Test.Basic{
    public class CountryStatesTests{
        [Fact(DisplayName = "With Empty Name")]
        public void DomainValidation_WithEmptyCountryName_ShouldThrowException()
        {
            //
            Assert.Throws<DomainExceptionValidation>(() => new CountryStates(1, string.Empty));
        }
        [Fact(DisplayName = "With Invalid CountryState ID")]
        public void DomainValidation_WithInvalidCountryStateID()
        {
            Assert.Throws<DomainExceptionValidation>(() => new CountryStates(-4, ""));
        }
        [Fact(DisplayName = "With Valid Data")]
        public void DomainValidation_WithValidData()
        {
            Exception ex = Record.Exception(() => new CountryStates(1, "Country State"));
            Assert.Null(ex);
        }
        [Fact(DisplayName = "With Valid Data Check Properties")]
        public void DomainValidation_WithValidDataCheckProperties()
        {
            var CountryState = new CountryStates(1, "Country State");
            Assert.Equal("Country State", CountryState.Name);
            Assert.Equal(1, CountryState.CountryId);
        }

    }
}