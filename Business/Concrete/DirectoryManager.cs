using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using StackExchange.Redis.Extensions.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DirectoryManager : IDirectoryService
    {
        IDirectoryDal _directoryDal;
        private readonly IRedisClient _redisCache;

        public DirectoryManager(IDirectoryDal directoryDal, IRedisClient redisCache)
        {
            _directoryDal = directoryDal;
            _redisCache = redisCache;
        }

        public async Task<Directory> AddAsync(Directory directory)
        {
            await _redisCache.Db0.RemoveAsync("directory");
            return await _directoryDal.AddAsync(directory);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _redisCache.Db0.RemoveAllAsync(new[] { "directory", $"directory_{id}" });
            return await _directoryDal.DeleteAsync(id);
        }

        public async Task<Directory> GetByIdAsync(int id)
        {
            var cacheKey = $"directory_{id}";
            var cachedData = await _redisCache.Db0.GetAsync<Directory>(cacheKey);
            if (cachedData != null)
                return cachedData;

            var result = await _directoryDal.GetAsync(x => x.DirectoryId == id);
            await _redisCache.Db0.AddAsync(cacheKey, result, TimeSpan.FromMinutes(5));
            return result;
        }

        public async Task<IEnumerable<Directory>> GetListAsync()
        {
            var isCacheable = false;
            string cacheKey = "directory";

            var cachedData = await _redisCache.Db0.GetAsync<IEnumerable<Directory>>(cacheKey);
            if (cachedData != null)
                return cachedData;

            isCacheable = true;

            var result = await _directoryDal.GetListAsync();
            if (isCacheable)
                await _redisCache.Db0.AddAsync(cacheKey, result, TimeSpan.FromMinutes(5));

            return result;
        }

        public async Task<Directory> UpdateAsync(Directory directory)
        {
            await _redisCache.Db0.RemoveAllAsync(new[] { "directory", $"directory_{directory.DirectoryId}" });
            return await _directoryDal.UpdateAsync(directory);
        }
    }
}
