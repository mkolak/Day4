using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Day4.Service.Common;
using Day4.Service;
using Day4.Model.Common;
using Day4.Model;
using System.Threading.Tasks;
using Day4.WebAPI.Models;

namespace Day4.WebAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        private IEmployeeService Service;

        public EmployeeController(IEmployeeService service)
        {
            this.Service = service;
        }

        [Route("api/employee/")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetAsync()
        {
            List<IEmployee> values = await Service.GetEmployeesAsync();
            if (!values.Any()) return Request.CreateResponse(HttpStatusCode.NotFound, "Not found");
            List<EmployeeView> returnList = new List<EmployeeView>();
            foreach (var employee in values) {
                returnList.Add(MapEmployee(employee));
            }
            return Request.CreateResponse(HttpStatusCode.OK, returnList);
        }

        [Route("api/employee/")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetEmployeesByPositionAsync(string position)
        { 
            List<IEmployee> values = await Service.GetEmployeesByValueAsync("department", position);

            if (!values.Any()) return Request.CreateResponse(HttpStatusCode.NotFound, "Not found");
            List<EmployeeView> returnList = new List<EmployeeView>();
            foreach (var employee in values)
            {
                returnList.Add(MapEmployee(employee));
            }
            return Request.CreateResponse(HttpStatusCode.OK, returnList);
        }

        [Route("api/employee/")]
        [HttpPost]
        public async Task<HttpResponseMessage> PostAsync(EmployeeView emp)
        {
            Employee newEmployee = new Employee { FirstName = emp.FirstName, LastName = emp.LastName, Department = emp.Department };
            return Request.CreateResponse(HttpStatusCode.OK,await Service.InsertEmployeeAsync(newEmployee));
        }

        [Route("api/employee/")]
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteAsync([FromBody] string fullName)
        {
            string[] name = fullName.Split(' ');
            if (name.Length != 2 || !(await Service.DeleteEmployeeAsync(name[0],name[1]))) 
                return Request.CreateResponse(HttpStatusCode.BadRequest, "No content to delete");
            return Request.CreateResponse(HttpStatusCode.OK, "Success");
        }

        private EmployeeView MapEmployee(IEmployee employee) {
            return new EmployeeView { FirstName = employee.FirstName, LastName = employee.LastName, Department = employee.Department };
        }

    }
}
