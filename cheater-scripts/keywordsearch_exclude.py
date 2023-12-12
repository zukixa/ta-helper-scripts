import os
import glob
import re

# Function to search for a keyword within specific Java files in a directory
def search_keyword_in_java_files(keyword):
    # Append '/*Array.java' to the current directory to search for Java array files
    directory = os.path.join('.', '*Array.java')

    # A list to hold the names of files that match the search criteria
    matched_files = []

    # Loop over all the '.java' files in the directory filtered by the pattern
    for file_path in glob.glob(directory):
        with open(file_path, 'r') as file:
            # Read the content of the file
            file_contents = file.read()

            # Prepare the keyword pattern to consider commas and spaces
            pattern = keyword.replace(" ", r"\s*")  # Allow any amount of whitespace
            pattern = pattern.replace(",", r"\s*,\s*")  # Allow whitespace around commas
            pattern = re.escape(pattern)  # Escape the rest of the keyword

            # If the keyword is found in the file, add the filename to the list
            if re.search(pattern, file_contents):
                matched_files.append(os.path.basename(file_path))

    # Return the list of matched files
    return matched_files

# Main code that gets user input and prints results
if __name__ == "__main__":
    # Input the search keyword
    keyword = input("Enter the keyword to search for: ")
    exclude = input("Exclude files with this keyword? (yes/no): ").lower() == "yes"  # Use the exclude logic as needed

    # Execute the search function
    matched_files = search_keyword_in_java_files(keyword)

    # Print the Java files where the keyword was found
    if matched_files:
        if not exclude:
            print("The keyword was found in the following files:")
        for file_name in matched_files:
            print(file_name)
    else:
        if not exclude:
            print("The keyword was not found in any Java files.")