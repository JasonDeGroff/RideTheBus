using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Windows.Forms;

namespace Ride_The_Bus
{
    public partial class Form1 : Form
    {

        // Thread-safe queue to store click events as integers
        private static ConcurrentQueue<int> clickQueue = new ConcurrentQueue<int>();

        // Flag to indicate if processing is ongoing
        private bool isProcessing = false;

        int index = 1;
        int nextPos = 1;

        public Form1()
        {
            InitializeComponent();


        }
        Random rand = new Random();
        Deck Deck = new Deck();
        List<Deck.Card> ColorStack = new List<Deck.Card>();
        List<Deck.Card> HighterLowerStack = new List<Deck.Card>();
        List<Deck.Card> InsideOutsideStack = new List<Deck.Card>();
        List<Deck.Card> SuitStack = new List<Deck.Card>();



        private void pictureBoxDeck_MouseDown(object sender, MouseEventArgs e)
        {
            // Enqueue a click event (e.g., just an integer ID or counter)
            clickQueue.Enqueue(1);
            // You can enqueue any integer representing a click


            // Start processing if not already running
            if
            (!isProcessing)
            {
                _ = ProcessQueueAsync();
            }
        }


        private async Task ProcessQueueAsync()
        {
            isProcessing = true;

            while (clickQueue.TryDequeue(out int click))
            {
                // Process the click (on UI thread)
                ProcessClick(click);



            }

            isProcessing = false;
        }

        private void ProcessClick(int click)
        {

            // This method runs on UI thread because ProcessQueueAsync is awaited on UI thread context
            // Update UI or perform the actual click processing here
            PlaceCard();

        }

        private void PlaceCard()
        {
            if (Deck.shuffledDeckList.Count > 0)
            {
                // Determine position of next card
                // If previous position was 4 reset to one
                switch (nextPos)
                {
                    case 1:
                        ColorStack.Add(Deck.shuffledDeckList[0]);
                        pictureBoxColor.Image = ColorStack[0].imageWhite;
                        Deck.shuffledDeckList.Remove(Deck.shuffledDeckList[0]);
                        nextPos++;
                        pictureBoxCheveron1.Visible = false;
                        pictureBoxCheveron2.Visible = true;
                        break;
                    case 2:
                        HighterLowerStack.Add(Deck.shuffledDeckList[0]);
                        pictureBoxValue.Image = HighterLowerStack[0].imageWhite;
                        Deck.shuffledDeckList.Remove(Deck.shuffledDeckList[0]);
                        nextPos++;
                        pictureBoxCheveron2.Visible = false;
                        pictureBoxCheveron3.Visible = true;
                        break;
                    case 3:
                        InsideOutsideStack.Add(Deck.shuffledDeckList[0]);
                        pictureBoxInsideOutside.Image = InsideOutsideStack[0].imageWhite;
                        Deck.shuffledDeckList.Remove(Deck.shuffledDeckList[0]);
                        nextPos++;
                        pictureBoxCheveron3.Visible = false;
                        pictureBoxCheveron4.Visible = true;
                        break;
                    case 4:
                        SuitStack.Add(Deck.shuffledDeckList[0]);
                        pictureBoxSuit.Image = SuitStack[0].imageWhite;
                        Deck.shuffledDeckList.Remove(Deck.shuffledDeckList[0]);
                        nextPos = 1;
                        pictureBoxCheveron4.Visible = false;
                        pictureBoxCheveron1.Visible = true;
                        break;
                }
                labelCardsRemaining.Text = $"Cards Remaining: {Deck.shuffledDeckList.Count}";
            }
        }

        private void buttonNextPlayer_Click(object sender, EventArgs e)
        {
            resetPOS();
        }

        private void resetPOS()
        {
            nextPos = 1;
            pictureBoxCheveron1.Visible = true;
            pictureBoxCheveron2.Visible = false;
            pictureBoxCheveron3.Visible = false;
            pictureBoxCheveron4.Visible = false;
        }

        private void buttonShuffleDeck_Click(object sender, EventArgs e)
        {
            Deck.Shuffle();
            labelCardsRemaining.Text = $"Cards Remaining: {Deck.shuffledDeckList.Count}";
        }

        private void buttonResetGame_Click (object sender, EventArgs e)
        {
            ColorStack.Clear();
            pictureBoxColor.Image = Properties.Resources.black_blank;
            HighterLowerStack.Clear();
            pictureBoxValue.Image = Properties.Resources.black_blank;
            InsideOutsideStack.Clear();
            pictureBoxInsideOutside.Image = Properties.Resources.black_blank;
            SuitStack.Clear();
            pictureBoxSuit.Image = Properties.Resources.black_blank;
            resetPOS();

            buttonShuffleDeck_Click(sender, e);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labelCardsRemaining.Text = $"Cards Remaining: {Deck.shuffledDeckList.Count}";
            // Save the label's current location relative to the Form
            Point labelLocationOnForm = labelCardsRemaining.Location;

            // Set the parent to PictureBox
            labelCardsRemaining.Parent = pictureBoxDeck;

            // Convert the location from Form coordinates to PictureBox coordinates
            labelCardsRemaining.Location = pictureBoxDeck.PointToClient(this.PointToScreen(labelLocationOnForm));

            // Set transparent background
            labelCardsRemaining.BackColor = Color.Transparent;
        }
    }
}
