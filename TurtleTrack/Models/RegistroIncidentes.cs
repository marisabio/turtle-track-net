using System.ComponentModel.DataAnnotations;

namespace TurtleTrack.Models
{
    public class RegistroIncidentes
    {
        [Key]
        public long Id { get; set; }
        
        public DateTime Data { get; set; }
        public string Especie { get; set; }
        public string Descricao { get; set; }
        public string UsuarioLogin { get; set; }
        public int RegiaoMonitoradaId { get; set; }
    }
}
