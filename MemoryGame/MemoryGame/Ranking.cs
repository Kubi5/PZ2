using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    internal class Ranking
    {
        public static List<Person> personList;

        private static List<Person> PersonList { get => personList; set => personList = value; }

        public static void ReadFromFile()
        {
            personList = new List<Person>();
            string fileName = @"C:\Users\FiFi\source\repos\MemoryGame\MemoryGame\ranking.txt";

            foreach (string line in File.ReadLines(fileName))
            {
                Person person = new Person();
                string[] words = line.Split(' ');

                person.Position = Int32.Parse(words[0]);
                person.Name = words[1];
                person.Points = Int32.Parse(words[2]);
                person.DifficultyLevel = words[3];

                personList.Add(person);
            }

            /*
            while (!reader.EndOfStream)
            {
                Person person = new Person();
                string line = reader.ReadLine();
                string[] words = line.Split(' ');

                person.Position = Int32.Parse(words[0]);
                person.Name = words[1];
                person.Points = Int32.Parse(words[2]);
                person.DifficultyLevel = words[3];

                personList.Add(person);
            }
            for(int i = 0; i < personList.Count; i++)
            {
                Console.WriteLine(personList[i].Position + " " + personList[i].Name + " " + personList[i].Points + " " + personList[i].DifficultyLevel + "\n");
            }
            */
        }

        public static void PlacingPlayerInRanking()
        {
            //czytam z pliku dane dodaje do listy graczy z top 10
            ReadFromFile();

            //czyszcze plik
            File.WriteAllText(@"C:\Users\FiFi\source\repos\MemoryGame\MemoryGame\ranking.txt", string.Empty);
            
            //przemieszczam jesli zawodnik bedzie w top 10
            for(int i = 0; i < personList.Count; i++)
            {
                if(personList[i].Points < Player.NumberOfPoints)
                {
                    //jesli gracz jest na 10 pozycji top 10
                    if(i == personList.Count - 1)
                    {
                        personList[i].Points = Player.NumberOfPoints;
                        personList[i].DifficultyLevel = Player.DifficultyLevel;
                        personList[i].Name = Player.PlayerName;
                        break;
                    }


                    for (int j = 9; j > i; --j)
                    {
                        personList[j].Points = personList[j - 1].Points;
                        personList[j].DifficultyLevel = personList[j - 1].DifficultyLevel;
                        personList[j].Name = personList[j - 1].Name;
                    }

                    
                    personList[i].Points = Player.NumberOfPoints;
                    personList[i].DifficultyLevel = Player.DifficultyLevel;
                    personList[i].Name = Player.PlayerName;
                    
                    break;
                }
            }
            
            using (StreamWriter writer = new StreamWriter(@"C:\Users\FiFi\source\repos\MemoryGame\MemoryGame\ranking.txt"))
            {
                foreach (Person person in personList)
                {
                    writer.WriteLine(person.Position + " " + person.Name + " " + person.Points + " " + person.DifficultyLevel);
                }
                writer.Close();
            }

        }

        public class Person
        {
            public int Position { get; set; }
            public string Name { get; set; }
            public int Points { get; set; }
            public String DifficultyLevel { get; set; }
        }
    }
}
