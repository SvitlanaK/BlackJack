using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("PRESS ENTER, PLEASE");
            Game game = new Game();
              
            while (true)
            {
                var key = Console.ReadKey(true);

                switch (key.Key)
                {

                    case ConsoleKey.Enter:
                        Console.Clear();
                        game.GameAction();
                        game.result = false;
                        break;
                    case ConsoleKey.Backspace:
                        if (game.result)
                        {
                            Console.Clear();
                            game.GameAction();
                            game.result = false;
                        }
                        else
                        {
                            game.Stand();
                        }
                        
                        break;
                    case ConsoleKey.Spacebar:
                        if (game.result)
                        {
                            Console.Clear();
                            game.GameAction();
                            game.result = false;

                        }
                        else
                        {
                            game.Hit();
                        }
                        
                        break;
                }
                
            }
             
        }
    }
}



           

        
  





