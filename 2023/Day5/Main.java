import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.List;

public class Main {

	public static void main(String[] args) {
		
		// Read the data
		String[] data = new String[0];
		try {
			List<String> dataList = Files.readAllLines(Paths.get("./test.txt"));
			data = dataList.toArray(new String[0]);
		} catch (Exception e) {
			e.printStackTrace();
		}

		System.out.println(Part1.Solution(data));

	}
}