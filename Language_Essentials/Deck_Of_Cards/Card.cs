namespace Deck_Of_Cards{
    public class Card {
        string stringVal {get;set;}
        string suit {get;set;}
        int val {get;set;}

        public Card(string value, string cardSuit, int numVal){
            stringVal = value;
            suit = cardSuit;
            val = numVal;
        }
    }
}