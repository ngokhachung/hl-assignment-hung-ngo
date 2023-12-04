using JokeeSingleServing.Models;

namespace JokeeSingleServing.DbConfig
{
    public class DbInitializer
    {
        public static void Initialize(JokeContext context)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            context.Database.EnsureCreated();

            if (context.Jokes.Any())
            {
                return;   // DB has been seeded
            }

            context.Jokes.AddRange(
                new Joke { Text = "Why did the chicken cross the road?", Likes = 0, Dislikes = 0 },
                new Joke { Text = "What do you get when you cross a snowman and a vampire?", Likes = 0, Dislikes = 0 }
                // Add more jokes as needed
            );

            context.SaveChanges();
        }
    }
}
