# Get the data
data = open("./Day6/data.txt", "r").read()

start_of_packet_marker = 0

# Loop through each character in the data
for i in range(len(data)):
    start_of_packet_marker += 1

    # Get groups of 4 at each index
    packet = [data[i], data[i + 1], data[i + 2], data[i + 3]]

    # Check for if there is not a duplicate in the group
    if len(packet) == len(set(packet)):

        # Show the answer
        print("The first packet begins at the index", start_of_packet_marker + 3)
        break