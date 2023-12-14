class Program
{
	public static void Main(string[] args)
	{
		// Parse the data
		string[] data = File.ReadAllLines("./data.txt");

		Console.WriteLine(Part1.Solution(data));
	}
}