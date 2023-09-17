

using System.ComponentModel.DataAnnotations;

namespace StarterKit.Domain.Models.Data
{
   
    public class User
    {
        [Key] 
        public int Id { get; set; }   
        public string Name { get; set; }
    }

}
