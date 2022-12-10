# Get the data
data = open("./Day7/test.txt", "r").read().splitlines()

class Directory:
	def __init__(self, name, contents) -> None:
		self.name = name
		self.contents = contents
class File:
	def __init__(self, name, size) -> None:
		self.name = name
		self.size = size


directories = []
current_directory = None


for command in data:
	
	if (command.startswith("$ cd")):

		# Make a new directory
		name = command.split(" ")[2]
		_current_directory = Directory(name, [])
		
		if (name == ".."):
			print("Going back a directory")

		
		# Check for if the current directory already is in the list
		# if it's not then add it
		for directory in directories:
			
			print(directory.name)

			if (Directory(directory).name == _current_directory.name):
				directories.append(_current_directory)
				

		# Make the current directory this one
		current_directory = _current_directory

print(directories)