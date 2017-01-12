using System;
using System.Collections.Generic;
using System.Linq;


namespace BlackJack.Base
{
    public class Hand
    {
        public bool IsDealer { get; set; }  
        private readonly List<Card> cards = new List<Card>(6);
        public  List<Card> Cards
        {
            get
            {
                return cards;
            }
        }
        public int Softvalue
        {
            get
            {
                return cards.Select(c => (int)c.Rank > 1 && (int)c.Rank < 11 ? (int)c.Rank : 10).Sum();
            }
        }

        public int TotalValue
        {
            get
            {
                var totalValue = Softvalue;
               var count = cards.Count(c => c.Rank == Rank.Ace);
                while (count-- > 0 && totalValue > 21)
                {
                    totalValue -= 9;
                }
                return totalValue;
            }
        }
        // count hidden cards Dealer
        public int FaceValue
        {
            get
            {
                var faceValue = cards.Where(c => !c.FaceUp)
                    .Select(c => (int)c.Rank > 1 && (int)c.Rank < 11 ? (int)c.Rank : 10).Sum();
               var count = cards.Count(c => c.Rank == Rank.Ace);
                while (count-- > 0 && faceValue > 21)
                {
                    faceValue -= 9;
                }
                return faceValue;
            }
        }

       
    }
}
