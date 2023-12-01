class Part2
{
	public static int Solution()
	{
		// Get the data/puzzle-input
		string[] data = File.ReadAllLines("./data.txt");

		// Loop through every single line and get the sum
		int sum = 0;
		foreach (string line in data) sum += GetSumOfLine(line);

		// Return the sum
		return sum;
	}

	private static int GetSumOfLine(string line)
	{
		Dictionary<string, int> writtenNumbers = new Dictionary<string, int>()
		{
			{ "one", 1 },
			{ "two", 2 },
			{ "three", 3 },
			{ "four", 4 },
			{ "five", 5 },
			{ "six", 6 },
			{ "seven", 7 },
			{ "eight", 8 },
			{ "nine", 9 }
		};

		List<int> numbers = new List<int>();

		// Loop through the current line
		for (int i = 0; i < line.Length; i++)
		{
			int number = 0;

			// Check for if there is a 'real' number at the current character
			int.TryParse(line[i].ToString(), out number);

			// Check for if there is a written number at the current index
			foreach (KeyValuePair<string, int> writtenNumber in writtenNumbers)
			{
				// Calculate the count to make sure there is no out of range exception
				int count = Math.Min(writtenNumber.Key.Length, line.Length - i);

				int index = line.IndexOf(writtenNumber.Key, i, count);
				if (index != -1) number = writtenNumber.Value;
			}

			// Check for if there is a number, and add it to the list
			if (number != 0) numbers.Add(number);
		}
		
		// Return the sum of the first + second number
		return int.Parse($"{numbers.First()}{numbers.Last()}");
	}
}