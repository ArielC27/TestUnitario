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
	}
}
