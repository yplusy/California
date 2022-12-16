using California.WebAPI.Entities;

namespace API.Example
{
    /// <summary>
    /// 终端
    /// </summary>
    public class Endpoint : Endpoint<List<Request>, List<Response>, Mapper>
    {
        public readonly CaliforniaContext _context;
        public Endpoint(CaliforniaContext context)
        {
            _context = context;
        }

        /// <summary>
        /// API配置
        /// </summary>
        public override void Configure()
        {
            //Version(1); // 版本
            Post("/api/example");
            AllowAnonymous(); // 允许匿名访问
            // 权限限制
            //Claims("AdminID", "EmployeeID");
            //Roles("Admin", "Manager");
            //Permissions("UpdateUsersPermission", "DeleteUsersPermission");
        }

        /// <summary>
        /// API入口
        /// </summary>
        /// <param name="r">请求体</param>
        /// <param name="c"></param>
        /// <returns></returns>
        public override async Task HandleAsync(List<Request> rs, CancellationToken c)
        {
            var entities = await Map.ToEntitiesAsync(rs);
            var data = await Data.PostExample(_context, entities);

            Response = await Map.ToResponsesAsync(data);
            //    ThrowError("提供的凭据无效！");
        }
    }
}