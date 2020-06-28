using System;
using System.Collections.Generic;
using System.Text;
using SmartCtlDriveApp.Model;

namespace SmartCtl.Domain
{
    public class DriveInformation
    {
        public int ID { get; set; }
        public string SerialNumber { get; set; }
        public string ModelName { get; set; }
        public string ModelFamily { get; set; }
        public string FormFactor { get; set; }
        public long BlockCount { get; set; }
        public long BytesCount { get; set; }
        public string FirmwareVersion { get; set; }
        public int RPM { get; set; }
        public int ATAVersionMinor { get; set; }
        public int ATAVersionMajor { get; set; }
        public string ATAVersionName { get; set; }
        public string SATASpeed { get; set; }
        public bool SmartOK { get; set; }
        public bool HasErrorRecovery { get; set; }
        public int PowerOnHours { get; set; }
        public int PowerCycleCount { get; set; }
        public int Temperature { get; set; }
    }
}
