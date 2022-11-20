using California.WebAPI.Entities;
using Newtonsoft.Json.Linq;

namespace California.WebAPI.API.User.Login
{
    /// <summary>
    /// 请求体
    /// </summary>
    public class Request : UserInfoEntity
    {

    }
    /// <summary>
    /// 请求体验证
    /// </summary>
    public class Validator : Validator<Request>
    {
        public Validator()
        {

        }
    }
    /// <summary>
    /// 响应
    /// </summary>
    public class Response : UserInfoEntity
    {
        public string UserName { get; set; }
        public IEnumerable<string> UserPermissions { get; set; }
        public string TokenValue { get; set; }
        public DateTime TokenExpiryDate { get; set; }

        public string Message = "This endpoint hasn't been implemented yet!";
    }
}