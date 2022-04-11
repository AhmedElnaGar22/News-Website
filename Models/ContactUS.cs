using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreApp.Models
{
    public class ContactUS
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [StringLength(15)]
        public string Name { get; set; }
        [Required]
        public string Message { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
    }
}
