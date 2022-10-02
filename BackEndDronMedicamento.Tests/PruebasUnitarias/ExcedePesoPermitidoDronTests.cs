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
            //Preparaci�n
            var excedepesodronconmedicamentos = new ExcedePesoPermitidoDronAttribute();
            var valor = 510;
            var valcontext = new ValidationContext(new { Peso = valor });

            //Ejecuci�n
            var resultado = excedepesodronconmedicamentos.GetValidationResult(valor, valcontext);

            //Verificaci�n
            Assert.AreEqual("Se ha sebrepasado el peso m�ximo del Dron: 500gr", resultado.ErrorMessage);

        }
    }
}