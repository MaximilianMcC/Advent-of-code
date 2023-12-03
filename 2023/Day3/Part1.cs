class Part1
{
	public static int Solution(string[] schematic)
	{
		int sum = 0;

		// Loop through all characters in the schematic. If a symbol is found, look at
		// all of the symbols neighbors. If one of the neighbors is a number, then keep
		// searching on the X of that current line until the entire number has been discovered.		

		// Loop through all characters in the schematic
		for (int y = 0; y < schematic.Length; y++)
		{
			for (int x = 0; x < schematic[y].Length; x++)
			{
				// Get the character
				char character = schematic[y][x];

				// Check for if the character isn't a number, or a `.` (symbol)
				if (character == '.' && int.TryParse(character.ToString(), out _)) continue;

				// Get all of the neighbors, and check for if its a number
				List<Tuple<int, int>> numberLocations = new List<Tuple<int, int>>();
				if (int.TryParse(schematic[y][x - 1].ToString(), out _)) numberLocations.Add(new Tuple<int, int>(y, x - 1));
			}
		}

		return sum;
	}
}