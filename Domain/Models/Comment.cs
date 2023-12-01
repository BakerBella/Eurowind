using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public class Comment
{
    [Key]
    public int Id { get; set; }
    public string Body { get; set; }
   
    [ForeignKey("Post")]
    public int PostId { get; set; }
    public Post Post { get; set; }

    [ForeignKey("User")]
    public string Username { get; set; }
    public User User { get; set; }
}