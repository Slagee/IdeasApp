using Microsoft.Extensions.Caching.Memory;

namespace IdeaAppLibrary.DataAccess.impl;

public class MongoStatusData : IStatusData
{
    private readonly IMemoryCache _cache;
    private readonly IMongoCollection<StatusModel> _statuses;
    private const string CacheName = "StatusData";

    public MongoStatusData(IDbConnection db, IMemoryCache cache)
    {
        _cache = cache;
        _statuses = db.StatusCollection;
    }

    public async Task<List<StatusModel>> GetAllStatuses()
    {
        var output = _cache.Get<List<StatusModel>>(CacheName);
        if (output is not null)
            return output;

        var result = await _statuses.FindAsync(_ => true);
        output = result.ToList();
        _cache.Set(CacheName, output, TimeSpan.FromDays(1));
        
        return output;
    }

    public Task CreateStatus(StatusModel status)
    {
        return _statuses.InsertOneAsync(status);
    }
}