﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace LibreriaAriel
{
	public class ProductoXUnitTest
	{
		//[Test]
		//public void GetPrecio_PremiumCliente_ReturnsPrecio80()
		//{
		//	Producto producto = new Producto
		//	{
		//		Precio = 50
		//	};
		//	var resultado = producto.GetPrecio(new Cliente { IsPremium = true });

		//	Assert.That(resultado, Is.EqualTo(40));
		//}

		//[Test]
		//public void GetPrecio_PremiumClienteMoq_ReturnsPrecio80()
		//{
		//	Producto producto = new Producto
		//	{
		//		Precio = 50
		//	};

		//	var cliente = new Mock<ICliente>();
		//	cliente.Setup(s => s.IsPremium).Returns(true);

		//	var resultado = producto.GetPrecio(cliente.Object);

		//	Assert.That(resultado, Is.EqualTo(40));
		//}

	}
}
