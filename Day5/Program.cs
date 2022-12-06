using System.Text.RegularExpressions;

class Program
{
	
	public static void Main(string[] args)
	{

		// Get the data
		string[] data = File.ReadAllLines("./data.txt");

	}









	// Print the contents of an array
	static void DebugArray<T>(T[] array, string? title = null)
	{
		if (title != null) Console.Write(title + " array: ");
		for (int i = 0; i < array.Length; i++)
		{
			Console.Write(array[i]); 
			if (i != array.Length - 1) Console.Write(", ");
		}
		Console.WriteLine();
	}

	// Print the contents of a list
	static void DebugList<T>(List<T> list, string? title = null)
	{
		if (title != null) Console.Write(title + " list: ");
		for (int i = 0; i < list.Count; i++)
		{
			Console.Write(list[i]);
			if (i != list.Count - 1) Console.Write(", ");
		}
		Console.WriteLine();
	}
}