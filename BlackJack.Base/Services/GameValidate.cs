using System;
using System.Collections.Generic;
using System.Linq;


namespace BlackJack.Base
{
    public class GameValidate { 

        GameService server = new GameService();
        private Hand player = new Hand();
        private Hand dealer = new Hand();
        
        public GameValidate()
        {
            Player = player;
            Dealer = dealer;
            player.IsDealer = false;
            dealer.IsDealer = true;
        }
        public Hand Player { get; set; }
        public Hand Dealer { get; set; }
        
        public GameResult result;
        public GameResult Result
        {
            get
            {
                return result;
            }

            private set
            {
                if (result != value)
                {
                    result = value;
                }
            }
        }
        public void GameStart()
        {
            Result = GameResult.None;
            server.DeckCard();
            server.Shuffle();
            server.Clear(Dealer);
            server.Clear(Player);
            server.TakeCard(Dealer);
            server.TakeCard(Player);
            if(Player.Softvalue == 21 && Dealer.Softvalue == 21)
            {
                server.Show(Dealer);
                Result = GameResult.Draw;
            }
            if(Player.Softvalue == 21)
            {
                server.Show(Dealer);
                Result =  GameResult.PlayerWon;
            }
            if(Dealer.TotalValue == 21)
            {
                server.Show(Dealer);
                Result = GameResult.DealerWon;
            }
        }
            
        public void Hit()
        {
            server.GetCard(player);
            if(Player.TotalValue > 21)
            {
                server.Show(Dealer);
                Result = GameResult.DealerWon;
            }
        }

        public void Stand()
        {
            while (Dealer.Softvalue < 18)
            {
                server.GetCard(Dealer);
            }
            if(Dealer.TotalValue > 21 || Player.TotalValue > Dealer.TotalValue)
            {
                server.Show(Dealer);
                Result = GameResult.PlayerWon;
            }
            if(Dealer.TotalValue == Player.TotalValue)
            {
                server.Show(dealer);
                Result = GameResult.Draw;
            }
            if(Dealer.TotalValue <= 21 && Dealer.TotalValue > Player.TotalValue)
            {
                server.Show(Dealer);
                Result = GameResult.DealerWon;
            }
            
        }

    }
}
