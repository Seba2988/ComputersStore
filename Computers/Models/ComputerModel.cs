using System.ComponentModel.DataAnnotations;
namespace Computers.Models
{
    public class ComputerModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please add a model")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Please add a CPU")]
        public string CPU { get; set; }

        [Required(ErrorMessage = "Please add a GPU")]
        public string GPU { get; set; }

        [Required(ErrorMessage = "Please add a RAM memory")]
        public int RAM { get; set; }

        [Required(ErrorMessage = "Please add a ROM memory")]
        public int ROM { get; set; }

        [Required(ErrorMessage = "Please add a motherboard")]
        public string Motherboard { get; set; }

        [Required(ErrorMessage = "Please add a power supply")]
        public string PowerSupply { get; set; }

        [Required (ErrorMessage = "Please add a price")]
        [Range(0, int.MaxValue, ErrorMessage = "The price must be positive")]
        public int Price { get; set; }
    }
}
