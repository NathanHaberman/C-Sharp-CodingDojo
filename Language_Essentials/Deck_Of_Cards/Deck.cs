using System;
using System.Collections.Generic;

namespace Deck_Of_Cards{
    public class Deck {
        private List<Card> cards = new List<Card>();

        public Deck(){
            Resert();
            System.Console.WriteLine("The deck is ready!");
        }
        public Card Deal(){
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }
        public void Shuffle(){
            List<Card> shuffledDeck = new List<Card>();
            Random rand = new Random();
            for (int i=0; i<52; i++){
                int index = rand.Next(0,cards.Count);
                shuffledDeck.Add(cards[index]);;
                cards.RemoveAt(index);
            }
            cards = shuffledDeck;
        }
        public void Resert(){
            string[] values = {"A","2","3","4","5","6","7","8","9","10","J","Q","K"};
            string[] suits = {"H","C","D","S"};
            foreach (string suit in suits){
                for (int i=0; i<values.Length; i++){
                    Card newCard = new Card(values[i],suit,i+1);
                    cards.Add(newCard);
                }
            }
        }
    }
}