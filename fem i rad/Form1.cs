﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fem_i_rad
{
    public partial class Form1 : Form
    {
        bool turn = true; //När det blir true så är det X:s turn to go,false = O:s turn

        int turn_count = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";

            turn = !turn;
            b.Enabled = false;
            turn_count++;
            checkForWinner();
        }

        private void checkForWinner()
        {
            bool there_is_a_winner = false;

            //Horisontella checks
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                there_is_a_winner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                there_is_a_winner = true;
            
            // Verticalla checks
           else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                there_is_a_winner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                there_is_a_winner = true;

            if (there_is_a_winner)
            {
                disablebuttons();

                string winner = "";
                if (turn)
                    winner = "O";
                else
                    winner = "X";

                MessageBox.Show(winner + "Wins!", "Yay!");
            }
            else
            {
                if (turn_count == 9)
                    MessageBox.Show("Draw!", "Gae");
            }


            // foreach (Control c in Controls)
            //{

            //}

        }//Avslutar CheckForWinner här

        private void disablebuttons()
        {
            try
            {

            
            foreach (Control c in Controls)
            {
                Button b = (Button)c;
                b.Enabled = false;
                }//foreach slut
            }
            catch
            {
                    
            }
        }

    }
}
