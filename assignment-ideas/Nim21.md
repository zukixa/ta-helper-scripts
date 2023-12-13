### Programming Assignment Instructions: Nim 21 Game

#### Objective
Develop a simple Nim 21 game in which players take turns to increase a count to exactly 21. The player who is forced to say 21 loses the game. The game should support one human player and two computer-controlled players.

#### Initial Setup

1. Open your preferred Java development environment.
2. Create a new Java class named `Nim21` in your project.

#### Requirements

- Implement the game logic according to the provided sample solution.
- Use the provided random and scanner objects for input and random decisions.
- The game should be played in a console environment.
- Ensure the user can decide whether to play a new round after each completes.

#### Instructions

**Class Structure**

- `main`: Creates a game loop where rounds are played until the user decides to stop.
- `playRound`: Begins a new round, tracks the current count, and determines when the round ends.
- `playerTurn`: Handles human input, validates it, and updates the count accordingly.
- `computerTurn`: Calculates the computer's move and updates the count.
- `bestComputerMove`: Contains the computer's strategy to avoid reaching 21.
- `validateInput`: Validates the human player's input and returns how much to increase the count.

**Game Flow**

1. Display a welcome message.
2. Enter the main game loop:
   - Call `playRound` until the user wishes to stop.
   - After each round, prompt the user to play again.
   - Validate the user’s response to ensure it’s either "yes" or "no."
3. Display a closing message when the user chooses to exit the game.

**Play Round**

- Initialize the count at 0.
- Randomly select which player (human or computer) starts the game by setting `currentPlayer`.
- Continue the game until the count reaches at least 21.
- Depending on the current player, call either `playerTurn` or `computerTurn`.
- Validate and update the count after each turn.
- Declare the loser once 21 is reached or exceeded.
- Rotate turns among players.

**Player Turn**

- Prompt the user for their move.
- Get input from the user.
- Validate the input to ensure it's a continuous sequence of numbers starting from the current count + 1.
- If the input is valid, return the number of numbers counted; otherwise, prompt again.

**Computer Turn**

- Calculate the computer's move using `bestComputerMove`.
- Display the count for each number the computer 'says.'
- Return the computed move count.

**Best Computer Move**

- The computer should try to force the player to reach 21.
- Define a target count that the computer tries to avoid. For example, 20.
- The computer should consider the maximum number it can 'say' in one turn. For example, up to 3.
- Use modular arithmetic to find the optimal move.
- If the current count is close enough to force a loss on another player, do so.

**Validate Input**

- Check if the input is within the valid range (1 to 3 numbers).
- Convert strings to integers and validate if they form a continuous sequence.
- Catch any formatting errors (non-integer input).
- Return the number of valid numbers or an error code if the input is invalid.

#### Testing

- Compile the code and run the program.
- Test the program with various inputs, including invalid ones to ensure proper validation.
- Check that the game ends correctly and declares the right winner.
- Ensure the user can play multiple rounds without issue.

#### Documentation

- Document your code with comments to make it clear what each section does.
