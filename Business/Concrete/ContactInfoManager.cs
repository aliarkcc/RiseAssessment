using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ContactInfoManager : IContactInfoService
    {
        IContactInfoDal _contactInfoDal;

        public ContactInfoManager(IContactInfoDal contactInfoDal)
        {
            _contactInfoDal = contactInfoDal;
        }

        public async Task<ContactInfo> AddAsync(ContactInfo contactInfo)
        {
            return await _contactInfoDal.AddAsync(contactInfo);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _contactInfoDal.DeleteAsync(id);
        }

        public async Task<ContactInfo> GetByIdAsync(int id)
        {
            return await _contactInfoDal.GetAsync(x => x.DirectoryId == id);
        }

        public List<ContactInfoDto> GetDirectoryDetailDto(int id)
        {
            return _contactInfoDal.GetDirectoryDetailDto(id);
        }

        public async Task<IEnumerable<ContactInfo>> GetListAsync()
        {
            return await _contactInfoDal.GetListAsync();
        }

        public async Task<ContactInfo> UpdateAsync(ContactInfo contactInfo)
        {
            return await _contactInfoDal.UpdateAsync(contactInfo);
        }
    }
}
