# Code Improvement Report

This report details the initiatives conducted following improvement requests on code samples pp4-pp6.cs. The requested improvements aimed to refine the code samples based on peer review sessions, discussions, and incorporating feedback into an iterative process.

## Improvement Requests Summary:

Suggestions were made to iteratively test and refine the provided code samples through peer reviews and discussions. Here's an outline of the proposed enhancements:

- **Iterative Testing**: Conduct tests on the code samples with peers to identify code smells.
- **Peer Feedback**: Share the code without comments for blind review, conduct "show and discover" sessions to compare findings.
- **Discussion on Code Smells**: Talk about contentious code smells and explore alternative perspectives and solutions.
- **Code Smell Expansion**: In discussions, extend the scope of potential code smells to be embedded in the code samples.
- **Refinement Process**: Enhance the code samples based on collected information and repeat the process until no more significant improvements can be made.
- **Documentation**: In the annotated code samples, include a link or ID to each code smell as referenced in Martin Fowler’s book "Clean Code" (Chapter 17) and an explanatory video attachment.

## Conducted Efforts:

- **Iterative Testing with Students**: The code samples pp4-pp6.cs were tested iteratively with multiple students.

### Findings:

- **Lack of Clear Guidance**: Students indicated the absence of a well-defined rubric or checklist to identify code smells.
- **Insufficient Context**: Particularly for pp4, there was a need to add more context to the program, as it appeared overly simplistic.
- **Explanatory Deficits**: The examples lacked proper explanations, categorizations, and links providing the rationale for identified code smells.
- **Difficulty Level**: While pp4.cs was considered too basic, pp5 and pp6 were not viewed as relatable to real-world scenarios.
- **Enriching Assignments**: Recommending the inclusion of explanations for identified code smells to facilitate learning.

## Implemented Changes:

- **Integration of Code Smells**: Migrated key code smells from pp4.cs to pp5.cs, creating a new sample called pp7.cs.
- **Status Quo for Well-Received Code**: Maintaining pp6.cs as it was and renaming it to pp8.cs due to positive feedback.
- **Real World Example Transformation**: Introduced pp9.cs, which is adapted from a real JavaScript example on GitHub to C#, reflecting the preferred coding language in this context.
- **Enhanced Documentation**: All code samples from pp7 to pp8 now include comprehensive explanations detailing code smell categories, occurrence lines, and appropriate links to their explanations. pp9 uses the documentation already provided by the github sample, as it is extremely detailed in itself already.

It is anticipated that these changes will improve the pedagogical value of the code samples and encourage a deeper understanding of code quality through practical analysis and discussion.