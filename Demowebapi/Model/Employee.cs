using System;
using System.ComponentModel.DataAnnotations;
namespace Demowebapi.Model;

public class Employee{

    [Key]
    public int empid{get;set;}
    public string empname{get;set;}
    public decimal empsalary{get;set;}
    public int deptid{get;set;}

    public Department Department{get;set;}
    
}