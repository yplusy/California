global using FastEndpoints;
global using FastEndpoints.Security;
using California.WebAPI.Entities;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();
builder.Services.AddDbContext<CaliforniaContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));//注册数据库上下文
builder.Services.AddFastEndpoints();//FastEndpoints框架核心
//builder.Services.AddAuthenticationJWTBearer("TokenSigningKey");//添加jwt认证
builder.Services.AddAuthenticationJWTBearer(builder.Configuration["JwtSigningKey"]);
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
    addJWTBearerAuth: true);//添加swagger,并在swagger上显示输入token的按钮

var app = builder.Build();
app.UseAuthentication();//启用jwt认证
app.UseAuthorization();
app.UseFastEndpoints(c =>
{
    c.Versioning.Prefix = "v";
});//启用FastEndpoints框架核心
app.UseOpenApi(); //启用swagger扫描api
app.UseSwaggerUi3(c => c.ConfigureDefaults()); //默认配置启用swagger的ui
app.Run();
