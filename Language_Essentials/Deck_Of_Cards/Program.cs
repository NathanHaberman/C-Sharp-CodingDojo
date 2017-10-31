using System;
using System.Collections.Generic;

namespace Deck_Of_Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck playingCards = new Deck();
            playingCards.Shuffle();
            Player me = new Player("Nathan");
            me.Draw(playingCards);
            me.Draw(playingCards);
            me.Draw(playingCards);
            me.Discard(2);
        }
    }
}
