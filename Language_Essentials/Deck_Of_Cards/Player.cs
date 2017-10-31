using System.Collections.Generic;

namespace Deck_Of_Cards{
    public class Player{
        private string name;
        private List<Card> hand = new List<Card>();
        public Player(string playerName){
            name = playerName;
        }
        public void Draw(Deck deckInPlay){
            hand.Add(deckInPlay.Deal());
        }
        public Card Discard(int index){
            if (index < hand.Count){
                Card card = hand[index];
                hand.RemoveAt(index);
                return card;
            } else {
                return null;
            }
        }
    }
}