using BackEndDronMedicamento.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace BackEndDronMedicamento.Tests.PruebasUnitarias
{
    [TestClass]
    public class ExcedePesoPermitidoDronTests
    {
        [TestMethod]
        public void PesoPermitidoDron_DevuelveError()
        {
            //Preparación
            var excedepesodronconmedicamentos = new ExcedePesoPermitidoDronAttribute();
            var valor = 510;
            var valcontext = new ValidationContext(new { Peso = valor });

            //Ejecución
            var resultado = excedepesodronconmedicamentos.GetValidationResult(valor, valcontext);

            //Verificación
            Assert.AreEqual("Se ha sebrepasado el peso máximo del Dron: 500gr", resultado.ErrorMessage);

        }
    }
}