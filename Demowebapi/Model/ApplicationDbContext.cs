using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Demowebapi.Model;

namespace Demowebapi.Models;

public class ApplicationDbContext:DbContext{

    public virtual DbSet<Employee> Employees{get;set;}
    public virtual DbSet<Department> Departments{get;set;}
    public ApplicationDbContext(){

    }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> op):base(op){

    }
    protected override void OnConfiguring(DbContextOptionsBuilder ob){
        if(!ob.IsConfigured){
            ob.UseSqlServer("User ID=sa;password=examlyMssql@123; server=localhost;Database=EntDb;trusted_connection=false;Persist Security Info=False;Encrypt=False;");
        }
    }

}
