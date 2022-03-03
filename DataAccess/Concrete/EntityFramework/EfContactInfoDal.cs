using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfContactInfoDal : EfBaseRepository<ContactInfo, Context>, IContactInfoDal
    {
        public List<ContactInfoDto> GetDirectoryDetailDto(int id)
        {
            using (Context db= new Context())
            {
                var result = from dr in db.Directories
                             join ci in db.ContactInfos on dr.DirectoryId equals ci.DirectoryId
                             where ci.DirectoryId == id
                             select new ContactInfoDto
                             {
                                 DirectoryId = dr.DirectoryId,
                                 Name = dr.Name,
                                 Surname = dr.Surname,
                                 Company = dr.Company,
                                 ContactInfos = (from ci in db.ContactInfos
                                                 where ci.DirectoryId == id
                                                 select new ContactInfo
                                                 {
                                                     Id = ci.Id,
                                                     DirectoryId = dr.DirectoryId,
                                                     Email = ci.Email,
                                                     PhoneNumber = ci.PhoneNumber,
                                                     Location = ci.Location
                                                 }).ToList()

                             };
                return result.ToList();
            }
        }
    }
}
