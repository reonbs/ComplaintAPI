using System;
using Microsoft.EntityFrameworkCore;
using Bankly.Complaint.Respository.Models;

namespace Bankly.Complaint.Respository
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ProductComplaint> ProductComplaints { get; set; }
    }
}
