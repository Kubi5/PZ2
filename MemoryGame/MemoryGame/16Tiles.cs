using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
   
    public partial class Form2 : Form
    {
        Label firstCardSelected = null;
        Label secondCardSelected = null;
        Stopwatch stopwatch = new Stopwatch();

        Random random = new Random();
        

        List<string> icons = new List<string>()
        {
        "O", "O", "s", "s", "N", "N", "T", "T",
        "l", "l", "w", "w", "Z", "Z", "h", "h"
        };

      
        public void ShufflingTheList()
        {
            icons = icons.OrderBy(i => Guid.NewGuid()).ToList();
        }

        private void AddImagesForSquares()
        {
            this.ShufflingTheList();
            int i = 0;
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                iconLabel.Text = icons[i++];
                //iconLabel.ForeColor = iconLabel.BackColor;
            }
        }

        public void TimeToLearnImages(int value)
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                iconLabel.ForeColor = Color.White;
            }
            timer2.Interval = value*1000;

            timer2.Start();
        }

        public void SettingTheTimeToDisplayPair(int value)
        {
            timer1.Interval = value * 1000;
        }

        public Form2()
        {
            InitializeComponent();
            AddImagesForSquares();
            TimeToLearnImages(TimeHandler.TimeToLearnTiles);
            SettingTheTimeToDisplayPair(TimeHandler.TimeToDisplayPair);
        }


        private void label1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                if (clickedLabel.ForeColor == Color.White)
                    return;
            }

            if (firstCardSelected == null)
            {
                firstCardSelected = clickedLabel;
                firstCardSelected.ForeColor = Color.White;
                return;
            }

            secondCardSelected = clickedLabel;
            secondCardSelected.ForeColor = Color.White;

            this.CheckIfTheGameEnds();

            if(firstCardSelected.Text == secondCardSelected.Text)
            {
                firstCardSelected = null;
                secondCardSelected = null;
                return;
            }
            
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            Player.WrongAnswers++;

            firstCardSelected.ForeColor = firstCardSelected.BackColor;
            secondCardSelected.ForeColor = secondCardSelected.BackColor;

            firstCardSelected = null;
            secondCardSelected = null;

        }

        public void PlayerResults()
        {
            Player.TimeSpentOnGame = (int)stopwatch.ElapsedMilliseconds / 1000;
            Player.CalculatePoints();
            MessageBox.Show(Player.PlayerName + " you matched all the icons in " + Player.TimeSpentOnGame + " s!\n" + "Wrong answers number: " + Player.WrongAnswers +"\nYour points:  " + Player.NumberOfPoints, "Well done");

        }

        private void CheckIfTheGameEnds()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }

            //koniec czasu zgadywania
            stopwatch.Stop();

            PlayerResults();
            Ranking.PlacingPlayerInRanking();

            Close();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                iconLabel.ForeColor = iconLabel.BackColor;
            }
            timer2.Stop();

            //patrzymy ile czasu zajmuje graczowi odgadniecie pól
            stopwatch.Start();
        }
    }
}
