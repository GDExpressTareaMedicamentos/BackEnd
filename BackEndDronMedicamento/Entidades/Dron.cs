using BackEndDronMedicamento.Enum;
using System.ComponentModel.DataAnnotations;

namespace BackEndDronMedicamento.Entidades
{
    public class Dron
    {
        [Key]
        public string NumeroSerie { get; set; }
        public string Modelo { get; set; }
        [Required]
        public int PesoLimite { get; set; }
        [Required]
        public int CapacidadBateria { get; set; }
        [Required]
        public string Estado { get; set; }


    }
}
