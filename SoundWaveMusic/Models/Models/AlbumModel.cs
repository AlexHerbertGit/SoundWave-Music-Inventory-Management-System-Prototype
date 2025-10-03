using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SoundWaveMusic.Models
{
    public class AlbumModel
    {
        [JsonPropertyName("albumId")]
        public int AlbumId { get; set; }

        [Required]
        [StringLength(100)]
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [Required]
        [JsonPropertyName("releaseYear")]
        public DateTime ReleaseYear { get; set; }

        [StringLength(100)]
        [JsonPropertyName("label")]
        public string Label { get; set; }

        [StringLength(500)]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("artistId")]
        public int ArtistId { get; set; }

        [JsonPropertyName("genreId")]
        public int GenreId { get; set; }

        [JsonPropertyName("cdQuantity")]
        public int CDQuantity { get; set; }

        [JsonPropertyName("vinylQuantity")]
        public int VinylQuantity { get; set; }

        [JsonPropertyName("products")]
        public IList<ProductModel> Products { get; set; }

        public AlbumModel()
        {
            Products = new List<ProductModel>();
        }
    }
}
