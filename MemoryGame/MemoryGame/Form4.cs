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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Activated(object sender, EventArgs e)
        {

            Ranking.ReadFromFile();
            
            label2.Text = Ranking.personList[0].Position + ". " + Ranking.personList[0].Name.ToUpper() + "  points: " + Ranking.personList[0].Points + ", level: " + Ranking.personList[0].DifficultyLevel;
            label3.Text = Ranking.personList[1].Position + ". " + Ranking.personList[1].Name.ToUpper() + "  points: " + Ranking.personList[1].Points + ", level: " + Ranking.personList[1].DifficultyLevel;
            label4.Text = Ranking.personList[2].Position + ". " + Ranking.personList[2].Name.ToUpper() + "  points: " + Ranking.personList[2].Points + ", level: " + Ranking.personList[2].DifficultyLevel;
            label5.Text = Ranking.personList[3].Position + ". " + Ranking.personList[3].Name.ToUpper() + "  points: " + Ranking.personList[3].Points + ", level: " + Ranking.personList[3].DifficultyLevel;
            label6.Text = Ranking.personList[4].Position + ". " + Ranking.personList[4].Name.ToUpper() + "  points: " + Ranking.personList[4].Points + ", level: " + Ranking.personList[4].DifficultyLevel;
            label7.Text = Ranking.personList[5].Position + ". " + Ranking.personList[5].Name.ToUpper() + "  points: " + Ranking.personList[5].Points + ", level: " + Ranking.personList[5].DifficultyLevel;
            label8.Text = Ranking.personList[6].Position + ". " + Ranking.personList[6].Name.ToUpper() + "  points: " + Ranking.personList[6].Points + ", level: " + Ranking.personList[6].DifficultyLevel;
            label9.Text = Ranking.personList[7].Position + ". " + Ranking.personList[7].Name.ToUpper() + "  points: " + Ranking.personList[7].Points + ", level: " + Ranking.personList[7].DifficultyLevel;
           label10.Text = Ranking.personList[8].Position + ". " + Ranking.personList[8].Name.ToUpper() + "  points: " + Ranking.personList[8].Points + ", level: " + Ranking.personList[8].DifficultyLevel;
           label11.Text = Ranking.personList[9].Position + ". " + Ranking.personList[9].Name.ToUpper() + "  points: " + Ranking.personList[9].Points + ", level: " + Ranking.personList[9].DifficultyLevel;
            
        }
    }
}
