using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCtl.Domain;

namespace SmartCtl.Db.Config
{
    class DriveInformationConfig : IEntityTypeConfiguration<DriveInformation>
    {
        public void Configure(EntityTypeBuilder<DriveInformation> builder)
        {
            builder.HasKey(u => u.ID);
            builder.Property(a => a.ID).ValueGeneratedOnAdd();
            builder.Property(a => a.SerialNumber).IsRequired().HasMaxLength(16);
            builder.Property(a => a.ModelName).IsRequired().HasMaxLength(64);
            builder.Property(a => a.ModelFamily).IsRequired().HasMaxLength(64);
            builder.Property(a => a.FormFactor).IsRequired().HasMaxLength(16);
            builder.Property(a => a.BlockCount).IsRequired();
            builder.Property(a => a.BytesCount).IsRequired();
            builder.Property(a => a.FirmwareVersion).IsRequired().HasMaxLength(16);
            builder.Property(a => a.ATAVersionName).IsRequired().HasMaxLength(64);
            builder.Property(a => a.ATAVersionMajor).IsRequired();
            builder.Property(a => a.ATAVersionMinor).IsRequired();
            builder.Property(a => a.SATASpeed).IsRequired().HasMaxLength(16);
            builder.Property(a => a.SmartOK).IsRequired().HasDefaultValue(false);
            builder.Property(a => a.HasErrorRecovery).IsRequired().HasDefaultValue(false);
            builder.Property(a => a.PowerOnHours).IsRequired();
            builder.Property(a => a.PowerCycleCount).IsRequired();
            builder.Property(a => a.Temperature).IsRequired();
        }
    }
}
