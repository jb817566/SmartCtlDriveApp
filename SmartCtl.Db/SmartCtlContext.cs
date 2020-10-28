using System;
using Microsoft.EntityFrameworkCore;
using SmartCtl.Db.Config;
using SmartCtl.Domain;
using SmartCtl.Domain.Entity;

namespace SmartCtl.Db
{
    public class SmartCtlContext : DbContext
    {
        public DbSet<DriveInformation> DriveInformation { get; set; }
        public DbSet<ZFSPool> ZFSPool { get; set; }
        public DbSet<ZFSPoolInfo> ZFSPoolInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (Environment.OSVersion.Platform == PlatformID.Unix)
            {
                options.UseSqlite("Data Source=SmartCtl.db");
            }
            else
            {
                options.UseSqlite("Data Source=C:\\Users\\Public\\SmartCtl.db");
            }
        }


    }
}
