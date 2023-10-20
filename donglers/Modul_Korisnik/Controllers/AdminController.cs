using donglers.Data;
using donglers.Helpers;
using donglers.Models;
using donglers.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace donglers.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class AdminController : Controller
{
    private readonly ApplicationDbContext _dbContext;

    public AdminController(ApplicationDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    [HttpGet]
    public ActionResult<bool> AdminLogin([FromHeader] string username, [FromHeader] string password)
    {
        if (_dbContext.Admin.Any(x => x.password == password && x.username == username))
        {
            return Ok(true);
        }

        return false;
    }

    [HttpPost]
    public ActionResult<Admin> AddAdmin([FromBody] AdminVM admin)
    {
        if (_dbContext.Admin.Any(x => x.username == admin.username))
        {
            return BadRequest("Admin sa ovim username postoji!");
        }

        var newAdmin = new Admin()
        {
            username = admin.username,
            password = admin.password
        };

        if (string.IsNullOrEmpty(newAdmin.password) || string.IsNullOrEmpty(newAdmin.username))
        {
            return BadRequest("username ili password ne smiju biti prazni!");
        }

        _dbContext.Admin.Add(newAdmin);
        _dbContext.SaveChanges();

        return Ok(newAdmin);
    }

    [HttpPost]
    public ActionResult<Korisnik> DodajUcitelja([FromBody] UciteljAddVM noviUcitelj)
    {
        var newUcitelj = new Korisnik()
        {
            ime = noviUcitelj.ime,
            prezime = noviUcitelj.prezime,
            email = noviUcitelj.email,
            password = noviUcitelj.password,
            is_student = false,
            datum_rodenja = noviUcitelj.datum_rodenja,
            score = 0,
            prihvacena_pravila = true,
            status = Status.Aktivan,
            datum_kreiranja = DateTime.Now
        };
            
        if (!EmailValidator.ValidateEmail(newUcitelj.email))
        {
            return BadRequest("Unesite ispravan email!");
        }

        if (string.IsNullOrEmpty(newUcitelj.email) ||
            string.IsNullOrEmpty(newUcitelj.ime) ||
            string.IsNullOrEmpty(newUcitelj.prezime))
        {
            return BadRequest("Unesite sva polja!");
        }

        if (_dbContext.Korisnik.Any(x => x.email == newUcitelj.email))
        {
            return BadRequest("Korisnik sa ovom mail adresom već postoji!");
        }
        
        if (newUcitelj.password.Length < 8)
        {
            return BadRequest("Lozinka ne smije biti kraća od 8 karaktera!");
        }

        _dbContext.Korisnik.Add(newUcitelj);
        _dbContext.SaveChanges();

        return Ok(newUcitelj);
    }

    [HttpGet]
    public ActionResult<IEnumerable<Korisnik>> GetAllUcitelji()
    {
        var listKorisnika = _dbContext.Korisnik.Where(x => x.is_student == false);

        return Ok(listKorisnika);
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<Korisnik>> GetAllUcenici()
    {
        var listKorisnika = _dbContext.Korisnik.Where(x => x.is_student);

        return Ok(listKorisnika);
    }

    [HttpPut]
    public ActionResult<Korisnik> DisableKorisnik([FromHeader] int korisnik_id)
    {
        var korisnik = _dbContext.Korisnik.FirstOrDefault(x => x.korisnik_id == korisnik_id);

        if (korisnik == null)
            return BadRequest("Korisnik ne postoji!");

        korisnik.status = Status.Neaktivan;

        _dbContext.Korisnik.Update(korisnik);
        _dbContext.SaveChanges();

        return Ok(korisnik);
    }
    
    [HttpPut]
    public ActionResult<Korisnik> ActivateKorisnik([FromHeader] int korisnik_id)
    {
        var korisnik = _dbContext.Korisnik.FirstOrDefault(x => x.korisnik_id == korisnik_id);

        if (korisnik == null)
            return BadRequest("Korisnik ne postoji!");

        korisnik.status = Status.Aktivan;

        _dbContext.Korisnik.Update(korisnik);
        _dbContext.SaveChanges();

        return Ok(korisnik);
    }

}