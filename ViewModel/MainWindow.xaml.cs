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
using System.Windows.Shapes;

namespace Trivia_Tracker.ViewModel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void ButtonAddGame_Click(object sender, RoutedEventArgs e)
        {
            // Add Game Button Clicked
            AddGame addGameWindow = new AddGame();
            addGameWindow.Show();
            this.Hide();

            addGameWindow.Closed += (s, args) => this.Show();
        }

        public void ButtonAddPlayer_Click(object sender, RoutedEventArgs e)
        {
            // Add Player Button Clicked
            AddPlayer addPlayerWindow = new AddPlayer();
            addPlayerWindow.Show();
            this.Hide();

            addPlayerWindow.Closed += (s, args) => this.Show();
        }

        public void ButtonPlayerStats_Click(object sender, RoutedEventArgs e)
        {
            // Add Team Button Clicked
            PlayerStats playerStatsWindow = new PlayerStats();
            playerStatsWindow.Show();
            this.Hide();

            playerStatsWindow.Closed += (s, args) => this.Show();
        }

        public void ButtonAddPlayer_Click(object sender, RoutedEventArgs e)
        {
            // Add Player Button Clicked
        }

        public void ButtonPlayerStats_Click(object sender, RoutedEventArgs e)
        {
            // Player Stats Button Clicked
        }
    }
}
