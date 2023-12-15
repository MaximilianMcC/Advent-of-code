public class Map {
	
	public int DestinationRangeStart;
	public int SourceRangeStart;
	public int RangeLength;

	public Map(int destinationRangeStart, int sourceRangeStart, int rangeLength) {

		// Assign values
		DestinationRangeStart = destinationRangeStart;
		SourceRangeStart = sourceRangeStart;
		RangeLength = rangeLength;
	}

	@Override
	public String toString()
	{
		return "DestinationRangeStart:\t" + DestinationRangeStart + "\n" +
			"SourceRangeStart:\t" + SourceRangeStart + "\n" +
			"RangeLength:\t\t" + RangeLength;
	}

}
