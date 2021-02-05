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

namespace Day4.WebAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        static IEmployeeService Service = new EmployeeService();

        [Route("api/employee/")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetAsync()
        {

            Task<List<IEmployee>> valuesTask = Service.GetEmployeesAsync();
            List<IEmployee> values = await valuesTask;
            if (!values.Any()) return Request.CreateResponse(HttpStatusCode.NotFound, "Not found");

            return Request.CreateResponse(HttpStatusCode.OK, values);
        }

        [Route("api/employee/")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetEmployeesByPositionAsync(string position)
        {

            Task<List<IEmployee>> valuesTask = Service.GetEmployeesByValueAsync("department", position);
            List<IEmployee> values = await valuesTask;

            if (!values.Any()) return Request.CreateResponse(HttpStatusCode.NotFound, "Not found");

            return Request.CreateResponse(HttpStatusCode.OK, values);
        }

        [Route("api/employee/")]
        [HttpPost]
        public async Task<HttpResponseMessage> PostAsync(Employee emp)
        {
            return Request.CreateResponse(HttpStatusCode.OK,await Service.InsertEmployeeAsync(emp));
        }

        [Route("api/employee/")]
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteAsync([FromBody] int id)
        { 
            if (await Service.DeleteEmployeeAsync(id)) return Request.CreateResponse(HttpStatusCode.OK, "Success");
            return Request.CreateResponse(HttpStatusCode.BadRequest, "No content to delete");
        }

    }
}
