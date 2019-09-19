using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProyectoAnalisis.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Guardar()
        {

            cuenta.CuentaBancariaId = 4;
            cuenta.Fecha = DateTime.Now;
            cuenta.Nombre = "Juan";
            cuenta.Balance = 0;

            paso = repositorio.Guardar(cuenta);
            Assert.AreEqual(true, paso);
        }
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
