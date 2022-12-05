class Program
{
    
    public static void Main(string[] args)
    {

        // Get the data
        string[] data = File.ReadAllLines("./data.txt");

        // Parse the first part of the data
        List<string> crateStack1 = new List<string>();
        List<string> crateStack2 = new List<string>();
        List<string> crateStack3 = new List<string>();
        List<string> crateStack4 = new List<string>();
        List<string> crateStack5 = new List<string>();
        List<string> crateStack6 = new List<string>();
        List<string> crateStack7 = new List<string>();
        List<string> crateStack8 = new List<string>();
        List<string> crateStack9 = new List<string>();

        // Loop through all the crates and add them to a list
        List<char>[] crates = new List<char>[8];
        for (int i = 0; i < 8; i++)
        {
            string currentCrateRow = data[0..8][i];
            crates[i] = currentCrateRow.ToList<char>();
        }

        // Remove all the ascii art
        foreach (List<char> crate in crates)
        {
            foreach (char crateItem in crate)
            {
                crate.Remove(' ');
                crate.Remove('[');
                crate.Remove(']');
            }
        }

        for (int i = 0; i < crates.Count(); i++)
        {
            for (int j = 0; j < crates[i].Count(); j++)
            {
                Console.WriteLine(crates[i][j]);
            }
        }


        // Parse the second part of the data
    }
}