using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace donglers.Models;

public class Poruka
{
    [Key]
    public int poruka_id { get; set; }
    [ForeignKey(nameof(posiljaoc))]
    public int posiljaoc_id { get; set; }
    public Korisnik posiljaoc { get; set; }
    [ForeignKey(nameof(primaoc))]
    public int primaoc_id { get; set; }
    public Korisnik primaoc { get; set; }
    public string naslov { get; set; }
    public string sadrzaj { get; set; }
    public bool is_pregledana { get; set; }
    public DateTime? datum_slanja { get; set; }
}