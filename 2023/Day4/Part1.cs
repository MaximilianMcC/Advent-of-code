using System.Linq.Expressions;

class Part1
{
	public static int Solution(string[] data)
	{
		Card[] cards = new Card[data.Length];

		// Split up all of the cards to get the
		// winning numbers and number scratched
		for (int i = 0; i < data.Length; i++)
		{
			// Get rid of the card number
			string cardInfo = data[i].Split(":")[1];
			string[] numbers = cardInfo.Split(" | ");

			// Make the card
			Card card = new Card(GetNumbersFromString(numbers[0]), GetNumbersFromString(numbers[1]));
			cards[i] = card;
		}



		// Loop over the card and get the total points
		int totalPoints = 0;
		foreach (Card card in cards)
		{
			totalPoints += GetPointsFromCard(card);
		}
		return totalPoints;
	}

	private static int GetPointsFromCard(Card card)
	{
		int totalPoints = 0;

		// Loop through every scratched number and check
		// for if its in the winning numbers list
		foreach (int scratchedNumber in card.ScratchedNumbers)
		{
			if (card.WinningNumbers.Contains(scratchedNumber))
			{
				if (totalPoints == 0) totalPoints = 1;
				else totalPoints *= 2;
			}
		}

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