global using FastEndpoints;
global using FastEndpoints.Security;
using California.WebAPI.Entities;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();

#region appsettings����
//builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
//builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
#endregion

#region ���ݿ�������
//builder.Services.AddDbContext<CaliforniaContext>(
//    options => options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerConStr")));
builder.Services.AddDbContext<CaliforniaContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQLConStr")));
//builder.Services.AddDbContext<CaliforniaContext>(
//    options => options.UseMySQL(builder.Configuration.GetConnectionString("MySQLConStr")));
#endregion

#region Redis

#endregion

#region FastEndpoints��ܺ���
builder.Services.AddFastEndpoints();
#endregion

#region jwt��֤
builder.Services.AddJWTBearerAuth(builder.Configuration["JwtSigningKey"]);
#endregion

#region ����
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

#region swagger&api�汾
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
    addJWTBearerAuth: true); // ���swagger,����swagger����ʾ����token�İ�ť
#endregion

#region app
var app = builder.Build();
// ����jwt��֤
app.UseAuthentication();
// ���ÿ������
app.UseCors("Cors");
// ��Ȩ
app.UseAuthorization();
// ����FastEndpoints��ܺ���
app.UseFastEndpoints(c =>
{
    c.Versioning.Prefix = "v";
});
// ����swaggerɨ��api
app.UseSwaggerGen();
//app.UseOpenApi();
// Ĭ����������swagger��ui
//app.UseSwaggerUi3(c => c.ConfigureDefaults());
// ʹ�÷ֲ�ʽ����
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