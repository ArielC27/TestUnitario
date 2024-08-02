namespace LibreriaAriel
{
	public class Operacion
	{
		public List<int> NumerosImpares = new();
		public int SumarNumeros(int num1, int num2)
		{
			return num1 + num2;
		}

		public bool IsValorPar(int num)
		{
			return num % 2 == 0;
		}

		public double SumarDecimal(double num1, double num2)
		{
			return num1 + num2;
		}

		public List<int> GetListaNumerosImpares(int intervaloMin, int intervaloMax)
		{
			NumerosImpares.Clear();
			for (int i = intervaloMin; i <= intervaloMax; i++)
			{
				if (i % 2 != 0)
				{
					NumerosImpares.Add(i);
				}
			}
			return NumerosImpares;
		}

	}
}
