import java.util.Arrays;

public class Part2 {

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

		// Loop over every distance in the list
		int similarityScore = 0;
		for (int i = 0; i < leftList.length; i++) {
			
			// Keep track of how many times a
			// similar number comes up
			int appearances = 0;
			int leftNumber = leftList[i];

			// Loop over the right list and get how
			// many times the left list value appears
			for (int j = 0; j < rightList.length; j++) {
				
				if (leftNumber == rightList[j]) appearances++;
			}

			System.out.println(leftNumber + " appears in the right list " + appearances + " times.");

			// Update the similarity score
			int score = leftNumber * appearances;
			similarityScore += Math.abs(score);
		}

		// Print the answer
		System.out.println("Similarity score: " + similarityScore);
	}
}
