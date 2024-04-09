namespace OldBarom.Core.Domain.Account
{
    public interface ISeedWorldInitial
    {
        void SeedContinents();
        void SeedCountries();
        void SeedStates();
        void SeedCities();
        void SeedRegions();
        void SeedSubRegions();
    }
}
