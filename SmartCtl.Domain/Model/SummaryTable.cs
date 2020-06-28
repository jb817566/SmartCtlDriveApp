<<<<<<< HEAD
﻿namespace SmartCtl.Domain.Model
=======
﻿namespace SmartCtlDriveApp.Model
>>>>>>> f1bc0fb3fb847744c599ad3aed2f4686cf8a44b9
{
    public class SummaryTable
    {
        public int error_number { get; set; }
        public int lifetime_hours { get; set; }
        public CompletionRegisters completion_registers { get; set; }
        public string error_description { get; set; }
        public PreviousCommands[] previous_commands { get; set; }
    }
}