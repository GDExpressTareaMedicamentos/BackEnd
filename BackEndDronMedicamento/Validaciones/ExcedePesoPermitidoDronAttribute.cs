using System.ComponentModel.DataAnnotations;

namespace BackEndDronMedicamento.Validaciones
{
    public class ExcedePesoPermitidoDronAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return new ValidationResult("Valor inválido..");

            int peso;
            if (!int.TryParse(value.ToString(), out peso))
                return new ValidationResult("Valor debe ser un numero..");

            if (peso <= 500)
                return ValidationResult.Success;
            else
                return new ValidationResult("Se ha sebrepasado el peso máximo del Dron: 500gr");

        }
    }
}
