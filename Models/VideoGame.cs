using System.ComponentModel.DataAnnotations.Schema;

namespace VideoGameApp.Models  // ✅ Ensure this matches your project name
{
    public class VideoGame
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;


        [Column(TypeName = "decimal(18,2)")] 
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public int DeveloperId { get; set; }
        public Developer Developer { get; set; } = default!;
    }
}
