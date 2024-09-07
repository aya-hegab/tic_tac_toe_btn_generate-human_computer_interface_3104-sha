using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tic_tac_toe_btn_generate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GenerateButtons();
            
        }
        Button [,] buttons = new Button[3,3];
        private void GenerateButtons()
        {
            for (int i=0; i<3; i++)
            {
                for (int j=0; j<3; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Size = new Size(150, 150);
                    buttons[i, j].Location = new Point(i * 150, j * 150);
                    buttons[i, j].FlatStyle = FlatStyle.Flat;
                    buttons[i, j].Font = new System.Drawing.Font(DefaultFont.FontFamily, 80, FontStyle.Bold);
                    buttons[i,j].Click += new EventHandler(button_Click);
                    panel1.Controls.Add(buttons[i, j]);
                }
                
            }
        }
        void button_Click(object sender, EventArgs s)
        {
            
            Button button = sender as Button;
            if (button.Text != "")
                return;
            button.Text = PlayerButton.Text;
            toggle_Player();
            
        }
        private void toggle_Player()
        {
            CheckWinner();
            if (PlayerButton.Text == "X")
                PlayerButton.Text = "O";
            else PlayerButton.Text = "X";
        }

        private void showWinner(List<Button> winnerbuttons)
        {
            foreach (var button in winnerbuttons)
            {
                button.BackColor = Color.Red;

            }
            MessageBox.Show("Player " + PlayerButton.Text + " Wins");
            Application.Restart();

        }
        private void CheckWinner()
        {
            List<Button> winnerButton = new List<Button>();
            //Vertical
            for (int i = 0; i < 3; i++)
            {
                winnerButton = new List<Button>();
                for (int j = 0; j < 3; j++)
                {
                    if (buttons[i, j].Text != PlayerButton.Text)
                        break;
                    winnerButton.Add(buttons[i, j]);
                    if (j==2)
                    {
                        showWinner(winnerButton);
                        return;
                    }
                }
            }
            //Horizontal
            for (int i = 0; i < 3; i++)
            {
                winnerButton = new List<Button>();
                for (int j = 0; j < 3; j++)
                {
                    if (buttons[j, i].Text != PlayerButton.Text)
                    {
                        break;
                    }
                    winnerButton.Add(buttons[j, i]);
                    if (j == 2)
                    {
                        showWinner(winnerButton);

                        return;
                    }
                }
                
            }

            //Diagonal1
            winnerButton = new List<Button>();
            for (int i = 0, j = 0; i < 3; i++, j++)
            {

                if (buttons[i, j].Text != PlayerButton.Text)
                {
                    break;
                }
                winnerButton.Add(buttons[i, j]);
                if (j == 2)
                {
                    showWinner(winnerButton);
                    return;

                }
            }
            //Diagonal2
            winnerButton = new List<Button>();
            for (int i = 2, j = 0; j < 3; i--, j++)
            {

                if (buttons[i, j].Text != PlayerButton.Text)
                {
                    break;
                }
                winnerButton.Add(buttons[i, j]);
                if (j == 2)
                {
                    showWinner(winnerButton);
                    return;

                }
            }

            //Tie
            foreach (var button in buttons)
            {
                if (button.Text == "")
                    return;
            }
            MessageBox.Show("Draw");
            Application.Restart();



        }

    }
}
