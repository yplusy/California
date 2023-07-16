using California.WebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Blog.Query
{
    public static class Data
    {
        public static async Task<List<BlogEntity>> GetBlog(CaliforniaContext db, BlogEntity entity)
        {
            if (entity.BlogId == null)
            {
                var data = db.Blog.ToListAsync();
                return await data;
            }
            else
            {
                var data = db.Blog.Where(b => b.BlogId == entity.BlogId).ToListAsync();
                return await data;
            }
        }
    }
}