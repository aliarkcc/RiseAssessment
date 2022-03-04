using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfContactInfoDal : EfBaseRepository<ContactInfo, Context>, IContactInfoDal
    {
        public List<ContactLocationDescDto> GetContactDesc()
        {
            using (Context db= new Context())
            {
                var result = db.ContactInfos
                   .GroupBy(p => p.Location)
                   .Select(g => new ContactLocationDescDto { Name = g.Key, Count = g.Count() })
                   .OrderByDescending(a => a.Count);
                return result.ToList();
            }
        }

        public List<ContactLocationDescDto> GetDirectoryCountToLocation()
        {
            using (Context db = new Context())
            {
                var result = db.ContactInfos
                    .GroupBy(x => x.Location)
                    .Select(g => new ContactLocationDescDto { Name = g.Key, Count = g.Select(x => x.DirectoryId).Distinct().Count() });
                return result.ToList();
            }
        }

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

        public List<ContactLocationDescDto> GetTelNumberCountToLocation()
        {
            using (Context db = new Context())
            {
                var result = db.ContactInfos
                    .GroupBy(x => x.Location)
                    .Select(g => new ContactLocationDescDto { Name = g.Key, Count = g.Select(x => x.DirectoryId).Distinct().Count()});
                return result.ToList();
            }
        }
    }
}
