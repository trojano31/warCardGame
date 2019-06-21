using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarCardGame
{
    class Game
    {
        public Player Player1 { get; set; }
        public Card P1CurrentCard { get; set; }
        public Player Player2 { get; set; }
        public Card P2CurrentCard { get; set; }
        public Deck Deck { get; set; }
        public List<Card> Stack { get; set; }
        public int Round { get; set; }
        public int RoundLimit { get; set; } = 30;

        public Game(string playerName)
        {
            this.Player1 = new Player(playerName);
            this.Player2 = new Player("Computer");
            this.Deck = new Deck();
            this.Stack = new List<Card>();
        }

        public void PrepareGame()
        {
            Deck.DistributeCards(Player1, Player2);
            Round = 0;
        }

        public void PlayRound(bool addRound = true)
        {
            if (addRound) Round++;
            Card p1Card = Player1.GetCard();
            Card p2Card = Player2.GetCard();
            P1CurrentCard = p1Card;
            P2CurrentCard = p2Card;
            Stack.Add(p1Card);
            Stack.Add(p2Card);

            if(p1Card.Value > p2Card.Value)
            {
                GiveBounty(Player1);
            } else if (p1Card.Value < p2Card.Value)
            {
                GiveBounty(Player2);
            } else {
                Battle();
            }
        }

        public void Battle()
        {
            Stack.Add(Player1.GetCard());
            Stack.Add(Player1.GetCard());
            Stack.Add(Player2.GetCard());
            Stack.Add(Player2.GetCard());

            PlayRound(false); 
        }

        public void GiveBounty(Player player)
        {
            player.Cards.AddRange(Stack);
            Stack.Clear();
        }

        public bool CheckIfGameFinished()
        {
            if (Round >= this.RoundLimit) return true;

            if (Player1.Cards.Count == 0 || Player2.Cards.Count == 0) return true;

            if (Player1.WarsWon == 3 || Player2.WarsWon == 3) return true;

            return false;
        }

        public Player GetWinner()
        {
            if (Player1.WarsWon == 3 || Player1.Cards.Count > Player2.Cards.Count) return Player1;

            return Player2;
        }

        public bool CheckIfDraw()
        {
            if(Player1.Cards.Count == Player2.Cards.Count && Player1.WarsWon < 3 && Player2.WarsWon < 3)
            {
                this.RoundLimit += 10;
                return true;
            }
            return false;
        }
    }
}
