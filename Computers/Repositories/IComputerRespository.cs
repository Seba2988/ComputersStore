using Computers.Models;
using Microsoft.AspNetCore.JsonPatch;
namespace Computers.Repositories
{
    public interface IComputerRespository
    {
        Task<List<ComputerModel>> GetAllComputersAsync();
        Task<ComputerModel> GetComputerByIdAsync(int computerId);
        Task<int> AddComputerAsync(ComputerModel computerModel);

        Task UpdateComputerAsync(int computerId, ComputerModel computer);
        Task UpdateComputerPatchAsync(int computerId, JsonPatchDocument computer);
        Task DeleteComputerAsync(int computerId);

        Task<List<ComputerModel>> GetComputersByCriteria(SearchModel searchModel);
    }
}
