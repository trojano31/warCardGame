using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarCardGame
{
    public partial class Form1 : Form
    {
        private Game _game; 
        public Form1()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            _game = new Game("Player");
            _game.PrepareGame();
            label8.Text = _game.Player2.Cards.Count.ToString();
            label7.Text = _game.Player1.Cards.Count.ToString();
            label10.Text = _game.Round.ToString();
            button2.Enabled = true;
            button1.Enabled = false;
        }

        private void nextRound_Click(object sender, EventArgs e)
        {
            if (_game.CheckIfGameFinished())
            {
                if (!_game.CheckIfDraw())
                {
                    var winner = _game.GetWinner();
                    MessageBox.Show(winner.Name + " has won the game in " + _game.Round + " rounds!");
                    button2.Enabled = false;
                    button1.Enabled = true;
                    return;
                }
                return;
            }
            label8.Text = _game.Player2.Cards.Count.ToString();
            label7.Text = _game.Player1.Cards.Count.ToString();
            _game.PlayRound();
            p1_current_card.Text = $"{_game.P1CurrentCard.Type} of {_game.P1CurrentCard.Kind}";
            p2_current_card.Text = $"{_game.P2CurrentCard.Type} of {_game.P2CurrentCard.Kind}";
            label10.Text = _game.Round.ToString();
        }
    }
}
