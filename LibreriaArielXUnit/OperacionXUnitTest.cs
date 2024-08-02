using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriaAriel;
using Xunit;


namespace LibreriaAriel
{
    public class OperacionXUnitTest
    {
        [Fact]
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
            Assert.Equal(119, resultado);

        }

        [Theory]
        [InlineData(3, false)]
        [InlineData(5, false)]
        [InlineData(7, false)]
        public void IsValorPar_InputNumImpar_ReturnFalse(int numImpar, bool expectedResult)
        {
            Operacion op = new();
            var resultado = op.IsValorPar(numImpar);

            Assert.Equal(expectedResult, resultado);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(6)]
        [InlineData(20)]
        public void IsValorPar_InputNumPar_ReturnTrue(int numPar)
        {
            Operacion op = new();

            bool isPar = op.IsValorPar(numPar);

            Assert.True(isPar);
        }

        //[Theory]
        //[InlineData(2.2, 1.2)]
        //[InlineData(2.23, 1.24)]s
        //public void SumarDecimal_InputDosNumeros_GetValorCorrecto(double num1Test, double num2Test)
        //{
        //    //arrange
        //    //Inicializar las variables o componentes que ejecutaran el test
        //    Operacion op = new();

        //    //Act
        //    double resultado = op.SumarDecimal(num1Test, num2Test);

        //    //Assert
        //    Assert.Equal(resultado, Is.InRange(3.3, 3.5)); //Valido los valores para este rango establecido

        //}

        //[Fact]
        //public void GetListaNumerosImpares_InputMinMaxIntervalos_ReturnsListImpares()
        //{
        //    Operacion op = new();
        //    List<int> numerosImparesEsperados = new() { 5, 7, 9 };
        //    List<int> resultados = op.GetListaNumerosImpares(5, 10);

        //    Assert.That(resultados, Is.EquivalentTo(numerosImparesEsperados));
        //    Assert.That(resultados, Does.Contain(5));
        //    Assert.That(resultados, Is.Not.Empty);
        //    Assert.That(resultados.Count, Is.EqualTo(3));
        //    Assert.That(resultados, Is.Ordered.Ascending); //Por defecto toma el orden de forma ascendente
        //    Assert.That(resultados, Is.Unique); //Verificacion de que no haya elementos duplicados
        //}
    }
}
