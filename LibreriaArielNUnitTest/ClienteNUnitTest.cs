using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LibreriaAriel
{
	[TestFixture]
	public class ClienteNUnitTest
	{
		private Cliente cliente;

		[SetUp]
		public void SetUp()
		{
			cliente = new Cliente();
		}

		[Test]
		public void CrearNombreColeto_InputNombreApellido_ReturnNombreCompleto()
		{
			//string nombreCompleto = cliente.CrearNombreColeto("Ariel", "Gutierrez");
			cliente.CrearNombreColeto("Ariel", "Gutierrez");

			Assert.Multiple(() =>
			{
				Assert.That(cliente.ClienteNombre, Is.EqualTo("Ariel Gutierrez"));
				Assert.That(cliente.ClienteNombre, Does.Contain("gutierrez").IgnoreCase);
				Assert.That(cliente.ClienteNombre, Does.StartWith("Ariel"));
				Assert.That(cliente.ClienteNombre, Does.EndWith("Gutierrez"));
			});
		}

		[Test]
		public void ClienteNombre_NoValue_ReturnsNull()
		{
			Assert.That(cliente.ClienteNombre, Is.Null);
		}

		[Test]
		public void DescuentoEvaluacion_DefaultClient_ReturnsDescuentoIntervalo()
		{
			int descuento = cliente.Descuento;
			Assert.That(descuento, Is.InRange(5, 24));
		}

		[Test]
		public void CrearNombreColeto_InputNombre_ReturnsNotNull()
		{
			cliente.CrearNombreColeto("Ariel", "");
			Assert.That(cliente.ClienteNombre, Is.Not.Null);
			Assert.That(string.IsNullOrEmpty(cliente.ClienteNombre), Is.EqualTo(false));
		}

		[Test]
		public void ClienteNombre_InputNombreEnBlanco_ThrowsException()
		{
			//var exceptionDetalle = Assert.Throws<ArgumentException>(() => cliente.CrearNombreColeto("", "Gutierrez"));
			//Assert.That("El nombre esta en blaco", Is.EqualTo(exceptionDetalle.Message));'
			Assert.That(() =>
			cliente.CrearNombreColeto(" ", "Gutierrez"), Throws.ArgumentException.With.Message.EqualTo("El nombre esta en blanco")
			);

			Assert.Throws<ArgumentException>(() => cliente.CrearNombreColeto("", "Gutierrez"));
			Assert.That(() =>
			cliente.CrearNombreColeto(" ", "Gutierrez"), Throws.ArgumentException
			);

		}

		[Test]
		public void GetClienteDetalle_CrearClienteConMenos500TotalOrder_ReturnsClienteBasico()
		{
			cliente.OrderTotal = 150;
			var resultado = cliente.GetClienteDetalle();
			Assert.That(resultado, Is.TypeOf<ClienteBasico>());
		}

		[Test]
		public void GetClienteDetalle_CrearClienteConMas500TotalOrder_ReturnsClientePremium()
		{
			cliente.OrderTotal = 700;
			var resultado = cliente.GetClienteDetalle();
			Assert.That(resultado, Is.TypeOf<ClientePremium>());
		}
	}
}
