using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCGame
{
    internal class Game
    {
        private GameFunctions game;
        private string GeneratedNum;
        public void GameStart()
        {
            game = new GameFunctions();
            GameFunctions.Enter(); 
            while (true)
            {
                Console.WriteLine("Игра началась!");
                GeneratedNum = GameFunctions.GenerateNumber();
                while (true)
                {
                    int _currentTryNumber = GameFunctions.ReadAndCheckNumber();
                    if (game.CheckPlayerWin(_currentTryNumber, GeneratedNum))
                    {
                        Console.WriteLine($"Вы выйграли, количество попыток: {game.PlayerTries}");
                        GameFunctions.Save(game.PlayerTries);
                        break;
                    }
                    else
                        Console.WriteLine(GameFunctions.CountCowsAndBulls(_currentTryNumber, GeneratedNum));
                }
                GameFunctions.ContinueGameMenu();
            }
           
        }
    }
}
