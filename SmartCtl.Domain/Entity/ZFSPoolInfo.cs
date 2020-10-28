using System;

namespace SmartCtl.Domain.Entity
{
    public class ZFSPoolInfo
    {
        public int ID { get; set; }
        /// <summary>
        /// RAID Level
        /// </summary>
        public RaidLevel RaidLevel { get; set; } = RaidLevel.UNKNOWN;
        /// <summary>
        /// DriveInformation ID
        /// </summary>
        public int DriveID { get; set; }
        /// <summary>
        /// Drive Capacity
        /// </summary>
        public double Capacity { get; set; }

        /// <summary>
        /// ZFSPool ID
        /// </summary>
        public int PoolID { get; set; }
    }
}
