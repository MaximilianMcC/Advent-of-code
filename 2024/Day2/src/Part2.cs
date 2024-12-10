class Part2
{
	public static void Solve()
	{
		string[] data = Program.GetData(true);
		// string[] data = Program.GetData();



		// Loop over every report
		int safeReports = 0;
		foreach (string report in data)
		{
			// Extract all of the levels from the report
			// TODO: Do a better way
			int[] levels = report.Split(" ").Select(level => int.Parse(level)).ToArray();

			// Check for if the initial level is safe.
			// If its not, then remove a number from
			// the level until we remove the potentially
			// problematic level
			bool safe = IsLevelSafe(levels);
			if (safe == false)
			{
				for (int i = 0; i < levels.Length; i++)
				{
					List<int> levelList = levels.ToList();
					levelList.RemoveAt(i);

					Console.WriteLine(string.Join(" ", levels) + "\t" + string.Join(" ", levelList.ToArray()));

					safe = IsLevelSafe(levelList.ToArray());
				}
			}

			if (safe) safeReports++;
		}

		Console.WriteLine(safeReports);
	}

	private static bool IsLevelSafe(int[] level)
	{
		bool safe = true;
		bool increasing = false;

		// Loop over every pair of levels and check 
		// for how much they increase/decrease by
		for (int i = 1; i < level.Length; i++)
		{
			// Get the difference
			int difference = level[i - 1] - level[i];

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

		// Say if its safe or not
		return safe;
	}
}