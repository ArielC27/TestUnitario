﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaAriel
{
	public class Producto
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public double Precio { get; set; }

		public double GetPrecio(Cliente cliente)
		{
			if (cliente.IsPremium)
			{
				return Precio * .8d;
			}
			return Precio;
		}
		public double GetPrecio(ICliente cliente)
		{
			if (cliente.IsPremium)
			{
				return Precio * .8d;
			}
			return Precio;
		}
	}
}
