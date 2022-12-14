using California.WebAPI.Entities;
using Microsoft.Extensions.Configuration.Json;

namespace California.WebAPI
{
    public class AppSettings
    {
        public static IConfiguration Configuration = new ConfigurationBuilder().Add(
            new JsonConfigurationSource
            {
                Path = "appsettings.json",
                ReloadOnChange = true
            }
            ).Build();

        //public static CaliforniaContext _context = new CaliforniaContext()

        public readonly CaliforniaContext _context;
        public AppSettings(CaliforniaContext context)
        {
            _context = context;
        }
    }
}
