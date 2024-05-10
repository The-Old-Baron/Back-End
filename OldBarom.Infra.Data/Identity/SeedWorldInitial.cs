using OldBarom.Core.Domain.Account;
using OldBarom.Core.Domain.Entities.Basic;
using OldBarom.Infra.Data.Context;
namespace OldBarom.Infra.Data.Identity
{
    public class SeedWorldInitial : ISeedWorldInitial
    {
        private readonly ApplicationDbContext _context;
        public void SeedCities()
        {
            List<Cities> cities = new List<Cities>();
            cities.Add(new Cities("New York", 1));
            cities.Add(new Cities("Los Angeles", 1));
            cities.Add(new Cities("Chicago", 1));
            cities.Add(new Cities("Houston", 1));
            cities.Add(new Cities("Phoenix", 1));
            
            cities.Add(new Cities("Toronto", 2));
            cities.Add(new Cities("Montreal", 2));
            cities.Add(new Cities("Vancouver", 2));
            cities.Add(new Cities("Calgary", 2));
            cities.Add(new Cities("Edmonton", 2));

            cities.Add(new Cities("Mexico City", 3));
            cities.Add(new Cities("Ecatepec", 3));
            cities.Add(new Cities("Guadalajara", 3));
            cities.Add(new Cities("Puebla", 3));
            cities.Add(new Cities("Juárez", 3));

            cities.Add(new Cities("São Paulo", 4));
            cities.Add(new Cities("Rio de Janeiro", 4));
            cities.Add(new Cities("Salvador", 4));
            cities.Add(new Cities("Brasília", 4));
            cities.Add(new Cities("Fortaleza", 4));

            cities.Add(new Cities("Buenos Aires", 5));
            cities.Add(new Cities("Córdoba", 5));
            cities.Add(new Cities("Rosario", 5));
            cities.Add(new Cities("Mendoza", 5));
            cities.Add(new Cities("La Plata", 5));
            _context.Cities.AddRange(cities);
        }

        public void SeedContinents()
        {
            List<Regions> continents = new List<Regions>();
            continents.Add(new Regions("North America", "NA"));
            continents.Add(new Regions("South America", "SA"));
            continents.Add(new Regions("Europe", "EU"));
            continents.Add(new Regions("Asia", "AS"));
            continents.Add(new Regions("Africa", "AF"));
            continents.Add(new Regions("Oceania", "OC"));
            _context.Regions.AddRange(continents);
        }

        public void SeedCountries()
        {
            List<Countries> countries = new List<Countries>();
            countries.Add(new Countries("United States", "USA", "840", "US", "USD", "Dollar", 1));
            countries.Add(new Countries("Canada", "CAN", "124", "CA", "CAD", "Dollar", 2));
            countries.Add(new Countries("Mexico", "MEX", "484", "MX", "MXN", "Peso", 3));
            countries.Add(new Countries("Brazil", "BRA", "076", "BR", "BRL", "Real", 4));
            countries.Add(new Countries("Argentina", "ARG", "032", "AR", "ARS", "Peso", 5));         
            _context.Countries.AddRange(countries);
        }


        public void SeedStates()
        {
            List<CountryStates> states = new List<CountryStates>();
            states.Add(new CountryStates(1, "New York"));
            states.Add(new CountryStates(1, "California"));
            states.Add(new CountryStates(1, "Illinois"));
            states.Add(new CountryStates(1, "Texas"));
            states.Add(new CountryStates(1, "Arizona"));

            states.Add(new CountryStates(2, "Ontario"));
            states.Add(new CountryStates(2, "Quebec"));
            states.Add(new CountryStates(2, "British Columbia"));
            states.Add(new CountryStates(2, "Alberta"));

            states.Add(new CountryStates(3, "Mexico City"));
            states.Add(new CountryStates(3, "State of Mexico"));
            states.Add(new CountryStates(3, "Jalisco"));
            states.Add(new CountryStates(3, "Puebla"));
            states.Add(new CountryStates(3, "Chihuahua"));

            states.Add(new CountryStates(4, "São Paulo"));
            states.Add(new CountryStates(4, "Rio de Janeiro"));
            states.Add(new CountryStates(4, "Bahia"));
            states.Add(new CountryStates(4, "Federal District"));
            states.Add(new CountryStates(4, "Ceará"));

            states.Add(new CountryStates(5, "Buenos Aires"));
            states.Add(new CountryStates(5, "Córdoba"));
            states.Add(new CountryStates(5, "Santa Fe"));
            states.Add(new CountryStates(5, "Mendoza"));
            states.Add(new CountryStates(5, "Buenos Aires"));
            _context.CountryStates.AddRange(states);
        }

        
    }
}
