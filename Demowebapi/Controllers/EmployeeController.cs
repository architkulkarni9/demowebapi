using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Demowebapi.Model;
 
namespace Demowebapi.Controllers
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
            var data = (from m in context.Employees where m.empid == id select m).FirstOrDefault();
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
 
        [HttpPut]
        [Route("EditEmployee/{id}")]
        public IActionResult Put(int id, Employee emp)
        {
            if(ModelState.IsValid)
            {
                Employee e = context.Employees.Find(id);
                emp.empname = emp.empname;
                context.SaveChanges();
                return Ok();
            }
 
            return BadRequest("Unable to Edit Record");
        }
 
        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var detail = context.Employees.Where(d=> d.empid == id);
                if(detail.Count() != 0)
                {
                    throw new Exception("Cannot Delete Movie");
                }
                var data = context.Employees.Find(id);
                context.Employees.Remove(data);
                context.SaveChanges();
                return Ok();
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
 
            }
        }
 
 
    }      
}