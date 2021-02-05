using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day4.Service.Common;
using Day4.Model.Common;
using Day4.Repository.Common;
using System.Data.SqlClient;
using Day4.Model;
using Day4.Repository;
using System.Data;

namespace Day4.Service
{
    public class EmployeeService : IEmployeeService
    {
        static IEmployeeRepository Repository = new EmployeeRepository();

        public List<IEmployee> GetEmployees()
        {
            DataSet employees = Repository.QueryAll(); 
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

        public List<IEmployee> GetEmployeesByValue(string field, string value)
        {
            DataSet employees = Repository.QueryByStringValue(field, value);
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
        public string InsertEmployee(IEmployee employee)
        {
            Repository.Insert(employee);
            return "Success";
        }

        public bool DeleteEmployee(int id)
        {
            return Repository.Delete(id);
        }

    }
}
