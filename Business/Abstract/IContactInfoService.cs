using Entities.Concrete;
using Entities.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContactInfoService
    {
        Task<ContactInfo> AddAsync(ContactInfo contactInfo);
        Task<bool> DeleteAsync(int id);
        Task<ContactInfo> GetByIdAsync(int id);
        Task<IEnumerable<ContactInfo>> GetListAsync();
        Task<ContactInfo> UpdateAsync(ContactInfo contactInfo);
        List<ContactInfoDto> GetDirectoryDetailDto(int id);
    }
}
