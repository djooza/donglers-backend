using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace donglers.Models;

public class Kurs
{
    [Key]
    public int kurs_id { get; set; }
    public string naziv { get; set; }
    public string opis { get; set; }
    public List<Level> leveli { get; set; }
    public DateTime? datum_kreiranja { get; set; }
    [ForeignKey(nameof(kreator))]
    [NotNull]
    public int kreator_id { get; set; }
    public Korisnik kreator { get; set; }
}