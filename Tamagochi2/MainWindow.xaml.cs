using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tamagochi2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Tamagochi tamagochi;
        private MediaPlayer player = new MediaPlayer();
        private MediaPlayer playerMain = new MediaPlayer();
        private readonly System.Windows.Threading.DispatcherTimer timerLife = new System.Windows.Threading.DispatcherTimer();
        private readonly System.Windows.Threading.DispatcherTimer timerThoughts = new System.Windows.Threading.DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            player.MediaFailed += (s, r) => MessageBox.Show("Error");
            player.Open(new Uri(@"sound/Pikachu_start.mp3", UriKind.RelativeOrAbsolute));
            player.Play();
        }

        private void btnStartGame_Click(object sender, RoutedEventArgs e)
        {
            tamagochi = new Tamagochi();

            DrawGame();
            DrawTamagochi();

            DrawLifeBarDecreasing();
            DrawThoughtsChange();
            playerMain.Open(new Uri(@"sound/main.mp3", UriKind.RelativeOrAbsolute));
            playerMain.Play();
            PlayPikachuThought();


        }

        private void PlayPikachuThought()
        {
            
            switch (tamagochi.ThoughtID)
            {
                case 0: //feed
                    {
                        player.Open(new Uri(@"sound/Pikachu_feed.mp3", UriKind.RelativeOrAbsolute));
                        break;
                    }
                case 1: //walk
                    {
                        player.Open(new Uri(@"sound/Pikachu_walk.mp3", UriKind.RelativeOrAbsolute));
                        break;
                    }
                case 2: //cure
                    {
                        player.Open(new Uri(@"sound/Pikachu_sick.mp3", UriKind.RelativeOrAbsolute));
                        break;
                    }
                case 3: //sleep
                    {
                        player.Open(new Uri(@"sound/Pikachu_sleep.mp3", UriKind.RelativeOrAbsolute));
                        break;
                    }
                case 4: //play
                    {
                        player.Open(new Uri(@"sound/Pikachu_play.mp3", UriKind.RelativeOrAbsolute));
                        break;
                    }
                case 5: //thank you
                    {
                        player.Open(new Uri(@"sound/Pikachu_thankyou.mp3", UriKind.RelativeOrAbsolute));
                        break;
                    }
                default:
                    break;
            }

            player.Play();


        }

        private void DrawThoughtsChange()
        {
            timerThoughts.Interval = TimeSpan.FromSeconds(10);
            timerThoughts.Tick += TickThought;
            timerThoughts.Start();
        }

        private void TickThought(object sender, EventArgs e)
        {
            tamagochi.ThoughtID = tamagochi.GetNewThoughtID();
            DrawTamagochiThougts();
            PlayPikachuThought();
        }

        private void DrawLifeBarDecreasing()
        {
            timerLife.Interval = TimeSpan.FromSeconds(1);
            timerLife.Tick += TickLife;
            timerLife.Start();
        }

        private void TickLife(object sender, EventArgs e)
        {
            tamagochi.LowerLife(10);
            DrawTamagochiLifeBar();
        }

        private void DrawTamagochi()
        {
            DrawTamagochiLifeBar();
            DrawTamagochiThougts();
        }

        private void DrawTamagochiThougts()
        {
            myCanvasThoughts.Children.Clear();
            Shape thoughts = tamagochi.GetThoughtsShape();
            Canvas.SetLeft(thoughts, 80);
            Canvas.SetTop(thoughts, 30);
            myCanvasThoughts.Children.Add(thoughts);

            Label lbThoughts = new Label();
            lbThoughts.Content = tamagochi.Thoughts[tamagochi.ThoughtID];
            lbThoughts.Foreground = new SolidColorBrush(Colors.Green);
            lbThoughts.FontWeight = FontWeights.Bold;
            lbThoughts.FontSize = 15;

            Canvas.SetLeft(lbThoughts, 100);
            Canvas.SetTop(lbThoughts, -25);
            myCanvasThoughts.Children.Add(lbThoughts);
        }

        private void DrawTamagochiLifeBar()
        {
            myCanvasLife.Children.Clear();
            Shape lifeBar = tamagochi.GetLifeBar();
            Canvas.SetLeft(lifeBar, 30);
            Canvas.SetTop(lifeBar, 15);

            myCanvasLife.Children.Add(lifeBar); 
        }

        private void DrawGame()
        {
            gridGame.Visibility = Visibility.Visible;
        }

        private void btnFeed_Click(object sender, RoutedEventArgs e)
        {
            if (tamagochi.ThoughtID == 0)
            {
                tamagochi.AddLife(tamagochi.LifeAdditionStep);
                DrawTamagochiThougts();
                DrawTamagochiLifeBar();
                PlayPikachuThought();

            }

        }
        private void btnWalk_Click(object sender, RoutedEventArgs e)
        {
            if (tamagochi.ThoughtID == 1)
            {
                tamagochi.AddLife(tamagochi.LifeAdditionStep);
                DrawTamagochiThougts();
                DrawTamagochiLifeBar();
                PlayPikachuThought();

            }
        }
        private void btnCure_Click(object sender, RoutedEventArgs e)
        {
            if (tamagochi.ThoughtID == 2)
            {
                tamagochi.AddLife(tamagochi.LifeAdditionStep);
                DrawTamagochiThougts();
                DrawTamagochiLifeBar();
                PlayPikachuThought();

            }
        }
        private void btnSleep_Click(object sender, RoutedEventArgs e)
        {
            if (tamagochi.ThoughtID == 3)
            {
                tamagochi.AddLife(tamagochi.LifeAdditionStep);
                DrawTamagochiThougts();
                DrawTamagochiLifeBar();
                PlayPikachuThought();

            }
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            if (tamagochi.ThoughtID == 4)
            {
                tamagochi.AddLife(tamagochi.LifeAdditionStep);
                DrawTamagochiThougts();
                DrawTamagochiLifeBar();
                PlayPikachuThought();

            }
        }

    }
}
