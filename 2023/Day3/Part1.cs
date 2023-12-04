using System.Numerics;

class Part1
{
	public static int Solution(string[] schematic)
	{
		int sum = 0;

		// Loop through all characters in the schematic. If a symbol is found, look at
		// all of the symbols neighbors. If one of the neighbors is a number, then keep
		// searching on the X of that current line until the entire number has been discovered.		

		// Replace the `.`'s with empty strings to make parsing numbers easier
		schematic = schematic.Select(str => str.Replace('.', ' ')).ToArray();

		// Loop through all characters in the schematic, but ignore the edges
		for (int i = 1; i < schematic.Length - 1; i++)
		{
			for (int j = 1; j < schematic[i].Length - 1; j++)
			{
				// Check for if we are on a symbol (not a number or space)
				if (int.TryParse(schematic[i][j].ToString(), out _) || schematic[i][j] == ' ') continue;

				// Get the coordinates of any adjacent/neighboring numbers
				List<Vector2> adjacentNumbers = GetNeighbors(schematic, new Vector2(i, j));
				
				// Loop through all of the numbers on the same x axis until
				// the entire number is revealed both forwards and back
				foreach (Vector2 numberPosition in adjacentNumbers)
				{
					int currentNumber = schematic[(int)numberPosition.X][(int)numberPosition.Y];
				}
			}
		}

		return sum;
	}



	private static List<Vector2> GetNeighbors(string[] schematic, Vector2 startPosition)
	{
		List<Vector2> neighbors = new List<Vector2>();

		// Use a position map to check for neighbors in nicer written way then hardcoding
		// each value/coordinate by hand
		// TODO: Just map x values, then increase/decrease y 
		Vector2[][] positionMap = {
			new Vector2[3] { new Vector2(-1, 1), new Vector2(0, 1), new Vector2(1, 1) },
			new Vector2[3] { new Vector2(-1, 0), new Vector2(0, 0), new Vector2(1, 0) },
			new Vector2[3] { new Vector2(-1, -1), new Vector2(0, -1), new Vector2(1, -1) }
		};

		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				// Get the position of the current thingy relative to the
				// starting position that was given
				int x = (int)startPosition.X + (int)positionMap[i][j].X;
				int y = (int)startPosition.Y + (int)positionMap[i][j].Y;
				Vector2 position = new Vector2(x, y);

				// Check for if the thing at the position is a number
				if (int.TryParse(schematic[(int)position.X][(int)position.Y].ToString(), out _) == false) continue;
				neighbors.Add(position);
			}
		}

		return neighbors;
	}
}