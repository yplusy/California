using California.WebAPI;
using California.WebAPI.Entities;

namespace API.Blog.Add
{
    public static class Data
    {
        /// <summary>
        /// 添加博客
        /// </summary>
        /// <param name="db"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool PostBlog(CaliforniaContext db, BlogEntity entity)
        {
            entity.BlogId = Guid.NewGuid().ToString();
            //entity.CreateTime = DateTime.Now;
            db.Blog.Add(entity);
            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            var data = db.Blog.Where(b => b.BlogId == entity.BlogId).FirstOrDefault();
            return data != null ? true : false;
        }
    }
}