namespace Api_net_core_8.Models.Pc
{
    //این قسمت برای تست رلیشن در کلاس ها است
    public class PcDetails
    {
        public int Id { get; set; }

        public string? Description { get; set; }
        public string? Ram { get; set; }
        public string? MotherBord { get; set; }
        public string? Power { get; set; }
        public int? PcCpuId { get; set; }

        public PcCpu? PcCpu { get; set; }
    }
}
