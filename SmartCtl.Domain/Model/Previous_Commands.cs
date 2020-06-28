
﻿namespace SmartCtl.Domain.Model



{
    public class PreviousCommands
    {
        public Registers registers { get; set; }
        public int powerup_milliseconds { get; set; }
        public string command_name { get; set; }
    }
}