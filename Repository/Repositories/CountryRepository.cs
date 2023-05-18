using Domain.Models;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository(AppDbContext context) : base(context) { }

        public async Task<Country> SearchByName(string searchText)
        {
            if (searchText is null) throw new ArgumentNullException(nameof(searchText));

            IEnumerable<Country> countries = await GetAllAsync();

            Country country = countries.FirstOrDefault(c => c.Name.ToLower().Trim().Contains(searchText.ToLower().Trim()));

            if (country is null) throw new NullReferenceException(nameof(country));

            return country;
        }
    }
}
