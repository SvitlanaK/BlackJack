using System;
using System.Collections.Generic;
using System.Linq;


namespace BlackJack.Base
{
    public class Game { 

        Deck deck;
        Hand hand = new Hand();
        
    public Game()
    {
        Player = new Player();
        Dealer = new Dealer();
    }
    Hand Hand { get; set; }
    public Player Player { get; set; }
    public Dealer Dealer { get; set; }
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
        public void GameAction()
        {
            deck = new Deck();
            Result = GameResult.None;
            deck.Shuffle();
            Dealer.Hand.Clear();
            Player.Hand.Clear();
            deck.TakeCard(Dealer.Hand);
            deck.TakeCard(Player.Hand);
            if(Player.Hand.Softvalue == 21 && Dealer.Hand.Softvalue == 21)
            {
                Dealer.Hand.Show();
                Result = GameResult.Draw;
            }
            if(Player.Hand.Softvalue == 21)
            {
                Dealer.Hand.Show();
                Result =  GameResult.PlayerWon;
            }
            if(Dealer.Hand.TotalValue == 21)
            {
                Dealer.Hand.Show();
                Result = GameResult.DealerWon;
            }
        }
            
        public void Hit()
        {
            deck.GetCard(Player.Hand);
            if(Player.Hand.TotalValue > 21)
            {
                Dealer.Hand.Show();
                Result = GameResult.DealerWon;
            }
        }

        public void Stand()
        {

            while (Dealer.Hand.Softvalue < 18)
            {
                deck.GetCard(Dealer.Hand);
            }
            if(Dealer.Hand.TotalValue > 21 || Player.Hand.TotalValue > Dealer.Hand.TotalValue)
            {
                Dealer.Hand.Show();
                Result = GameResult.PlayerWon;
            }
            if(Dealer.Hand.TotalValue == Player.Hand.TotalValue)
            {
                Dealer.Hand.Show();
                Result = GameResult.Draw;
            }
            if(Dealer.Hand.TotalValue <= 21 && Dealer.Hand.TotalValue > Player.Hand.TotalValue)
            {
                Dealer.Hand.Show();
                Result = GameResult.DealerWon;
            }
            
        }

    }
}
