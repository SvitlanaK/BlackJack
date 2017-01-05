

namespace BlackJack.Base
{
    public class Player
    {
        public Hand Hand { get; set; }
        public Player()
        {
            Hand = new Hand(isDealer: false);
        }
    }
}

