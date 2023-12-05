# code similarity script
# usually, it does provide a very general sense of code similarity between files.
# could be made a LOT more efficient with further normalizations, but they're tricky to make.
# ...

import glob
import re
from sklearn.feature_extraction.text import TfidfVectorizer
from sklearn.metrics.pairwise import cosine_similarity

# List all Java files
all_files = glob.glob("*.java")

# Request input file prefixes from user, split by spaces
file_prefixes = input("Please enter the file names (without the extension) separated by spaces: ").split()

# Dict to hold files by their prefix
files_by_prefix = {prefix: [file for file in all_files if re.search(prefix, file)] for prefix in file_prefixes}

# Function to compute similarity
def calculate_similarity(files):
    file_to_text = {}

    # Read each file and save its content
    for file in files:
        with open(file, 'r') as f:
            content = f.read()
            # Remove all /* ... */ comments
            content = re.sub(re.compile("/\*.*?\*/", re.DOTALL), "", content)
            # Remove all // ... comments
            content = re.sub(re.compile("//.*?$", re.MULTILINE), "", content)
            # Other ideas: Remove // comments, Normalize variables, etc...
            file_to_text[file] = content

    # Get the text of files
    texts = list(file_to_text.values())

    # Calculate tf-idf features for each text
    tfidf_vectorizer = TfidfVectorizer().fit_transform(texts)

    # Calculate the similarity among each pair of documents
    similarities = cosine_similarity(tfidf_vectorizer)

    # Prepare result
    results = []
    num_files = len(files)

    for i in range(num_files):
        for j in range(i+1, num_files):
            similarity = similarities[i][j]*100  # Convert to %
            results.append({"file1": files[i], "file2": files[j], "similarity": similarity})

    # Sort the results based on similarity
    results.sort(key=lambda x: x['similarity'], reverse=True)

    return results

# Use a loop to call calculate_similarity for each file_prefix
results_dict = {prefix: calculate_similarity(files) for prefix, files in files_by_prefix.items()}

# Display results for each file group
for prefix, results in results_dict.items():
    print(f"Results for {prefix} files:")
    for h in results[:5]:
        print(f'{h["file1"]}-{h["file2"]}, {h["similarity"]}\n')
    print("-" * 40)