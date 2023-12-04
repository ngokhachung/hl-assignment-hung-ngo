using System.ComponentModel.DataAnnotations;

namespace JokeeSingleServing.Models
{
    public class Joke
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Text { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }
    }
}
