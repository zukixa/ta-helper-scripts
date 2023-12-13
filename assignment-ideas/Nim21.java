import java.util.Random;
import java.util.Scanner;

public class Nim21 {
    private static final Scanner scanner = new Scanner(System.in);
    private static final Random random = new Random();
    private static int currentPlayer; // 0 for human, 1 and 2 for computers

    public static void main(String[] args) {
        System.out.println("Welcome to the Nim 21 Game!");
        boolean playAgain = true;

        while (playAgain) {
            playRound();
            System.out.print("Play again? (yes/no): ");
            String playAgainResponse = scanner.next();
            playAgain = "yes".equalsIgnoreCase(playAgainResponse.trim());
            scanner.nextLine(); // Clear buffer
        }

        System.out.println("Thank you for playing Nim 21!");
    }

    private static void playRound() {
        int count = 0;
        currentPlayer = random.nextInt(3); // Randomly select starter of the game

        while (count < 21) {
            System.out.println("\nCurrent count: " + count);
            count += (currentPlayer == 0) ? playerTurn(count) : computerTurn(count);

            if (count >= 21) {
                System.out.println("Player " + currentPlayer + " reached 21 and loses!");

                if (currentPlayer == 0) {
                    System.out.println("You lose. Better luck next time!");
                } else {
                    System.out.println("Computer player " + currentPlayer + " loses!");
                }
                break;
            }

            currentPlayer = (currentPlayer + 1) % 3; // Switch turns
        }
    }

    private static int playerTurn(int currentCount) {
        while (true) {
            System.out.print("Your turn - enter your numbers: ");
            String input = scanner.nextLine();
            String[] parts = input.trim().split("\\s+");
            int numbersCounted = validateInput(parts, currentCount);

            if (numbersCounted > 0) {
                return numbersCounted;
            }
            System.out.println("Invalid input. Please try again.");
        }
    }

    private static int computerTurn(int currentCount) {
        // The computer uses its strategy to determine and display the best move
        int moveCount = bestComputerMove(currentCount);
        for (int i = 1; i <= moveCount; i++) {
            System.out.println("Computer " + currentPlayer + " counts " + (currentCount + i));
        }
        return moveCount; // This is the number of moves/count the computer made
    }

    // Strategy logic to return the number of counts to move
    private static int bestComputerMove(int currentCount) {
        int targetCount = 20; // Goal is not to say this
        int maxCount = 3; // Maximum count per turn

        // Strategy to play optimally and not to get to 21
        if (currentCount < targetCount - maxCount) {
            int modResult = (targetCount - currentCount - 1) % (maxCount + 1);
            return modResult == 0 ? 1 : modResult;
        }

        return Math.min(Math.max(targetCount - currentCount, 1), maxCount);
    }

    private static int validateInput(String[] inputParts, int currentCount) {
        if (inputParts.length < 1 || inputParts.length > 4) {
            return -1;
        }
        int count = 0;
        for (String part : inputParts) {
            try {
                int num = Integer.parseInt(part);
                if (num != currentCount + count + 1) {
                    return -1;
                }
                count++;
            } catch (NumberFormatException e) {
                return -1;
            }
        }

        return count;
    }
}