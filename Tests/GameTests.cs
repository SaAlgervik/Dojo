using TicTac;
using FluentAssertions;

namespace Tests;

public class GameTests
{
    [Fact]
    public void PrintBoard_WhenGameStarts_ShouldPrintEmptyBoard()
    {
        // Arrange
        const string expectedOutput = "==========\r\n 1 | 2 | 3 \r\n---+---+---\r\n 4 | 5 | 6 \r\n---+---+---\r\n 7 | 8 | 9 \r\n==========\r\n";
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Game.PrintBoard();

        // Assert
        var output = stringWriter.ToString();
        output.Should().Be(expectedOutput);
    }
    
    [Fact]
    public void PlayGame_WhenPlayerOnePicksNrOne_BoardShouldPrintXOnNrOne()
    {
        //Arrange
        const string expectedOutput = "==========\r\n X | 2 | 3 \r\n---+---+---\r\n 4 | 5 | 6 \r\n---+---+---\r\n 7 | 8 | 9 \r\n==========\r\n";
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        Game.PlayerMove(1);
        
        //Act
        Game.PrintBoard();

        
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
        var botTurn = game.BotTurn();


        //Assert
        botTurn.Should().BeInRange(1, 9);

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