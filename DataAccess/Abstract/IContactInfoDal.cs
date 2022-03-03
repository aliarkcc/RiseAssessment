using Core.DataAccess;
using Entities.Concrete;
using Entities.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IContactInfoDal:IBaseRepository<ContactInfo>
    {
        List<ContactInfoDto> GetDirectoryDetailDto(int id);
    }
}
