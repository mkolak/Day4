using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day4.Service.Common;
using Day4.Model.Common;
using Day4.Repository.Common;
using Day4.Model;
using Day4.Repository;
using System.Data;

namespace Day4.Service
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository Repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            this.Repository = repository;
        }

        public async Task<List<IEmployee>> GetEmployeesAsync()
        {
            return await Repository.QueryAllAsync();            
        }

        public async Task<string> InsertEmployeeAsync(IEmployee employee)
        {
            employee.Id = Guid.NewGuid();
            await Repository.InsertAsync(employee);
            return "Success";
        }

        public async Task<bool> DeleteEmployeeAsync(string firstName, string lastName)
        {
            return await Repository.DeleteAsync(firstName, lastName);
        }

    }
}
