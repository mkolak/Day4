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

namespace Day4.WebAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        static IEmployeeService Service = new EmployeeService();

        [Route("api/employee/")]
        [HttpGet]
        public HttpResponseMessage Get()
        {

            List<IEmployee> values = Service.GetEmployees();

            if (!values.Any()) return Request.CreateResponse(HttpStatusCode.NotFound, "Not found");

            return Request.CreateResponse(HttpStatusCode.OK, values);
        }

        [Route("api/employee/")]
        [HttpGet]
        public HttpResponseMessage GetEmployeesByPosition(string position)
        {

            List<IEmployee> values = Service.GetEmployeesByValue("department", position);

            if (!values.Any()) return Request.CreateResponse(HttpStatusCode.NotFound, "Not found");

            return Request.CreateResponse(HttpStatusCode.OK, values);
        }

        [Route("api/employee/")]
        [HttpPost]
        public HttpResponseMessage Post(Employee emp)
        {
            return Request.CreateResponse(HttpStatusCode.OK, Service.InsertEmployee(emp));
        }

        [Route("api/employee/")]
        [HttpDelete]
        public HttpResponseMessage Delete([FromBody] int id)
        {
            if (Service.DeleteEmployee(id)) return Request.CreateResponse(HttpStatusCode.OK, "Success");
            return Request.CreateResponse(HttpStatusCode.BadRequest, "No content to delete");
        }

    }
}
