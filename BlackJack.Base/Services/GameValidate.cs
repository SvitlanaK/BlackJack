using BlackJack.Base.Model;

namespace BlackJack.Base
{
    public class GameValidate : Game
	{ 
        GameService service = new GameService();
		private Hand player = new Hand();
		private Hand dealer = new Hand();

		public GameValidate()
		{
			Player = player;
			Dealer = dealer;
			Player.IsDealer = false;
			Dealer.IsDealer = true;
		}
		public void GameStart()
        {
            Result = GameResult.None;
			service.DeckCard();
			service.Shuffle();
			service.Clear(Dealer);
			service.Clear(Player);
			service.TakeCard(Dealer);
			service.TakeCard(Player);
			if(Player.Softvalue == 21 && Dealer.Softvalue == 21)
            {
				service.Show(Dealer);
                Result = GameResult.Draw;
            }
            if(Player.Softvalue == 21)
            {
				service.Show(Dealer);
                Result =  GameResult.PlayerWon;
            }
            if(Dealer.TotalValue == 21)
            {
				service.Show(Dealer);
                Result = GameResult.DealerWon;
            }
        }
            
        public void Hit()
        {
			service.GetCard(Player);
            if(Player.TotalValue > 21)
            {
				service.Show(Dealer);
                Result = GameResult.DealerWon;
            }
        }

        public void Stand()
        {
            while (Dealer.Softvalue < 18)
            {
				service.GetCard(Dealer);
            }
            if(Dealer.TotalValue > 21 || Player.TotalValue > Dealer.TotalValue)
            {
				service.Show(Dealer);
                Result = GameResult.PlayerWon;
            }
            if(Dealer.TotalValue == Player.TotalValue)
            {
				service.Show(Dealer);
                Result = GameResult.Draw;
            }
            if(Dealer.TotalValue <= 21 && Dealer.TotalValue > Player.TotalValue)
            {
				service.Show(Dealer);
                Result = GameResult.DealerWon;
            }
            
        }

    }
}
