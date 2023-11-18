using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Demowebapi.Model;

public class ApplicationDbContext:DbContext{

    public virtual DbSet<Employee> Employees{get;set;}
    public virtual DbSet<Department> Departments{get;set;}
    public ApplicationDbContext(){

    }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> op):base(op){

    }
    protected override void OnConfiguring(DbContextOptionsBuilder ob){
        if(!ob.IsConfigured){
            ob.UseSqlServer("User ID=sa;password=examlyMssql@123; server=localhost;Database=ApplicationDb;trusted_connection=false;Persist Security Info=False;Encrypt=False;");
        }
    }

}
