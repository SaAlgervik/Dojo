using TicTac;
using FluentAssertions;

namespace Tests;

public class GameTests
{
    [Fact]
    public void PrintBoard_WhenGameStarts_ShouldPrintEmptyBoard()
    {
        // Arrange
        var game = new Game();
        const string expectedOutput = "==========\r\n 1 | 2 | 3 \r\n---+---+---\r\n 4 | 5 | 6 \r\n---+---+---\r\n 7 | 8 | 9 \r\n==========\r\n";
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        game.PrintBoard();

        // Assert
        var output = stringWriter.ToString();
        output.Should().Be(expectedOutput);
    }
    
    [Fact]
    public void PlayGame_WhenPlayerOnePicksNrOne_BoardShouldPrintXOnNrOne()
    {
        //Arrange
        var game = new Game();
        const string expectedOutput = "==========\r\n X | 2 | 3 \r\n---+---+---\r\n 4 | 5 | 6 \r\n---+---+---\r\n 7 | 8 | 9 \r\n==========\r\n";
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        game.PlayerMove(1);
        
        //Act
        game.PrintBoard();

        
        //Assert
        var output = stringWriter.ToString();
        output.Should().Be(expectedOutput);
    }
    
    [Fact]
    public void PlayGame_WhenBotTurn_ShouldPickBetweenOneAndNine()
    {
        //Arrange
        var game = new Game();
        
        //Act
        var botTurn = game.BotMove();

        //Assert
        botTurn.Should().BeInRange(1, 9);

    }
    
    //This is not a good way to test this, but I don't know how to test random in a good way with the time box we have  
    [Fact]
    public void PlayGame_WhenBotTurn_ShouldNotPickTakenNumber()
    {
        //Arrange
        var game = new Game
        {
            Board = new[,]
            {
                { 'X', 'X', 'O' },
                { 'O', '5', 'O' },
                { 'O', 'X', 'X' }
            }
        };

        //Act
        var botTurn = game.BotMove();

        //Assert
        botTurn.Should().Be(5);
    }
    
    [Fact]
    public void PlayGame_WhenPlayerTurn_ShouldNotPickTakenNumber()
    {
        //Arrange
        var game = new Game
        {
            Board = new[,]
            {
                { 'X', '2', '3' },
                { 'O', '5', '6' },
                { 'O', 'X', 'X' }
            }
        };

        //Act
        var playerCanMove = game.PlayerMove(1);

        //Assert
        playerCanMove.Should().BeFalse();
    }

    
    [Fact]
    public void PlayGame_WhenPlayed_ShouldRunNineRounds()
    {
        //Arrange
        var game = new Game
        {
            Turn = 0
        };
    
        //Act
        game.PlayGame();
        
        //Assert
        game.Turn.Should().Be(9);
    }
}