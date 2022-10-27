using IdeaAppLibrary.DataAccess.impl;

namespace IdeaAppUI;

public static class RegisterServices
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
        builder.Services.AddMemoryCache();

        builder.Services.AddSingleton<IDbConnection, DbConnection>();
        builder.Services.AddTransient<ICategoryData, MongoCategoryData>();
        builder.Services.AddTransient<IStatusData, MongoStatusData>();
        builder.Services.AddTransient<IIdeaData, MongoIdeaData>();
        builder.Services.AddTransient<IUserData, MongoUserData>();
    }
}