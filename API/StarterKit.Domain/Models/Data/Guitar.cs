using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterKit.Domain.Models.Data
{
    public class Guitar
    {
        [Key]
        public int Id { get; set; }
        public string Model { get; set; }

    }
}
