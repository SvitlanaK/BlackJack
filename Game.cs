using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ
{
    public class Game
    {
         Deck deck;
         Hand hand = new Hand();
        public bool result;
       
        
        public Game()
        {
            Player = new Player();
            Dealer = new Dealer();
        }
        Hand Hand { get; set; }
        public Player Player { get; set; }
        public Dealer Dealer { get; set; }
       
        
        public void GameAction() {
              if (deck == null)
            {
                deck = new Deck();
            }
            else
            {
                deck.Reset();
            }

            deck.Shuffle();
            Dealer.Hand.Clear();
            Player.Hand.Clear();
            deck.TakeCard(Dealer.Hand);
            Dealer.DealerHand();
             deck.TakeCard(Player.Hand);
            Player.PlayerHand();
            if (Player.Hand.Softvalue() == 21)
            {
                if (Dealer.Hand.Softvalue() == 21)
                {
                    result =true;
                    Console.WriteLine("DRAW");
                }
                else if(Player.Hand.Softvalue() == 21 || Dealer.Hand.Softvalue() < Player.Hand.Softvalue())
                {
                    result = true;
                    Console.WriteLine("BLACK JACK!!!!! Player WON");
                }
                else
                {
                    result = true;
                    Console.WriteLine("Player WON");
                    
                }

                Dealer.Hand.Show();
                
            }
            else if (Dealer.Hand.TotalValue == 21)
            {
                Dealer.Hand.Show();
                result = true;
                Console.WriteLine("Dealer WON");
               
            }
            Console.WriteLine("Hit - {Spacebar} or Stand - {backspace}");

        }
        public void Hit()
        {
            deck.TakeCards(Player.Hand);
            Player.PlayerHand();
            if (Player.Hand.TotalValue > 21)
            {
                Dealer.Hand.Show();
                result = true;
                Console.WriteLine("Dealer WON");
                
            }
        }

        public void Stand()
        {
          
            if (Dealer.Hand.Softvalue() < 18)
            {
                deck.TakeCards(Dealer.Hand);
            }

            if (Dealer.Hand.TotalValue > 21 || Player.Hand.TotalValue > Dealer.Hand.TotalValue)
            {
                result = true;
                Console.WriteLine("Player WON");
            }
            else if (Dealer.Hand.TotalValue == Player.Hand.TotalValue)
            {
                result = true;
                Console.WriteLine("Player DRAW");
            }
            else
            {
                result = true;
                Console.WriteLine("Dealer WON");
            }

               Dealer.Hand.Show();
            Dealer.DealerHand();
        }
    }
}

