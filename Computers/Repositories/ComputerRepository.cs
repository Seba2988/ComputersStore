using AutoMapper;
using Computers.Data;
using Computers.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace Computers.Repositories
{
    public class ComputerRepository:IComputerRespository
    {
        private readonly ComputersStoreContext _context;
        private readonly IMapper _mapper;

        public ComputerRepository(ComputersStoreContext computersStoreContext, IMapper mapper)
        {
            _context = computersStoreContext;
            _mapper = mapper;
        }

        public async Task<List<ComputerModel>> GetAllComputersAsync()
        {
            var computers = await _context.Computers.ToListAsync();
            return _mapper.Map<List<ComputerModel>>(computers);
        }

        public async Task<ComputerModel> GetComputerByIdAsync(int computerId)
        {
            var computer = await _context.Computers.FindAsync(computerId);
            return _mapper.Map<ComputerModel>(computer);
        }

        public async Task<int> AddComputerAsync(ComputerModel computerModel)
        {
            var computer = new Computer()
            {
                Model = computerModel.Model,
                CPU = computerModel.CPU,
                GPU = computerModel.GPU,
                RAM = computerModel.RAM,
                ROM = computerModel.ROM,
                Motherboard = computerModel.Motherboard,
                PowerSupply = computerModel.PowerSupply,
                Price = computerModel.Price
            };
            _context.Computers.Add(computer);
            await _context.SaveChangesAsync();
            return computer.Id;
        }

        public async Task UpdateComputerAsync(int computerId, ComputerModel computerModel)
        {
            var computer = new Computer()
            {
                Id = computerId,
                Model = computerModel.Model,
                CPU = computerModel.CPU,
                GPU = computerModel.GPU,
                RAM = computerModel.RAM,
                ROM = computerModel.ROM,
                Motherboard = computerModel.Motherboard,
                PowerSupply = computerModel.PowerSupply,
                Price = computerModel.Price
            };
            _context.Computers.Update(computer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateComputerPatchAsync(int computerId, JsonPatchDocument computerModel)
        {
            var computer = await _context.Computers.FindAsync(computerId);
            if(computer!=null)
            {
                computerModel.ApplyTo(computer);
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteComputerAsync(int computerId)
        {
            var computer = new Computer() { Id = computerId };
            _context.Computers.Remove(computer);
            await _context.SaveChangesAsync();
        }

       
    }
}
