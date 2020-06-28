namespace SmartCtl.Domain.Model
{
    public class Flags
    {
        public int value { get; set; }
        public string _string { get; set; }
        public bool prefailure { get; set; }
        public bool updated_online { get; set; }
        public bool performance { get; set; }
        public bool error_rate { get; set; }
        public bool event_count { get; set; }
        public bool auto_keep { get; set; }
    }
}