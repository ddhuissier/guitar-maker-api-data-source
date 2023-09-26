using System.ComponentModel.DataAnnotations;

namespace StarterKit.Domain.Models.Data
{
    public partial class DataTranslation
    {
        [Key]
        public int Id { get; set; }
        public string Domain { get; set; }
        public string Culture { get; set; }
        public string Tag { get; set; }
        public string Label { get; set; }
        public string Value { get; set; }
        public bool Active { get; set; }
    }
}