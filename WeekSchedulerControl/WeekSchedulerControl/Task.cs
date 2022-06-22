using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekSchedulerControl
{
    public  class Task
    {
        public string startTask { get; set; }
        public string dayOfTheTask { get; set; }
        public int duration { get; set; }
        
        public string activity { get; set; }
        public string notes { get; set; }

        public int Xloc { get; set; }
        public int Yloc { get; set; }
       
    }

    public class TaskList
    {
        public static List<Task> tasks = new List<Task>();
    }
}
