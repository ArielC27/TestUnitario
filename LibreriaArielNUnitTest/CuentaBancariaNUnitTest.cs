using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace LibreriaAriel
{
    [TestFixture]
    public class CuentaBancariaNUnitTest
    {
        private CuentaBancaria cuenta;

        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void Depostio_InputMonto100LoggerFake_ReturnsTrue()
        {
            CuentaBancaria cuentaBancaria = new CuentaBancaria(new LoggerFake()); ;

            var resultado = cuentaBancaria.Deposito(100);
            Assert.That(resultado, Is.True);
            Assert.That(cuentaBancaria.GetBalance, Is.EqualTo(100));
        }

        [Test]
        public void Depostio_InputMonto100Mocking_ReturnsTrue()
        {
            var mocking = new Mock<ILoggerGeneral>();
            CuentaBancaria cuentaBancaria = new CuentaBancaria(mocking.Object);

            var resultado = cuentaBancaria.Deposito(100);
            Assert.That(resultado, Is.True);
            Assert.That(cuentaBancaria.GetBalance, Is.EqualTo(100));
        }

        [Test]
        [TestCase(200, 100)]
        [TestCase(200, 150)]
        public void Retiro_Retiro100ConBalance200_ReturnsTrue(int balance, int retiro)
        {
            var loggerMock = new Mock<ILoggerGeneral>();
            loggerMock.Setup(x => x.LogDataBase(It.IsAny<string>())).Returns(true);
            loggerMock.Setup(x => x.LogBalanceDespuesRetiro(It.Is<int>(x => x > 0))).Returns(true);

            CuentaBancaria cuentaBancaria = new CuentaBancaria(loggerMock.Object);
            cuentaBancaria.Deposito(balance);
            var resultado = cuentaBancaria.Retiro(retiro);

            Assert.That(resultado, Is.True);

        }

        [Test]
        [TestCase(200, 300)]
        public void Retiro_Retiro300ConBalance200_ReturnsFalse(int balance, int retiro)
        {
            var loggerMock = new Mock<ILoggerGeneral>();
            //loggerMock.Setup(x => x.LogBalanceDespuesRetiro(It.Is<int>(x => x < 0))).Returns(false);
            loggerMock.Setup(x => x.LogBalanceDespuesRetiro(It.IsInRange<int>(int.MinValue, -1, Moq.Range.Inclusive))).Returns(false);

            CuentaBancaria cuentaBancaria = new CuentaBancaria(loggerMock.Object);
            cuentaBancaria.Deposito(balance);
            var resultado = cuentaBancaria.Retiro(retiro);

            Assert.That(resultado, Is.False);

        }

        [Test]
        public void CuentaBancariaLoggerGeneral_LogMocking_ReturnTrue()
        {
            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            string textPrueba = "texto de rueba";

            loggerGeneralMock.Setup(x => x.MessageConReturnsStr(It.IsAny<string>())).Returns<string>(str => str.ToLower());
            var resultado = loggerGeneralMock.Object.MessageConReturnsStr("texto de rueba");

            Assert.That(resultado, Is.EqualTo(textPrueba));
        }

        [Test]
        public void CuentaBancariaLoggerGeneral_LogMockingOutput_ReturnTrue()
        {
            var loggerGeneral = new Mock<ILoggerGeneral>();
            var textPrueba = "prueba";
            var parameterOut = "";

            loggerGeneral.Setup(x => x.MessageConParametroOutReturnsBoolean(It.IsAny<string>(), out textPrueba)).Returns(true);
            var resultado = loggerGeneral.Object.MessageConParametroOutReturnsBoolean("rechazo", out parameterOut);

            Assert.That(resultado, Is.True);
        }

        [Test]
        public void CuentaBancariaLoggerGeneral_LogMockingObjetoRef_ReturnTrue()
        {
            var loggerGeneralMock = new Mock<ILoggerGeneral>();

            Cliente cliente = new();
            Cliente clienteNoUtilizado = new();

            loggerGeneralMock.Setup(x => x.MessageConObjetoReferenciaReturnsBoolean(ref cliente)).Returns(true);

            var resultado = loggerGeneralMock.Object.MessageConObjetoReferenciaReturnsBoolean(ref cliente);
            var resultado2 = loggerGeneralMock.Object.MessageConObjetoReferenciaReturnsBoolean(ref clienteNoUtilizado);

            Assert.That(resultado, Is.True);
            Assert.That(resultado2, Is.False);
        }

        [Test]
        public void CuentaBancariaLoggerGeneral_LogMockingPropiedadPrioridadTipo_ReturnsTrue()
        {
            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            loggerGeneralMock.Setup(x => x.PrioridadLogger).Returns(10);
            loggerGeneralMock.Setup(x => x.TipoLogger).Returns("warning");

            Assert.That(loggerGeneralMock.Object.PrioridadLogger, Is.EqualTo(10));
            Assert.That(loggerGeneralMock.Object.TipoLogger, Is.EqualTo("warning"));

            //CAllBACKS
            string textParametro = "Prueba";
            loggerGeneralMock.Setup(x => x.LogDataBase(It.IsAny<string>())).Returns(true).Callback<string>(parametro => textParametro += parametro);
            loggerGeneralMock.Object.LogDataBase("Testing");

            Assert.That(textParametro, Is.EqualTo("PruebaTesting"));
        }

        [Test]
        public void CuentaBancariaLoggerGeneral_VerifyEjemplo()
        {
            var loggerGeneralMock = new Mock<ILoggerGeneral>();

            CuentaBancaria cuentaBancaria = new(loggerGeneralMock.Object);
            cuentaBancaria.Deposito(100);
            Assert.That(cuentaBancaria.GetBalance(), Is.EqualTo(100));

            //Verifica cuantas veces el mock esta llamando a metodo .message
            loggerGeneralMock.Verify(x => x.Message(It.IsAny<string>()), Times.Exactly(3));

            //Verificacion de cuantas veces se ejecuto las properties
            loggerGeneralMock.VerifySet(x => x.PrioridadLogger = 100, Times.Once);
        }
    }
}
