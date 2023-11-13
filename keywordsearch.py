# keyword searcher script
# usually, best to find "certain things" that seem dumb
# such as using arrays (searching "[]") in week 1, if arrays are introduced in week 6.
# ...
import os
import glob
import re

# Input the search keyword
keyword = input("Enter the keyword to search for: ")

# Append '/*.java' to the current directory to search for java files
directory = os.path.join('.', '*.java')

# A list to hold the names of matched files
matched_files = []

# Loop over all the '.java' files in the directory
for file_path in glob.glob(directory):
    with open(file_path, 'r') as file:
        # Read the content of the file
        file_contents = file.read()

        # If the keyword is found in the file, add the filename to the list
        if re.search(r'\b' + re.escape(keyword) + r'\b', file_contents):
            matched_files.append(os.path.basename(file_path))

# Print the Java files where the keyword was found
if matched_files:
    print("The keyword was found in the following files:")
    for file_name in matched_files:
        print(file_name)
else:
    print("The keyword was not found in any Java files.")