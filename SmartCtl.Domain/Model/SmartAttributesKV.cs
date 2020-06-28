
﻿namespace SmartCtl.Domain.Model



{
    public class SmartAttributesKV
    {
        public int id { get; set; }
        public string name { get; set; }
        public int value { get; set; }
        public int worst { get; set; }
        public int thresh { get; set; }
        public string when_failed { get; set; }
        public Flags flags { get; set; }
        public RawValueStrings raw { get; set; }
    }
}