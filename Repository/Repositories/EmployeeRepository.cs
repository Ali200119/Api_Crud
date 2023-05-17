using System.Threading.Tasks;
using Domain.Models;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext context) : base(context) { }

        public async Task<Employee> SearchByName(string searchText)
        {
            if (searchText is null) throw new ArgumentNullException(nameof(searchText));

            IEnumerable<Employee> employees = await GetAllAsync();

            Employee employee = employees.FirstOrDefault(e => e.FullName.ToLower().Trim().Contains(searchText.ToLower().Trim()));

            if (employee is null) throw new NullReferenceException(nameof(employee));

            return employee;
        }
    }
}