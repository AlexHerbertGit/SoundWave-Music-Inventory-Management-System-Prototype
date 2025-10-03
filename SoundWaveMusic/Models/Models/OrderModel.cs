using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SoundWaveMusic.Models
{
    public class OrderModel
    {
        [JsonPropertyName("orderId")]
        public int OrderId { get; set; }

        [Required]
        [StringLength(100)]
        [JsonPropertyName("customerName")]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(20)]
        [JsonPropertyName("customerPhone")]
        public string CustomerPhone { get; set; }

        [Required]
        [StringLength(100)]
        [JsonPropertyName("customerEmail")]
        public string CustomerEmail { get; set; }

        [Required]
        [StringLength(200)]
        [JsonPropertyName("customerAddress")]
        public string CustomerAddress { get; set; }

        [Required]
        [JsonPropertyName("orderDate")]
        public DateTime OrderDate { get; set; }

        [JsonPropertyName("subtotal")]
        public decimal Subtotal { get; set; }

        [JsonPropertyName("shippingCost")]
        public decimal ShippingCost { get; set; }

        [JsonPropertyName("totalCost")]
        public decimal TotalCost { get; set; }

        [JsonIgnore]
        [JsonPropertyName("orderItems")]
        public IList<OrderItemModel> OrderItems { get; set; }

        public OrderModel()
        {
            OrderItems = new List<OrderItemModel>();
        }
    }
}
