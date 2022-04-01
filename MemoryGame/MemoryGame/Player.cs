using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    internal class Player
    {
        static String playerName;
        static int timeSpentOnGame;
        static int wrongAnswers = 0;
        static int numberOfPoints;
        static String difficultyLevel;

        public static string PlayerName { get => playerName; set => playerName = value; }
        public static int TimeSpentOnGame { get => timeSpentOnGame; set => timeSpentOnGame = value; }
        public static int NumberOfPoints { get => numberOfPoints; set => numberOfPoints = value; }
        public static int WrongAnswers { get => wrongAnswers; set => wrongAnswers = value; }
        public static string DifficultyLevel { get => difficultyLevel; set => difficultyLevel = value; }

        public static void CalculatePoints()
        {
            int Max_Points = 1000;

            if (difficultyLevel.Equals("easy"))
            {
                NumberOfPoints = Max_Points - (TimeSpentOnGame * 8) - (wrongAnswers * 8);
            }
            if (difficultyLevel.Equals("medium"))
            {
                NumberOfPoints = Max_Points - (TimeSpentOnGame * 5) - (wrongAnswers * 5);
            }


        }
    }

}
