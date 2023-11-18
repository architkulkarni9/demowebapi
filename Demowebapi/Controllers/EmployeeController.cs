using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using demowebapi.Model;
 
namespace demowebapi.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class EmployeeController : ControllerBase
    {
        ApplicationDbContext context = new ApplicationDbContext();
 
 
        [HttpGet]
        [Route("ListEmployees")]
        public IActionResult Get()
        {
            var data = from m in context.Employees select m;
            return Ok(data);
        }
        [HttpGet]
        [Route("ListEmployees/{id}")]
        public IActionResult Get(int id)
        {
            if(id == null)
            {
                return BadRequest("Id cannot be null");
            }
            var data = (from m in context.Employees where m.Id == id select m).FirstOrDefault();
            if(data == null)
            {
                return NotFound($"Employee {id} not found"); //404
            }
            return Ok(data); //200
        }
 
        [HttpPost]
        [Route("AddEmployee")]
        public IActionResult Post(Employee emp)
        {
            if(ModelState.IsValid)
            {
                try{
                    context.Employees.Add(emp);
                    context.SaveChanges();
                }
                catch(SystemException ex)
                {
                    return BadRequest(ex.InnerException.Message);
                }
            }
 
            return Created("Record Added", emp); //
        }
    }
}