using FindADev.ASP.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindADev.ASP.Helper
{
    public static class HTMLImageReader
    {
        public static string ReadFromUser(UserModel user)
        {
            return $"data: {user.Profile.ImageMimeType};base64, {Convert.ToBase64String(user.Profile.Image)}";
        }

        public static UserModel GetUser(this ISession session)
        {
            return session.GetObject<UserModel>("user");
        }
    }
}
