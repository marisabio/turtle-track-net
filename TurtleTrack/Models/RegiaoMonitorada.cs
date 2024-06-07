using System.ComponentModel.DataAnnotations;

namespace TurtleTrack.Models
{
    public class RegiaoMonitorada
    {
        [Key]
        public long Id { get; set; }
        
        public string Regiao { get; set; }
        public string Praia { get; set; }
        public int QntdNinhos { get; set; }
        public int QntdOvos { get; set; }
        public string Riscos { get; set; }
        public string Especie { get; set; }
    }
}
