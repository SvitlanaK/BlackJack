using System;
using System.Collections.Generic;
using System.Linq;


namespace BlackJack.Base
{
    public class Deck
    {

        private List<Card> cards = new List<Card>(52);
        Random random = new Random();
        public Deck()
        {
            var qvery =
               from suit in Enumerable.Range(1, 4)
               from rank in Enumerable.Range(1, 13)
               select new Card((Rank)rank, (Suit)suit);

            cards = qvery.ToList();
        }
            //Shuffle cards
        public void Shuffle()
        {
            List<Card> newCards = new List<Card>();
            while(cards.Count > 0)
            {
                int CardToMove = random.Next(cards.Count);
                newCards.Add(cards[CardToMove]);
                cards.RemoveAt(CardToMove);
            }
            cards = newCards;
        }

        public void TakeCard(Hand hand)
        {

            var card = cards.First();
            hand.AddCard(card);
            cards.Remove(card);
            card = cards.First();
            if (hand.IsDealer)
            {
                card.ShowCard();
            }
            hand.AddCard(card);
            cards.Remove(card);
        }

        public void GetCard(Hand hand)
        {
            hand.AddCard(cards.First());
            cards.RemoveAt(0);
        }
    }
}

