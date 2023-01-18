using Microsoft.EntityFrameworkCore.Storage;

namespace API.RedisDemo
{
    public class Endpoint : Endpoint<Request, Response>
    {
        public override void Configure()
        {
            Post("/api/redis");
            AllowAnonymous(); // 允许匿名访问
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            //var value = distributedCache.Get("name-key");
            //string valStr = string.Empty;
            //if (value == null)
            //{
            //    valStr = "孙悟空三打白骨精！";
            //    // 存储的数据必须为字节，所以需要转换一下
            //    var encoded = Encoding.UTF8.GetBytes(valStr);
            //    // 配置类：30秒过时
            //    var options = new DistributedCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(30));
            //    distributedCache.Set("name-key", encoded, options);
            //}
            //else
            //{
            //    valStr = Encoding.UTF8.GetString(value);
            //}
            //Response.Message = valStr;

            //Response.Message = "error";
            await SendAsync(Response);
        }
    }
}