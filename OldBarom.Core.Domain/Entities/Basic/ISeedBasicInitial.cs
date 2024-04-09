using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBarom.Core.Domain.Entities.Basic
{
    public interface ISeedBasicInitial
    {
        void SeedContries();
        void SeedStates();
        void SeedCities();
        void SeedRegions();
    }
}
