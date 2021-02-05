using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day4.Repository.Common;
using Day4.Model.Common;
using System.Data;

namespace Day4.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private SqlConnection Connection;

        public async Task<DataSet> QueryAllAsync() {
            Connection = new SqlConnection("Data Source=DESKTOP-0NGMPOG;Initial Catalog=CompanyDB;Trusted_Connection=True;");
            using (Connection) {
                //SqlCommand selectComm = new SqlCommand("SELECT * FROM Departments;", Connection);
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Employees;", Connection);
                Connection.Open();
                DataSet dataSet = new DataSet();
                await Task.Run(() => adapter.Fill(dataSet, "Employees"));             
                return dataSet;
            }
            
        }

        public async Task<DataSet> QueryByStringValueAsync (string field, string value){
            Connection = new SqlConnection("Data Source=DESKTOP-0NGMPOG;Initial Catalog=CompanyDB;Trusted_Connection=True;");
            using (Connection) {
                //SqlCommand selectComm = new SqlCommand("SELECT * FROM Departments WHERE " + field + " = " + value + ";", Connection);
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Employees WHERE " + field + " = '" + value + "';", Connection);
                Connection.Open();
                DataSet dataSet = new DataSet();
                await Task.Run(() => adapter.Fill(dataSet, "Employees"));
                return dataSet;
            }
        }

        public async Task InsertAsync(IEmployee employee) {
            Connection = new SqlConnection("Data Source=DESKTOP-0NGMPOG;Initial Catalog=CompanyDB;Trusted_Connection=True;");
            string dataStr = "(" + employee.Id + ", '" + employee.FirstName + "', '" + employee.LastName + "', '" + employee.Department + "')";
            using (Connection) {
                SqlCommand insertComm = new SqlCommand("INSERT INTO Employees VALUES " + dataStr + ";", Connection);
                Connection.Open();
                await Task.Run(() => insertComm.ExecuteNonQuery());
            }
        }

        public async Task<bool> DeleteAsync(int id) {
            Connection = new SqlConnection("Data Source=DESKTOP-0NGMPOG;Initial Catalog=CompanyDB;Trusted_Connection=True;");
            using (Connection) {
                SqlCommand selectComm = new SqlCommand("SELECT * FROM Employees WHERE EmployeeID = " + id + ";", Connection);
                Connection.Open();
                Task<SqlDataReader> readerTask = Task.Run(() => selectComm.ExecuteReader());
                SqlDataReader reader = await readerTask;
                if (reader.HasRows)
                {
                    reader.Close();
                    SqlCommand deleteComm = new SqlCommand("DELETE FROM Employees WHERE EmployeeID = " + id + ";", Connection);
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
