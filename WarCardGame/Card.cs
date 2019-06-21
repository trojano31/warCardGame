using System;

namespace WarCardGame
{
    public class Card
    {
        public int Value { get; set; }
        public string Type { get; set; }
        public string Kind { get; set; }

        public Card(string type, string kind)
        {
            this.Kind = kind;
            this.Type = type;
            this.Value = GetValue(type);
        }

        private int GetValue(string type)
        {
            switch (type)
            {
                case "Jack":
                    return 11;
                case "Queen":
                    return 12;
                case "King":
                    return 13;
                case "Ace":
                    return 14;
                default:
                    return Int32.Parse(type);
            }
        }
    }
}