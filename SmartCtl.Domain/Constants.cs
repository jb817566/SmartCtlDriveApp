using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCtl.Domain
{
    public static class Constants
    {
        public const string ZFS_DATE= "ddd MMM dd HH:mm yyyy";
        public const string SMARTCTL_ARGS = " --info --all --json=c --nocheck standby {0}";
        public const string ZFS_ARGS = "zfs get -H all";
        public const string ZFS_COMMAND = "/sbin/zfs";
    }
}
