class Part2
{
	public static void Run()
	{
		string[] data = File.ReadAllLines("./data.txt");
		// string[] data = File.ReadAllLines("./example.txt");

		int loops = 0;
		int dial = 50;
		for (int i = 0; i < data.Length; i++)
		{
			string action = data[i];

			Console.Write($"The dial is rotated {action} to point at ");

			// Check for which direction we are going
			int sign = action[0] == 'R' ? 1 : -1;
			action = action.Replace("L", "");
			action = action.Replace("R", "");

			// Rotate the dial
			int rotation = int.Parse(action);

			for (int j = 0; j < Math.Abs(rotation); j++)
			{
				dial += 1 * sign;
				if (dial > 99) dial = 0;
				if (dial < 0) dial = 99;

				if (dial == 0) loops++;
			}
			Console.WriteLine(dial);
		}

		Console.WriteLine("Loops: " + loops);
	}
}