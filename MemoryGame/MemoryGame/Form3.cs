using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    public partial class Form3 : Form
    {
        Label firstClicked = null;
        Label secondClicked = null;

        Random random = new Random();

        List<String> icons = new List<String>()
        {
            "z","z","w","w","x","x","y","y","Z","Z","Y","Y",
            "X","X","v","v","V","V","t","t","T","T","p","p",
            "P","P","R","R","r","r","W","W","L","L","l","l"
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
            timer2.Interval = value * 1000;

            timer2.Start();
        }

        public void SettingTheTimeToDisplayPair(int value)
        {
            timer1.Interval = value * 1000;
        }

        public Form3()
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

            if (firstClicked == null)
            {
                firstClicked = clickedLabel;
                firstClicked.ForeColor = Color.White;
                return;
            }

            secondClicked = clickedLabel;
            secondClicked.ForeColor = Color.White;

            this.CheckIfTheGameEnds();

            if (firstClicked.Text == secondClicked.Text)
            {
                firstClicked = null;
                secondClicked = null;
                return;
            }

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            firstClicked = null;
            secondClicked = null;
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
            MessageBox.Show("You matched all the icons!", "Well done");
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
        }
    }
}
