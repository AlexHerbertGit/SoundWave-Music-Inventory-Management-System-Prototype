using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWaveMusic.Entities
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }

        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public int Quantity { get; set; }
        public decimal PriceAtTime { get; set; }    //Price at the time of Order.
        public decimal LineTotal => Quantity * PriceAtTime;

        // Navigation Properties
        public Order? Order { get; set; }
        public Product? Product { get; set; }
    }
}
