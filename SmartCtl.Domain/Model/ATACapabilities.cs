namespace SmartCtl.Domain.Model
{
    public class ATACapabilities
    {
        public int value { get; set; }
        public bool error_recovery_control_supported { get; set; }
        public bool feature_control_supported { get; set; }
        public bool data_table_supported { get; set; }
    }
}