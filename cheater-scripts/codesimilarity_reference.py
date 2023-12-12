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
    
# tekleabelweldeab_4140667_113046019_Point.java
# tekleabelweldeab_4140667_113046019_Point.java - carrenoalfonso_4352839_113049537_Point.java: Similarity=88.03373719824538%
# tekleabelweldeab_4140667_113046019_Point.java - lora_4135378_113031228_Point.java: Similarity=39.10187623190932%
# tekleabelweldeab_4140667_113046019_Point.java - maldonadojissel_4391652_113021656_Point.java: Similarity=36.885148730866526%
# tekleabelweldeab_4140667_113046019_Point.java - vorkfrederik_4284912_113035586_Point.java: Similarity=35.971616250131426%
# tekleabelweldeab_4140667_113046019_Point.java - bachourvictor_4234486_113034483_Point.java: Similarity=35.13936420028029%
# tekleabelweldeab_4140667_113046019_Point.java - issoupovdaniel_4371779_113013457_Point.java: Similarity=34.802855579016715%
# ... 
# tekleabelweldeab_4140667_113046019_Point.java - mudaliarnishita_4248608_113048070_PointArrayTester-1.java: Similarity=1.219213703309855%
# tekleabelweldeab_4140667_113046019_Point.java - krivenkosavva_4369452_113011730_PointArrayTester-1.java: Similarity=1.033531254568391%
# tekleabelweldeab_4140667_113046019_Point.java - shehadehjad_4377767_113047881_PointArrayTester-2.java: Similarity=0.9545560095703991%
# tekleabelweldeab_4140667_113046019_Point.java - doanryan_4251182_113044227_PointArrayTester.java: Similarity=0.8630562288051017%
# tekleabelweldeab_4140667_113046019_Point.java - yimjoel_4324074_113048808_PointArrayTester.java: Similarity=0.8221391483305642%
# tekleabelweldeab_4140667_113046019_Point.java - kumardaksh_4258507_113044437_PointArrayTester.java: Similarity=0.49917693566984644%
# -------------
# tekleabelweldeab_4140667_113046021_PointArray.java
# tekleabelweldeab_4140667_113046021_PointArray.java - vorkfrederik_4284912_113035588_PointArray.java: Similarity=79.75955368546715%
# tekleabelweldeab_4140667_113046021_PointArray.java - phamnathan_4357802_113044069_PointArray.java: Similarity=79.40429014575983%
# tekleabelweldeab_4140667_113046021_PointArray.java - kennedyjj_4227960_112998373_PointArray.java: Similarity=75.27067859187831%
# tekleabelweldeab_4140667_113046021_PointArray.java - mohamedridwan_4246974_113049934_PointArray.java: Similarity=74.17490321133472%
# tekleabelweldeab_4140667_113046021_PointArray.java - mokhnatkinroman_4256980_113044660_PointArray.java: Similarity=74.01484141778022%
# tekleabelweldeab_4140667_113046021_PointArray.java - huangcheng_4381715_112986804_PointArray.java: Similarity=68.34638572633979%
# tekleabelweldeab_4140667_113046021_PointArray.java - ismailbalkhais_4259330_113045513_PointArray.java: Similarity=67.90628743611117%
# tekleabelweldeab_4140667_113046021_PointArray.java - yishakyariedmehari_4076827_113026104_PointArray.java: Similarity=63.37817748727789%
# tekleabelweldeab_4140667_113046021_PointArray.java - mudaliarnishita_4248608_113048067_PointArray-1.java: Similarity=61.12389724200492%
# ...
# tekleabelweldeab_4140667_113046021_PointArray.java - issoupovdaniel_4371779_113013459_PointArrayTester.java: Similarity=6.33197394476856%
# tekleabelweldeab_4140667_113046021_PointArray.java - bonaseracaleb_4377432_113047479_PointArrayTester.java: Similarity=6.308223770728016%
# tekleabelweldeab_4140667_113046021_PointArray.java - yimjoel_4324074_113048808_PointArrayTester.java: Similarity=6.117809144032436%
# tekleabelweldeab_4140667_113046021_PointArray.java - krivenkosavva_4369452_113011730_PointArrayTester-1.java: Similarity=5.409457114317222%
# tekleabelweldeab_4140667_113046021_PointArray.java - wuudylan_4222998_113032074_PointArrayTester.java: Similarity=4.983090299960386%
# -------------
# tekleabelweldeab_4140667_113046023_PointArrayTester.java
# tekleabelweldeab_4140667_113046023_PointArrayTester.java - yishakyariedmehari_4076827_113026105_PointArrayTester.java: Similarity=68.23597163936084%
# tekleabelweldeab_4140667_113046023_PointArrayTester.java - ramosnoahliljoshua_4259816_113019807_PointArrayTester.java: Similarity=46.80312436896873%
# tekleabelweldeab_4140667_113046023_PointArrayTester.java - demyanyukandriy_4138764_113049735_PointsArrayTester.java: Similarity=40.078670268492004%
# tekleabelweldeab_4140667_113046023_PointArrayTester.java - phammegan_4373971_113037119_PointArrayTester.java: Similarity=36.15617599344097%
# tekleabelweldeab_4140667_113046023_PointArrayTester.java - doanryan_4251182_113044227_PointArrayTester.java: Similarity=33.42234391608906%
# ...
# tekleabelweldeab_4140667_113046023_PointArrayTester.java - krivenkosavva_4369452_113011726_Point-1.java: Similarity=1.607101168210678%
# tekleabelweldeab_4140667_113046023_PointArrayTester.java - tekleabelweldeab_4140667_113046019_Point.java: Similarity=1.5085043749963363%
# tekleabelweldeab_4140667_113046023_PointArrayTester.java - wuudylan_4222998_113032072_Point.java: Similarity=1.4616067397359853%
# tekleabelweldeab_4140667_113046023_PointArrayTester.java - tangriley_4095970_112989185_Point.java: Similarity=1.2549117940442769%