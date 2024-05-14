import glob
import re
from sklearn.feature_extraction.text import TfidfVectorizer
from sklearn.metrics.pairwise import cosine_similarity

# Helper function to read and preprocess a file
def read_and_preprocess_file(file_path):
    with open(file_path, 'r') as f:
        content = f.read()
        content = re.sub(re.compile("/\*.*?\*/", re.DOTALL), "", content)  # Remove all /* ... */ comments
        content = re.sub(re.compile("//.*?$", re.MULTILINE), "", content)  # Remove all // ... comments
    return content

# Function to calculate similarity with a reference file
def calculate_similarity_with_reference(reference_file, other_files):
    file_to_text = {}

    # Read and preprocess the reference file
    ref_content = read_and_preprocess_file(reference_file)
    file_to_text[reference_file] = ref_content

    # Read and preprocess other files
    for file in other_files:
        file_content = read_and_preprocess_file(file)
        file_to_text[file] = file_content

    # Get the text of files
    texts = list(file_to_text.values())

    # Calculate tf-idf features for each text
    tfidf_vectorizer = TfidfVectorizer().fit_transform(texts)

    # Calculate the similarity of each file to the reference file
    similarities = cosine_similarity(tfidf_vectorizer[0:1], tfidf_vectorizer[1:])

    # Prepare result - comparing all other files to the reference file
    results = [{"file1": reference_file, "file2": other_files[i], "similarity": similarities[0][i]*100} for i in range(len(other_files))]

    # Sort the results based on similarity
    results.sort(key=lambda x: x['similarity'], reverse=True)

    return results

# List all Java files except the reference file
all_files = glob.glob("*.java")
reference_file = input("Please enter the file name of the reference file with extension: ")
all_files.remove(reference_file)  # Remove the reference file from the list of files to be compared

# Calculate similarity of all files with the reference file
results = calculate_similarity_with_reference(reference_file, all_files)

# Display results
print(f"Results for files compared to {reference_file}:")
for result in results:
    print(f'{result["file1"]} - {result["file2"]}: Similarity={result["similarity"]}%')
    
