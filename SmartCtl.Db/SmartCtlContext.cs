using System;
using Microsoft.EntityFrameworkCore;
using SmartCtl.Domain;

namespace SmartCtl.Db
{
    public class SmartCtlContext : DbContext
    {
            public DbSet<DriveInformation> DriveInformation { get; set; }
            protected override void OnConfiguring(DbContextOptionsBuilder options)
                => options.UseSqlite("Data Source=C:\\Users\\Public\\SmartCtl.db");
    }
}
