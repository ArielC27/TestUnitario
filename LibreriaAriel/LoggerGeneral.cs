using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaAriel
{
	public interface ILoggerGeneral
	{
		void Message(string message);
		bool LogDataBase(string message);
		bool LogBalanceDespuesRetiro(int balanceDespuesRetiro);
	}
	public class LoggerGeneral : ILoggerGeneral
	{
		public bool LogBalanceDespuesRetiro(int balanceDespuesRetiro)
		{
			if (balanceDespuesRetiro >= 0)
			{
				Console.WriteLine("Exito de la operacion");
				return true;
			}
			Console.WriteLine("Erro");
			return false;
		}

		public bool LogDataBase(string message)
		{
			Console.WriteLine(message);
			return true;
		}

		public void Message(string message)
		{
			Console.WriteLine(message);
		}
	}

	public class LoggerFake : ILoggerGeneral
	{
		public bool LogBalanceDespuesRetiro(int balanceDespuesRetiro)
		{
			throw new NotImplementedException();
		}

		public bool LogDataBase(string message)
		{
			throw new NotImplementedException();
		}

		public void Message(string message)
		{
		}
	}
}
