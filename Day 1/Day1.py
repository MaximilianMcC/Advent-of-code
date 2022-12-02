# --- Day 1: Calorie Counting ---

# Get the data
data = open("data.txt", "r").read()


totalCalories = []


# Split the data into different elf's
elfs = data.split("\n\n")
for elf in elfs:
    
    # Get the total calories from the elf
    calories = elf.split("\n")
    calories = list(map(int, calories))
    totalCalories.append(sum(calories))


# Get the biggest amount of calories
currentBiggest = 0
for currentCalorie in totalCalories:
    if (currentCalorie > currentBiggest):
        currentBiggest = currentCalorie

print("The biggest calorie is", currentBiggest)