namespace SmartCtl.Domain.Model
{
    public class ATASmartAttributes
    {
        public int revision { get; set; }
        public SmartAttributesKV[] table { get; set; }
    }
}