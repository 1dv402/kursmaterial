using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Emp2Usr
{
	public class AdService
	{
		private readonly Random _random = new Random();

		private string CreatePassword(int length = 0, int minLenght = 8, int maxLenght = 12, int numberOfNonAplhanumericCharacters = 0)
		{
			if (length == 0)
			{
				if (minLenght < 6)
				{
					throw new ArgumentException("minLength måste vara större eller lika med 6.");
				}

				if (minLenght > maxLenght)
				{
					throw new ArgumentException("minLength måste vara mindre eller lika med maxLength.");
				}

				length = _random.Next(minLenght, maxLenght + 1);
			}
			else if (length < 6)
			{
				throw new ArgumentException("length måste vara större eller lika med 6.");
			}

			if (numberOfNonAplhanumericCharacters > length - 3)
			{
				throw new ArgumentException("numberOfNonAplhanumericCharacters är för många i förhållande till totala antalet tecken i lösenordet.");
			}


			// Initierar array med teckengrupper.
			string[] characterGroups = {"ABCDEFGHJKLMNPQRSTUVWXYZ",   // uteslutit I och O
										"abcdefghjkmnopqrstuvwxyz",   // uteslutit l
										"23456789",                   // uteslutit 0 och 1
										"!#$%&()*+-./"                // uteslutit , " och '
									   };

			// Skapar variabel för lösenord...
			StringBuilder password = new StringBuilder(length);

			// ...variabel för vilka teckengrupper som ska användas.
			List<int> characterGroupIndexes = new List<int> { 0, 1, 2 };

			// Lägger till hur många gånger teckengrupp 4 ska användas, ...
			characterGroupIndexes.AddRange(Enumerable.Repeat(3, numberOfNonAplhanumericCharacters));

			// ...slumpar resterande teckengrupper mellan 0 och 2, och..
			for (int i = 0; i < length; i++)
			{
				characterGroupIndexes.Add(_random.Next(3));
			}

			// ...blandar teckengrupperna,...
			for (int i = characterGroupIndexes.Count - 1; i > 0; i--)
			{
				int index = _random.Next(i + 1);
				var temp = characterGroupIndexes[index];
				characterGroupIndexes[index] = characterGroupIndexes[i];
				characterGroupIndexes[i] = temp;
			}

			// ...slumpar tecken från grupperna, och...
			foreach (var index in characterGroupIndexes)
			{
				password.Append(characterGroups[index][_random.Next(characterGroups[index].Length)]);
			}

			// ...returnerar det slumpade lösenordet.
			return password.ToString();
		}

		private string ConvertToNonDiacriticString(string source)
		{
			var normalized = source.Normalize(NormalizationForm.FormKD);
			var ascii = Encoding.GetEncoding("us-ascii",
				new EncoderReplacementFallback(String.Empty),
				new DecoderReplacementFallback(String.Empty));
			var encodedBytes = new byte[ascii.GetByteCount(normalized)];
			ascii.GetBytes(normalized, 0, normalized.Length, encodedBytes, 0);
			return ascii.GetString(encodedBytes);
		}
	}
}