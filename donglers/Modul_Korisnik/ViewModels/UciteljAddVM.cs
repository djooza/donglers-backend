using donglers.Data;

namespace donglers.ViewModels;

public class UciteljAddVM
{
    public string ime { get; set; }
    public string prezime { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public DateTime? datum_rodenja { get; set; }
}