using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace blog_app.Entities;

public class HashTag
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int HashTagId { get; set; }
    
    [Required]
    public string Name { get; set; } = null!;
    
    
    public ICollection<Post> Posts { get; set; } = new List<Post>();
}