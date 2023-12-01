// --- Day 4: Camp Cleanup ---


// Imports
const fileSystem = require("fs");



// Get the data
const data = fileSystem.readFileSync("./data.txt", "utf8");

let totalOverlaps = 0;

const sectionAssignments = data.split("\n");
for (let i = 0; i < sectionAssignments.length; i++) {

    const elfPair = sectionAssignments[i];

    // Get the range of ids for the first elf
    let firstElf = elfPair.split(",")[0].split("-");
    firstElf[0] = parseInt(firstElf[0]);
    firstElf[1] = parseInt(firstElf[1]);

    let secondElf = elfPair.split(",")[1].split("-");
    secondElf[0] = parseInt(secondElf[0]);
    secondElf[1] = parseInt(secondElf[1]);

    console.log(firstElf);


    // Check for overlap in both pairs
    if (firstElf[0] >= secondElf[0]) {
        if (firstElf[1] <= secondElf[1]) {
            totalOverlaps += 1;
            continue;
        }
    }
    if (secondElf[0] >= firstElf[0]) {
        if (secondElf[1] <= firstElf[1]) {
            totalOverlaps += 1;
            continue;
        }
    }


}

// Show the total amount of overlaps
console.log("Total overlaps: " + totalOverlaps);