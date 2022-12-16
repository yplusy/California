using California.WebAPI.Entities;

namespace API.Test
{
    public static class Data
    {
        internal static async Task<List<BlogEntity>> GetPendingArticles(CaliforniaContext db)
        {
            var data = db.Blog.ToList();
            return data;
        }
    }
}