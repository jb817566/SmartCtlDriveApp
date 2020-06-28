
﻿namespace SmartCtl.Domain.Model



{
    public class Registers
    {
        public int command { get; set; }
        public int features { get; set; }
        public int count { get; set; }
        public int lba { get; set; }
        public int device { get; set; }
        public int device_control { get; set; }
    }
}