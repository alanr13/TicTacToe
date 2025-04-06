Game game = new Game();
game.Run();

class Board
{
    public char[,] GameBoard { get; set; }
    public Board()
    {
        GameBoard = new char[,]
        { {' ', ' ', ' ' },
        { ' ', ' ', ' ' },
        {' ', ' ', ' '} };
    }

    public void PrintBoard()
    {
        Console.WriteLine(" {0} | {1} | {2}", GameBoard[0, 0], GameBoard[0, 1], GameBoard[0, 2]);
        Console.WriteLine("---+---+---");
        Console.WriteLine(" {0} | {1} | {2}", GameBoard[1, 0], GameBoard[1, 1], GameBoard[1, 2]);
        Console.WriteLine("---+---+---");
        Console.WriteLine(" {0} | {1} | {2}", GameBoard[2, 0], GameBoard[2, 1], GameBoard[2, 2]);
    }
}

class Player
{
    public char side;
    public int roundsWon = 0;
    public Player()
    {

    }
}

class Game
{
    int round = 0;
    Board board = new Board();
    static char[] side = { 'X', 'O' };
    Player player1 = new Player();
    Player player2 = new Player();
    public Player currentPlayer;
    public Game()
    {

    }

    public void Run()
    {
        while (round < 5)
        {
            round++;
            Console.WriteLine($"Round {round}");
            Thread.Sleep(3000);
            Console.Clear();

            int turns = 0;
            char input;
            currentPlayer = player2;
            Console.WriteLine("Which side do you choose?");
            while (true)
            {
                input = Console.ReadKey().KeyChar;
                if (Char.ToUpper(input) == 'X')
                {
                    player1.side = side[0];
                    player2.side = side[1];
                    break;
                }
                else if (Char.ToUpper(input) == 'O')
                {
                    player1.side = side[1];
                    player2.side = side[0];
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong sign. Try again");
                }
            }

            Console.WriteLine("");
            board.PrintBoard();
            while (true)
            {
                while (true)
                {
                    turns++;
                    Console.WriteLine(currentPlayer == player1 ? $"Player 1, where do you want to place the sign?" : $"Player 2, where do you want to place the sign?");
                    input = Console.ReadKey().KeyChar;
                    if (IsNotOccupied(input))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nThat place is occupied. Try again.");
                    }
                }
                Console.WriteLine("");
                board.PrintBoard();

                if (turns > 8)
                {
                    GameResult();
                    Set2DValue(board.GameBoard);
                    player1.roundsWon++;
                    player2.roundsWon++;
                    break;
                }
                else if(GameDecider())
                {
                    GameResult();
                    Set2DValue(board.GameBoard);
                    currentPlayer.roundsWon++;
                    break;
                }

                if(currentPlayer.roundsWon == 3)
                {
                    Console.WriteLine(currentPlayer == player1 ? $"Player 1 won the game." : $"Player 2 won the game.");
                    Environment.Exit(0);
                }
                if (currentPlayer == player2)
                {
                    currentPlayer = player1;
                }
                else
                {
                    currentPlayer = player2;
                }
            }
        }
    }

    bool GameDecider()
    {
        for (int i = 0; i < board.GameBoard.GetLength(0); i++)
        {
            if ((board.GameBoard[i, 0] == currentPlayer.side && board.GameBoard[i, 1] == currentPlayer.side && board.GameBoard[i, 2] == currentPlayer.side)
                || (board.GameBoard[0, i] == currentPlayer.side && board.GameBoard[1, i] == currentPlayer.side && board.GameBoard[2, i] == currentPlayer.side))
                return true;
        }

        if ((board.GameBoard[0, 0] == currentPlayer.side && board.GameBoard[1, 1] == currentPlayer.side && board.GameBoard[2, 2] == currentPlayer.side)
            || (board.GameBoard[0, 2] == currentPlayer.side && board.GameBoard[1, 1] == currentPlayer.side && board.GameBoard[2, 0] == currentPlayer.side))
            return true;
        return false;
    }
    void GameResult()
    {
        Console.WriteLine(GameDecider() ? $"{currentPlayer} won." : "Draw.");
    }

    bool IsNotOccupied(char choice)
    {
        switch (choice)
        {
            case '1':
                if (board.GameBoard[0, 0] != 'X' && board.GameBoard[0, 0] != 'O')
                {
                    board.GameBoard[0, 0] = currentPlayer.side;
                    return true;
                }
                return false;
            case '2':
                if (board.GameBoard[0, 1] != 'X' && board.GameBoard[0, 1] != 'O')
                {
                    board.GameBoard[0, 1] = currentPlayer.side;
                    return true;
                }
                return false;
            case '3':
                if (board.GameBoard[0, 2] != 'X' && board.GameBoard[0, 2] != 'O')
                {
                    board.GameBoard[0, 2] = currentPlayer.side;
                    return true;
                }
                return false;
            case '4':
                if (board.GameBoard[1, 0] != 'X' && board.GameBoard[1, 0] != 'O')
                {
                    board.GameBoard[1, 0] = currentPlayer.side;
                    return true;
                }
                return false;
            case '5':
                if (board.GameBoard[1, 1] != 'X' && board.GameBoard[1, 1] != 'O')
                {
                    board.GameBoard[1, 1] = currentPlayer.side;
                    return true;
                }
                return false;
            case '6':
                if (board.GameBoard[1, 2] != 'X' && board.GameBoard[1, 2] != 'O')
                {
                    board.GameBoard[1, 2] = currentPlayer.side;
                    return true;
                }
                return false;
            case '7':
                if (board.GameBoard[2, 0] != 'X' && board.GameBoard[2, 0] != 'O')
                {
                    board.GameBoard[2, 0] = currentPlayer.side;
                    return true;
                }
                return false;
            case '8':
                if (board.GameBoard[2, 1] != 'X' && board.GameBoard[2, 1] != 'O')
                {
                    board.GameBoard[2, 1] = currentPlayer.side;
                    return true;
                }
                return false;
            case '9':
                if (board.GameBoard[2, 2] != 'X' && board.GameBoard[2, 2] != 'O')
                {
                    board.GameBoard[2, 2] = currentPlayer.side;
                    return true;
                }
                return false;
            default:
                Console.WriteLine("Wrong number");
                break;

        }
        return false;
    }

    char[,] Set2DValue(char[,] array)
    {
        for(int i = 0; i < array.GetLength(0); i++)
        {
            for(int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = ' ';
            }
        }
        return array;
    }
}
