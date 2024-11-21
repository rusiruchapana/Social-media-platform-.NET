using System.ComponentModel.DataAnnotations;

namespace blog_app.Entities;

public class HashTag
{
    [Key]
    public int HashTagId { get; set; }
    
    [Required]
    public string Name { get; set; } = null!;
    
    
    public ICollection<Post> Posts { get; set; } = new List<Post>();
}