using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Trivia_Tracker.Helpers;
using Trivia_Tracker.Model;

namespace Trivia_Tracker.ViewModel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DatabaseHelper.GetConnection();
            InitializeComponent();
            
            PlayerQuery playerQuery = new PlayerQuery();
            
            ResponseQuery responseQuery = new ResponseQuery();


            List<Player> players = playerQuery.GetAllPlayers();
            List<Response> responses = new ResponseQuery().getAllResponses();

            foreach (Player player in players)
            {
                Debug.WriteLine($"Player ID: {player.PlayerID}, Name: {player.FirstName} {player.LastName}, Username: {player.Username}, Total Score: {player.TotalScore}");

            }
            foreach (Response response in responses)
            {
                Debug.WriteLine($"Response ID: {response.ResponseID}, Question ID: {response.QuestionID}, Player ID: {response.PlayerID}, Answer: {response.ResponseText}, Is Correct: {response.IsCorrect}, Is Bonus Used: {response.BonusUsed}");
            }
        }

        public void ButtonAddGame_Click(object sender, RoutedEventArgs e)
        {
            // Add Game Button Clicked

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

        private void PlayerListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Player List Box Selection Changed
            var selectedPlayer = PlayerListBox.SelectedItems.Cast<Player>().ToList();

            SetPlayerHeader(Player1Header, selectedPlayer, 0, 3);
            SetPlayerHeader(Player2Header, selectedPlayer, 1, 4);
            SetPlayerHeader(Player3Header, selectedPlayer, 2, 5);
            SetPlayerHeader(Player4Header, selectedPlayer, 3, 6);
        }

        private void SetPlayerHeader(TextBlock header, List<Player> selected, int index, int columnIndex)
        {
            if (index < selected.Count)
            {
                header.Text = selected[index].FirstName + " " + selected[index].LastName;
                header.Visibility = Visibility.Visible;
                Round1Grid.ColumnDefinitions[columnIndex].Width = GridLength.Auto;
            }
            else
            {
                header.Text = string.Empty;
                header.Visibility = Visibility.Collapsed;
                Round1Grid.ColumnDefinitions[columnIndex].Width = new GridLength(0);
            }
        }
    }
}
