using donglers.AutentifikacijaAutorizacija;
using donglers.Data;
using donglers.Helpers;
using donglers.Models;
using donglers.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace donglers.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class KorisnikController : Controller
{
    private readonly ApplicationDbContext _dbContext;

    public KorisnikController(ApplicationDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    [HttpPost]
    public ActionResult<Korisnik> Registruj([FromBody] RegistracijaDto korisnik)
    {
        var newKorisnik = new Korisnik()
        {
            ime = korisnik.ime,
            prezime = korisnik.prezime,
            email = korisnik.email,
            password = korisnik.password,
            is_student = true,
            datum_rodenja = korisnik.datum_rodenja,
            score = 0,
            prihvacena_pravila = korisnik.prihvacena_pravila,
            status = Status.Aktivan,
            datum_kreiranja = DateTime.Now
        };

        if (!EmailValidator.ValidateEmail(newKorisnik.email))
        {
            return BadRequest("Unesite ispravan email!");
        }

        if (string.IsNullOrEmpty(newKorisnik.email) ||
            string.IsNullOrEmpty(newKorisnik.ime) ||
            string.IsNullOrEmpty(newKorisnik.prezime))
        {
            return BadRequest("Unesite sva polja!");
        }

        if (!newKorisnik.prihvacena_pravila)
        {
            return BadRequest("Prihvatite pravila zajednice!");
        }

        if (_dbContext.Korisnik.Any(x => x.email == newKorisnik.email))
        {
            return BadRequest("Korisnik sa ovom mail adresom već postoji!");
        }
        
        if (newKorisnik.password.Length < 8)
        {
            return BadRequest("Lozinka ne smije biti kraća od 8 karaktera!");
        }
        
        _dbContext.Korisnik.Add(newKorisnik);
        _dbContext.SaveChanges();

        return Ok(newKorisnik);
    }

    [HttpPut]
    public ActionResult<Korisnik> UpdateProfile([FromBody] UpdateProfileVM editProfile)
    {
        var autentifikacija = HttpContext.GetAuthToken();

        if (autentifikacija == null)
            return BadRequest("Korisnik nije logiran!");

        var logiraniKorisnik = _dbContext.Korisnik.Find(autentifikacija.korisnik_id);

        if (editProfile.password.Length < 8)
            return BadRequest("Password ne smije biti kraći od 8 karaktera!");

        if (string.IsNullOrEmpty(editProfile.ime) ||
            string.IsNullOrEmpty(editProfile.prezime))
            return BadRequest("Ime i prezime ne mogu biti prazni!");

        logiraniKorisnik.ime = editProfile.ime;
        logiraniKorisnik.prezime = editProfile.prezime;
        logiraniKorisnik.password = editProfile.password;
        logiraniKorisnik.datum_rodenja = editProfile.datum_rodenja;

        _dbContext.Korisnik.Update(logiraniKorisnik);
        _dbContext.SaveChanges();
            
        return Ok(logiraniKorisnik);
    }
    

}