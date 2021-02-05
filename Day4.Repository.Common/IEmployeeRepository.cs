using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day4.Model.Common;
using Day4.Model;

namespace Day4.Repository.Common
{
    public interface IEmployeeRepository
    {
        DataSet QueryAll();

        DataSet QueryByStringValue(string field, string value);

        void Insert(IEmployee employee);

        bool Delete(int id);
    }
}
