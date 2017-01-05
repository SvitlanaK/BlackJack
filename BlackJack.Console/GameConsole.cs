

namespace BlackJack.Console
{
    using System;
    using BlackJack.Base;
    
    public class GameConsole
    {
        Game game = new Game();
        public  string Print(Card card)
        {
            char suite = '?';
            switch (card.Suit)
            {
                case Suit.Club:
                    suite = '♣';
                    break;
                case Suit.Diamond:
                    suite = '♦';
                    break;
                case Suit.Heart:
                    suite = '♥';
                    break;
                case Suit.Spade:
                    suite = '♠';
                    break;
            }
            var num = (int)card.Rank > 1 && (int)card.Rank < 11 ?
                ((int)card.Rank).ToString() :
                Enum.GetName(typeof(Rank), card.Rank).Substring(0, 1);

            return num + " " + suite;
        }
        public void DealerHand()
        {
            Console.WriteLine("Dealer's hand({0})", game.Dealer.Hand.FaceValue);

            for (int i = 0; i < game.Dealer.Hand.Cards.Count; i++)
            {
                Console.WriteLine(game.Dealer.Hand.Cards[i].FaceUp ? Print(game.Dealer.Hand.Cards[i]) : "XXX");
            }
        }
        public void PlayerHand()
        {
            Console.WriteLine("Player's hand({0})", game.Player.Hand.TotalValue);
            for (int i = 0; i < game.Player.Hand.Cards.Count; i++)
            {
                Console.WriteLine(Print(game.Player.Hand.Cards[i]));
            }
        }
        private  void ResultGame()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            
             if (game.Result == GameResult.DealerWon)
            {
                Console.WriteLine("Dealer WON");
            }
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            if (game.Result == GameResult.PlayerWon)
            {
                Console.WriteLine("PLAYER WON");
            }
            Console.ForegroundColor = ConsoleColor.Yellow;

            if (game.Result == GameResult.Draw)
            {
                Console.WriteLine("DRAW");
            }
            Console.ResetColor();
            
        }
        public void newGame()
        { 
            while (true)
            {
                var key = Console.ReadKey(true);

                switch (key.Key)
                {

                    case ConsoleKey.Enter:
                        Console.Clear();
                        game.GameAction();
                        break;
                    case ConsoleKey.Backspace:
                        if (game.Result!=GameResult.None)
                        {
                            Console.Clear();
                            game.GameAction();
                        }
                        else
                        {
                            game.Stand();
                        }
                        break;
                    case ConsoleKey.Spacebar:
                        if (game.Result != GameResult.None)
                        {
                            Console.Clear();
                            game.GameAction();
                        }
                        else
                        {
                            game.Hit();
                        }
                        break;
                }
                        DealerHand();
                        PlayerHand();
                        ResultGame();
                if(game.Result == GameResult.None)
                {
                    Console.WriteLine("Hit - {Spacebar} or Stand - {backspace} and NewGame - {Enter}");
                }
                        
            }
            
        }
    }
}


  
