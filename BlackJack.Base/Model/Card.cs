using System;


namespace BlackJack.Base
{
    public class Card
    {
        public Suit Suit { get; set; }
        public Rank Rank { get; set; }
        public bool FaceUp { get; set; }
		//
        public Card(Rank r, Suit s)
        {
            this.Rank = r;
            this.Suit = s;
            this.FaceUp = false;
        }
        
    }
}