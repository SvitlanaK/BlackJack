using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ
{
   public class Player
    {
        Hand hand = new Hand();
       public Hand Hand { get; set; }
        public Player()
        {
            Hand = new Hand(isDealer: false);
        }
      public void PlayerHand()
        {
            
            Console.WriteLine("Player's hand({0})", Hand.TotalValue);
            for (int i = 0; i < Hand.Cards.Count; i++)
            {
                Console.WriteLine(Hand.Cards[i].ToString());
            }
        }
    }
}
