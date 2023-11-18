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
    public class DepartmentController : ControllerBase
    {
        ApplicationDbContext context = new ApplicationDbContext();
 
 
        [HttpGet]
        [Route("ListDepartments")]
        public IActionResult Get()
        {
            var data = from m in context.Departments select m;
            return Ok(data);
        }
        [HttpGet]
        [Route("ListDepartment/{id}")]
        public IActionResult Get(int id)
        {
            if(id == null)
            {
                return BadRequest("Id cannot be null");
            }
            var data = (from m in context.Departments where m.DepartmentId == id select m).FirstOrDefault();
            if(data == null)
            {
                return NotFound($"Department {id} not found"); //404
            }
            return Ok(data); //200
        }
 
        [HttpPost]
        [Route("AddDepartment")]
        public IActionResult Post(Department department)
        {
            if(ModelState.IsValid)
            {
                try{
                    context.Departments.Add(department);
                    context.SaveChanges();
                }
                catch(SystemException ex)
                {
                    return BadRequest(ex.InnerException.Message);
                }
            }
 
            return Created("Record Added", department); //
        }
 
        [HttpPut]
        [Route("EditEmployee/{id}")]
        public IActionResult Put(int id, Department department)
        {
            if(ModelState.IsValid)
            {
                Department d = context.Departments.Find(id);
                d.DepartmentName = department.DepartmentName;
                d.DepartmentId = department.DepartmentId;
                context.SaveChanges();
                return Ok();
            }
 
            return BadRequest("Unable to Edit Record");
        }
 
        [HttpDelete]
        [Route("DeleteDepartment/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var detail = context.Departments.Where(d=> d.DepartmentId == id);
                if(detail.Count() != 0)
                {
                    throw new Exception("Cannot Delete Movie");
                }
                var data = context.Departments.Find(id);
                context.Departments.Remove(data);
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