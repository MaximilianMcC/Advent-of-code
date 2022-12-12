package Day8;

import java.io.File;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Part1 {

	public static void main(String[] args) {
		
		// Get the data
		List<String> data = new ArrayList<String>();
		try {
			File file = new File("./Day8/test.txt");
			Scanner fileReader = new Scanner(file);

			while (fileReader.hasNextLine()) {
				data.add(fileReader.nextLine());
			}

			fileReader.close();

		} catch(Exception e) {
			e.printStackTrace();
		}

		System.out.println("Data: " + data);
		System.out.println("Data length: " + data.size());

		int dataWidth = data.get(0).length();
		System.out.println("Data width: " + dataWidth);



		System.out.println("\n\n");



		// Loop through every tree in the forest
		for (int forestY = 1; forestY < data.size(); forestY++) {
			for (int forestX = 1; forestX < dataWidth; forestX++) {
				
				

				// Check for if the tree position is in the bounds of the array
				if ((forestX > (dataWidth - 2)) || (forestY > data.size() - 2)) continue;



				// Get the current tree
				int tree = Integer.parseInt(data.get(forestY).split("")[forestX]);
				System.out.println("Current tree: " + tree);

				// Get the tree to the left of it
				int leftTree = Integer.parseInt(data.get(forestY).split("")[forestX - 1]);
				System.out.println("Left tree: " + leftTree);

				// Get the tree to the right of it
				int rightTree = Integer.parseInt(data.get(forestY).split("")[forestX + 1]);
				System.out.println("Right tree: " + rightTree);

				// Get the tree above it
				int topTree = Integer.parseInt(data.get(forestY - 1).split("")[forestX]);
				System.out.println("Top tree: " + topTree);
				
				// Get the tree below it
				int bottomTree = Integer.parseInt(data.get(forestY + 1).split("")[forestX]);
				System.out.println("Bottom tree: " + bottomTree);

				System.out.println("\n");
				System.out.println(" " + topTree + " ");
				System.out.println(leftTree + "" + tree + "" + rightTree);
				System.out.println(" " + bottomTree + " ");

				
				System.out.println("\n\n\n");
			}

			System.out.println("\n\n-------------\n\n");
		}

	}

}