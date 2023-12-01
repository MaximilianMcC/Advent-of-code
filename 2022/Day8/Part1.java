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




		// Get the width of each line of the data
		int dataWidth = data.get(0).length();


		int visibleTrees = 0;


		// Get the trees on the outside of the forest
		int outsideTrees = (dataWidth * 2) + (data.size() - 2) * 2;
		visibleTrees += outsideTrees;

		// Loop through every tree in the forest
		for (int forestY = 1; forestY < data.size(); forestY++) {
			for (int forestX = 1; forestX < dataWidth; forestX++) {
				
				// Check for if the coordinates are out of bounds
				//TODO: Add to the outside trees thing
				if ((forestX > (dataWidth - 2)) || (forestY > data.size() - 2)) continue;
				

				
				// Get the current tree
				int tree = Integer.parseInt(data.get(forestY).split("")[forestX]);

				// Get the tree to the left of it
				int leftTree = Integer.parseInt(data.get(forestY).split("")[forestX - 1]);

				// Get the tree to the right of it
				int rightTree = Integer.parseInt(data.get(forestY).split("")[forestX + 1]);

				// Get the tree above it
				int topTree = Integer.parseInt(data.get(forestY - 1).split("")[forestX]);

				// Get the tree below it
				int bottomTree = Integer.parseInt(data.get(forestY + 1).split("")[forestX]);


				// Check for if the current tree is visible
				boolean visible = false;
				if (topTree < tree && leftTree < tree) visible = true;
				else if (topTree < tree && rightTree < tree) visible = true;
				else if (bottomTree < tree && leftTree < tree) visible = true;
				else if (bottomTree < tree && rightTree < tree) visible = true;

				if (visible) visibleTrees++;
			}

		}

		// Print the answer
		System.out.println("Visible trees outside: " + outsideTrees);
		System.out.println("Visible trees: " + (visibleTrees - outsideTrees));
		System.out.println("Visible trees total: " + visibleTrees);

	}

}