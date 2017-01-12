using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Base.Model
{
	public class Game
	{
		private GameResult result;
		public Hand Player { get; set; }
		public Hand Dealer { get; set; }
		public GameResult Result
		{
			get
			{
				return result;
			}

			protected set
			{
				if(result != value)
				{
					result = value;
				}
			}
		}
	}
}
