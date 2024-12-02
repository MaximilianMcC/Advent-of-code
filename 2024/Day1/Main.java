import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.Arrays;

public class Main {

	// Read the input
	public static String[] getData(boolean test) {

		try {
			String dataPath = test ? "./test.txt" : "./data.txt";
			return Files.readAllLines(Paths.get(dataPath)).toArray(new String[0]);

		} catch (Exception e) { 

			System.err.println(e);
			return new String[0];
		}
	}

	public static void main(String[] args) {

		Part1.solve();
		// Part2.solve();
	}
}