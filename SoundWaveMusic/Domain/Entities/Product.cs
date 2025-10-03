using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWaveMusic.Domain.Entities
{
    public abstract class Product
    {
        public int ProductId { get; set; }
        public int AlbumId { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public DateTime DateLastModified { get; set; }
        public string? ProductPhotoUrl { get; set; }

        // Navigation Properties
        public Album? Album { get; set; }
        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}
