using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day4.Model.Common;
using Day4.Model;

namespace Day4.Service.Common
{
    public interface IEmployeeService
    {
        List<IEmployee> GetEmployees();

        List<IEmployee> GetEmployeesByValue(string field, string value);

        string InsertEmployee(IEmployee employee);

        bool DeleteEmployee(int id);

    }
}
