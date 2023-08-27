namespace HRM.Api.Models;

public class Employee {
    public int Id { get; set;}
    public required string Name { get; set;}
    public required string Designation { get; set; }
    public required string FathersName { get; set; }
    public required string MothersName { get; set; }
    public DateTime DateOfBirth { get; set; }

}