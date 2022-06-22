using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeekSchedulerControl
{
    public partial class UserControl1 : UserControl
    {

        DateTime thisWeek = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

        int labelX;
        int labelY;
        TaskWindow taskWindow;
        int numberOfColumns = 8;
        int numberOfRows = 49;
        int rowHeight = 15;
        int columnWidth = 80;
        Boolean taskAdded = false;
        int notinterval = 60;

        public int NotifyInterval
        {
            get { return notinterval; }
            set { notinterval = value; }
        }
        

        string UserNotes;
        int duration;
        string activity;

        TableLayoutPanel tlp = new TableLayoutPanel();

        public Label[,] Labels;
        public Boolean[,] ifLabelModify;

        public event EventHandler Notify;

        public UserControl1()
        {
            InitializeComponent();
        }

        


        public void creatingLayout()
        {
            this.Size = new Size(numberOfColumns*columnWidth +25, numberOfRows*rowHeight-190);

            tlp.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;

            tlp.ColumnCount = numberOfColumns;
            tlp.RowCount = numberOfRows;
            tlp.AutoScroll = true;
            tlp.MaximumSize = new Size(800,560);

            for (int i = 0; i < tlp.ColumnCount; i++)
            {
                tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, columnWidth));
            }
            for (int i = 0; i < tlp.RowCount; i++)
            {
                tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, rowHeight));
            }

            tlp.Padding = new Padding(4, 4, 4, 4);
            tlp.AutoSize = true;
            //tlp.Dock = DockStyle.Fill;
            //tlp.Location = new Point(0, 0);

            //tlp.Controls.Remove(tlp.GetControlFromPosition(0, 0));

            Labels = new Label[numberOfRows, numberOfColumns];
            ifLabelModify = new Boolean[numberOfRows, numberOfColumns];
            

            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    Labels[i, j] = new Label();
                    ifLabelModify[i, j] = false;
                    createLabel(Labels[i, j]);
                    tlp.Controls.Add(Labels[i, j]);
                    if (i != 0 && j != 0)
                    {
                        Labels[i, j].Click += labels_click;
                    }
                }
            }

            Button button1 = new Button();
            button1.Visible = true;
            button1.Text = "<";
            
            button1.Size = new Size(42, 19);
            button1.Location = new Point(4,3);
            button1.Font =  new Font("Montserrat", 8F, FontStyle.Bold, GraphicsUnit.Point, 238);
            this.Controls.Add(button1);

            Button button2 = new Button();
            button2.Visible = true;
            button2.Text = ">";
                  
            button2.Size = new Size(42, 19);
            button2.Location = new Point(46, 3);
            button2.Font = new Font("Montserrat", 8F, FontStyle.Bold, GraphicsUnit.Point, 238);
            this.Controls.Add(button2);

            this.Controls.Add(tlp);

            button1.Click += button1_click;
            button2.Click += button2_click;
        }

        private void cleaningLabels()
        {
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    if (i != 0 && j != 0)
                    {
                        Labels[i, j].Text = string.Empty;
                        Labels[i, j].BackColor = Color.Transparent;
                        Labels[i, j].ForeColor = Color.Transparent;
                        ifLabelModify[i, j] = false;
                    }
                }
            }
            
        }


        protected void button1_click(object sender, EventArgs e)
        {
            this.thisWeek = thisWeek.AddDays(-14);
            this.fillingTheDates();

            this.cleaningLabels();


            this.colorLabels(TaskList.tasks);

        }

        protected void button2_click(object sender, EventArgs e)
        {
            this.fillingTheDates();

            this.cleaningLabels();

            this.colorLabels(TaskList.tasks);
        }

        protected void labels_click(object sender, EventArgs e)
        {
            Label clickedlabel = (Label)sender;

            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    if(clickedlabel == Labels[i, j])
                    {
                        labelX = i;
                        labelY = j;
                    }
                        
                }
            }

            taskWindow = new TaskWindow(clickedlabel,labelX,labelY);
            taskWindow.ShowDialog();

            this.UserNotes = taskWindow.userNotes;
            this.duration = taskWindow.duration;
            this.activity = taskWindow.activity;
            this.taskAdded = taskWindow.taskAdded;

            if(taskAdded)
            {
                Task task = new Task();
                task.dayOfTheTask = Labels[0, labelY].Text;
                task.startTask = Labels[labelX, 0].Text;
                task.duration = taskWindow.duration;
                task.activity = taskWindow.activity;
                task.Xloc = this.labelX;
                task.Yloc = this.labelY;
                task.notes = taskWindow.userNotes;
                this.AddTaskToTL(task);
            }

            colorLabels(TaskList.tasks);

        }

        public void AddTaskToTL(Task task)
        {
            TaskList.tasks.Add(task);
        }

        public List<Task> getTasks()
        {
            return TaskList.tasks;
        }

        



        public void colorLabels(List<Task> tasks)
        {
            List<String> currentWeek = new List<String>();
            for(int i = 1; i < 8; i++)
            {
                currentWeek.Add(Labels[0,i].Text);
            }
            
            foreach (String date in currentWeek) {
                foreach (Task task in tasks)
                {
                    if (task.activity.Equals("SPORT") && task.dayOfTheTask.Equals(date))
                    {
                        for (int i = 0; i < task.duration / 30; i++)
                        {
                            if (!ifLabelModify[task.Xloc + i, task.Yloc])
                            {
                                Labels[task.Xloc + i,task.Yloc ].BackColor = Color.Red;
                                Labels[task.Xloc + i,task.Yloc ].Text = task.notes;
                                Labels[task.Xloc + i,task.Yloc ].ForeColor = Color.White;
                                Labels[task.Xloc + i,task.Yloc ].Font = new Font("Montserrat", 8F, FontStyle.Bold, GraphicsUnit.Point, 238);
                            }
                            ifLabelModify[task.Xloc + i, task.Yloc] = true;
                        }
                    }
                    if (task.activity.Equals("MUSIC LESSONS") && task.dayOfTheTask.Equals(date))
                    {
                        for (int i = 0; i < task.duration / 30; i++)
                        {
                            if (!ifLabelModify[task.Xloc + i, task.Yloc])
                            {
                                Labels[task.Xloc + i,task.Yloc].BackColor = Color.Green;
                                Labels[task.Xloc + i,task.Yloc].Text = task.notes;
                                Labels[task.Xloc + i,task.Yloc].ForeColor = Color.White;
                                Labels[task.Xloc + i,task.Yloc].Font = new Font("Montserrat", 8F, FontStyle.Bold, GraphicsUnit.Point, 238);
                            }
                            ifLabelModify[task.Xloc + i, task.Yloc] = true;
                        }
                    }
                    if (task.activity.Equals("FREE TIME") && task.dayOfTheTask.Equals(date))
                    {
                        for (int i = 0; i < task.duration / 30; i++)
                        {
                            if (!ifLabelModify[task.Xloc + i, task.Yloc])
                            {
                                Labels[task.Xloc + i, task.Yloc].BackColor = Color.Blue;
                                Labels[task.Xloc + i, task.Yloc].Text = task.notes;
                                Labels[task.Xloc + i, task.Yloc].ForeColor = Color.White;
                                Labels[task.Xloc + i, task.Yloc].Font = new Font("Montserrat", 8F, FontStyle.Bold, GraphicsUnit.Point, 238);
                            }
                            ifLabelModify[task.Xloc + i, task.Yloc] = true;
                        }
                    }
                    if (task.activity.Equals("SCHOOL") && task.dayOfTheTask.Equals(date))
                    {
                        for (int i = 0; i < task.duration / 30; i++)
                        {
                            if (!ifLabelModify[task.Xloc + i, task.Yloc])
                            {
                                Labels[task.Xloc + i, task.Yloc].BackColor = Color.Purple;
                                Labels[task.Xloc + i, task.Yloc].Text = task.notes;
                                Labels[task.Xloc + i, task.Yloc].ForeColor = Color.White;
                                Labels[task.Xloc + i, task.Yloc].Font = new Font("Montserrat", 8F, FontStyle.Bold, GraphicsUnit.Point, 238);
                            }
                            ifLabelModify[task.Xloc + i, task.Yloc] = true;
                        }

                        
                    }
                }
                
                
                
            }

        }

        public void createLabel(Label label)
        {
            label.Text = String.Empty;
            label.Size = new Size(columnWidth, rowHeight);
            label.Margin = new Padding(0);
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Font = new Font("Montserrat", 8F, FontStyle.Regular, GraphicsUnit.Point, 238);
        }

        public void fillingHours()
        {
            string oo = "00";
            string half = "30";
            int startingHour = 0;

            for(int i = 1; i < numberOfRows; i++)
            {
                if (i % 2 == 1)
                {
                    Labels[i, 0].Text = $"{startingHour}:{oo} - {startingHour}:{half}";
                }
                if(i % 2 == 0)
                {
                   Labels[i,0].Text = $"{startingHour}:{half} - {startingHour+1}:{oo}";
                    startingHour++;
                }
            }
        }

        public void fillingTheDates()
        {

            for(int i = 1; i< numberOfColumns; i++)
            {
                
                Labels[0, i].Text = $"{thisWeek.Day}.{thisWeek.Month}.{thisWeek.Year}";
                Labels[0, i].Font = new Font("Montserrat", 8F, FontStyle.Bold, GraphicsUnit.Point, 238);
                
                
                thisWeek = thisWeek.AddDays(1);

            }
        }



        private void UserControl1_Load(object sender, EventArgs e)
        {
            timer1.Start();

            creatingLayout();
            fillingHours();
            fillingTheDates();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            foreach (Task task in getTasks())
            {
                string[] cuttingstarthour = task.startTask.Split(' ');

                string[] taskdate = task.dayOfTheTask.Split('.');
                string[] taskhour = cuttingstarthour[0].Split(':');
                int day = int.Parse(taskdate[0]);
                int month = int.Parse(taskdate[1]);
                int year = int.Parse(taskdate[2]);
                if (taskhour[0].Equals("00"))
                {
                    taskhour[0] = "0";
                }
                if (taskhour[1].Equals("00"))
                {
                    taskhour[1] = "0";
                }
                int hour = int.Parse(taskhour[0]);
                int minute = int.Parse(taskhour[1]);


                DateTime taskstartDate = new DateTime(year, month, day,hour,minute,0);

                if ((DateTime.Now - taskstartDate).Minutes < notinterval && (DateTime.Now - taskstartDate).Minutes < 0)
                {
                    Notify.Invoke(sender, e);
                }
            }

            timer1.Start();
        }
    }
}
