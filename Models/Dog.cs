using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Dog
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public bool Fena { get; set; }
        [Required]
        public string Rasa { get; set; }
        [Required]
        public string Jmeno { get; set; }
        public int Vek { get; set; }
        [ForeignKey("MajitelId")]
        public IdentityUser Majitel { get; set; }
        [Required]
        public string MajitelId { get; set; }
    }
}
