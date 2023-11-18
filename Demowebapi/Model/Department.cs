using System;
using System.ComponentModel.DataAnnotations;
namespace Demowebapi.Model;
using System.Collections.Generic;

public class Department{

    [Key]
    public int deptid{get;set;}
    public string deptname{get;set;}

    public ICollection<Employee>? Employees{get;set;} 
    
}