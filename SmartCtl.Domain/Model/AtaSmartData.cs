namespace SmartCtl.Domain.Model
{
    public class AtaSmartData
    {
        public OfflineDataCollection offline_data_collection { get; set; }
        public SelfTest self_test { get; set; }
        public Capabilities capabilities { get; set; }
    }
}