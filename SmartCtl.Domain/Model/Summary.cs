<<<<<<< HEAD
﻿namespace SmartCtl.Domain.Model
=======
﻿namespace SmartCtlDriveApp.Model
>>>>>>> f1bc0fb3fb847744c599ad3aed2f4686cf8a44b9
{
    public class Summary
    {
        public int revision { get; set; }
        public int count { get; set; }
        public int logged_count { get; set; }
        public SummaryTable[] table { get; set; }
    }
}