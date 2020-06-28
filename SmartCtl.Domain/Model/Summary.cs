namespace SmartCtl.Domain.Model
{
    public class Summary
    {
        public int revision { get; set; }
        public int count { get; set; }
        public int logged_count { get; set; }
        public SummaryTable[] table { get; set; }
    }
}