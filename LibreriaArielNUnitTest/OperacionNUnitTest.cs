using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LibreriaAriel;


namespace LibreriaAriel
{
	[TestFixture]
	public class OperacionNUnitTest
	{
		[Test]
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
			Assert.That(119 == resultado);

		}

		[Test]
		[TestCase(3, ExpectedResult = false)]
		[TestCase(5, ExpectedResult = false)]
		[TestCase(7, ExpectedResult = false)]
		public bool IsValorPar_InputNumImpar_ReturnFalse(int numImpar)
		{
			Operacion op = new();
			return op.IsValorPar(numImpar);
		}

		[Test]
		[TestCase(4)]
		[TestCase(6)]
		[TestCase(20)]
		public void IsValorPar_InputNumPar_ReturnTrue(int numPar)
		{
			Operacion op = new();

			bool isPar = op.IsValorPar(numPar);

			Assert.That(isPar, Is.EqualTo(true));
		}

		[Test]
		[TestCase(2.2, 1.2)]
		[TestCase(2.23, 1.24)]
		public void SumarDecimal_InputDosNumeros_GetValorCorrecto(double num1Test, double num2Test)
		{
			//arrange
			//Inicializar las variables o componentes que ejecutaran el test
			Operacion op = new();

			//Act
			double resultado = op.SumarDecimal(num1Test, num2Test);

			//Assert
			Assert.That(resultado, Is.InRange(3.3, 3.5)); //Valido los valores para este rango establecido

		}

		[Test]
		public void GetListaNumerosImpares_InputMinMaxIntervalos_ReturnsListImpares()
		{
			Operacion op = new();
			List<int> numerosImparesEsperados = new() { 5, 7, 9 };
			List<int> resultados = op.GetListaNumerosImpares(5, 10);

			Assert.That(resultados, Is.EquivalentTo(numerosImparesEsperados));
			Assert.That(resultados, Does.Contain(5));
			Assert.That(resultados, Is.Not.Empty);
			Assert.That(resultados.Count, Is.EqualTo(3));
			Assert.That(resultados, Is.Ordered.Ascending); //Por defecto toma el orden de forma ascendente
			Assert.That(resultados, Is.Unique); //Verificacion de que no haya elementos duplicados
		}
	}
}
