using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using donglers.Data;

namespace donglers.Models;

public class Korisnik
{
    [Key]
    public int korisnik_id { get; set; }
    public string ime { get; set; }
    public string prezime { get; set; }
    public string email { get; set; }
    [JsonIgnore]
    public string password { get; set; }
    public bool is_student { get; set; }
    public DateTime? datum_rodenja { get; set; }
    public int score { get; set; }
    public bool prihvacena_pravila { get; set; }
    public Status status { get; set; }
    public DateTime? datum_kreiranja { get; set; }
}