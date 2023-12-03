class Part2
{
	
	public static int Solution(string[] data)
	{
		int sum = 0;

		foreach (string game in data)
		{
			sum += IsGamePossible(game);
		}

		return sum;
	}

	private static int IsGamePossible(string gameInput)
	{
		// Get the ID of the current game
		int id = int.Parse(gameInput.Split(" ")[1].Replace(':', '\0'));
		string games = gameInput.Split(":")[1];

		int totalCubeSubsets = 0;
		int correctCubes = 0;

		// Loop through each pair of cubes in the game
		foreach (string cubePair in games.Split(';'))
		{
			totalCubeSubsets++;

			// Get how many of what cubes were in the current game
			int redCubes = 0;
			int greenCubes = 0;
			int blueCubes = 0;

			foreach (string currentCube in cubePair.Split(','))
			{
				// Update the cube counter with the colors
				string[] cube = currentCube.Trim().Split(' ');
				if (cube[1] == "red") redCubes += int.Parse(cube[0]);
				if (cube[1] == "green") greenCubes += int.Parse(cube[0]);
				if (cube[1] == "blue") blueCubes += int.Parse(cube[0]);
			}

			// Check for if the correct amount of cubes were present in the current subset
			if (redCubes <= 12 && greenCubes <= 13 && blueCubes <= 14) correctCubes++;
		}

		// Check for if the game is possible
		if (totalCubeSubsets == correctCubes) return id;
		return 0;
	}

}