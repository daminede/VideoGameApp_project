using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VideoGameApp.Models  // ✅ Ensure this matches your project name
{
    public class Developer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        // ✅ Navigation Property
        public List<VideoGame> VideoGame { get; set; } = new();
    }
}
