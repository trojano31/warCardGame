using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarCardGame
{
    class Player : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public List<Card> Cards { get; set; }
        public int WarsWon { get; set; }

        private Random _random = new Random();

        public event PropertyChangedEventHandler PropertyChanged;

        public Player(string name)
        {
            this.Name = name;
            this.Cards = new List<Card>();
            this.WarsWon = 0;
        }

        public Card GetCard()
        {
            Card card = Cards.ElementAt(_random.Next(Cards.Count));
            Cards.Remove(card);
            return card;
        }
    }   
}
