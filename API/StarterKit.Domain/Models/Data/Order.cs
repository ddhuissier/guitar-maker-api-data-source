
using System.ComponentModel.DataAnnotations;

namespace StarterKit.Domain.Models.Data
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Number { get; set; }
        public ICollection<Product> Products { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus Status { get; set; }

    }
    public enum OrderStatus
    {
        Open,
        Pending,
        Process,
        Delivered,
        Close
    }
}
