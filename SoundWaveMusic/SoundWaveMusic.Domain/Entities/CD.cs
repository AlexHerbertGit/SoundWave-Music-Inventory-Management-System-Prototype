using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWaveMusic.Domain.Entities
{
    public class CD : Product
    {
        public int CDId { get; set; }
        public string? CaseType { get; set; }
        public string? Manufacturer { get; set; }
    }
}
