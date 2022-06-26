using AutoMapper;
using Computers.Data;
using Computers.Models;
namespace Computers.Helpers
{
    public class ApplicationMapper:Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Computer, ComputerModel>().ReverseMap();
        }
    }
}
