using SmartCtl.Domain;

namespace SmartCtl.Domain.Model
{
    public class SmartOutput
    {
        public DriveInformation Out() =>
            new DriveInformation()
            {
                SerialNumber = this.serial_number,
                ModelName = this.model_name,
                ModelFamily = this.model_family,
                FormFactor = this.form_factor.name,
                BlockCount = this.user_capacity.blocks,
                BytesCount = this.user_capacity.bytes,
                FirmwareVersion = this.firmware_version,
                RPM = this.rotation_rate,
                ATAVersionName = this.ata_version._string,
                ATAVersionMajor = this.ata_version.major_value,
                ATAVersionMinor = this.ata_version.minor_value,
                SATASpeed = this.interface_speed.max._string,
                SmartOK = this.smart_status.passed,
                HasErrorRecovery = this.ata_sct_capabilities.error_recovery_control_supported,
                //SmartAttr = this.ata_smart_attributes.table.FirstOrDefault(a => a.)
                PowerOnHours = this.power_on_time.hours,
                PowerCycleCount = this.power_cycle_count,
                Temperature = this.temperature.current,
            };
        public int[] json_format_version { get; set; }
        public Smartctl smartctl { get; set; }
        public Device device { get; set; }
        public string model_family { get; set; }
        public string model_name { get; set; }
        public string serial_number { get; set; }
        public Wwn wwn { get; set; }
        public string firmware_version { get; set; }
        public UserCapacity user_capacity { get; set; }
        public int logical_block_size { get; set; }
        public int physical_block_size { get; set; }
        public int rotation_rate { get; set; }
        public FormFactor form_factor { get; set; }
        public Trim trim { get; set; }
        public bool in_smartctl_database { get; set; }
        public Ata_Version ata_version { get; set; }
        public SataVersion sata_version { get; set; }
        public InterfaceSpeed interface_speed { get; set; }
        public LocalTime local_time { get; set; }
        public SmartStatus smart_status { get; set; }
        public AtaSmartData ata_smart_data { get; set; }
        public ATACapabilities ata_sct_capabilities { get; set; }
        public ATASmartAttributes ata_smart_attributes { get; set; }
        public PowerOnHours power_on_time { get; set; }
        public int power_cycle_count { get; set; }
        public Temperature temperature { get; set; }
        public ATASmartErrorLog ata_smart_error_log { get; set; }
        public SMARTLog ata_smart_self_test_log { get; set; }
        //public Ata_Smart_Selective_Self_Test_Log ata_smart_selective_self_test_log { get; set; }
    }
}