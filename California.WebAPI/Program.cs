global using FastEndpoints;
global using FastEndpoints.Security;
using California.WebAPI.Entities;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();
builder.Services.AddDbContext<CaliforniaContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));//ע�����ݿ�������
builder.Services.AddFastEndpoints();//FastEndpoints��ܺ���
//builder.Services.AddAuthenticationJWTBearer("TokenSigningKey");//���jwt��֤
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
    addJWTBearerAuth: true);//���swagger,����swagger����ʾ����token�İ�ť

var app = builder.Build();
app.UseAuthentication();//����jwt��֤
app.UseAuthorization();
app.UseFastEndpoints(c =>
{
    c.Versioning.Prefix = "v";
});//����FastEndpoints��ܺ���
app.UseOpenApi(); //����swaggerɨ��api
app.UseSwaggerUi3(c => c.ConfigureDefaults()); //Ĭ����������swagger��ui
app.Run();
