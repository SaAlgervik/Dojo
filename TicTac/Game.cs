namespace TicTac;

public class Game
{
    public int Turn = 0;
    public char Player = 'X';

    private static readonly char[,] Board =
    {
        { '1', '2', '3' },
        { '4', '5', '6' },
        { '7', '8', '9' }
    };

    public static void PrintBoard()
    {
        Console.WriteLine("==========");
        Console.WriteLine($" {Board[0, 0]} | {Board[0, 1]} | {Board[0, 2]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {Board[1, 0]} | {Board[1, 1]} | {Board[1, 2]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {Board[2, 0]} | {Board[2, 1]} | {Board[2, 2]} ");
        Console.WriteLine("==========");
    }

    public void PlayGame()
    {
        while (Turn < 9)
        {
            Turn++;
        }
    }

    public static void PlayerMove(int position)
    {
        if (position == 1)
        {
            Board[0, 0] = 'X';
        }
    }
    
    public int BotTurn()
    {
        return new Random().Next(1, 9);
    }
}