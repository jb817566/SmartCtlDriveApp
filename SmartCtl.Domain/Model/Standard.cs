namespace SmartCtlDriveApp.Model
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