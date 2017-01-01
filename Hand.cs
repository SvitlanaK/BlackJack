using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

namespace BJ
{
    public class Hand
    {
        public Hand(bool isDealer = false)
        {
            this.IsDealer = isDealer;
        }
         public bool IsDealer { get; set; }
        Card card = new Card();
        private readonly List<Card> cards = new List<Card>(5);
        public List<Card> Cards
        {
            get
            {
                return cards;
            }
        }
        
        public int Softvalue()
        {
            int sum = 0;
            foreach (var c in cards)
            {
                if ((int)c.rank > 1 && (int)c.rank < 11)
                {
                    sum += (int)c.rank;
                }
                else
                {
                    sum += 10;
                } 
            }
            return sum;
        }
       
        public int TotalValue
        {
            get
            {
                var value = Softvalue();
                var count = cards.Count(c => c.rank == Rank.Ace);
                if(count-- > 0  && value > 21)
                {
                    value -= 9;
                }
                return value;
            }
        
        }
        // count hidden cards Dealer
        public int FaceValue
        {
            get
            {
                var faceValue = cards.Where(c => c.FaceUp)
                    .Select(c => (int)c.rank > 1 && (int)c.rank < 11 ? (int)c.rank : 10).Sum();
                var count = cards.Count(c => c.rank == Rank.Ace);
                if (count-- > 0 && faceValue > 21)
                {
                    faceValue -= 9;
                }
                return faceValue;
            }
        }
      
        public void AddCard(Card card)
        {
            cards.Add(card);
        }
        // show hidden cards Dealer
        public void Show()
        {
            foreach( var c in cards)
            {
                if (!c.FaceUp)
                {
                    c.ShowCard();
                }
            }
        }
        public void Clear()
        {
            cards.Clear();
        }
    }
}
