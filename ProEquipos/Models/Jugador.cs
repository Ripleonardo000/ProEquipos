using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProEquipos.Models
{
    public class Jugador
    {




        [Key]
        
        public int Id { get; set; }
        [MaxLength(100)]
        public string Nombre { get; set; }
        [MaxLength(100)]
        public string Posicion { get; set; }

        [Range(0, 100)]
        public int Edad {  get; set; }









        
        public Equipo? Equipo { get; set; }

        [ForeignKey("Equipo")]
        public int IdEquipo { get; set; }
    }
}
