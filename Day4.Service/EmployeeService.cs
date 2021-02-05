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
        static IEmployeeRepository Repository = new EmployeeRepository();

        public async Task<List<IEmployee>> GetEmployeesAsync()
        {
            Task<DataSet> dataSetTask = Repository.QueryAllAsync();
            DataSet employees = await dataSetTask;
            List<IEmployee> retVal = new List<IEmployee>();
            foreach (DataRow pRow in employees.Tables[0].Rows) {
                retVal.Add(new Employee()
                {
                    Id = Convert.ToInt32(pRow.ItemArray.GetValue(0).ToString()),
                    FirstName = pRow.ItemArray.GetValue(1).ToString(),
                    LastName = pRow.ItemArray.GetValue(2).ToString(),
                    Department = pRow.ItemArray.GetValue(3).ToString()
                });
            }
            return retVal;
        }

        public async Task<List<IEmployee>> GetEmployeesByValueAsync(string field, string value)
        {
            Task<DataSet> dataSetTask = Repository.QueryByStringValueAsync(field, value);
            DataSet employees = await dataSetTask;
            List<IEmployee> retVal = new List<IEmployee>();
            foreach (DataRow pRow in employees.Tables[0].Rows)
            {
                retVal.Add(new Employee()
                {
                    Id = Convert.ToInt32(pRow.ItemArray.GetValue(0).ToString()),
                    FirstName = pRow.ItemArray.GetValue(1).ToString(),
                    LastName = pRow.ItemArray.GetValue(2).ToString(),
                    Department = pRow.ItemArray.GetValue(3).ToString()
                });
            }
            return retVal;
        }
        public async Task<string> InsertEmployeeAsync(IEmployee employee)
        {
            await Repository.InsertAsync(employee);
            return "Success";
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            return await Repository.DeleteAsync(id);
        }

    }
}
