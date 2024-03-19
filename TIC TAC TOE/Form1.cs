using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TIC_TAC_TOE
{
    public partial class Form1 : Form
    {
        List<Button> buttons;

        public enum Player {x, o};
        Player currentPlayer;
        int CpuCount=0, PlayerCount=0;
        Random random = new Random ();


        public Form1()
        {
             InitializeComponent();
             RestartGame();


        }

        private void CPUmove(object sender, EventArgs e)
        {
            if (buttons.Count > 0)
            {
                int index = random.Next(buttons.Count);
                buttons[index].Enabled = false;
                currentPlayer = Player.o;
                buttons[index].Text = currentPlayer.ToString();
                buttons[index].BackColor = Color.DeepPink;
                buttons.RemoveAt(index);
                CheckGame();
                CpuTimer.Stop();
                
            }

        }

        private void PlayerClickButton(object sender, EventArgs e)
        {
            var button = (Button)sender;
            currentPlayer = Player.x;
            button.Text=currentPlayer.ToString();
            button.Enabled = false;
            button.BackColor = Color.FloralWhite;
            buttons.Remove(button);
            CpuTimer.Start();
            CheckGame();

        }

        private void RestartGame(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void CheckGame()
{
    if (buttons.Count == 0)
    {
        CpuTimer.Stop();
        MessageBox.Show("IT'S A TIE!");
        RestartGame();
        return;
    }

    if (button1.Text == "x" && button2.Text == "x" && button3.Text == "x"
     || button4.Text == "x" && button5.Text == "x" && button6.Text == "x"
     || button7.Text == "x" && button8.Text == "x" && button9.Text == "x"
     || button1.Text == "x" && button4.Text == "x" && button7.Text == "x"
     || button2.Text == "x" && button5.Text == "x" && button8.Text == "x"
     || button3.Text == "x" && button6.Text == "x" && button9.Text == "x"
     || button1.Text == "x" && button5.Text == "x" && button9.Text == "x"
     || button3.Text == "x" && button5.Text == "x" && button7.Text == "x")
    {
        CpuTimer.Stop();
        MessageBox.Show("Player wins", "Rezultat");
        PlayerCount++;
        label1.Text = "Player wins: " + PlayerCount.ToString();
    }
    else if (button1.Text == "o" && button2.Text == "o" && button3.Text == "o"
          || button4.Text == "o" && button5.Text == "o" && button6.Text == "o"
          || button7.Text == "o" && button8.Text == "o" && button9.Text == "o"
          || button1.Text == "o" && button4.Text == "o" && button7.Text == "o"
          || button2.Text == "o" && button5.Text == "o" && button8.Text == "o"
          || button3.Text == "o" && button6.Text == "o" && button9.Text == "o"
          || button1.Text == "o" && button5.Text == "o" && button9.Text == "o"
          || button3.Text == "o" && button5.Text == "o" && button7.Text == "o")
    {
        CpuTimer.Stop();
        MessageBox.Show("cpu wins", "Rezultat");
        CpuCount++;
        label2.Text = "cpu wins:  " + CpuCount.ToString();
    }
}
        private void RestartGame()
        {
            buttons = new List<Button> {button1, button2, button3, button4, button5, button6, button7, button8, button9};
            foreach(Button x in buttons)
            {
                x.Text = "?";
                x.Enabled = true;
                x.BackColor = DefaultBackColor;
            }
        }
    }
}
