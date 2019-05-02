using AndDigitalTechTest.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AndDigitalTechTest.Models;
using Microsoft.AspNetCore.Diagnostics;
using System.IO;

namespace AndDigitalTechTest.Controllers
{
    [Produces("application/json")]
    [Route("api/CustomersDetails")]
    public class CustomersDetailsController : Controller
    {
        private readonly ICustomerDetailsService _customersDetailsService;

        public CustomersDetailsController(ICustomerDetailsService customersDetailsService)
        {
            _customersDetailsService = customersDetailsService;
        }
        // GET: api/CustomersDetails
        [HttpGet]
        public IEnumerable<CustomersDetails> Get()
        {
            return _customersDetailsService.ReadAll();

        }
        // GET: api/CustomersDetails/5
        [HttpGet("{id}", Name = "Get")]
        public CustomersDetails Get(int id)
        {
            return _customersDetailsService.Read(id);
        }

        // POST: api/CustomersDetails
        [HttpPost]
        public void Post([FromBody]CustomersDetails customersDetails)
        {
            _customersDetailsService.Create(customersDetails);
        }

        // PUT: api/CustomersDetails/5
        [HttpPut("{id}")]
        public void Put([FromBody]CustomersDetails customersDetails)
        {
            _customersDetailsService.Update(customersDetails);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _customersDetailsService.Delete(id);
        }

        string ExceptionMessage;
        public void ErrorHandeling()
        {
            var exceptionHandlerPathFeature =
        HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            if (exceptionHandlerPathFeature?.Error is FileNotFoundException)
            {
                ExceptionMessage = "File error thrown";
            }
            if (exceptionHandlerPathFeature?.Path == "/index")
            {
               ExceptionMessage += " from home page";
            }
        }
      }
    }
