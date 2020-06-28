<<<<<<< HEAD
﻿namespace SmartCtl.Domain.Model
=======
﻿namespace SmartCtlDriveApp.Model
>>>>>>> f1bc0fb3fb847744c599ad3aed2f4686cf8a44b9
{
    public class Standard
    {
        public int revision { get; set; }
        public int count { get; set; }
        public Table2[] table { get; set; }
        public int error_count_total { get; set; }
        public int error_count_outdated { get; set; }
    }
}