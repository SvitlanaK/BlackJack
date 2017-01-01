using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ
{
    public class Dealer : Hand
    {

        public Hand Hand { get; set; }
        public Dealer()
        {
            Hand = new Hand(isDealer: true);
        }
        public void DealerHand()
        {
            Console.WriteLine("Dealer's hand({0})", Hand.FaceValue);

            for (int i = 0; i < Hand.Cards.Count; i++)
            {
                Console.WriteLine(Hand.Cards[i].FaceUp ? Hand.Cards[i].ToString() : "XXX");


            }
        }
    }
}

