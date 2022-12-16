using California.WebAPI;
using California.WebAPI.Entities;

namespace API.Example
{
    public class Mapper : Mapper<Request, Response, ExampleEntity>
    {
        public async Task<List<ExampleEntity>> ToEntitiesAsync(List<Request> rs)
        {
            List<ExampleEntity> es = new();
            try
            {
                foreach (var item in rs)
                {
                    ExampleEntity e = new();
                    e.UserName = item.UserName;
                    e.PasswordHash = item.PasswordHash;
                    es.Add(e);
                }
                return es;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<Response>> ToResponsesAsync(List<ExampleEntity> es)
        {
            List<Response> rs = new();
            try
            {
                foreach (var item in es)
                {
                    Response r = new();
                    r.UserName = item.UserName;
                    r.UserPermissions = null;
                    r.TokenValue = JWTBearer.CreateToken(
                        signingKey: AppSettings.Configuration.GetSection("JwtSigningKey").Value,// Config["JwtSigningKey"], // 密钥
                        expireAt: DateTime.Now.AddDays(1), // 过期时间
                        claims: new[] { ("Username", r.UserName), ("UserID", "001") }, // 声称
                        roles: new[] { "Admin", "Management" }, // 角色
                        permissions: new[] { "ManageInventory", "ManageUsers" } // 权限
                    );
                    r.TokenExpiryDate = DateTime.Now.AddDays(1);
                    rs.Add(r);
                }
                return rs;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}