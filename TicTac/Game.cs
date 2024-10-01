namespace TicTac;

public class Game
{
    public int Turn = 0;
    private const char  Player = 'X';
    private const char Bot = 'O';

    public char[,] Board =
    {
        { '1', '2', '3' },
        { '4', '5', '6' },
        { '7', '8', '9' }
    };

    public void PrintBoard()
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

    public void PlayerMove(int position)
    {
        if (position == 1)
        {
            Board[0, 0] = 'X';
        }
    }
    
    public int BotTurn()
    {
        int botPosition;
        
        while (true)
        {
            botPosition = new Random().Next(1, 10);
            var row = (botPosition - 1) / 3;
            var col = (botPosition - 1) % 3;

            if (Board[row, col] == 'X' || Board[row, col] == 'O') continue;
            
            Board[row, col] = Bot;
            break;
        }

        return botPosition;
    }
}