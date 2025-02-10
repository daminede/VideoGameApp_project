using Microsoft.EntityFrameworkCore;
using VideoGameApp.Models;

namespace VideoGameApp.Services
{
    public class VideoGameService  // ✅ Fixed Typo Here
    {
        private readonly ApplicationDbContext _context;

        public VideoGameService(ApplicationDbContext context)  // ✅ Fixed Typo Here
        {
            _context = context;
        }

        public async Task<List<VideoGame>> GetAllGamesAsync()
        {
            return await _context.VideoGame.ToListAsync();
        }

        public async Task<VideoGame> GetVideoGameByIdAsync(int id)
        {
            return await _context.VideoGame.FirstOrDefaultAsync(vg => vg.Id == id);
        }

        public async Task AddVideoGameAsync(VideoGame videoGame)
        {
            if (videoGame == null)
            {
                throw new ArgumentNullException(nameof(videoGame));
            }

            if (await _context.VideoGame.AnyAsync(vg => vg.Title.Equals(videoGame.Title, StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException("A video game with the same title already exists.");
            }

            _context.VideoGame.Add(videoGame);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateVideoGameAsync(VideoGame videoGame)
        {
            if (videoGame == null)
            {
                throw new ArgumentNullException(nameof(videoGame));
            }

            var existingVideoGame = await _context.VideoGame.FirstOrDefaultAsync(vg => vg.Id == videoGame.Id);
            if (existingVideoGame != null)
            {
                existingVideoGame.Title = videoGame.Title;
                existingVideoGame.Developer = videoGame.Developer;
                existingVideoGame.Genre = videoGame.Genre;
                existingVideoGame.ReleaseDate = videoGame.ReleaseDate;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteVideoGameAsync(int id)
        {
            var videoGame = await _context.VideoGame.FirstOrDefaultAsync(vg => vg.Id == id);
            if (videoGame != null)
            {
                _context.VideoGame.Remove(videoGame);
                await _context.SaveChangesAsync();
            }
        }
    }
}
