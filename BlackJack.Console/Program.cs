


namespace BlackJack.Console
{
    using System;
    using BlackJack.Base;
    class Program
    {
        static void Main(string[] args)
        {
			Console.WriteLine("PRESS ENTER, PLEASE");
			GameConsole action = new GameConsole();
			while(true)
			{
				action.Action();
			}
		}
    }
}
    

