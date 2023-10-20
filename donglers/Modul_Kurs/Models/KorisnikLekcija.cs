using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace donglers.Models;

public class KorisnikLekcija
{
    [Key]
    public int korisnik_lekcija_id { get; set; }
    [ForeignKey(nameof(korisnik))]
    public int korisnik_id { get; set; }
    public Korisnik korisnik { get; set; }
    [ForeignKey(nameof(lekcija))]
    public int lekcija_id { get; set; }
    public Lekcija lekcija { get; set; }
}