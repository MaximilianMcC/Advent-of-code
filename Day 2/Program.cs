public class Program {
    
    enum Move
    {
        ROCK = 1,
        PAPER = 2,
        SCISSORS = 3
    }

    public static void Main(string[] args)
    {

        // --- Day 2: Rock Paper Scissors ---

        // Get the data
        string data = File.ReadAllText("./data.txt");
        
        // Get all of the games
        int totalScore = 0;
        string[] games = data.Split("\n");
        foreach (string gameInput in games)
        {
            int score = 0;
            

            // Get the opponents move
            Move opponentsMove = new Move();
            if (gameInput[0] == 'A') opponentsMove = Move.ROCK;
            else if (gameInput[0] == 'B') opponentsMove = Move.PAPER;
            else if (gameInput[0] == 'C') opponentsMove = Move.SCISSORS;

            // Get your move
            Move yourMove = new Move();
            if (gameInput[2] == 'X') yourMove = Move.ROCK;
            else if (gameInput[2] == 'Y') yourMove = Move.PAPER;
            else if (gameInput[2] == 'Z') yourMove = Move.SCISSORS;
            score += (int)yourMove;

            // See who wins
            if (yourMove == opponentsMove) score += 3;
            else {
                if (yourMove == Move.ROCK && opponentsMove == Move.SCISSORS) score += 6;
                else if (yourMove == Move.SCISSORS && opponentsMove == Move.PAPER) score += 6;
                else if (yourMove == Move.PAPER && opponentsMove == Move.ROCK) score += 6;

                if (opponentsMove == Move.ROCK && yourMove == Move.SCISSORS) score += 0;
                else if (opponentsMove == Move.SCISSORS && yourMove == Move.PAPER) score += 0;
                else if (opponentsMove == Move.PAPER && yourMove == Move.ROCK) score += 0;
            }

            totalScore += score;
        }

        Console.WriteLine("Total score: " + totalScore);

    }

}