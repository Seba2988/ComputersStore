using System.ComponentModel.DataAnnotations;
namespace Computers.Data
{
    public class Computer
    { 
        public int Id { get; set; }

        //[Required]
        public string Model { get; set; }

        //[Required]
        public string CPU { get; set; }

        //[Required]
        public string GPU { get; set; }

        //[Required]
        public int RAM { get; set; }

        //[Required]
        public int ROM { get; set; }

        //[Required]
        public string Motherboard { get; set; }

        //[Required]
        public string PowerSupply { get; set; }

        //[Required]
        //[Range(0, int.MaxValue)]
        public int Price { get; set; }
    }
}
