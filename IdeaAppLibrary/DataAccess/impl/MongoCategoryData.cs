using Microsoft.Extensions.Caching.Memory;

namespace IdeaAppLibrary.DataAccess.impl;

public class MongoCategoryData : ICategoryData
{
    private readonly IMemoryCache _cache;
    private readonly IMongoCollection<CategoryModel> _categories;
    private const string CacheName = "CategoryData";

    public MongoCategoryData(IDbConnection db, IMemoryCache cache)
    {
        _cache = cache;
        _categories = db.CategoryCollection;
    }

    public async Task<List<CategoryModel>> GetAllCategories()
    {
        var output = _cache.Get<List<CategoryModel>>(CacheName);
        
        if (output is not null)
            return output;
        
        var result = await _categories.FindAsync(_ => true);
        output = result.ToList();
        _cache.Set(CacheName, output, TimeSpan.FromDays(1));

        return output;
    }

    public Task CreateCategory(CategoryModel category)
    {
        return _categories.InsertOneAsync(category);
    }
}