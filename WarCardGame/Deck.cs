using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarCardGame
{
    class Deck
    {
        private List<Card> _cards = new List<Card>();
        private Random _random = new Random();

        public Deck()
        {
            string[] kinds = new string[] { "Diamonds", "Spades", "Hearts", "Clubs" };
            string[] types = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

            foreach (var kind in kinds)
            {
                foreach (var type in types)
                {
                    _cards.Add(new Card(type, kind));
                }
            }
        }

        public void DistributeCards(Player player1, Player player2)
        {
            while(_cards.Count > 0)
            {
                player1.Cards.Add(GetRandomCard());
                player2.Cards.Add(GetRandomCard());
            }
        }

        private Card GetRandomCard()
        {
            Card card = _cards.ElementAt(_random.Next(_cards.Count));
            _cards.Remove(card);
            return card;
        }
    }
}
