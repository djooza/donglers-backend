using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace donglers.Models;

public class Autentifikacija
{
    [Key]
    public int autentifikacija_id { get; set; }
    [ForeignKey(nameof(korisnik))]
    public int korisnik_id { get; set; }
    public Korisnik korisnik { get; set; }
    public string vrijednost { get; set; }
    public DateTime datum_autentifikcije { get; set; }
}