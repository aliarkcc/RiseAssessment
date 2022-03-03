using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DirectoryManager : IDirectoryService
    {
        IDirectoryDal _directoryDal;

        public DirectoryManager(IDirectoryDal directoryDal)
        {
            _directoryDal = directoryDal;
        }

        public async Task<Directory> AddAsync(Directory directory)
        {
            return await _directoryDal.AddAsync(directory);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _directoryDal.DeleteAsync(id);
        }

        public async Task<Directory> GetByIdAsync(int id)
        {
            return await _directoryDal.GetAsync(x=>x.DirectoryId==id);
        }

        public async Task<IEnumerable<Directory>> GetListAsync()
        {
            return await _directoryDal.GetListAsync();
        }

        public async Task<Directory> UpdateAsync(Directory directory)
        {
            return await _directoryDal.UpdateAsync(directory);
        }
    }
}
