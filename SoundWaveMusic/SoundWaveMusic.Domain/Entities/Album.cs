using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWaveMusic.Domain.Entities
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string Title { get; set; } = string.Empty;
        public int ReleaseYear { get; set; }
        public string? Label { get; set; }
        public string? Description { get; set; }

        public int ArtistId { get; set; }
        public int GenreId { get; set; }

        // Navigation Properties
        public Artist? Artist { get; set; }
        public Genre? Genre { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
