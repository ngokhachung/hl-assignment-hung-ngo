using JokeeSingleServing.Models;
using Microsoft.AspNetCore.Mvc;

namespace JokeeSingleServing.Controllers
{
    public class JokeController : Controller
    {
        private readonly JokeContext _context;

        public JokeController(JokeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var votedJokes = Request.Cookies["votedJokes"]?.Split(',').Select(int.Parse).ToList() ?? new List<int>();

            var joke = _context.Jokes
                .Where(j => !votedJokes.Contains(j.Id))
                .FirstOrDefault();

            if (joke == null)
            {
                return Content("That's all the jokes for today! Come back another day!");
            }

            return View(joke);
        }

        [HttpPost]
        public IActionResult Vote(int id, string voteType)
        {
            var joke = _context.Jokes.Find(id);

            if (joke == null)
            {
                return NotFound();
            }

            var votedJokes = Request.Cookies["votedJokes"]?.Split(',').Select(int.Parse).ToList() ?? new List<int>();

            if (votedJokes.Contains(id))
            {
                return Content("You have already voted for this joke.");
            }

            if (voteType == "like")
            {
                joke.Likes++;
            }
            else if (voteType == "dislike")
            {
                joke.Dislikes++;
            }
            else
            {
                return BadRequest("Invalid vote type.");
            }

            _context.SaveChanges();

            // Add the voted joke to the cookie
            votedJokes.Add(id);
            Response.Cookies.Append("votedJokes", string.Join(',', votedJokes));

            return RedirectToAction("Index");
        }
    }
}
