using BackEndDronMedicamento.Enum;
using System.ComponentModel.DataAnnotations;

namespace BackEndDronMedicamento.Entidades
{
    public class Dron
    {
        [Required]
        [StringLength(maximumLength: 100)]
        [Key]
        public string NumeroSerie { get; set; }
        public string Modelo { get; set; }        
        public int PesoLimite { get; set; }
        public int CapacidadBateria { get; set; }
        public string Estado { get; set; }


    }
}
