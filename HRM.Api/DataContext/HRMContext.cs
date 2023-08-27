using HRM.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace HRM.Api.DataContext;

public class HRMContext : DbContext
{
    public HRMContext(DbContextOptions<HRMContext> options)
        : base(options) 
    {

    }

    public DbSet<Employee> Employees { get; set; }
}
