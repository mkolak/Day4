using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day4.Model.Common;

namespace Day4.Repository.Common
{
    public interface IEmployeeRepository
    {
        Task<List<IEmployee>> QueryAllAsync();

        Task InsertAsync(IEmployee employee);

        Task<bool> DeleteAsync(string firstName, string lastName);
    }
}
