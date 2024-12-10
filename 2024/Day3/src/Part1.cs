using System.Text.RegularExpressions;

class Part1
{
	public static void Solve()
	{
		// Get the data
		string corruptedData = Program.GetData(false);

		int total = 0;

		// Loop over every character
		for (int i = 0; i < corruptedData.Length; i++)
		{
			// Check for if we have the starting bit of the multiplication command
			const string start = "mul(";
			if (i + start.Length > corruptedData.Length) continue;
			if (corruptedData.Substring(i, start.Length) != start) continue;

			// Each parameter can be up to three digits. Find them
			//? 3 + 3 = 6, because three potential digits
			//? 6 + 1 = 7, because we have the comma to separate params
			//? 7 + 1 = 8, because the method ends with a bracket
			const int maxLookAhead = 8;
			int lookAhead = Math.Min(maxLookAhead, corruptedData.Length - (i + start.Length));
			string potentialDigits = corruptedData.Substring(i + start.Length, lookAhead);

			// Check for if we have captured an ending
			int endIndex = potentialDigits.LastIndexOf(')');
			if (endIndex == -1) continue;
			potentialDigits = potentialDigits.Substring(0, endIndex);

			// Check for if we have enough parameters
			bool hasTwoDigits = potentialDigits.Contains(',');
			if (hasTwoDigits == false) continue;

			// Extract the two digits for multiplication
			// then do the multiplying
			string[] digits = Regex.Replace(potentialDigits, "[^0-9,]", "").Split(',');
			int result = int.Parse(digits[0]) * int.Parse(digits[1]);
			total += result;
		}

		Console.WriteLine("Total: " + total);
	}
}