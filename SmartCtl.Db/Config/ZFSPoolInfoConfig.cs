using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCtl.Domain;
using SmartCtl.Domain.Entity;

namespace SmartCtl.Db.Config
{
    class ZFSPoolInfoConfig : IEntityTypeConfiguration<ZFSPoolInfo>
    {
        public void Configure(EntityTypeBuilder<ZFSPoolInfo> builder)
        {
            builder.HasKey(u => u.ID);
            builder.Property(a => a.ID).ValueGeneratedOnAdd();
            builder.Property(a => a.RaidLevel).IsRequired();
            builder.Property(a => a.DriveID).IsRequired();
            builder.Property(a => a.PoolID).IsRequired();
            builder.Property(a => a.Capacity).IsRequired();
        }
    }
}
