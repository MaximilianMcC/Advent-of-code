class Part1
{
	public static void Solve()
	{
		// string[] data = Program.GetData(true);
		string[] data = Program.GetData();


		// Loop over every report
		int safeReports = 0;
		foreach (string report in data)
		{
			// Extract all of the levels from the report
			// TODO: Do a better way
			int[] levels = report.Split(" ").Select(level => int.Parse(level)).ToArray();

			bool safe = true;

			// Loop over every pair of levels and check 
			// for how much they increase/decrease by
			bool increasing = false;
			for (int i = 1; i < levels.Length; i++)
			{
				// Get the difference
				int difference = levels[i - 1] - levels[i];

				// Check for if the levels are increasing
				// or decreasing
				bool currentlyIncreasing = difference > 0;
				if (i == 1) increasing = currentlyIncreasing;
				else
				{
					if (currentlyIncreasing != increasing) safe = false;
				}

				// Check for if the difference is acceptable
				difference = Math.Abs(difference);
				if (!((difference >= 1) && (difference <= 3))) safe = false;
			}
		
			if (safe) safeReports++;
		}

		Console.WriteLine("Safe reports: " + safeReports);
	}
}