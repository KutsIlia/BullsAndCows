using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PCGame
{
    internal class GameFunctions
    {
        public int PlayerTries = 0;
        /// <summary>
        /// Метод, проверяющий, выйграл ли игрок или нет
        /// </summary>
        /// <param name="args">Ответ игрока - guess, загаданное число - num </param>
        public bool CheckPlayerWin(int guess, string GeneratedNumber)
        {
            PlayerTries++;
            if (guess.ToString() == GeneratedNumber)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Точка входа в программу (логирование или регистрация)
        /// </summary>
        /// <param name="args">Ответ игрока - guess, загаданное число - num </param>
        public static string CountCowsAndBulls(int guess, string GeneratedNumber)
        {
            int _cows = 0;
            int _bulls = 0;
            foreach (char i in guess.ToString())
            {
                if (GeneratedNumber.Contains(i) && guess.ToString().IndexOf(i) == GeneratedNumber.IndexOf(i))
                {
                    _bulls++;
                    _cows++;
                }

                else if (GeneratedNumber.Contains(i))
                    _cows++;
            }
            return $"Количество угаданных чисел: {_cows}. Количество совпадающих чисел: {_bulls}. Ваша комбинация - {guess}";
        }
        /// <summary>
        /// Сохранение результата игры в файл
        /// </summary>
        /// <param name="args">Количество ходов за игру</param>
        public static void Save(int num)
        {
            try
            {
                StreamWriter _f1 = new StreamWriter("top.txt", true);
                _f1.WriteLine(num);
                _f1.Close();
                StreamReader _read = new StreamReader("top.txt");
                string[] _top = _read.ReadToEnd().Split("\r\n");
                Array.Sort(_top);
                int _temp = Array.IndexOf(_top, num.ToString());
                Console.WriteLine($"Вы попали в топ {Math.Round(_temp /(float)(_top.Length - 1) * 100, 2)}%, место - {_temp}");
                _read.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        /// <summary>
        ///Метод для логирования игрока
        /// </summary>
        private static void LogIn()
        {
            try
            {
                StreamReader _read = new StreamReader("Пароли.txt");
                string[] _info = _read.ReadToEnd().Replace("\r\n", ":").Split(':');
                //проверка введенного пароля и логина
                while (true)
                {
                    Console.Write("Введите логин: ");
                    string _log = Console.ReadLine() ?? "None";
                    Console.Write("Введите пароль: ");
                    string _pass = Console.ReadLine() ?? "None";
                    if (_info.Contains(_log) && _info.Contains(_pass))
                    {
                        Console.Clear();
                        Console.WriteLine("Вы успешно вошли");
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Неверно введен логин или пароль");
                    }
                }
                _read.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        /// <summary>
        /// Метод для регистрации нового игрока
        /// </summary>
        private static void SignIn()
        {
            Random _random = new Random();
            try
            {
                Console.Write("Придумайте логин: ");
                string _log = Console.ReadLine() ?? $"User{_random.Next(1, 1000)}";
                Console.Write("Придумайте пароль: ");
                string? _passw;
                //проверка корректности введенного пароля
                while (true)
                {
                    _passw = Console.ReadLine();
                    if (_passw.Length > 0)
                        break;
                    else
                        Console.Write("Придумайте пароль: ");
                }
                //сохранение информации об игроке в файл
                StreamWriter _write = new StreamWriter("Пароли.txt", true);
                _write.WriteLine($"{_log}:{_passw}");
                _write.Close();
                Console.Clear();
                Console.WriteLine("Вы успешно зарегистрировались");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Точка входа в программу (логирование или регистрация)
        /// </summary>
        public static void Enter()
        {
            Console.WriteLine();
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Авторизация");
            Console.WriteLine("2. Регистрация");
            Console.WriteLine("3. Выход из игры");
            int _flag = 0;

            while (_flag==0)
            {
                Console.Write("Выберите пункт меню (1-4): ");
                string _choice = Console.ReadLine() ?? "None";
                switch (_choice)
                {
                    case "1":
                        LogIn();
                        _flag++;
                        break;
                    case "2":
                        SignIn();
                        _flag++;
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Такого пункта не существует, попробуйте еще раз.");
                        break;
                }            
            }
        }
        public static string GenerateNumber()
        {
            Random random = new Random();
            while (true)
            {
                string _temp = random.Next(100, 10000).ToString();
                if (_temp.Length == 4)
                {
                    if (_temp.Length == _temp.Distinct().Count())
                    {
                        return _temp;
                    }
                }
                else
                {
                    _temp = "0" + _temp;
                    if (_temp.Length == _temp.Distinct().Count())
                    {
                        return _temp;
                    }
                }
            }
        }
        public static int ReadAndCheckNumber()
        {
            Console.Write($"Введите комбинацию из 4 цифр: ");
            string _guess;
            while (true)
            {
                _guess = Console.ReadLine() ?? "None";
                if (_guess.All(char.IsDigit)  || _guess.ToString().Distinct().Count() != _guess.ToString().Length || _guess.ToString().Length != 4)
                {
                    return int.Parse(_guess);
                }
                else
                    Console.Write("Вы ввели неверный формат, введите еще раз: ");
            }
        }
        public static void ContinueGameMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Новая игра");
            Console.WriteLine("2. Выход из аккаунта");
            Console.WriteLine("3. Выход из игры");
            int _flag = 0;
            while (_flag==0)
            {
                Console.Write("Выберите пункт меню (1-3): ");
                string _choice = Console.ReadLine() ?? "None";
                switch (_choice)
                {
                    case "1":
                        _flag++;
                        break;
                    case "2":
                        GameFunctions.Enter();
                        _flag++;
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Такого пункта не существует, попробуйте еще раз.");
                        break;
                }
            }
        }
        
    }
}
