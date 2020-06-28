<<<<<<< HEAD
﻿namespace SmartCtl.Domain.Model
=======
﻿namespace SmartCtlDriveApp.Model
>>>>>>> f1bc0fb3fb847744c599ad3aed2f4686cf8a44b9
{
    public class Capabilities
    {
        public int[] values { get; set; }
        public bool exec_offline_immediate_supported { get; set; }
        public bool offline_is_aborted_upon_new_cmd { get; set; }
        public bool offline_surface_scan_supported { get; set; }
        public bool self_tests_supported { get; set; }
        public bool conveyance_self_test_supported { get; set; }
        public bool selective_self_test_supported { get; set; }
        public bool attribute_autosave_enabled { get; set; }
        public bool error_logging_supported { get; set; }
        public bool gp_logging_supported { get; set; }
    }
}