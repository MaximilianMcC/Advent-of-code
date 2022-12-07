class Part1
{
	
	public static void Main(string[] args)
	{

		// Get the data
		string[] data = File.ReadAllLines("./data.txt");

		// Split the data into 2 bits
		int dataSplitIndex = 0;
		for (int i = 0; i < data.Length; i++) 
		{
			// Get the split positions
			if (data[i] == "") dataSplitIndex = i;
		}

		// Parse the crates data
		string[] cratesData = data[0..dataSplitIndex];
		List<char>[] crates = new List<char>[9]; //! 9 is Hardcoded value. Change to be dynamic or whatever it's called

		for (int i = 0; i < crates.Length; i++)
		{
			// Remove all of the crate ascii art
			string crateRow = cratesData[i].Substring(cratesData[i].IndexOf(" ")).Replace(" ", "").Replace("[", "").Replace("]", "");

			// Add all of the individual crates to a "stack" of crates
			List<char> currentCrateRow = new List<char>();
			foreach (char crate in crateRow)
			{
				currentCrateRow.Add(crate);
			}
			crates[i] = currentCrateRow;
		}

		


		// Parse the move data
		string[] moveData = data[(dataSplitIndex + 1)..data.Length];
		for (int i = 0; i < moveData.Length; i++)
		{
			// Get the values from the strings
			//? Move X crates from list Y to list Z
			int quantity = int.Parse(moveData[i].Split(" ")[1]);
			int startPile = int.Parse(moveData[i].Split(" ")[3]) - 1;
			int endPile = int.Parse(moveData[i].Split(" ")[5]) - 1;

			// Make a copy of the crates that need be moved
			List<char> cratesToMove = crates[startPile].GetRange(0, quantity);

			// Remove the crates from the start pile
			cratesToMove.ForEach(crate => crates[startPile].Remove(crate));

			// Add the crates to the end pile
			crates[endPile].AddRange(cratesToMove);
		}



		// Get the top value from each pile
		string topCrates = "";
		for (int i = 0; i < crates.Length; i++)
		{
			for (int j = 0; j < crates[i].Count; j++)
			{
				if (j == crates[i].Count - 1)
				{
					topCrates += crates[i][j];
				}
			}
		}

		
		// Show the answer
		Console.WriteLine("The top crates on each stack are: " + topCrates);

	}
}