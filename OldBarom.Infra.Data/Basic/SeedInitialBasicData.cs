using OldBarom.Core.Domain.Entities.Basic;
using OldBarom.Core.Domain.Repository.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBarom.Infra.Data.Basic
{
    public class SeedInitialBasicData : ISeedBasicInitial
    {
        public ICityRepository _cityRepository;
        public SeedInitialBasicData(ICityRepository city) { 
            _cityRepository = city;
        }
        public void SeedContries()
        {
            throw new NotImplementedException();
        }

        public void SeedStates()
        {
            throw new NotImplementedException();
        }

        public void SeedCities()
        {
            throw new NotImplementedException();
        }

        public void SeedRegions()
        {
            throw new NotImplementedException();
        }
    }
}
