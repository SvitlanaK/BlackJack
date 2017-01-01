using System;
using System.Text;



namespace BJ
{
    public class Card
    {
        
        public Suit suit { get; set; }
        public Rank rank { get; set; }
        public bool FaceUp { get; set; }
        public Card() { }
        public Card (Rank r, Suit s)
        {
            this.rank = r;
            this.suit = s;
            this.FaceUp = false;
        }
        public void ShowCard()
        {
            this.FaceUp = !this.FaceUp;
        }
    
        public override string ToString()
        {
            char suite = '?';
            switch (this.suit)
            {
                case Suit.Club:
                  suite ='♣';
                    break;
                case Suit.Diamond:
                    suite='♦';
                    break;
                case Suit.Heart:
                    suite =  '♥';
                    break;
                case Suit.Spade:
                    suite = '♠';
                    break;
            }
           
            if((int)rank > 1 && (int)rank < 11)
            {
                return ((int)rank).ToString() + " "+ suite;
            }
            else
            {
               return Enum.GetName(typeof(Rank), rank).Substring(0,1) + " " + suite;
            }
           
        }
    }
}
