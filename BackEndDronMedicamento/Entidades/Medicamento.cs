using System.ComponentModel.DataAnnotations;

namespace BackEndDronMedicamento.Entidades
{
    public class Medicamento
    {
        // (permitido solo letras, números, ‘-‘, ‘_’);
        [RegularExpression(@"/^[A-Za-z0-9_-]+$/", ErrorMessage = "permitido solo letras, números, ‘-‘, ‘_’")]
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int Peso { get; set; }
        [Key]
        public string Codigo { get; set; }
        public string Imagen { get; set; }
    }
}
