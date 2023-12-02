class Program
{
	public static void Main(string[] args)
	{
		// string[] data = File.ReadAllLines("./test.txt");
		string[] data = File.ReadAllLines("./data.txt");

		Console.WriteLine(Part1.Solution(data));

	}
}