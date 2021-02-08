using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day4.Model;

namespace Day4.Model.Common
{
    public interface IEmployee
    {
        Guid Id { get; set; }

        string FirstName { get; set; }
        string LastName { get; set; }
        string Department { get; set; }
    }
}
