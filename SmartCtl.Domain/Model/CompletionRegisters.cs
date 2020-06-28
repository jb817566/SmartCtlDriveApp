namespace SmartCtl.Domain.Model
{
    public class CompletionRegisters
    {
        public int error { get; set; }
        public int status { get; set; }
        public int count { get; set; }
        public int lba { get; set; }
        public int device { get; set; }
    }
}