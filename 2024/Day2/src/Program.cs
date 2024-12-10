class Program
{
	public static string[] GetData(bool test = false)
	{
		return File.ReadAllLines(test ? "./test.txt" : "./data.txt");
	}

	public static void Main(string[] args)
	{
		// Part1.Solve();
		Part2.Solve();
	}
}