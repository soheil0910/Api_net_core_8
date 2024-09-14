namespace Api_net_core_8.Models.Pc
{
    //این قسمت برای تست رلیشن در کلاس ها است
    public class PC
    {
        public int Id { get; set; }

        public string? Name { get; set; }
        public int? DescriptionId { get; set; }
        public PcDetails? Description { get; set; }
    }
}
