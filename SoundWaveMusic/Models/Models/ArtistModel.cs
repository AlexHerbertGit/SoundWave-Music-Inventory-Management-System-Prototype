using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SoundWaveMusic.Models
{
    public class ArtistModel
    {
        [JsonPropertyName("artistId")]
        public int ArtistId { get; set; }

        [Required]
        [StringLength(100)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [StringLength(500)]
        [JsonPropertyName("biography")]
        public string Biography { get; set; }

        [JsonPropertyName("genreId")]
        public int GenreId { get; set; }

        [JsonPropertyName("genre")]
        [JsonIgnore]
        public GenreModel? Genre { get; set; }

        [JsonPropertyName("albums")]
        [JsonIgnore]
        public IList<AlbumModel> Albums { get; set; }

        public ArtistModel()
        {
            Albums = new List<AlbumModel>();
        }
    }
}
