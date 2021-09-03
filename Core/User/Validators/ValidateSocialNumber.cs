using Core.User.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.User.Validators
{
    public class ValidateSocialNumber : IValidateSocialNumber
    {
		public bool IsSocialNumber(string socialNumber)
		{
			if (socialNumber == null)
			{
				return true;
			}
			int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			string tempSocialName;
			string digito;
			int soma;
			int resto;
			socialNumber = socialNumber.Trim();
			socialNumber = socialNumber.Replace(".", "").Replace("-", "");
			if (socialNumber.Length != 11)
				return false;
			tempSocialName = socialNumber.Substring(0, 9);
			soma = 0;

			for (int i = 0; i < 9; i++)
				soma += int.Parse(tempSocialName[i].ToString()) * multiplicador1[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = resto.ToString();
			tempSocialName = tempSocialName + digito;
			soma = 0;
			for (int i = 0; i < 10; i++)
				soma += int.Parse(tempSocialName[i].ToString()) * multiplicador2[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = digito + resto.ToString();
			return socialNumber.EndsWith(digito);
		}
	}
}
