using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Demowebapi.Models;
using System.Collections.Generic;
using Demowebapi.ViewModel;

namespace Demowebapi.Controllers;

[ApiController]
[Route("/[controller]")]
public class EmployeeController:ControllerBase{
    EntDbContext context=new EntDbContext();

    [HttpGet]
    [Route("Display/Rating/Year")]
    public IActionResult GetDisplayEmployee(int rating, int year){
        var data=context.Movi.Where(m=>(m.Rating==rating && m.YearRelease==year));
        return Ok(data);
    }

    [HttpGet]
    [Route("DisplayByRating")]
    public IActionResult GetDisplayByRating(int rating){
        var data=context.Movie.Where(m=>m.Rating==rating);
        if(data.Count()==0){
            return NotFound("No Movies in rating"+rating);
        }
        return Ok(data);
    }

    [HttpGet] // Stored Procedure
    [Route("ShowMovies")] 
    public IActionResult GetShowMovies(){
        var data=context.Movie_VM.FromSqlInterpolated<Movie_VM>($"MovieInfo1");
        return Ok(data);
    }
    


    [HttpGet]
    [Route("ListEmployee")]
    public IActionResult Get(){
        var data=context.Employee.ToList();
        return Ok(data);
    }

    [HttpGet]
    [Route("Findbyid/{id}")]
    public IActionResult GetFindbyid(int id){
        if(id==null){
            return BadRequest("Id cannot be null");
        }
        // var data=(from m in context.Movies where m.Id==id select m).FirstorDefault();
        var data=context.Employee.Find(id);
        if(data==null){
            return NotFound($"Employee {id} not found");
        }
        return Ok(data);

    }

    [HttpPost]
    [Route("AddEmployee")]
    public IActionResult Post(Movie m){
        if(ModelState.IsValid){
            try{
                contextEmployee.Add(m);
                context.SaveChanges();
            }
            catch(System.Exception ex){
                return BadRequest(ex.InnerException.Message);
            }
        }
        return Created("Records Added",m);
    }

    [HttpPut]
    [Route("EditEmployee/{id}")]
    public IActionResult Put(int id, Movie m){
        if(ModelState.IsValid){
            Movie m1=context.Employee.Find(id);
            m1.name=m.name;
            m1.salary=m.salary;
            m1.YearRelease=m.YearRelease;
            context.SaveChanges();
            return Ok();
        }
        return BadRequest("Unable to Edit Record");
        
    }

    [HttpDelete]
    [Route("DeleteMovie/{id}")]
    public IActionResult Delete(int id){
        try{
            var data=context.Detail.Where(m=>m.MovieId==id);
            if(data.Count()!=0){
                throw new Exception("Cannot Delete");

            }
            var data2=context.Movie.Find(id);
            context.Movie.Remove(data2);
            context.SaveChanges();
            return Ok();
        }
        catch(System.Exception ex){
            return BadRequest(ex.Message);
        }
    }
    


}
