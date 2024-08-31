using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_03
{
    class Program
    {
        static void Main(string[] args)
        {

            // Просматривая сайты по поиску работы, у вас вызывает интерес следующая вакансия:

            // Требуемый опыт работы: без опыта
            // Частичная занятость, удалённая работа
            //
            // Описание 
            //
            // Стартап «Micarosppoftle» занимающийся разработкой
            // многопользовательских игр ищет разработчиков в свою команду.
            // Компания готова рассмотреть C#-программистов не имеющих опыта в разработке, 
            // но желающих развиваться в сфере разработки игр на платформе .NET.
            //
            // Должность Интерн C#/
            //
            // Основные требования:
            // C#, операторы ввода и вывода данных, управляющие конструкции 
            // 
            // Конкурентным преимуществом будет знание процедурного программирования.
            //
            // Не технические требования: 
            // английский на уровне понимания документации и справочных материалов
            //
            // В качестве тестового задания предлагается решить следующую задачу.
            //
            // Написать игру, в которою могут играть два игрока.
            // При старте, игрокам предлагается ввести свои никнеймы.
            // Никнеймы хранятся до конца игры.
            // Программа загадывает случайное число gameNumber от 12 до 120 сообщая это число игрокам.
            // Игроки ходят по очереди(игра сообщает о ходе текущего игрока)
            // Игрок, ход которого указан вводит число userTry, которое может принимать значения 1, 2, 3 или 4,
            // введенное число вычитается из gameNumber
            // Новое значение gameNumber показывается игрокам на экране.
            // Выигрывает тот игрок, после чьего хода gameNumber обратилась в ноль.
            // Игра поздравляет победителя, предлагая сыграть реванш

            Console.OutputEncoding = System.Text.Encoding.UTF8; //Кодировка вывода консоли
            Console.WriteLine("Добро пожаловать в игру \" Game Number \"");  //Приветствие
            Console.WriteLine("Сколько игроков будет играть?");
            int gamers = Convert.ToInt32(Console.ReadLine());   //Ввод количества игроков
            // Цикл будет повторятся пока игрок не введёт корректное число участников (от 1 до 5)
            while (gamers <= 0 || gamers > 5)
            {
                Console.WriteLine("В эту игру могут играть от 1го до 5ти игроков \n");
                gamers = Convert.ToInt32(Console.ReadLine());
            }

            List<string> players = new List<string>();  // Список игроков
                                                        //Заполнение списка игроков с клавиатуры
            int countGamers = 1;
            for (int i = 0; i < gamers; i++)
            {
                Console.WriteLine($"Введите имя {countGamers}-го игрока.");
                players.Add(Console.ReadLine());
                countGamers++;
            }
            Random randomNumber = new Random();
            int userTryNumber;  // Число которое будет выбрасывать игрок, после оно будет вычитаться из игрового числа 
            string userAnswer;  // Ответ игрока по завершению игры
            //Игрок указывает диапазон игрового числа (число будет случайным в выбранном диапазоне) 
            Console.WriteLine("Введите диапозон случайного числа (Првое число должно быть от 10 до 50. Второе от 50 до 150)");

            Console.WriteLine("Введите первое число: ");
            int gameNumber1 = Convert.ToInt32(Console.ReadLine());
            while (gameNumber1 < 10 || gameNumber1 > 50)
            {
                Console.WriteLine("По правилам игры перве число должно быть в деапозоне от 10 до 50");
                gameNumber1 = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Введите второе число: ");
            int gameNumber2 = Convert.ToInt32(Console.ReadLine());
            while (gameNumber2 < 50 || gameNumber2 > 150)
            {
                Console.WriteLine("По правилам игры второе число должно быть в деапозоне от 50 до 150");
                gameNumber2 = Convert.ToInt32(Console.ReadLine());
            }
            int gameNumber = randomNumber.Next(gameNumber1, gameNumber2);  //Игровое число. Формируется случайное число из диапазона введённого игроком
            
            


            Console.WriteLine($"Игровое число  {gameNumber}"); //Вывод загаданного (случайного) числа
            //Если игрок один то игра будет с компьютером
            if (players.Count == 1)
            {
                Console.WriteLine("Игра с компьютером!");
                players.Add("Computer");
            }
            //Пока игровое число не будет меньше нуля цикл повторится
            while (gameNumber > 0)
            {
                //Каждый игрок по очереди бросает кость 
                for (int i = 0; i < players.Count; i++)
                {
                    userTryNumber = randomNumber.Next(1, 4);
                    //Если все игроки выбыли из игры, то победил оставшийся
                    if (players.Count == 1)
                        {
                        Console.WriteLine($"Остался один игрок {players[i]}: Автопобеда!"); //Вывод победителя
                        Console.WriteLine($"чтобы продолжить введите \"Game\"\nчтобы выйти из игры введите Exit"); //Игра предлагает начать заново или выйти из игры
                        userAnswer = Console.ReadLine();
                        //Пока игрок не введёт корректную команду цикл будет повторяться (Game или Exit)
                            while (userAnswer != "Game" || userAnswer != "Exit")
                            {
                            //Если "Game" игра запустится заново
                                if (userAnswer == "Game")
                                {
                                    Process.Start(Assembly.GetExecutingAssembly().Location);
                                    Environment.Exit(0);
                                    Console.WriteLine($"Нажмите любую клавишу для продолжения");
                                }
                                //Если "Exit" игра завершится
                                if (userAnswer == "Exit")
                                {
                                    System.Environment.Exit(0);
                                }
                                Console.WriteLine($"чтобы продолжить введите \"Game\"\nчтобы выйти из игры введите Exit");
                                userAnswer = Console.ReadLine();
                            }
                        }

                    Console.WriteLine($"Ходит игрок {players[i]}");
                    //Если имя игрока Computer то кости кидаются автоматически
                    if (players[i].Equals("Computer"))
                    {
                        
                    }
                    else
                    {
                        string userTry = Console.ReadLine();
                        //Ход игрока, пока игрок не введёт команду userTry цикл будет повторяться
                        while (userTry != "userTry")
                        {
                            
                            Console.WriteLine("Введите команду \"userTry\" чтобы сделать хода");
                            userTry = Console.ReadLine();
                        }
                    }

                    Console.WriteLine($"Игрок {players[i]} выбросил чило {userTryNumber}");
                    gameNumber -= userTryNumber; //Из игрового числа вычитается число которое выбросил игрок 
                    //Если игровое число после вычитания равно 0 то выводится победитель и игра предлагает начать заново или выйти из игры 
                    if (gameNumber == 0)
                    {
                        Console.WriteLine($"У нас есть победитель! Это игрок под именем {players[i]}");
                        Console.WriteLine($"чтобы продолжить введите \"Game\"\nчтобы выйти из игры введите Exit");
                        userAnswer = Console.ReadLine();
                        while (userAnswer != "Game" || userAnswer != "Exit")
                        {
                            if (userAnswer == "Game")
                            {
                                Process.Start(Assembly.GetExecutingAssembly().Location);
                                Environment.Exit(0);
                                Console.WriteLine($"Нажмите любую клавишу для продолжения");
                            }
                            if (userAnswer == "Exit")
                            {
                                System.Environment.Exit(0);
                            }
                            Console.WriteLine($"чтобы продолжить введите \"Game\"\nчтобы выйти из игры введите Exit");
                            userAnswer = Console.ReadLine();
                        }

                        //break;
                    }
                    //Если игрок зашёл за пределы нуля то он выбывает из игры
                    if (gameNumber < 0)
                    {
                        Console.WriteLine($"Увы игрок {players[i]} выбыл из игры");
                        players.RemoveAt(i);
                        gamers -= 1;
                        Console.ReadKey();

                        //После того как один из игроков выбыл и игроков осталось больше одного,
                        //то задаётся новое игровое число и игра продолжается (от 12 до 40)
                        if (players.Count > 1)
                        {
                            Console.Clear();
                            gameNumber = randomNumber.Next(12, 40);
                            Console.WriteLine("игра продолжается");                            
                            Console.WriteLine("Список игроков:");
                            for (int j = 0; j < players.Count; j++) { Console.Write($"{players[j]}, "); };
                            Console.WriteLine();
                            Console.WriteLine($"Новое игровое число  {gameNumber}");

                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Победил игрок {players[0]}!");
                            Console.WriteLine($"чтобы продолжить введите \"Game\"\nчтобы выйти из игры введите Exit");
                            userAnswer = Console.ReadLine();
                            while (userAnswer != "Game" || userAnswer != "Exit")
                            {
                                if (userAnswer == "Game")
                                {
                                    Process.Start(Assembly.GetExecutingAssembly().Location);
                                    Environment.Exit(0);
                                    Console.WriteLine($"Нажмите любую клавишу для продолжения");
                                }
                                if (userAnswer == "Exit")
                                {
                                    System.Environment.Exit(0);
                                }
                                Console.WriteLine($"чтобы продолжить введите \"Game\"\nчтобы выйти из игры введите Exit");
                                userAnswer = Console.ReadLine();
                            }
                        }
                    }


                    Console.WriteLine($"Игровое число  {gameNumber}");

                }


               
            }
            Console.ReadKey();

        }
    }
}
    


            

            // * Бонус:
            // Подумать над возможностью реализации разных уровней сложности.
            // В качестве уровней сложности может выступать настраиваемое, в начале игры,
            // значение userTry, изменение диапазона gameNumber, или указание большего количества игроков (3, 4, 5...)

            // *** Сложный бонус
            // Подумать над возможностью реализации однопользовательской игры
            // т е игрок должен играть с компьютером


            // Демонстрация
            // Число: 12,
            // Ход User1: 3
            //
            // Число: 9
            // Ход User2: 4
            //
            // Число: 5
            // Ход User1: 2
            //
            // Число: 3
            // Ход User2: 3
            //
            // User2 победил!
        
    

