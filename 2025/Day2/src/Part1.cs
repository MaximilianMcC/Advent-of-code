class Part1
{
	public static void Run()
	{
		// string data = File.ReadAllText("./example.txt");
		string data = File.ReadAllText("./data.txt");

		long invalidIds = 0;

		// Loop over all ranges
		string[] ranges = data.Split(",");
		foreach (string range in ranges)
		{
			// Split it into both bits
			//? idk why but it wants this in a long for some reason even though the numbers are never that large
			string[] currentRange = range.Split("-");
			long start = long.Parse(currentRange[0]);
			long end = long.Parse(currentRange[1]);

			// Loop over each value in the range
			// TODO: Maybe add 1 to end idk
			for (long id = start; id < end + 1; id++)
			{
				if (HasPattern(id))
				{
					Console.WriteLine(id);
					invalidIds += id;
				}
			}
		}

		Console.WriteLine("Invalid ids: " + invalidIds);
	}

	// Find repeating bits
	private static bool HasPattern(long rawId)
	{
		string id = rawId.ToString();

		// The id must be even to be invalid
		// so there can be two haves
		if (id.Length % 2 != 0) return false;
		int patternLength = id.Length / 2;

		// Loop through both sides and make sure they match
		string pattern = "";
		for (int i = 0; i < patternLength; i++)
		{
			// Get both 'sides' of the pattern
			string front = pattern + id[i];
			string back = pattern + id[patternLength + i];

			// If the front and back aren't the
			// same then it is a valid id
			if (front != back) return false;

			// Update the new pattern
			pattern = front;
		}

		// Did contain a pattern
		return pattern.Length == patternLength;
	}
}