public class Part2 {
    
    public static void main(String[] args) {
        
        // --- Day 3: Rucksack Reorganization ---


        // Get the data
        List<String> data = new ArrayList<String>();
        try {
            File file = new File("./data.txt");
            Scanner fileReader = new Scanner(file);

            while (fileReader.hasNextLine()) {
                data.add(fileReader.nextLine());
            }
            fileReader.close();

        } catch(Exception e) {
            e.printStackTrace();
        }

        // Group the data into groups of 3
        

    }

}
