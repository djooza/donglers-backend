using donglers.AutentifikacijaAutorizacija;
using donglers.Data;
using donglers.Helpers;
using donglers.Models;
using donglers.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace donglers.Modul_Autentifikacija.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class AutentifikacijaController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public AutentifikacijaController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    [HttpGet]
    public ActionResult<MyAuthTokenExtension.LoginInformacije> TryLogin()
    {
        var autentifikacija = HttpContext.GetAuthToken();

        return new MyAuthTokenExtension.LoginInformacije(autentifikacija);
    }

    [HttpPost]
    public ActionResult<MyAuthTokenExtension.LoginInformacije> Login([FromBody] LoginVM loginVM)
    {
        var korisnik = _dbContext.Korisnik.FirstOrDefault(x => x.email == loginVM.email &&
                                                               x.password == loginVM.password);

        if (korisnik == null)
        {
            return new MyAuthTokenExtension.LoginInformacije(null);
        }

        if (korisnik.status == Status.Neaktivan)
        {
            return BadRequest("Vaš nalog je deaktiviran!");
        }

        var randomString = TokenGenerator.Generate(10);

        var noviToken = new Autentifikacija()
        {
            vrijednost = randomString,
            korisnik = korisnik,
            datum_autentifikcije = DateTime.Now
        };

        _dbContext.Add(noviToken);
        _dbContext.SaveChanges();

        return new MyAuthTokenExtension.LoginInformacije(noviToken);
    }

    [HttpPost]
    public ActionResult Logout()
    {
        Autentifikacija? autentifikacija = HttpContext.GetAuthToken();

        if (autentifikacija == null)
            return Ok();

        _dbContext.Remove(autentifikacija);
        _dbContext.SaveChanges();
        return Ok();
    }
}
