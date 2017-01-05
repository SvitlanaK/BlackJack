using System;
using System.Collections.Generic;
using System.Linq;


namespace BlackJack.Base
{
    public class Hand
    {
        public Hand(bool isDealer = false)
        {
            this.IsDealer = isDealer;
        }
        public bool IsDealer { get; set; }

        //Card card = new Card();
        private readonly List<Card> cards = new List<Card>(6);
        public List<Card> Cards
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
                int softValue = cards.Select(c => (int)c.Rank > 1 && (int)c.Rank < 11 ? (int)c.Rank : 10).Sum();
                return softValue;
            }
        }

        public int TotalValue
        {
            get
            {
                var value = Softvalue;
                var count = cards.Count(c => c.Rank == Rank.Ace);

                return value;
            }

        }
        // count hidden cards Dealer
        public int FaceValue
        {
            get
            {
                var faceValue = cards.Where(c => c.FaceUp)
                    .Select(c => (int)c.Rank > 1 && (int)c.Rank < 11 ? (int)c.Rank : 10).Sum();
                var count = cards.Count(c => c.Rank == Rank.Ace);

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
            foreach (var c in cards)
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
