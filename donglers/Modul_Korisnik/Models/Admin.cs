using System.ComponentModel.DataAnnotations;

namespace donglers.Models;

public class Admin
{
    [Key]
    public int admin_id { get; set; }
    public string username { get; set; }
    public string password { get; set; }
}