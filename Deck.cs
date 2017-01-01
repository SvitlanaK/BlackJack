using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

namespace BJ
{
    public class Deck
    {

        private List<Card> Cards = new List<Card>(52);
        public Deck()
        {
           Reset();
        }
       
        //Create a new deck 
        public void Reset()
        {
           Cards.Clear();
            Cards.AddRange(Enumerable.Range(1, 4)
                .SelectMany(s => Enumerable.Range(1, 13)
                .Select(n => new Card((Rank)n, (Suit)s))));
        }
        //Shuffle cards
        public void Shuffle()
        {
            Cards = Cards.OrderBy(c => Guid.NewGuid())
                         .ToList();
        }

        public void TakeCard(Hand hand)
        {
            
            var card = Cards.First();
            hand.AddCard(card);
            Cards.Remove(card);
            card = Cards.First();
            if (hand.IsDealer)
            {
                card.ShowCard();
            }
            hand.AddCard(card);
            Cards.Remove(card);
           // return card;
           // Console.WriteLine(hand.SoftValue);
        }

        public void TakeCards(Hand hand)
        {
            hand.AddCard(Cards.First());
            //Console.WriteLine(Cards[0]);
            Cards.RemoveAt(0);
        }
    }
}