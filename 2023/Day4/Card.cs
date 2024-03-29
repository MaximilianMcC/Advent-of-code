struct Card
{
	public int[] WinningNumbers { get; set; }
	public int[] ScratchedNumbers { get; set; }

	public Card(int[] winningNumbers, int[] scratchedNumbers)
	{
		WinningNumbers = winningNumbers;
		ScratchedNumbers = scratchedNumbers;
	}

	public override string ToString()
	{
		return $"Winning:\t{string.Join(", ", WinningNumbers)}\nScratched:\t{string.Join(", ", ScratchedNumbers)}";
	}
}