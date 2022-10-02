using System.ComponentModel.DataAnnotations;

namespace BackEndDronMedicamento.Entidades
{
    public class DronMedicamento
    {        
        public string CodigoMedicamento { get; set; }
        [Key]
        public string CodigoDron { get; set; }
    }
}
