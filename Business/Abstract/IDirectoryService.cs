using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDirectoryService
    {
        Task<Directory> AddAsync(Directory directory);
        Task<bool> DeleteAsync(int id);
        Task<Directory> GetByIdAsync(int id);
        Task<IEnumerable<Directory>> GetListAsync();
        Task<Directory> UpdateAsync(Directory directory);
    }
}
