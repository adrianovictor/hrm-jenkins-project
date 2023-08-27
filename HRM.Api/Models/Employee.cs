namespace HRM.Api.Models;

public class Employee {
    public int Id { get; set;}
    public required string Name { get; set;} = string.Empty;
    public required string Designation { get; set; } = string.Empty;
    public required string FathersName { get; set; } = string.Empty;
    public required string MothersName { get; set; } = string.Empty; 
    public DateTime DateOfBirth { get; set; }

}