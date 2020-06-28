<<<<<<< HEAD
﻿namespace SmartCtl.Domain.Model
=======
﻿namespace SmartCtlDriveApp.Model
>>>>>>> f1bc0fb3fb847744c599ad3aed2f4686cf8a44b9
{
    public class Smartctl
    {
        public int[] version { get; set; }
        public string svn_revision { get; set; }
        public string platform_info { get; set; }
        public string build_info { get; set; }
        public string[] argv { get; set; }
        public int exit_status { get; set; }
        public Message[] messages { get; set; }
    }
}