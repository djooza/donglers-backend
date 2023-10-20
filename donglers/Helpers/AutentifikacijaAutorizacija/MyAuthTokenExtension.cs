using System.Text.Json.Serialization;
using donglers.Data;
using donglers.Models;
using Microsoft.EntityFrameworkCore;

namespace donglers.AutentifikacijaAutorizacija;

public static class MyAuthTokenExtension
{
    public class LoginInformacije
    {
        public LoginInformacije(Autentifikacija? autentifikacija)
        {
            this.autentifikacija = autentifikacija;
        }

        [JsonIgnore] public Korisnik? korisnik => autentifikacija?.korisnik;
        public Autentifikacija? autentifikacija { get; set; }
        public bool isLogiran => korisnik != null;

    }

    public static LoginInformacije GetLoginInfo(this HttpContext httpContext)
    {
        var token = httpContext.GetAuthToken();

        return new LoginInformacije(token);
    }

    public static Autentifikacija? GetAuthToken(this HttpContext httpContext)
    {
        string token = httpContext.GetMyAuthToken();
        ApplicationDbContext? db = httpContext.RequestServices.GetService<ApplicationDbContext>();

        Autentifikacija? korisnik = db?.Autentifikacija
            .Include(s => s.korisnik)
            .SingleOrDefault(x => x.vrijednost == token);

        return korisnik;
    }


    public static string GetMyAuthToken(this HttpContext httpContext)
    {
        string token = httpContext.Request.Headers["autentifikacija-token"];
        return token;
    }
}