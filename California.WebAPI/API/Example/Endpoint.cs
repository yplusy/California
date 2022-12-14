namespace API.Example
{
    /// <summary>
    /// 终端
    /// </summary>
    public class Endpoint : Endpoint<Request, Response, Mapper>
    {
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
        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            if (true)
            {
                var jwtToken = JWTBearer.CreateToken(
                    signingKey: Config["JwtSigningKey"], //密钥
                    expireAt: DateTime.UtcNow.AddDays(1), //过期时间
                    claims: new[] { ("Username", r.UserName), ("UserID", "001") }, //声称
                    roles: new[] { "Admin", "Management" }, //角色
                    permissions: new[] { "ManageInventory", "ManageUsers" } //权限
                    );
                Response.UserName = r.UserName;
                Response.UserPermissions = null;
                Response.TokenValue = jwtToken;
                Response.TokenExpiryDate = DateTime.UtcNow.AddDays(1);
                await SendAsync(Response);
            }
            else
            {
                ThrowError("提供的凭据无效！");
            }
        }
    }
}