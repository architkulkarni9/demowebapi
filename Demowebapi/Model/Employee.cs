using System;
using System.ComponentModel.DataAnnotations;
namespace Demowebapi.Model;

public class Employee{
    public int id{get;set;}
    public string name{get;set;}
    public decimal salary{get;set;}
    public int deptid{get;set;}
    
}