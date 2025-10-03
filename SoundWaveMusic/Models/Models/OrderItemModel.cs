using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SoundWaveMusic.Models
{
    public class OrderItemModel
    {
        [JsonPropertyName("id")]
        public int OrderItemId { get; set; }

        [Required]
        [JsonPropertyName("orderId")]
        public int OrderId { get; set; }

        [Required]
        [JsonPropertyName("productId")]
        public int ProductId { get; set; }

        [Required]
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("product")]
        public ProductModel Product { get; set; }

        [JsonIgnore]
        public string ProductName => Product?.Album?.Title ?? "Unknown";

        [JsonIgnore]
        public decimal ProductPrice => Product?.Price ?? 0;
        [JsonIgnore]
        public decimal LineTotal => ProductPrice * Quantity;
    }
}
