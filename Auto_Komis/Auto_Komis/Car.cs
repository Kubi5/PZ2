using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Komis
{
    internal class Car
    {
        string carProducer;
        string carModel;
        string carEngine;
        string carColor;

        public string CarProducer { get => carProducer; set => carProducer = value; }
        public string CarModel { get => carModel; set => carModel = value; }
        public string CarEngine { get => carEngine; set => carEngine = value; }
        public string CarColor { get => carColor; set => carColor = value; }

        public override string ToString()
        {
            return this.carProducer + " " + this.carModel + " " + this.carEngine + " " + this.carColor;
        }
    }
}
