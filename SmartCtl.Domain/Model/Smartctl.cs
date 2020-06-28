namespace SmartCtl.Domain.Model
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