using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCtl.Domain;
using SmartCtl.Domain.Entity;

namespace SmartCtl.Db.Config
{
    class ZFSPoolConfig : IEntityTypeConfiguration<ZFSPool>
    {
        public void Configure(EntityTypeBuilder<ZFSPool> builder)
        {
            builder.HasKey(u => u.ID);
            builder.Property(a => a.ID).ValueGeneratedOnAdd();
            builder.Property(a => a.PoolName).IsRequired().HasMaxLength(512);
            builder.Property(a => a.MountPoint).IsRequired();
            builder.Property(a => a.Available).IsRequired();
            builder.Property(a => a.Capacity).IsRequired();
            builder.Property(a => a.MemberCount).IsRequired();
            builder.Property(a => a.CompressionType).IsRequired();
            builder.Property(a => a.DateCreated).IsRequired();
        }
    }
}
