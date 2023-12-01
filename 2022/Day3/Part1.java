package Day3;

import java.io.File;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;


public class Part1 {

    
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

        int totalItemPriorities = 0;
        for (String rucksack : data) {
            
            // Split each of the rucksacks into 2 parts
            int compartmentSize = rucksack.length() / 2;
            String compartment1 = rucksack.substring(0, compartmentSize);
            String compartment2 = rucksack.substring(compartmentSize, rucksack.length());

            // Find the item that appears in both compartments
            char item = ' ';
            for (char compartment1Item : compartment1.toCharArray()) {
                for (char compartment2Item : compartment2.toCharArray()) {
                    
                    if (compartment1Item == compartment2Item) item = compartment1Item;
                }
            }

            // Get the item priority
            int itemPriority = 0;
            if (Character.isLowerCase(item)) {
                
                char[] priorities = "abcdefghijklmnopqrstuvwxyz".toCharArray();
                for (int i = 0; i < priorities.length; i++) {
                    
                    if (item == priorities[i]) itemPriority = (i + 1);
                }

            } else if (Character.isUpperCase(item)) {

                char[] priorities = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".toCharArray();
                for (int i = 0; i < priorities.length; i++) {
                    
                    //? 26 is length of alphabet
                    if (item == priorities[i]) itemPriority = (i + 1) + 26; 
                }
            }

            totalItemPriorities += itemPriority;
        }

        // Give the answer
        System.out.println("Total item priorities for each elf: " + totalItemPriorities);
    }
}