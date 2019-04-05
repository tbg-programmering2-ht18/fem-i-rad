using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace fem_i_rad
{
    public partial class Form1 : Form
    {
        bool turn = true; //När det blir true så är det X:s turn to go,false = O:s turn

        int player1_count = 0;
        int player2_count = 0;
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
            if (sender is Button)
            {
                //När spelare klickar på en knapp och texten sänds in och skriver det ut
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
        }

        private void checkForWinner()
        {
            bool there_is_a_winner = false;

            //Horisontalla checkningar efter vinnare
            if ((A1.Text == A4.Text) && (A4.Text == A5.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                there_is_a_winner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                there_is_a_winner = true;

            // Verticalla checkningar efter vinnare
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            else if ((A4.Text == B2.Text) && (B2.Text == C2.Text) && (!A4.Enabled))
                there_is_a_winner = true;
            else if ((A5.Text == B3.Text) && (B3.Text == C3.Text) && (!A5.Enabled))
                there_is_a_winner = true;

            // Diagonalla checkningar efter vinnare
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            else if ((A5.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
                there_is_a_winner = true;

            if (there_is_a_winner)
            {
                disablebuttons();

                string winner = "";
                if (turn)
                    //Om O winner så skrivs O ut
                    winner = "O";
                //om X winner så skrivs x ut
                else
                    winner = "X";

                score.Text = winner + " winner";

                MessageBox.Show(winner + "Wins!", "Yay!");
            }
            else
            {
                //Om alla 9 knapparna blir använda och det blir lika så winner ingen.
                if (turn_count == 9)
                    MessageBox.Show("Draw!", "Gae");
            }


            // foreach (Control c in Controls)
            //{

            //}

        }//Avslutar CheckForWinner här

        //Stänger av knapparna
        private void disablebuttons()
        {
            try
            {



                //Resetar alla knappar och startar om spelet på nytt
                foreach (Control c in Controls)
                {
                    if (c is Button)
                    {
                        Button b = (Button)c;
                        if (b.Tag == null)
                        {
                            b.Enabled = false;
                        }
                    }
                }//foreach slut
            }
            catch { }


            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;

            //resetar knapparna
            foreach (Control c in Controls)
            {
                if (c is Button)
                {
                    Button b = (Button)c;
                    if (b.Tag == null || b.Tag.ToString() =="" )
                    {
                        b.Enabled = true;

                        b.Text = "";
                    }
                }
                //resets the score-label så den startas om
                if (c is Label)
                {
                    Label l = (Label)c;

                    l.Text = "";




                }


            }//foreach slut
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void score_Click(object sender, EventArgs e)
        {

        }
    }
}


