using System.Text.RegularExpressions;

class Part2
{
	private static string corruptedData = Program.GetData(false);

	public static void Solve()
	{
		// Keep track of our total, and if we're currently enabled
		int total = 0;
		bool enabled = true;

		// Loop over every character
		for (int i = 0; i < corruptedData.Length; i++)
		{
			if (FindMethod("do", i)) enabled = true;
			if (FindMethod("don't", i)) enabled = false;

			// If we can, then add the new multiplied values 
			if (enabled) total += GetMultiplication(i);
		}

		Console.WriteLine("Total: " + total);
	}

	private static bool FindMethod(string methodName, int index)
	{
		string method = methodName + "()";

		// Check for if we have enough room for the method
		if (index + method.Length > corruptedData.Length) return false;
		if (corruptedData.Substring(index, method.Length) != method) return false;

		// Get the method if it exists
		return corruptedData.Substring(index, method.Length).Trim() == method;
	}

	private static int GetMultiplication(int index)
	{
		// Check for if we have the starting bit of the multiplication command
		const string start = "mul(";
		if (index + start.Length > corruptedData.Length) return 0;
		if (corruptedData.Substring(index, start.Length) != start) return 0;

		// Each parameter can be up to three digits. Find them
		//? 3 + 3 = 6, because three potential digits
		//? 6 + 1 = 7, because we have the comma to separate params
		//? 7 + 1 = 8, because the method ends with a bracket
		const int maxLookAhead = 8;
		int lookAhead = Math.Min(maxLookAhead, corruptedData.Length - (index + start.Length));
		string potentialDigits = corruptedData.Substring(index + start.Length, lookAhead);

		// Check for if we have captured an ending
		int endIndex = potentialDigits.LastIndexOf(')');
		if (endIndex == -1) return 0;
		potentialDigits = potentialDigits.Substring(0, endIndex);

		// Check for if we have enough parameters
		bool hasTwoDigits = potentialDigits.Contains(',');
		if (hasTwoDigits == false) return 0;

		// Extract the two digits for multiplication
		// then do the multiplying
		string[] digits = Regex.Replace(potentialDigits, "[^0-9,]", "").Split(',');
		int result = int.Parse(digits[0]) * int.Parse(digits[1]);
		return result;
	}
}