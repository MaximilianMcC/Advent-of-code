# Get the data
data = open("./Day6/data.txt", "r").read()

start_of_message_marker = 0

# Loop through each character in the data
for i in range(len(data)):
    start_of_message_marker += 1

    # Get groups of 4 at each index
    packet = [data[i], data[i + 1], data[i + 2], data[i + 3], data[i + 4], data[i + 5], data[i + 6], data[i + 7], data[i + 8], data[i + 9], data[i + 10], data[i + 11], data[i + 12], data[i + 13]]

    # Check for if there is not a duplicate in the group
    if len(packet) == len(set(packet)):

        # Show the answer
        print("The first message packet begins at the index", start_of_message_marker + 13)
        break