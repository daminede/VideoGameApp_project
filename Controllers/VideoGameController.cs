using Microsoft.AspNetCore.Mvc;
using VideoGameApp.Data;
using VideoGameApp.Models;
using System.Linq;

namespace VideoGameApp.Controllers
{
    public class VideoGamesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VideoGamesController(ApplicationDbContext context)
        {
            _context = context;
        }

       
        public IActionResult Index()
        {
            var games = _context.VideoGame.ToList(); 
            return View(games); 
        }

       
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Create(VideoGame game)
        {
            if (ModelState.IsValid)
            {
                _context.VideoGame.Add(game);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(game);
        }

        
        public IActionResult Edit(int id)
        {
            var game = _context.VideoGame.Find(id);
            if (game == null) return NotFound();
            return View(game);
        }

        
        [HttpPost]
        public IActionResult Edit(int id, VideoGame game)
        {
            if (id != game.Id) return BadRequest("Game ID mismatch.");
            if (ModelState.IsValid)
            {
                _context.Update(game);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(game);
        }

        
        public IActionResult Delete(int id)
        {
            var game = _context.VideoGame.Find(id);
            if (game != null)
            {
                _context.VideoGame.Remove(game);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
