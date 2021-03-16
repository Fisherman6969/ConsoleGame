using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class Program
    {
        static void Main()
        {
            string player_default = "▌"; //Player default
            string player_jump = "▀"; //Player jumping

            bool jump;

            int score = 0;

            Random random = new Random();   //Places the stone

            Console.Clear();
            Console.WriteLine("Ready? (Press any key)");
            Console.ReadKey();

            while (true)
            {
                String[] stone = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " };
                int count = 0;
                int e = random.Next(1, stone.Length);
                stone[e] = "▄";
                do
                {
                    jump = false;

                    System.Threading.Thread.Sleep(300);

                    Console.Clear();

                    Console.Write(player_default); //The Player

                    if(Console.KeyAvailable == true)    //Player jumps
                    {
                        jump = true;
                        Console.ReadKey();  //To reset the boolean
                        Console.Clear();
                        Console.Write(player_jump);
                    }

                    foreach (var item in stone) //
                    {
                        Console.Write(item);
                    }

                    if(stone[0] == "▄" && jump == false)
                    {
                        GameOver(score);
                    }

                    for (int i = 1; i < stone.Length; i++)
                    {
                        stone[i - 1] = stone[i];
                        stone[i] = " ";
                    }
                    count++;
                } while (count < stone.Length);
                score++;
            }
        }
        public static bool KeyAvailable { get; }

        public static void GameOver(int score)
        {
            Console.Clear();
            Console.WriteLine("Game Over!");
            Console.WriteLine("Your Score: " + score);
            Console.ReadKey();
            Main();
            
        }
    }
}
