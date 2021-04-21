using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDeck
{

    class Program
    {
        static void Main(string[] args)
        {
            // initialize the deck of cards
            Deck d = new Deck();
            // Runs isEmpty
            Console.WriteLine(d.IsEmpty());
            // Runs shuffle method
            d.Shuffle();

            // Runs the deal method 52 times.
            for (int i = 0; i < 52; i++)
            {
                d.Deal();
            }
        }
    }
    // Create Card Class
    class Card
    {
        // Create enum for suits
        public enum Suits
        {
            Clubs,
            Spades,
            Hearts,
            Diamonds
        }
        // Create enum for values
        public enum Values
        {
            Ace = 1,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King
        }
        // Initialize card parameters 
        public Suits Suit { get; set; }
        public Values Value { get; set; }
    }
    // Creates Deck class
   class Deck : Card
    {
        // Initialize card deck
        private Card[] deck;

        // Deck constructor
        public Deck()
        {
            // Create deck with size 52
            deck = new Card[52];
            CreateDeck();
        }
        // CreateDeck method
        public void CreateDeck()
        {
            int i = 0;
            // Loops through suits enum
            foreach(Suits s in Enum.GetValues(typeof(Suits)))
            {
                // Loops through values enum
                foreach (Values v in Enum.GetValues(typeof(Values)))
                {
                    // create a card for every suit and value
                    deck[i] = new Card { Suit = s, Value = v };
                    i++;
                }
            }
        }
        // Checks to see if deck is empty
        public bool IsEmpty()
        {
            return !deck.Any();
        }
        // Method to shuffle deck
        public void Shuffle()
        {
            // Creates random number
            Random rand = new Random();
            // Creates a tempory card
            Card temp;

            // Loop to shuffle cards 1000 times
            for (int shuffleTimes = 0; shuffleTimes < 1000; shuffleTimes++)
            {
                // Loops through all the cards
                for (int i = 0; i < 52; i++)
                {
                    // Switches positions of 2 random cards
                    int secIndex = rand.Next(13);
                    temp = deck[i];
                    deck[i] = deck[secIndex];
                    deck[secIndex] = temp;
                }
            }
        }
        // Method to deal the cards
        public void Deal()
        {
            // Using try and catch to avoid crashing.
            try
            {
                // Finds first card in deck
                Card card = deck[0];
                // Displays first card in deck
                Console.WriteLine("\n"+card.Value + " of " + card.Suit);
                // Removes first card in deck
                deck = deck.Where(val => val != card).ToArray();
            }
            // If loop is out of range it means no cards are left
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("\nNo cards left");
            }
        }
    }
}
