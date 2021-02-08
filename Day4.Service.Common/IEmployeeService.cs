using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day4.Model.Common;

namespace Day4.Service.Common
{
    public interface IEmployeeService
    {
        Task<List<IEmployee>> GetEmployeesAsync();

        Task<List<IEmployee>> GetEmployeesByValueAsync(string field, string value);

        Task<string> InsertEmployeeAsync(IEmployee employee);

        Task<bool> DeleteEmployeeAsync(string firstName, string lastName);

    }
}
