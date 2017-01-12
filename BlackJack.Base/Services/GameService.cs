using System;
using System.Collections.Generic;
using System.Linq;


namespace BlackJack.Base
{
    public class GameService
    {
		private List<Card> cards = new List<Card>(52);
        Random random = new Random();
        public void DeckCard()
        {
            var qvery =
               from suit in Enumerable.Range(1, 4)
               from rank in Enumerable.Range(1, 13)
               select new Card((Rank)rank, (Suit)suit);

            cards = qvery.ToList();
        }
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
            hand.Cards.Add(card);
            cards.Remove(card);
            card = cards.First();
            if (hand.IsDealer)
            {
                card.FaceUp = !card.FaceUp;
            }
            hand.Cards.Add(card);
            cards.Remove(card);
        }

        public void GetCard(Hand hand)
        {
            hand.Cards.Add(cards.First());
            cards.RemoveAt(0);
        }
       
        public void Show(Hand hand)
        {
            foreach (var c in hand.Cards)
            {
               c.FaceUp = false;
            }
        }
        public void Clear(Hand hand)
        {
            hand.Cards.Clear();
        }
    }
}

