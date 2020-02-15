using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Tamagochi2
{
    class Tamagochi
    {
        public int Life { get; set; }
        public int LifeAdditionStep { get; set; }
        public int ThoughtID { get; set; }
        public string[] Thoughts { get; set; }
        public Tamagochi()
        {
            Life = 1000;
            LifeAdditionStep = 150;
            Thoughts = new string[] { "Feed me! ", "Walk with me!", "I am sick...", "I want sleep!", "I want to play!", "Thanks, Vika!" };
            ThoughtID = GetNewThoughtID();
        }

        public int GetNewThoughtID()
        {
            Random rnd = new Random();
            int thoughtID = rnd.Next(0, 5);
            return thoughtID;
        }

        public Shape GetLifeBar()
        {
            Rectangle lifeBar = new Rectangle();
            lifeBar.Width = Life *2 /10;
            lifeBar.Height = 20;
            LinearGradientBrush filler = new LinearGradientBrush(Colors.Red, Colors.IndianRed, 1);
            lifeBar.Fill = filler;
            
            return lifeBar;
        }

        internal Shape GetThoughtsShape()
        {
            Polygon thoughts = new Polygon();
            SolidColorBrush filler = new SolidColorBrush();
            filler.Color = Colors.FloralWhite;
            thoughts.Fill = filler;

            PointCollection points = new PointCollection();
            points.Add(new Point(0, 0));
            points.Add(new Point(15, -80));
            points.Add(new Point(140, -50));
            points.Add(new Point(130, 0));
            points.Add(new Point(15, -20));

            thoughts.Points = points;
            SolidColorBrush stroke = new SolidColorBrush();
            stroke.Color = Colors.Green;
            thoughts.Stroke = stroke;
            thoughts.StrokeThickness = 3;

            return thoughts;
        }

        internal void LowerLife(int lowlife)
        {
            if (Life <= lowlife)
            { }
            else
            {
                Life -= lowlife;
            }
        }

        internal void AddLife(int addLife)
        {
            if (Life >= 1500)
            { }
            else
            {
                Life += addLife;
            }

            ThoughtID = 5;
        }
    }
}
