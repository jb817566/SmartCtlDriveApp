<<<<<<< HEAD
﻿namespace SmartCtl.Domain.Model
=======
﻿namespace SmartCtlDriveApp.Model
>>>>>>> f1bc0fb3fb847744c599ad3aed2f4686cf8a44b9
{
    public class ATACapabilities
    {
        public int value { get; set; }
        public bool error_recovery_control_supported { get; set; }
        public bool feature_control_supported { get; set; }
        public bool data_table_supported { get; set; }
    }
}