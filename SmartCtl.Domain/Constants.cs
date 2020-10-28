using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartCtl.Domain.Enum;

namespace SmartCtl.Domain
{
    public static class Constants
    {
        public static List<CompressionType> CompressionTypes = System.Enum.GetValues(typeof(CompressionType)).Cast<CompressionType>().ToList();

        public const string ZFS_DATE= "ddd MMM dd HH:mm yyyy";
        public const string SMARTCTL_ARGS = " --info --all --json=c --nocheck standby {0}";
        public const string ZFS_ARGS = "zfs get -H all";
        public const string ZFS_COMMAND = "/sbin/zfs";
    }
}
