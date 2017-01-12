

namespace BlackJack.Console
{
    using System;
    using BlackJack.Base;
    
    public class GameConsole
    {
        GameValidate game = new GameValidate();
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
        public void HandCard(Hand hand)
        {
            var user = hand.IsDealer ? "DEALER" : "PLAYER";
            var name = hand.IsDealer ? game.Dealer : game.Player;
            var value = hand.IsDealer ? game.Dealer.FaceValue : game.Player.TotalValue;
            Console.WriteLine("{0}'s hand({1})",user, value);

            for (int i = 0; i < name.Cards.Count; i++)
            {
                Console.WriteLine(name.Cards[i].FaceUp ? "XXX": Print(name.Cards[i]) );
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
        public void Action()
        {
            var key = Console.ReadKey(true);
            switch (key.Key)
                {

                    case ConsoleKey.Enter:
                        Console.Clear();
                        game.GameStart();
                        break;

					case ConsoleKey.Backspace:
						game.Stand();
                        break;

                    case ConsoleKey.Spacebar:
                        game.Hit();
						break;
                }
						HandCard(game.Dealer);
						HandCard(game.Player);
					    ResultGame();
                if(game.Result == GameResult.None)
                {
                    Console.WriteLine("Hit - {Spacebar} or Stand - {backspace} and NewGame - {Enter}");
                }
                        
            }
            
        }
    }



  
