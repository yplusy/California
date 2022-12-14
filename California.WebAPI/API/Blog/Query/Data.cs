using California.WebAPI.Entities;

namespace API.Blog.Query
{
    public static class Data
    {
        public static Task GetBlog(CaliforniaContext db, BlogEntity entity)
        {
            if (entity.BlogId == null)
            {
                var data = db.Blog.ToList();
                return data;
            }
            else
            {
                var data = db.Blog.Where(b => b.BlogId == entity.BlogId).FirstOrDefault();
                return data;
            }
        }
    }
}