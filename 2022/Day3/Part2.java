package Day3;

import java.io.File;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;


public class Part2 {
    
    public static void main(String[] args) {

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
        List<String> elfGroups = new ArrayList<String>();
        for (int i = 2; i < data.size(); i += 3) {
            
            String group = "";
            group += data.get(i - 2) + "\n";
            group += data.get(i - 1) + "\n";
            group += data.get(i);
            elfGroups.add(group);
        }


        int totalBadgePriorities = 0;
        for (String group : elfGroups) {

            String[] rucksacks = group.split("\n");

            // Find the badge that appears in all 3 rucksacks
            char badge = ' ';
            for (char rucksack1 : rucksacks[0].toCharArray()) {
                for (char rucksack2 : rucksacks[1].toCharArray()) {
                    for (char rucksack3 : rucksacks[2].toCharArray()) {
                        
                        if (rucksack1 == rucksack2 && rucksack2 == rucksack3) badge = rucksack1;
                    }
                }
            }

            // Get the badge priority
            int badgePriority = 0;
            if (Character.isLowerCase(badge)) {
                
                char[] priorities = "abcdefghijklmnopqrstuvwxyz".toCharArray();
                for (int i = 0; i < priorities.length; i++) {
                    
                    if (badge == priorities[i]) badgePriority = (i + 1);
                }

            } else if (Character.isUpperCase(badge)) {

                char[] priorities = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".toCharArray();
                for (int i = 0; i < priorities.length; i++) {
                    
                    //? 26 is length of alphabet
                    if (badge == priorities[i]) badgePriority = (i + 1) + 26; 
                }
            }

            totalBadgePriorities += badgePriority;
        }

        // Give the answer
        System.out.println("Total badge priorities for each group: " + totalBadgePriorities);
    }

}
