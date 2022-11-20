using California.WebAPI.Entities;
using System.Security.Claims;

namespace California.WebAPI.API.User.Login
{
    /// <summary>
    /// 终端
    /// </summary>
    public class Endpoint : Endpoint<Request, Response, Mapper>
    {
        public readonly CaliforniaContext _dbContext;
        public Endpoint(CaliforniaContext context)
        {
            _dbContext = context;
        }
        /// <summary>
        /// API配置
        /// </summary>
        public override void Configure()
        {
            Version(1);//版本
            Post("/user/login");//路由
            AllowAnonymous();//允许匿名访问
        }
        /// <summary>
        /// API入口
        /// </summary>
        /// <param name="r"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            var entity = await Map.ToEntityAsync(r);
            //entity.UserId = Guid.NewGuid().ToString();
            //_dbContext.User.Add(entity);
            //await _dbContext.SaveChangesAsync();
            var data = _dbContext.User.Where(p => p.UserName == entity.UserName && p.Pwd == entity.Pwd).FirstOrDefault();
            Response.TokenExpiryDate = DateTime.UtcNow.AddHours(4);
            Response.TokenValue = JWTBearer.CreateToken(
                signingKey: Config["JwtSigningKey"],
                expireAt: DateTime.UtcNow.AddHours(1),
                claims: new[] { ("UserName", entity.UserName), ("UserId", entity.UserId) },
                roles: null,
                permissions: null);
            Response.Message = entity.UserName;
            await SendAsync(Response);
        }
    }
}