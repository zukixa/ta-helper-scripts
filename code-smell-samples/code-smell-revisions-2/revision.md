# Code Improvement Report

This report details the initiatives conducted following improvement requests on code samples pp7-pp9.cs. The requested improvements aimed to refine the code samples based on peer review sessions, discussions, and incorporating feedback into an iterative process.

## Improvement Requests Summary:

Suggestions were made to iteratively test and refine the provided code samples through peer reviews and discussions. Here's an outline of the proposed enhancements:

- **Clarification Improvements**: Replace the text of the generically labeled links, such as “Link to further explanation”, with text that names the code smell, such as “See G16: Obscured Intent”. This will help the reader learn the code smell name, without having to click through the link each time. It also will allow the reader to see which items are for the same or different code smells.
- **Add additional explanations:** The .md file organizes the code smells conceptually, which is useful to show how things relate, but it makes it difficult to see which line of the source code has which code smells. Is there a way to make it visually clear that a particular line of code is associated with a particular set of code smells?
- **Clarify & Continue User Testing**: In the description of the user testing, list the number of students it was tested on, also do one or more rounds of user testing and revisions, until the user testing is not revealing much to improve.

## Conducted Efforts:
- **Iterative Testing with Students**: The code samples pp7-pp9.cs were tested iteratively with two students, each getting one try at each of the three improved variants, making the total of Unit Tests conducted at 7 students.

## Implemented Changes:
- **Table Construction**: The corresponding .md files have been updated with their new line values, and have been improved with the displayment of a table at the top of the markdown file, directly connecting the line number to the code smell in question. This was implemented in pp10.cs and pp11.cs
- **Additional Explanations**: As for pp11.cs, as it is a direct real-world example, the exact correspondence to code smells was not possible, so a summarized version of the original explanation was put into pp12small.md -- whereas the old version still resides in pp12full.md -- which was a decision as part of a student being overwhelmed at the full explanation provided by pp9.md, the precursor.
- **More content**: pp10.cs and pp11.cs have received additional codesmells into their loop, which are more tricky ones, as one student has cited those two files to be "largely good, but too reliant on obvious code-smells." 

It is anticipated that these changes will improve the pedagogical value of the code samples and encourage a deeper understanding of code quality through practical analysis and discussion.