using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCtlDriveApp.Model
{
    public class Type
    {
        public int value { get; set; }
        public string _string { get; set; }
    }

    //public class Ata_Smart_Selective_Self_Test_Log
    //{
    //    public int revision { get; set; }
    //    public Table3[] table { get; set; }
    //    public Flags1 flags { get; set; }
    //    public int power_up_scan_resume_minutes { get; set; }
    //}

    //public class Flags1
    //{
    //    public int value { get; set; }
    //    public bool remainder_scan_enabled { get; set; }
    //}

    //public class Table3
    //{
    //    public int lba_min { get; set; }
    //    public int lba_max { get; set; }
    //    public Status3 status { get; set; }
    //}

    //public class Status3
    //{
    //    public int value { get; set; }
    //    public string _string { get; set; }
    //}

}
