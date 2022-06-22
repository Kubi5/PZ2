using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeekSchedulerControl
{
    public partial class TaskWindow : Form
    {
        public TaskWindow(Label label,int x,int y)
        {
            InitializeComponent();
            clickedLabel = label;
            labelX = x;
            labelY = y;
        }
        static string[] activityList = {"SCHOOL",
            "MUSIC LESSONS",
            "SPORT",
            "FREE TIME"};

        public Label clickedLabel;
        public int duration = 30;
        public int labelX;
        public int labelY;
        public string userNotes = "";
        public string activity = "";
        public Boolean taskAdded = false;
        

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            
            if (trackBar1.Value % 30 != 0 || trackBar1.Value == 450)
            {
                trackBar1.Value = (trackBar1.Value / 30) * 30;
                duration = trackBar1.Value;
                label3.Text = $"{trackBar1.Value} minutes";
            }
        }

        private void TaskWindow_Load(object sender, EventArgs e)
        {
            foreach(var value in activityList)
            {
                comboBox1.Items.Add(value.ToString());
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            userNotes = textBox1.Text;
            activity = comboBox1.Text;
            duration = trackBar1.Value;
            taskAdded = true;
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            userNotes = textBox1.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            activity = comboBox1.Text;
        }
    }
}
