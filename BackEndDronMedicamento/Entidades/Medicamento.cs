using System.ComponentModel.DataAnnotations;

namespace BackEndDronMedicamento.Entidades
{
    public class Medicamento
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int Peso { get; set; }
        [Key]
        public string Codigo { get; set; }
        public string Imagen { get; set; }
    }
}
