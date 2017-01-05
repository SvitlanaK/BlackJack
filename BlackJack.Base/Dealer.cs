using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Base
{
    public class Dealer : Hand
    {
        public Hand Hand { get; set; }
        public Dealer()
        {
            Hand = new Hand(isDealer: true);
        }
    }
}


