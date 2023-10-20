using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using donglers.Data;

namespace donglers.Models;

public class Level
{
    [Key]
    public int level_id { get; set; }
    [NotNull]
    public Stepen stepen { get; set; }
    public string opis { get; set; }
    public List<Lekcija> lekcije { get; set; }
    public DateTime? datum_kreiranja { get; set; }
    [ForeignKey(nameof(kreator))]
    [NotNull]
    public int kreator_id { get; set; }
    public Korisnik kreator { get; set; }
}