using System.Text.RegularExpressions;

class Part1
{
	
	public static void Main(string[] args)
	{

		// Get the data
		string[] data = File.ReadAllLines("./data.txt");

		// Split the data into 2 bits
		int cratesDataIndex = 0;
		int moveDataIndex = 0;
		for (int i = 0; i < data.Length; i++) 
		{
			// Get the split positions
			if (data[i] == "")
			{
				cratesDataIndex = i;
				moveDataIndex = i + 1;
			}
		}

		// Parse the crates data
		string[] cratesData = data[0..cratesDataIndex];
		List<char>[] crates = new List<char>[cratesDataIndex];

		for (int i = 0; i < crates.Length; i++)
		{
			// Remove all of the crate ascii art
			string crateRow = cratesData[i].Substring(cratesData[i].IndexOf(" ")).Replace(" ", "").Replace("[", "").Replace("]", "");

			// Add all of the individual crates to a "stack" of crates
			foreach (char crate in crateRow)
			{
				Console.Write(crate + " ");
			}
			Console.WriteLine();
		}


		Debug.Array(crates);




		// Parse the move data
		
	}
}


















class Debug
{
	// Print the contents of an array
	public static void Array<T>(T[] array, string? title = null, bool multiline = false)
	{
		if (title != null) Console.WriteLine($"{title} array contents - length: {array.Length}");
		for (int i = 0; i < array.Length; i++)
		{
			if (multiline == true) Console.WriteLine(array[i]);
			else
			{
				Console.Write(array[i]); 
				if (i != array.Length - 1) Console.Write(", ");
			}
		}
		Console.WriteLine();
	}

	// Print the contents of a list
	public static void List<T>(List<T> list, string? title = null, bool multiline = false)
	{
		if (title != null) Console.WriteLine($"{title} list contents - count: {list.Count}");
		for (int i = 0; i < list.Count; i++)
		{
			if (multiline == true) Console.WriteLine(list[i]);
			else
			{
				Console.Write(list[i]);
				if (i != list.Count - 1) Console.Write(", ");
			}
		}
		Console.WriteLine();
	}
}