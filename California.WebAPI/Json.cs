using System.Text.Json;

namespace California.WebAPI
{
    public static class Json
    {
        public static object ToJson(this string Json)
        {
            return Json == null ? null : JsonSerializer.Serialize(Json);
        }
        public static string ToJson(this object obj)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            return JsonSerializer.Serialize(obj, options);
        }
    }
}
