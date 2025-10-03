using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWaveMusic.Entities
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Biography { get; set; }
        public int GenreId { get; set; }

        // Navigation Properties
        public Genre? Genre { get; set; }
        public ICollection<Album>? Albums { get; set; }
    }
}
