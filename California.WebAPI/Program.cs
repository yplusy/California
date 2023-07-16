global using FastEndpoints;
global using FastEndpoints.Security;
using California.WebAPI.Entities;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();

#region appsettings访问
//builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
//builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
#endregion

#region 数据库上下文
//builder.Services.AddDbContext<CaliforniaContext>(
//    options => options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerConStr")));
builder.Services.AddDbContext<CaliforniaContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQLConStr")));
//builder.Services.AddDbContext<CaliforniaContext>(
//    options => options.UseMySQL(builder.Configuration.GetConnectionString("MySQLConStr")));
#endregion

#region Redis

#endregion

#region FastEndpoints框架核心
builder.Services.AddFastEndpoints();
#endregion

#region jwt认证
builder.Services.AddJWTBearerAuth(builder.Configuration["JwtSigningKey"]);
#endregion

#region 跨域
builder.Services.AddCors(co =>
{
    co.AddPolicy("Cors", cpb =>
    {
        //cpb.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        cpb.WithOrigins("http://localhost:5173",
                        "http://localhost:5173")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
#endregion

#region swagger&api版本
builder.Services.AddSwaggerDoc(s =>
{
    s.DocumentName = "alpha";
    s.Title = "api";
    s.Version = "v1";
})
    .AddSwaggerDoc(maxEndpointVersion: 1, settings: s =>
    {
        s.DocumentName = "alpha 1";
        s.Title = "api";
        s.Version = "v1";
    })
    .AddSwaggerDoc(maxEndpointVersion: 2, settings: s =>
    {
        s.DocumentName = "alpha 2";
        s.Title = "api";
        s.Version = "v2";
    },
    addJWTBearerAuth: true); // 添加swagger,并在swagger上显示输入token的按钮
#endregion

#region app
var app = builder.Build();
// 启用jwt认证
app.UseAuthentication();
// 配置跨域组件
app.UseCors("Cors");
// 授权
app.UseAuthorization();
// 启用FastEndpoints框架核心
app.UseFastEndpoints(c =>
{
    c.Versioning.Prefix = "v";
});
// 启用swagger扫描api
app.UseSwaggerGen();
//app.UseOpenApi();
// 默认配置启用swagger的ui
//app.UseSwaggerUi3(c => c.ConfigureDefaults());
// 使用分布式缓存
//app.Lifetime.ApplicationStarted.Register(() =>
//{
//    var currentTimeUTC = DateTime.UtcNow.ToString();
//    byte[] encodedCurrentTimeUTC = System.Text.Encoding.UTF8.GetBytes(currentTimeUTC);
//    var options = new DistributedCacheEntryOptions()
//        .SetSlidingExpiration(TimeSpan.FromSeconds(20));
//    app.Services.GetService<IDistributedCache>()
//                              .Set("cachedTimeUTC", encodedCurrentTimeUTC, options);
//});
app.Run();
#endregion