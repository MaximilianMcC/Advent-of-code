using System;
using System.IO;

public class Program {
    
    enum Move
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3,

        Lose = 1,
        Draw = 2,
        Win = 3
    }

    public static void Main(string[] args)
    {

        // --- Day 2: Rock Paper Scissors ---

        // Get the data
        string data = File.ReadAllText("./Day2/data.txt");
        
        // Get all of the games
        string[] games = data.Split("\n");

        // Part 1
        int totalScore1 = 0;
        foreach (string gameInput in games)
        {
            int score = 0;
            

            // Get the opponents move
            Move opponentsMove = new Move();
            if (gameInput[0] == 'A') opponentsMove = Move.Rock;
            else if (gameInput[0] == 'B') opponentsMove = Move.Paper;
            else if (gameInput[0] == 'C') opponentsMove = Move.Scissors;

            // Get your move
            Move yourMove = new Move();
            if (gameInput[2] == 'X') yourMove = Move.Rock;
            else if (gameInput[2] == 'Y') yourMove = Move.Paper;
            else if (gameInput[2] == 'Z') yourMove = Move.Scissors;
            score += (int)yourMove;

            // See who wins
            if (yourMove == opponentsMove) score += 3;
            else {
                if (yourMove == Move.Rock && opponentsMove == Move.Scissors) score += 6;
                else if (yourMove == Move.Scissors && opponentsMove == Move.Paper) score += 6;
                else if (yourMove == Move.Paper && opponentsMove == Move.Rock) score += 6;

                if (opponentsMove == Move.Rock && yourMove == Move.Scissors) score += 0;
                else if (opponentsMove == Move.Scissors && yourMove == Move.Paper) score += 0;
                else if (opponentsMove == Move.Paper && yourMove == Move.Rock) score += 0;
            }

            totalScore1 += score;
        }

        // Part 2
        int totalScore2 = 0;
        foreach (string gameInput in games)
        {
            int score = 0;
            

            // Get the opponents move
            Move opponentsMove = new Move();
            if (gameInput[0] == 'A') opponentsMove = Move.Rock;
            else if (gameInput[0] == 'B') opponentsMove = Move.Paper;
            else if (gameInput[0] == 'C') opponentsMove = Move.Scissors;

            // Get your move
            Move yourMove = new Move();
            if (gameInput[2] == 'X') yourMove = Move.Lose;
            else if (gameInput[2] == 'Y') yourMove = Move.Draw;
            else if (gameInput[2] == 'Z') yourMove = Move.Win;

            // Get new moves
            if (yourMove == Move.Lose)
            {
                if (opponentsMove == Move.Rock) yourMove = Move.Scissors;
                else if (opponentsMove == Move.Scissors) yourMove = Move.Paper;
                else if (opponentsMove == Move.Paper) yourMove = Move.Rock;
            }
            else if (yourMove == Move.Draw) yourMove = opponentsMove;
            else if (yourMove == Move.Win)
            {
                if (opponentsMove == Move.Scissors) yourMove = Move.Rock;
                else if (opponentsMove == Move.Paper) yourMove = Move.Scissors;
                else if (opponentsMove == Move.Rock) yourMove = Move.Paper;
            }
            score += (int)yourMove;

            // See who wins
            if (yourMove == opponentsMove) score += 3;
            else
            {
                if (yourMove == Move.Rock && opponentsMove == Move.Scissors) score += 6;
                else if (yourMove == Move.Scissors && opponentsMove == Move.Paper) score += 6;
                else if (yourMove == Move.Paper && opponentsMove == Move.Rock) score += 6;

                if (opponentsMove == Move.Rock && yourMove == Move.Scissors) score += 0;
                else if (opponentsMove == Move.Scissors && yourMove == Move.Paper) score += 0;
                else if (opponentsMove == Move.Paper && yourMove == Move.Rock) score += 0;
            }

            totalScore2 += score;
        }

        // Answers
        Console.WriteLine("Total score for part 1: " + totalScore1);
        Console.WriteLine("Total score for part 2: " + totalScore2);
    }

}