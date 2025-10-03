using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SoundWaveMusic.Models
{
    public class VinylModel : ProductModel
    {

        [Required]
        [StringLength(20)]
        [JsonPropertyName("vinylSize")]
        public string VinylSize { get; set; }

        [Required]
        [StringLength(20)]
        [JsonPropertyName("vinylSpeed")]
        public string VinylSpeed { get; set; }

        [Required]
        [StringLength(20)]
        [JsonPropertyName("sleeveType")]
        public string SleeveType { get; set; }

    }
}
