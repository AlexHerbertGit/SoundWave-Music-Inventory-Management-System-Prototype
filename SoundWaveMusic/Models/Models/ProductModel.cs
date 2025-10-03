using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SoundWaveMusic.Models
{
    public class ProductModel
    {
        [JsonPropertyName("productId")]
        public int ProductId { get; set; }

        [Required]
        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [Required]
        [JsonPropertyName("stockQuantity")]
        public int StockQuantity { get; set; }

        [JsonPropertyName("dateLastModified")]
        public DateTime DateLastModified { get; set; }

        [Required]
        [StringLength(100)]
        [JsonPropertyName("productType")]
        public string ProductType { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public AlbumModel? Album { get; set; }

        [Required]
        [JsonPropertyName("albumId")]
        public int AlbumId { get; set; }

    }
}
