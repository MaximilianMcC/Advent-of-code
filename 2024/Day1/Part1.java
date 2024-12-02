import java.util.Arrays;

public class Part1 {

	public static void solve() {
		
		// Get the data as strings
		String[] data = Main.getData(false);
		
		// Convert the data into two lists of ints
		int[] leftList = new int[data.length];
		int[] rightList = new int[data.length];

		// Split the data into the lists
		for (int i = 0; i < data.length; i++) {
			
			// Extract each side of the list
			String[] line = data[i].split("   ");

			// Add them to the list
			leftList[i] = Integer.parseInt(line[0]);
			rightList[i] = Integer.parseInt(line[1]);
		}

		// Sort both lists with the smallest at the bottom
		// and the biggest at the top 
		Arrays.sort(leftList);
		Arrays.sort(rightList);

		// Loop over every distance in the list
		int totalDistance = 0;
		for (int i = 0; i < data.length; i++) {
			
			// Get the distance between the two points
			int distance = rightList[i] - leftList[i];

			// Add it to the total count
			totalDistance += Math.abs(distance);
		}

		// Print the answer
		System.out.println("Total distance: " + totalDistance);
	}
}
