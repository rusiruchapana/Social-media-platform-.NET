using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApp.Models;

public class RevokedToken
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id {get; set; }
    public string Token { get; set; }
    public DateTime RevokedAt { get; set; }
    public DateTime ExpiresAt { get; set; }
}