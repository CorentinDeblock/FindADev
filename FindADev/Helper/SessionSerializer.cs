using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace FindADev.ASP.Helper
{
    public static class SessionSerializer
    {
        public static void SetObject<T>(this ISession session, string key,T value)
        {
            session.SetString(key,JsonConvert.SerializeObject(value));
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            return JsonConvert.DeserializeObject<T>(session.GetString(key));
        }

        public static bool Has(this ISession session,string key)
        {
            return session.GetString(key) != null;
        }
    }
}
