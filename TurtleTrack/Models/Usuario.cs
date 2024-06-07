using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TurtleTrack.Models
{
    public class Usuario
    {
        [Key]
        public String Login { get; set; }
        
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
