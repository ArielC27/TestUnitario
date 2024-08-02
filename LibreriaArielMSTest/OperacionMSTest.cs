using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriaAriel;

namespace LibreriaArielMSTest
{
	[TestClass]
	public class OperacionMSTest
	{
		[TestMethod]
		public void SumarNumeros_InputDosNumeros_GetValorCorrecto()
		{
			//arrange
			//Inicializar las variables o componentes que ejecutaran el test
			Operacion op = new();
			int num1Test = 50;
			int num2Test = 69;

			//Act
			int resultado = op.SumarNumeros(num1Test, num2Test);

			//Assert
			Assert.AreEqual(119, resultado);

		}
	}
}
