using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.ViewModels
{
    public class DogIM
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
    }
}
