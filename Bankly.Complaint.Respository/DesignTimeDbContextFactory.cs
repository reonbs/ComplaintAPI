﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Bankly.Complaint.Respository
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            //you can change to you local , this runs online in design time
            builder.UseNpgsql(@"Server=localhost;Database=BanklyComplaintDb;Port=5432;User Id=reo;Password=habakuk2:2;");
            return new AppDbContext(builder.Options);
        }
    }
}
