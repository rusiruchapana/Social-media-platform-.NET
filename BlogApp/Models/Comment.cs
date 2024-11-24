using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApp.Models;

public class Comment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    public string Text { get; set; }
    
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    [Required]
    [ForeignKey(nameof(Post))]
    public int PostId { get; set; }
    
    
    public Post Post { get; set; }
}