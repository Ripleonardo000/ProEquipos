using System.ComponentModel.DataAnnotations;

namespace ProEquipos.Models
{
    public class Equipo
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        [MaxLength(255)]
        public string Ciudad { get; set; }

        [Range(0, 255)]
        public string Titulos { get; set; }

        public Boolean AceptaExtranjeros {  get; set; }

        
    }
}
