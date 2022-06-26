namespace Computers.Models
{
    public class SearchModel
    {
        public string? Model { get; set; }
        public string? CPU { get; set; }
        public string? GPU { get; set; }
        public int? RAM { get; set; }
        public int? ROM { get; set; }
        public string? Motherboard { get; set; }
        public string? PowerSupply { get; set; }
        public int? Price { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
    }
}
