using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public class Post
{
    [Key]
    public int Id { get; set; }
    public User Owner { get; private set; }
    [ForeignKey("Owner")]
    public string OwnerUsername { get; set; }
    public string Title { get; private set; }
    public string Body { get; set; }

    public Post(string ownerUsername, string title, string body)
    {
        OwnerUsername = ownerUsername;
        Title = title;
        Body = body;
    }

    private Post()
    {
        //Empty
    }

    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}