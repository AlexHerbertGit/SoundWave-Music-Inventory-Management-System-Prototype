using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SoundWaveMusic.Models
{
    public class CDModel : ProductModel
    {

        [Required]
        [StringLength(50)]
        [JsonPropertyName("caseType")]
        public string CaseType { get; set; }

        [Required]
        [StringLength(100)]
        [JsonPropertyName("manufacturer")]
        public string Manufacturer { get; set; }

    }
}
