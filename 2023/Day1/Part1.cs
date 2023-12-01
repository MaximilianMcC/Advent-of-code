class Part1
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
		List<int> numbers = new List<int>();

		foreach (char character in line)
		{
			// Check for if the current character is a number
			int number = 0;
			int.TryParse(character.ToString(), out number);

			// Add the number to the list of numbers
			if (number != 0) numbers.Add(number);
		}
		
		// Return the sum of the first + second number
		return int.Parse($"{numbers.First()}{numbers.Last()}");
	}
}