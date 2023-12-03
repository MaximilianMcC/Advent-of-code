class Part1
{
	public static int Solution(string[] schematic)
	{
		int sum = 0;

		// Loop through all characters in the schematic. If a symbol is found, look at
		// all of the symbols neighbors. If one of the neighbors is a number, then keep
		// searching on the X of that current line until the entire number has been discovered.		

		// Replace the `.`'s with empty strings to make stuff easier
		schematic = schematic.Select(str => str.Replace('.', ' ')).ToArray();

		// Loop through all characters in the schematic
		for (int y = 0; y < schematic.Length; y++)
		{
			for (int x = 0; x < schematic[y].Length; x++)
			{
				// Get the character
				char character = schematic[y][x];

				// Check for if the character is a symbol (not an int)
				if (int.TryParse(character.ToString(), out _)) continue;

				// Get all of the neighbors, and check for if its a number
				List<Tuple<int, int>> neighbors = GetNeighbors(x, y, schematic);
				foreach (Tuple<int, int> numberPosition in neighbors)
				{
					// Keep on going along the x values for each number until the end is reached
					int startX = numberPosition.Item1;
					int xIndex = 0;
					string fullNumber = schematic[numberPosition.Item2][numberPosition.Item1].ToString();
					
					//? When reading the schematic it looks like the longest
					//? number that can be possible is three characters, so will
					//? search two characters out from the confirmed starting index
					const int lookAhead = 3;

					for (int i = 0; i < lookAhead; i++)
					{
						// Check for if we have already found all the numbers and exit
						if (fullNumber.Length >= 3) break;

						int number = 0;
						xIndex++;

						// Forwards/right
						int forwardX = startX + xIndex;
						if (forwardX < schematic.Length && int.TryParse(schematic[forwardX][numberPosition.Item2].ToString(), out number))
						{
							// Number was found going right
							xIndex++;
							fullNumber = fullNumber + number.ToString();
						}

						// Backwards/left
						int backwardX = startX - xIndex;
						if (backwardX >= 0 && int.TryParse(schematic[backwardX][numberPosition.Item2].ToString(), out number))
						{
							// Number was found going left
							xIndex--;
							fullNumber = number.ToString() + fullNumber;
						}
					}
				
					// Update the sum with new number
					sum += int.Parse(fullNumber);
				}
			}
		}

		return sum;
	}

	// TODO: Do in a cleaner way that doesn't make it look like a .min.js file!!
	// TODO: Replace tuple for vector2
	private static List<Tuple<int, int>> GetNeighbors(int x, int y, string[] grid)
	{
		List<Tuple<int, int>> neighbors = new List<Tuple<int, int>>();

		// Check top row
		if (y - 1 >= 0)
		{
			if (x - 1 >= 0 && int.TryParse(grid[y - 1][x - 1].ToString(), out _)) neighbors.Add(new Tuple<int, int>(y - 1, x - 1));
			if (int.TryParse(grid[y - 1][x].ToString(), out _)) neighbors.Add(new Tuple<int, int>(y - 1, x));
			if (x + 1 < grid[0].Length && int.TryParse(grid[y - 1][x + 1].ToString(), out _)) neighbors.Add(new Tuple<int, int>(y - 1, x + 1));
		}

		// Check middle row
		if (x - 1 >= 0 && int.TryParse(grid[y][x - 1].ToString(), out _)) neighbors.Add(new Tuple<int, int>(y, x - 1));
		if (x + 1 < grid[0].Length && int.TryParse(grid[y][x + 1].ToString(), out _)) neighbors.Add(new Tuple<int, int>(y, x + 1));

		// Check bottom row
		if (y + 1 < grid.Length)
		{
			if (x - 1 >= 0 && int.TryParse(grid[y + 1][x - 1].ToString(), out _)) neighbors.Add(new Tuple<int, int>(y + 1, x - 1));
			if (int.TryParse(grid[y + 1][x].ToString(), out _)) neighbors.Add(new Tuple<int, int>(y + 1, x));
			if (x + 1 < grid[0].Length && int.TryParse(grid[y + 1][x + 1].ToString(), out _)) neighbors.Add(new Tuple<int, int>(y + 1, x + 1));
		}

		return neighbors;
	}

}