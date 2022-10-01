using System.ComponentModel.DataAnnotations;

namespace BackEndDronMedicamento.Entidades
{
    public class Medicamento
    {
        public int ID { get; set; }
        // (permitido solo letras, números, ‘-‘, ‘_’);
        [RegularExpression(@"/^[A-Za-z0-9_-]+$/",
             ErrorMessage = "permitido solo letras, números, ‘-‘, ‘_’")]
        public string Nombre { get; set; }
        public int Peso { get; set; }
        public string Codigo { get; set; }
        public string Imagen { get; set; }
    }
}
