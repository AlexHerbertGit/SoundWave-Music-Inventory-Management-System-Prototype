using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWaveMusic.Entities
{
    public class Order
    {
        public int OrderId { get; set; }

        // Customer Details
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerPhone {  get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public string CustomerAddress {  get; set; } = string.Empty;

        //Order Cost and Shipping Cost
        public decimal Subtotal { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal TotalCost { get; set; }

        //Order Date and Time
        public DateTime OrderDateTime { get; set; }

        //Navigation Properties
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        //Calculate Order Total Method
        public void CalculateOrderTotal()
        {
            Subtotal = OrderItems.Sum(i => i.LineTotal);
            TotalCost = Subtotal + ShippingCost;
        }
    }
}
