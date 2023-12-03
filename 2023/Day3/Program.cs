class Program
{
	public static void Main(string[] args)
	{

		// Load the data
		string[] data = File.ReadAllLines("./test.txt");

		Console.WriteLine(Part1.Solution(data));

	}
}