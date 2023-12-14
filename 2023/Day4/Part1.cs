class Part1
{
	public static int Solution(string[] data)
	{
		// Split up all of the cards to get the
		// winning numbers and number scratched
		for (int i = 0; i < data.Length; i++)
		{
			// Get rid of the card number
			string cardInfo = data[i].Split(":")[1];
			string[] numbers = cardInfo.Split(" | ");

			// Make the card
			Card card = new Card(GetNumbersFromString(numbers[0]), GetNumbersFromString(numbers[1]));
			Console.WriteLine(card);
		}

		int totalPoints = 0;

		return totalPoints;
	}

	private static int[] GetNumbersFromString(string numberString)
	{
		List<int> numbers = new List<int>();
		foreach (string number in numberString.Split(" "))
		{
			// Filter out empty stuff
			if (number == "") continue;

			// Add the number
			numbers.Add(int.Parse(number));
		}

		return numbers.ToArray();
	}
}