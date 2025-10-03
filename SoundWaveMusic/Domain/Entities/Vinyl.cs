using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWaveMusic.Domain.Entities
{
    public class Vinyl : Product
    {
        public int VinylId { get; set; }
        public string? VinylSize { get; set; }
        public string? VinylSpeed { get; set; }
        public string? SleeveType { get; set; }
    }
}
