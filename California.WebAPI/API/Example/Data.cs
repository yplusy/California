using California.WebAPI.Entities;

namespace API.Example
{
    public static class Data
    {
        internal static async Task<List<ExampleEntity>> PostExample(CaliforniaContext db, List<ExampleEntity> entities)
        {
            #region 添加
            foreach (var item in entities)
            {
                item.UserId = Guid.NewGuid().ToString();
                db.Example.Add(item);
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            #endregion

            #region 查询
            var data = db.Example.ToList();
            return data;
            #endregion
        }
    }
}