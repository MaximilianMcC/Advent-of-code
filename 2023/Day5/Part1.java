import java.util.ArrayList;
import java.util.List;

public class Part1 {
	
	public static int Solution(String[] data) {

		// Get all of the seeds that need to be planted
		ArrayList<Integer> seedList = new ArrayList<Integer>();
		for (String number : data[0].split(" ")) {
			
			// Remove the seeds label at the start
			if (number.equals("seeds:")) continue;
			
			// Get the seed as a number
			int currentSeed = Integer.parseInt(number);
			seedList.add(currentSeed);
		};
		//todo: switch back to c#😬
		int[] seeds = seedList.stream().mapToInt(Integer::intValue).toArray();


		// Loop through all the sections
		List<Map>[] sections = new ArrayList[8];
		for (int i = 0; i < sections.length; i++) sections[i] = new ArrayList<Map>();

		int sectionIndex = -1;
		for (int i = 1; i < data.length; i++) {
			
			// Check for if we are in a new section
			if (data[i].endsWith(":")) {
				sectionIndex++;
				continue;
			}
			if (data[i].equals("")) continue;
			
			// Split up the values
			String[] values = data[i].split(" ");

			// Get all of the map values
			int destinationRangeStart = Integer.parseInt(values[0]);
			int sourceRangeStart = Integer.parseInt(values[1]);
			int rangeLength  = Integer.parseInt(values[2]);

			// Add the map to the section
			Map map = new Map(destinationRangeStart, sourceRangeStart, rangeLength);
			sections[sectionIndex].add(map);
		}

		// Loop through all of the mappings and do whatever it is needs to be done
		for (List<Map> section : sections) {
			for (Map map : section) {
				
				// Find the source range values
				int[] sourceRangeValues = new int[map.RangeLength];
				for (int i = 0; i < sourceRangeValues.length; i++) {
					sourceRangeValues[i] = map.SourceRangeStart + i;
				}

				// Find the destination range values
				int[] destinationRangeValues = new int[map.RangeLength];
				for (int i = 0; i < destinationRangeValues.length; i++) {
					destinationRangeValues[i] = map.DestinationRangeStart + i;
				}

				
			}
		}

		int locationNumber = 0;
		return locationNumber;
	}
	
}
