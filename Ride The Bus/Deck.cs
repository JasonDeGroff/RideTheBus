using Microsoft.VisualBasic.ApplicationServices;
using Ride_The_Bus.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ride_The_Bus
{
    public class Deck
    {
        public struct Card
        {
            public string cardName;
            public string cardSuit;
            public string color;
            public int cardValue;
            public Bitmap imageWhite;
            public Bitmap imageBlack;
        }
        
        Random rand = new Random();
        const int DECKSIZE = 52;
        int deckCount = 1;
        int deckTotal;
        private List<Card> unshuffledDeckList;
        public List<Card> shuffledDeckList;
        private static List<Card> newDeckList = new List<Card>()
            {
                new Card() {cardName = "Ace of Hearts",     cardSuit = "Hearts",    color = "red",      cardValue = 1,  imageWhite = Properties.Resources.HA,   imageBlack = Properties.Resources.HA1},
                new Card() {cardName = "Two of Hearts",     cardSuit = "Hearts",    color = "red",      cardValue = 2,  imageWhite = Properties.Resources.H2,   imageBlack = Properties.Resources.H21},
                new Card() {cardName = "Three of Hearts",   cardSuit = "Hearts",    color = "red",      cardValue = 3,  imageWhite = Properties.Resources.H3,   imageBlack = Properties.Resources.H31},
                new Card() {cardName = "Four of Hearts",    cardSuit = "Hearts",    color = "red",      cardValue = 4,  imageWhite = Properties.Resources.H4,   imageBlack = Properties.Resources.H41},
                new Card() {cardName = "Five of Hearts",    cardSuit = "Hearts",    color = "red",      cardValue = 5,  imageWhite = Properties.Resources.H5,   imageBlack = Properties.Resources.H51},
                new Card() {cardName = "Six of Hearts",     cardSuit = "Hearts",    color = "red",      cardValue = 6,  imageWhite = Properties.Resources.H6,   imageBlack = Properties.Resources.H61},
                new Card() {cardName = "Seven of Hearts",   cardSuit = "Hearts",    color = "red",      cardValue = 7,  imageWhite = Properties.Resources.H7,   imageBlack = Properties.Resources.H71},
                new Card() {cardName = "Eight of Hearts",   cardSuit = "Hearts",    color = "red",      cardValue = 8,  imageWhite = Properties.Resources.H8,   imageBlack = Properties.Resources.H81},
                new Card() {cardName = "Nine of Hearts",    cardSuit = "Hearts",    color = "red",      cardValue = 9,  imageWhite = Properties.Resources.H9,   imageBlack = Properties.Resources.H91},
                new Card() {cardName = "Ten of Hearts",     cardSuit = "Hearts",    color = "red",      cardValue = 10, imageWhite = Properties.Resources.H10,  imageBlack = Properties.Resources.H101},
                new Card() {cardName = "Jack of Hearts",    cardSuit = "Hearts",    color = "red",      cardValue = 11, imageWhite = Properties.Resources.HJ,   imageBlack = Properties.Resources.HJ1},
                new Card() {cardName = "Queen of Hearts",   cardSuit = "Hearts",    color = "red",      cardValue = 12, imageWhite = Properties.Resources.HQ,   imageBlack = Properties.Resources.HQ1},
                new Card() {cardName = "King of Hearts",    cardSuit = "Hearts",    color = "red",      cardValue = 13, imageWhite = Properties.Resources.HK,   imageBlack = Properties.Resources.HK1},
                new Card() {cardName = "Ace of Clubs",      cardSuit = "Clubs",     color = "black",    cardValue = 1,  imageWhite = Properties.Resources.CA,   imageBlack = Properties.Resources.CA1},
                new Card() {cardName = "Two of Clubs",      cardSuit = "Clubs",     color = "black",    cardValue = 2,  imageWhite = Properties.Resources.C2,   imageBlack = Properties.Resources.C21},
                new Card() {cardName = "Three of Clubs",    cardSuit = "Clubs",     color = "black",    cardValue = 3,  imageWhite = Properties.Resources.C3,   imageBlack = Properties.Resources.C31},
                new Card() {cardName = "Four of Clubs",     cardSuit = "Clubs",     color = "black",    cardValue = 4,  imageWhite = Properties.Resources.C4,   imageBlack = Properties.Resources.C41},
                new Card() {cardName = "Five of Clubs",     cardSuit = "Clubs",     color = "black",    cardValue = 5,  imageWhite = Properties.Resources.C5,   imageBlack = Properties.Resources.C51},
                new Card() {cardName = "Six of Clubs",      cardSuit = "Clubs",     color = "black",    cardValue = 6,  imageWhite = Properties.Resources.C6,   imageBlack = Properties.Resources.C61},
                new Card() {cardName = "Seven of Clubs",    cardSuit = "Clubs",     color = "black",    cardValue = 7,  imageWhite = Properties.Resources.C7,   imageBlack = Properties.Resources.C71},
                new Card() {cardName = "Eight of Clubs",    cardSuit = "Clubs",     color = "black",    cardValue = 8,  imageWhite = Properties.Resources.C8,   imageBlack = Properties.Resources.C81},
                new Card() {cardName = "Nine of Clubs",     cardSuit = "Clubs",     color = "black",    cardValue = 9,  imageWhite = Properties.Resources.C9,   imageBlack = Properties.Resources.C91},
                new Card() {cardName = "Ten of Clubs",      cardSuit = "Clubs",     color = "black",    cardValue = 10, imageWhite = Properties.Resources.C10,  imageBlack = Properties.Resources.C101},
                new Card() {cardName = "Jack of Clubs",     cardSuit = "Clubs",     color = "black",    cardValue = 11, imageWhite = Properties.Resources.CJ,   imageBlack = Properties.Resources.CJ1},
                new Card() {cardName = "Queen of Clubs",    cardSuit = "Clubs",     color = "black",    cardValue = 12, imageWhite = Properties.Resources.CQ,   imageBlack = Properties.Resources.CQ1},
                new Card() {cardName = "King of Clubs",     cardSuit = "Clubs",     color = "black",    cardValue = 13, imageWhite = Properties.Resources.CK,   imageBlack = Properties.Resources.CK1},
                new Card() {cardName = "King of Diamonds",  cardSuit = "Diamonds",  color = "red",      cardValue = 13, imageWhite = Properties.Resources.DK,   imageBlack = Properties.Resources.DK1},
                new Card() {cardName = "Queen of Diamonds", cardSuit = "Diamonds",  color = "red",      cardValue = 12, imageWhite = Properties.Resources.DQ,   imageBlack = Properties.Resources.DQ1},
                new Card() {cardName = "Jack of Diamonds",  cardSuit = "Diamonds",  color = "red",      cardValue = 11, imageWhite = Properties.Resources.DJ,   imageBlack = Properties.Resources.DJ1},
                new Card() {cardName = "Ten of Diamonds",   cardSuit = "Diamonds",  color = "red",      cardValue = 10, imageWhite = Properties.Resources.D10,  imageBlack = Properties.Resources.D101},
                new Card() {cardName = "Nine of Diamonds",  cardSuit = "Diamonds",  color = "red",      cardValue = 9,  imageWhite = Properties.Resources.D9,   imageBlack = Properties.Resources.D91},
                new Card() {cardName = "Eight of Diamonds", cardSuit = "Diamonds",  color = "red",      cardValue = 8,  imageWhite = Properties.Resources.D8,   imageBlack = Properties.Resources.D81},
                new Card() {cardName = "Seven of Diamonds", cardSuit = "Diamonds",  color = "red",      cardValue = 7,  imageWhite = Properties.Resources.D7,   imageBlack = Properties.Resources.D71},
                new Card() {cardName = "Six of Diamonds",   cardSuit = "Diamonds",  color = "red",      cardValue = 6,  imageWhite = Properties.Resources.D6,   imageBlack = Properties.Resources.D61},
                new Card() {cardName = "Five of Diamonds",  cardSuit = "Diamonds",  color = "red",      cardValue = 5,  imageWhite = Properties.Resources.D5,   imageBlack = Properties.Resources.D51},
                new Card() {cardName = "Four of Diamonds",  cardSuit = "Diamonds",  color = "red",      cardValue = 4,  imageWhite = Properties.Resources.D4,   imageBlack = Properties.Resources.D41},
                new Card() {cardName = "Three of Diamonds", cardSuit = "Diamonds",  color = "red",      cardValue = 3,  imageWhite = Properties.Resources.D3,   imageBlack = Properties.Resources.D31},
                new Card() {cardName = "Two of Diamonds",   cardSuit = "Diamonds",  color = "red",      cardValue = 2,  imageWhite = Properties.Resources.D2,   imageBlack = Properties.Resources.D21},
                new Card() {cardName = "Ace of Diamonds",   cardSuit = "Diamonds",  color = "red",      cardValue = 1,  imageWhite = Properties.Resources.DA,   imageBlack = Properties.Resources.DA1},
                new Card() {cardName = "King of Spades",    cardSuit = "Spades",    color = "black",    cardValue = 13, imageWhite = Properties.Resources.SK,   imageBlack = Properties.Resources.SK},
                new Card() {cardName = "Queen of Spades",   cardSuit = "Spades",    color = "black",    cardValue = 12, imageWhite = Properties.Resources.SQ,   imageBlack = Properties.Resources.SQ},
                new Card() {cardName = "Jack of Spades",    cardSuit = "Spades",    color = "black",    cardValue = 11, imageWhite = Properties.Resources.SJ,   imageBlack = Properties.Resources.SJ1},
                new Card() {cardName = "Ten of Spades",     cardSuit = "Spades",    color = "black",    cardValue = 10, imageWhite = Properties.Resources.S10,  imageBlack = Properties.Resources.S10},
                new Card() {cardName = "Nine of Spades",    cardSuit = "Spades",    color = "black",    cardValue = 9,  imageWhite = Properties.Resources.S9,   imageBlack = Properties.Resources.S91},
                new Card() {cardName = "Eight of Spades",   cardSuit = "Spades",    color = "black",    cardValue = 8,  imageWhite = Properties.Resources.S8,   imageBlack = Properties.Resources.S81},
                new Card() {cardName = "Seven of Spades",   cardSuit = "Spades",    color = "black",    cardValue = 7,  imageWhite = Properties.Resources.S7,   imageBlack = Properties.Resources.S71},
                new Card() {cardName = "Six of Spades",     cardSuit = "Spades",    color = "black",    cardValue = 6,  imageWhite = Properties.Resources.S6,   imageBlack = Properties.Resources.S61},
                new Card() {cardName = "Five of Spades",    cardSuit = "Spades",    color = "black",    cardValue = 5,  imageWhite = Properties.Resources.S5,   imageBlack = Properties.Resources.S51},
                new Card() {cardName = "Four of Spades",    cardSuit = "Spades",    color = "black",    cardValue = 4,  imageWhite = Properties.Resources.S4,   imageBlack = Properties.Resources.S41},
                new Card() {cardName = "Three of Spades",   cardSuit = "Spades",    color = "black",    cardValue = 3,  imageWhite = Properties.Resources.S3,   imageBlack = Properties.Resources.S31},
                new Card() {cardName = "Two of Spades",     cardSuit = "Spades",    color = "black",    cardValue = 2,  imageWhite = Properties.Resources.S2,   imageBlack = Properties.Resources.S21},
                new Card() {cardName = "Ace of Spades",     cardSuit = "Spades",    color = "black",    cardValue = 1,  imageWhite = Properties.Resources.SA,   imageBlack = Properties.Resources.SA1},
            };

        public Deck()
        {
            deckTotal = DECKSIZE * deckCount;
            unshuffledDeckList = new List<Card>();
            shuffledDeckList = new List<Card>();

            Shuffle();
        }
        public void BuildDeck()
        {
            for (int i = 0; i < deckTotal; i++)
            {
                int j = i % (DECKSIZE);
                unshuffledDeckList.Add(newDeckList[j]);
                Debug.WriteLine($"Current deck count: {unshuffledDeckList.Count}");
            }
        }

        public void Shuffle()
        {
            if (shuffledDeckList.Count > 0)
            {
                shuffledDeckList.Clear();
            }

            BuildDeck();
            int currentDeckSize = unshuffledDeckList.Count;
            for (int i = 0;i < currentDeckSize;i++)
            {
                int randomInt = rand.Next(unshuffledDeckList.Count);
                shuffledDeckList.Add(unshuffledDeckList[randomInt]);
                unshuffledDeckList.Remove(unshuffledDeckList[randomInt]);
            }  
        }

        public void DisplayShuffledDeck()
        {
            foreach (Card card in shuffledDeckList)
            {
                Debug.WriteLine(card.cardName);
            }
        }

        public Card RandomCard
        {
            get
            {
                int randomInt = rand.Next(DECKSIZE * deckCount);
                Card randCard = new Card();
                randCard = newDeckList[randomInt];

                return randCard;
            }
        }
    }
}
