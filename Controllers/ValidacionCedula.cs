using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppDermatologia.Controllers
{
	public class ValidacionCedula
	{
		public bool validar(string a)
		{
			int suma = 0;
			bool val = false;
			int[] ced = new int[10];
			try
			{
				for (int i = 0; i < 10; i++)
				{
					ced[i] = Convert.ToInt32(a.Substring(i, 1));
				}

				for (int index = 0; index < 9; index++)
				{
					if (index % 2 == 0)
					{
						suma += impares(ced[index]);
					}
					else
					{
						suma += ced[index];
					}
				}

				if ((dec_sup(suma) - suma) == ced[9])
				{
					val = true;
				}
			}
			catch
			{
				return false;
			}
			return val;
		}

		static int impares(int num)
		{
			int aux;
			aux = num * 2;
			if (aux > 9)
			{
				aux = aux - 9;
			}
			return aux;
		}

		static int dec_sup(int num)
		{
			int a;
			string num_d = num.ToString();
			a = Convert.ToInt32(num_d.Substring(0, 1));
			a++;
			a = a * 10;
			return a;
		}
	}
}