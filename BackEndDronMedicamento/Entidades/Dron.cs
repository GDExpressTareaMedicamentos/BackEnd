using BackEndDronMedicamento.Enum;
using System.ComponentModel.DataAnnotations;

namespace BackEndDronMedicamento.Entidades
{
    public class Dron
    {
        public int ID { get; set; }
        [Required]
        [StringLength(maximumLength: 100)]
        public string NumeroSerie { get; set; }
        public Modelos Modelo { get; set; }        
        public int PesoLimite { get; set; }
        public int CapacidadBateria { get; set; }
        public Estados Estado { get; set; }


    }
}
