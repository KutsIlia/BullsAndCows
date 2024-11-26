using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PCGame
{
    internal class Game
    {
        private GameMethods game;
        private string generatedNum;
        /// <summary>
        /// Запускает процесс игры
        /// </summary>
        public void GameStart()
        {
            game = new GameMethods();
            game.Enter();
            while (true)
            {
                Console.WriteLine("Игра началась!");
                generatedNum = game.GenerateNumber();
                while (true)
                {
                    string _currentTryNumber = game.ReadAndCheckNumber();
                    if (game.CheckPlayerWin(_currentTryNumber, generatedNum))
                    {
                        Console.WriteLine($"Вы выйграли, количество попыток: {game.PlayerTries}");
                        game.Save(game.PlayerTries);
                        break;
                    }
                    else
                        Console.WriteLine(game.CountCowsAndBulls(_currentTryNumber, generatedNum));
                }
                game.ContinueGameMenu();
            }

        }
    }
}
