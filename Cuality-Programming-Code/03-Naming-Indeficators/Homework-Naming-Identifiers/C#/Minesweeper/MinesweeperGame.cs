namespace MinesweeperGame
{
    using System;
    using System.Collections.Generic;

    public class Minesweeper
    {
        public class PlayerPoints
        {
            private string playerName;
            private int playerPoints;

            public string PlayerName
            {
                get
                {
                    return playerName;
                }

                set
                {
                    playerName = value;
                }
            }

            public int PLayerPoints
            {
                get
                {
                    return playerPoints;
                }

                set
                {
                    playerPoints = value;
                }
            }

            public PlayerPoints()
            {
            }

            public PlayerPoints(string playerName, int playerPoints)
            {
                this.playerName = playerName;
                this.playerPoints = playerPoints;
            }
        }

        private static void Main()
        {
            string userInput = string.Empty;
            char[,] gameField = CreateGameField();
            char[,] bombsPositions = PlaceBombs();
            int counter = 0;
            bool haveExplode = false;
            List<PlayerPoints> highscoresChart = new List<PlayerPoints>(6);
            int row = 0;
            int collumn = 0;
            bool gameStart = true;
            const int MaksTurns = 35;
            bool gameEnd = false;

            do
            {
                if (gameStart)
                {
                    Console.WriteLine(
                        "Lets Play “Minesweeper”. Try ti find fields withouth mines."
                        + " Input 'top' shows chart list, 'restart' starts new game, 'exit' exits the game !");
                    PrintGameField(gameField);
                    gameStart = false;
                }

                Console.Write("Enter Row and Column values : ");
                userInput = Console.ReadLine().Trim();
                if (userInput.Length >= 3)
                {
                    bool validRow = int.TryParse(userInput[0].ToString(), out row);
                    bool validColumn = int.TryParse(userInput[2].ToString(), out collumn);
                    bool validRowIndex = row <= gameField.GetLength(0);
                    bool validColumnIndex = collumn <= gameField.GetLength(1);
                    bool validInput = validRow && validColumn && validRowIndex && validColumnIndex;
                    
                    if (validInput)
                    {
                        userInput = "turn";
                    }
                }

                switch (userInput)
                {
                    case "top":
                        CreateHighscoresChart(highscoresChart);
                        break;
                    case "restart":
                        gameField = CreateGameField();
                        bombsPositions = PlaceBombs();
                        PrintGameField(gameField);
                        haveExplode = false;
                        gameStart = false;
                        break;
                    case "exit":
                        Console.WriteLine("Game Over!");
                        break;
                    case "turn":
                        if (bombsPositions[row, collumn] != '*')
                        {
                            if (bombsPositions[row, collumn] == '-')
                            {
                                ChangeTurnOfPlayer(gameField, bombsPositions, row, collumn);
                                counter++;
                            }

                            if (MaksTurns == counter)
                            {
                                gameEnd = true;
                            }
                            else
                            {
                                PrintGameField(gameField);
                            }
                        }
                        else
                        {
                            haveExplode = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\n Invalid Input !\n");
                        break;
                }

                if (haveExplode)
                {
                    PrintGameField(bombsPositions);
                    Console.Write("\n You Loose! You finished the game with {0} points. Enter your nickname : ", counter);
                    string playerName = Console.ReadLine();
                    PlayerPoints t = new PlayerPoints(playerName, counter);
                    if (highscoresChart.Count < 5)
                    {
                        highscoresChart.Add(t);
                    }
                    else
                    {
                        for (int i = 0; i < highscoresChart.Count; i++)
                        {
                            if (highscoresChart[i].PLayerPoints < t.PLayerPoints)
                            {
                                highscoresChart.Insert(i, t);
                                highscoresChart.RemoveAt(highscoresChart.Count - 1);
                                break;
                            }
                        }
                    }

                    highscoresChart.Sort((PlayerPoints nameA, PlayerPoints nameB) => nameB.PlayerName.CompareTo(nameA.PlayerName));
                    highscoresChart.Sort((PlayerPoints pointA, PlayerPoints pointB) => pointB.PLayerPoints.CompareTo(pointA.PLayerPoints));
                    CreateHighscoresChart(highscoresChart);

                    gameField = CreateGameField();
                    bombsPositions = PlaceBombs();
                    counter = 0;
                    haveExplode = false;
                    gameStart = true;
                }

                if (gameEnd)
                {
                    Console.WriteLine("\n Congratulations ! You opened 35 boxes without touching a mine.");
                    PrintGameField(bombsPositions);
                    Console.WriteLine("Enter your nickname : ");
                    string playerName = Console.ReadLine();
                    PlayerPoints points = new PlayerPoints(playerName, counter);
                    highscoresChart.Add(points);
                    CreateHighscoresChart(highscoresChart);
                    gameField = CreateGameField();
                    bombsPositions = PlaceBombs();
                    counter = 0;
                    gameEnd = false;
                    gameStart = true;
                }
            }

            while (userInput != "exit");
            Console.WriteLine("Thank you for playing Minesweeper Game !");
            Console.WriteLine("Good Bye.");
            Console.Read();
        }

        private static void CreateHighscoresChart(List<PlayerPoints> playerPoints)
        {
            Console.WriteLine("Points :");
            if (playerPoints.Count > 0)
            {
                for (int playerPosition = 0; playerPosition < playerPoints.Count; playerPosition++)
                {
                    Console.WriteLine("{0}. {1} --> {2} Boxes",
                        playerPosition + 1,
                        playerPoints[playerPosition].PlayerName,
                        playerPoints[playerPosition].PLayerPoints);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Highscores Chart is empty !\n");
            }
        }

        private static void ChangeTurnOfPlayer(char[,] gameField, char[,] bombsPositions, int row, int column)
        {
            char bombsQuantity = BombsCounter(bombsPositions, row, column);
            bombsPositions[row, column] = bombsQuantity;
            gameField[row, column] = bombsQuantity;
        }

        private static void PrintGameField(char[,] gameField)
        {
            int gameFieldRowsQuantity = gameField.GetLength(0);
            int gamefieldColumnsQuantity = gameField.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int rowCounter = 0; rowCounter < gameFieldRowsQuantity; rowCounter++)
            {
                Console.Write("{0} | ", rowCounter);
                for (int columnCounter = 0; columnCounter < gamefieldColumnsQuantity; columnCounter++)
                {
                    Console.Write(String.Format("{0} ", gameField[rowCounter, columnCounter]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateGameField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int rowCounter = 0; rowCounter < boardRows; rowCounter++)
            {
                for (int columnCounter = 0; columnCounter < boardColumns; columnCounter++)
                {
                    board[rowCounter, columnCounter] = '?';
                }
            }

            return board;
        }

        private static char[,] PlaceBombs()
        {
            int fieldRows = 5;
            int fieldCollumns = 10;
            char[,] gameFieldWithBombs = new char[fieldRows, fieldCollumns];

            for (int rowCounter = 0; rowCounter < fieldRows; rowCounter++)
            {
                for (int columnCounter = 0; columnCounter < fieldCollumns; columnCounter++)
                {
                    gameFieldWithBombs[rowCounter, columnCounter] = '-';
                }
            }

            List<int> randomIntegerList = new List<int>();
            while (randomIntegerList.Count < 15)
            {
                Random random = new Random();
                int randomInteger = random.Next(50);
                if (!randomIntegerList.Contains(randomInteger))
                {
                    randomIntegerList.Add(randomInteger);
                }
            }

            foreach (int randomInteger in randomIntegerList)
            {
                int currentCollumn = randomInteger / fieldCollumns;
                int currentRow = randomInteger % fieldCollumns;
                if (currentRow == 0 && randomInteger != 0)
                {
                    currentCollumn--;
                    currentRow = fieldCollumns;
                }
                else
                {
                    currentRow++;
                }

                gameFieldWithBombs[currentCollumn, currentRow - 1] = '*';
            }

            return gameFieldWithBombs;
        }

        private static void CalculateBombsQuantity(char[,] gameField)
        {
            int column = gameField.GetLength(0);
            int row = gameField.GetLength(1);

            for (int columnCounter = 0; columnCounter < column; columnCounter++)
            {
                for (int rowCounter = 0; rowCounter < row; rowCounter++)
                {
                    if (gameField[columnCounter, rowCounter] != '*')
                    {
                        char bombsQuantity = BombsCounter(gameField, columnCounter, rowCounter);
                        gameField[columnCounter, rowCounter] = bombsQuantity;
                    }
                }
            }
        }

        private static char BombsCounter(char[,] bombs, int row, int column)
        {
            int bombsQuantity = 0;
            int rows = bombs.GetLength(0);
            int columns = bombs.GetLength(1);

            if (row - 1 >= 0)
            {
                if (bombs[row - 1, column] == '*')
                {
                    bombsQuantity++;
                }
            }

            if (row + 1 < rows)
            {
                if (bombs[row + 1, column] == '*')
                {
                    bombsQuantity++;
                }
            }

            if (column - 1 >= 0)
            {
                if (bombs[row, column - 1] == '*')
                {
                    bombsQuantity++;
                }
            }

            if (column + 1 < columns)
            {
                if (bombs[row, column + 1] == '*')
                {
                    bombsQuantity++;
                }
            }

            if ((row - 1 >= 0) && (column - 1 >= 0))
            {
                if (bombs[row - 1, column - 1] == '*')
                {
                    bombsQuantity++;
                }
            }

            if ((row - 1 >= 0) && (column + 1 < columns))
            {
                if (bombs[row - 1, column + 1] == '*')
                {
                    bombsQuantity++;
                }
            }

            if ((row + 1 < rows) && (column - 1 >= 0))
            {
                if (bombs[row + 1, column - 1] == '*')
                {
                    bombsQuantity++;
                }
            }

            if ((row + 1 < rows) && (column + 1 < columns))
            {
                if (bombs[row + 1, column + 1] == '*')
                {
                    bombsQuantity++;
                }
            }

            return char.Parse(bombsQuantity.ToString());
        }
    }
}