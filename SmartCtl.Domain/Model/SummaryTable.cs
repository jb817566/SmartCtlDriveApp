namespace SmartCtlDriveApp.Model
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