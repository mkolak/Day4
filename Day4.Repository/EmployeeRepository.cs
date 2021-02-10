using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day4.Repository.Common;
using Day4.Model.Common;
using Day4.Model;
using System.Data;

namespace Day4.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private SqlConnection Connection;

        public async Task<List<IEmployee>> QueryAllAsync() {
            Connection = new SqlConnection("Data Source=DESKTOP-0NGMPOG;Initial Catalog=CompanyDB;Trusted_Connection=True;");
            using (Connection) {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Employees;", Connection);
                Connection.Open();
                DataSet dataSet = new DataSet();
                await Task.Run(() => adapter.Fill(dataSet, "Employees"));
                List<IEmployee> retVal = new List<IEmployee>();
                foreach (DataRow pRow in dataSet.Tables[0].Rows)
                {
                    retVal.Add(new Employee()
                    {
                        Id = Guid.Parse(pRow.ItemArray.GetValue(0).ToString()),
                        FirstName = pRow.ItemArray.GetValue(1).ToString(),
                        LastName = pRow.ItemArray.GetValue(2).ToString(),
                        Department = pRow.ItemArray.GetValue(3).ToString()
                    });
                }
                return retVal;
            }
            
        }

        public async Task<List<IEmployee>> QueryByStringValueAsync (string field, string value){
            Connection = new SqlConnection("Data Source=DESKTOP-0NGMPOG;Initial Catalog=CompanyDB;Trusted_Connection=True;");
            using (Connection) {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Employees WHERE " + field + " = '" + value + "';", Connection);
                Connection.Open();
                DataSet dataSet = new DataSet();
                await Task.Run(() => adapter.Fill(dataSet, "Employees"));
                List<IEmployee> retVal = new List<IEmployee>();
                foreach (DataRow pRow in dataSet.Tables[0].Rows)
                {
                    retVal.Add(new Employee()
                    {
                        Id = Guid.Parse(pRow.ItemArray.GetValue(0).ToString()),
                        FirstName = pRow.ItemArray.GetValue(1).ToString(),
                        LastName = pRow.ItemArray.GetValue(2).ToString(),
                        Department = pRow.ItemArray.GetValue(3).ToString()
                    });
                }
                return retVal;
            }
        }

        public async Task InsertAsync(IEmployee employee) {
            Connection = new SqlConnection("Data Source=DESKTOP-0NGMPOG;Initial Catalog=CompanyDB;Trusted_Connection=True;");
            string dataStr = "('" + employee.Id.ToString() + "', '" + employee.FirstName + "', '" + employee.LastName + "', '" + employee.Department + "')";
            using (Connection) {
                SqlCommand insertComm = new SqlCommand("INSERT INTO Employees VALUES " + dataStr + ";", Connection);
                Connection.Open();
                await Task.Run(() => insertComm.ExecuteNonQuery());
            }
        }

        public async Task<bool> DeleteAsync(string firstName, string lastName) {
            Connection = new SqlConnection("Data Source=DESKTOP-0NGMPOG;Initial Catalog=CompanyDB;Trusted_Connection=True;");
            using (Connection) {
                string append = "WHERE FirstName = '" + firstName + "' AND LastName = '" + lastName + "'; ";
                SqlCommand selectComm = new SqlCommand("SELECT * FROM Employees " + append, Connection);
                Connection.Open();
                SqlDataReader reader = await selectComm.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    reader.Close();
                    SqlCommand deleteComm = new SqlCommand("DELETE FROM Employees " + append, Connection);
                    await Task.Run(() => deleteComm.ExecuteNonQuery());
                    return true;
                }
                else {
                    reader.Close();
                    return false;
                }
            }
        }
    }
}
