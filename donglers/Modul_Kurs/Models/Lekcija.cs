using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using donglers.Data;

namespace donglers.Models;

public class Lekcija
{
    [Key]
    public int lekcija_id { get; set; }
    public string naziv { get; set; }
    public string sadrzaj { get; set; }
    public string postavka { get; set; }
    public string rjesenje { get; set; }
    [NotNull]
    public Tezina tezina { get; set; }
    public DateTime? datum_kreiranja { get; set; }
    [ForeignKey(nameof(kreator))]
    [NotNull]
    public int kreator_id { get; set; }
    public Korisnik kreator { get; set; }
}