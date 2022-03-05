using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using StackExchange.Redis.Extensions.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Business.Concrete
{
    public class ContactInfoManager : IContactInfoService
    {
        IContactInfoDal _contactInfoDal;
        private readonly IRedisClient _redisCache;
        public ContactInfoManager(IContactInfoDal contactInfoDal, IRedisClient redisClient)
        {
            _contactInfoDal = contactInfoDal;
            _redisCache = redisClient;
        }

        public async Task<ContactInfo> AddAsync(ContactInfo contactInfo)
        {
            await _redisCache.Db0.RemoveAsync("contactInfo");
            return await _contactInfoDal.AddAsync(contactInfo);            
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _redisCache.Db0.RemoveAllAsync(new[] { "contactInfo", $"contactInfo_{id}" });
            return await _contactInfoDal.DeleteAsync(id);           
        }

        public async Task<ContactInfo> GetByIdAsync(int id)
        {
            var cacheKey = $"contactInfo_{id}";
            var cachedData = await _redisCache.Db0.GetAsync<ContactInfo>(cacheKey);
            if (cachedData != null)
                return cachedData;
            var result = await _contactInfoDal.GetAsync(x => x.Id == id);
            await _redisCache.Db0.AddAsync(cacheKey, result, TimeSpan.FromMinutes(5));
            return result;
        }

        public ContactInfoDto GetDirectoryDetailDto(int id)
        {
            return _contactInfoDal.GetDirectoryDetailDto(id);
        }

        public async Task<IEnumerable<ContactInfo>> GetListAsync()
        {
            var isCacheable = false;
            string cacheKey = "contactInfo";

            var cachedData = await _redisCache.Db0.GetAsync<IEnumerable<ContactInfo>>(cacheKey);
            if (cachedData != null)
                return cachedData;

            isCacheable = true;

            var result = await _contactInfoDal.GetListAsync();
            if (isCacheable)
                await _redisCache.Db0.AddAsync(cacheKey, result, TimeSpan.FromMinutes(5));

            return result;
        }

        public async Task<ContactInfo> UpdateAsync(ContactInfo contactInfo)
        {
            await _redisCache.Db0.RemoveAllAsync(new[] { "contactInfo", $"contactInfo_{contactInfo.Id}" });
            return await _contactInfoDal.UpdateAsync(contactInfo);
        }
        public List<ContactLocationDescDto> GetContactDesc()
        {
            List<ContactLocationDescDto> newResult = new List<ContactLocationDescDto>();
            var result= _contactInfoDal.GetContactDesc();
            foreach (var item in result)
            {
                if (item.Name != null)
                {
                    newResult.Add(item);
                }
            }
            return newResult;
        }

        public List<ContactLocationDescDto> GetDirectoryCountToLocation()
        {
            List<ContactLocationDescDto> newResult = new List<ContactLocationDescDto>();
            var result = _contactInfoDal.GetDirectoryCountToLocation();
            foreach (var item in result)
            {
                if (item.Name != null)
                {
                    newResult.Add(item);
                }
            }
            return newResult;
        }
    }
}
