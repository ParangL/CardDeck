using System;
using System.Collections.Generic;

namespace CardDeck
{
    public class Card
    {
        public string cardType;
        public string cardValue;
        public int position;

        

        public Card(string cardtype, string cardvalue, int pos)
        {
            cardType = cardtype;
            cardValue = cardvalue;
            position = pos;
            
        }
    }

    public class Deck
    {
        public List<Card> deck = new List<Card>();

        public List<Card> Sort()
        {          
            string[] cardTypes = { "Diamonds", "Clubs", "Hearts", "Clubs" };
            string[] cardValues = { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };



            foreach (string type in cardTypes)
            {
                for(int i = 0; i < cardValues.Length; i++)
                {
                    Card newCard = new Card(cardValues[i], type, i + 1);
                    deck.Add(newCard);
                }
            }
            return deck;

        }

        public List<Card> Shuffle()
        {
            Random rand = new Random();
            for(int i = deck.Count-1; i > 0; i--)
            {
                int next = rand.Next(i + 1);
                Card temp = deck[next];
                deck[next] = deck[i];
                deck[i] = temp;
            }
            return deck;
        }

        public Card Pull()
        {
            if (deck.Count > 0)
            {
                Card top = deck[0];
                deck.RemoveAt(0);
                return top;
            }            
            return Pull();
            
        }
    }
  
    class Program
    {
        static void Main(string[] args)
        {            
            Deck newDraw = new Deck();
            newDraw.Sort();
            newDraw.Shuffle();
            newDraw.Pull();
            foreach (var type in newDraw.deck)
            {
                Console.Write(type.cardValue);
                Console.WriteLine(type.cardType);                               
            }

        }
    }
}

