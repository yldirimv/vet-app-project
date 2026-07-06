using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using VetMvc.Models;

namespace VetMvc.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<PetModel> Pets { get; set; }
        public DbSet<MedicineModel> Medicines { get; set; }
        public DbSet<TreatmentModel> Treatments { get; set; }
    }
}
