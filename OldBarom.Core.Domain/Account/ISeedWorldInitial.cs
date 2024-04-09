using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
