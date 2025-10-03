using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SoundWaveMusic.Models
{
    public class GenreModel
    {
        [JsonPropertyName("genreId")]
        public int GenreId { get; set; }

        [Required]
        [StringLength(50)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [StringLength(50)]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("artists")]
        public IList<ArtistModel> Artists { get; set; }

        [JsonPropertyName("albums")]
        public IList<AlbumModel> Albums { get; set; }

        public GenreModel()
        {
            Artists = new List<ArtistModel>();
            Albums = new List<AlbumModel>();
        }
    }
}
