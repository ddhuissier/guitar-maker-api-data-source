using System.ComponentModel.DataAnnotations;

namespace StarterKit.Domain.Models.Data
{
    public partial class Product
    {
        [Key]
        public int Id { get; set; }
        public string Label { get; set; }
    }
}