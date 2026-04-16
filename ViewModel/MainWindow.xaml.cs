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
using Trivia_Tracker.View;


namespace Trivia_Tracker.ViewModel
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly AddGameView _addGameView = new();
        private readonly StatsView _statsView = new();
        private readonly PlayersView _playersView = new();
        private readonly SettingsView _settingsView = new();

        private bool _isLoaded;

        public MainWindow()
        {
            DatabaseHelper.GetConnection();
            InitializeComponent();

            Loaded += (_, __) =>
            {
                _isLoaded = true;

                int savedIndex = Properties.Settings.Default.LastNavIndex;

                if (savedIndex < 0 || savedIndex > 3)
                {
                    savedIndex = 0;
                }

                NavList.SelectedIndex = savedIndex; // loads last saved view
                NavigateTo(savedIndex);
            };

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


        //private void PlayerListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    // Player List Box Selection Changed
        //    var selectedPlayer = PlayerListBox.SelectedItems.Cast<Player>().ToList();

        //    SetPlayerHeader(Player1Header, selectedPlayer, 0, 3);
        //    SetPlayerHeader(Player2Header, selectedPlayer, 1, 4);
        //    SetPlayerHeader(Player3Header, selectedPlayer, 2, 5);
        //    SetPlayerHeader(Player4Header, selectedPlayer, 3, 6);
        //}

        //private void SetPlayerHeader(TextBlock header, List<Player> selected, int index, int columnIndex)
        //{
        //    if (index < selected.Count)
        //    {
        //        header.Text = selected[index].FirstName + " " + selected[index].LastName;
        //        header.Visibility = Visibility.Visible;
        //        Round1Grid.ColumnDefinitions[columnIndex].Width = GridLength.Auto;
        //    }
        //    else
        //    {
        //        header.Text = string.Empty;
        //        header.Visibility = Visibility.Collapsed;
        //        Round1Grid.ColumnDefinitions[columnIndex].Width = new GridLength(0);
        //    }
        //}

        private void NavList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!_isLoaded)
            {
                return;
            }
            if (MainContentHost == null)
            {
                return;
            }

            int index = NavList.SelectedIndex;
            if (index < 0)
            {
                return;
            }

            Properties.Settings.Default.LastNavIndex = index;
            Properties.Settings.Default.Save();

            NavigateTo(index);
        }

        private void NavigateTo(int index)
        {
            switch (index)
            {
                case 0:
                    MainContentHost.Content = _addGameView;
                    Title = "Trivia Tracker - Add Game";
                    break;
                case 1:
                    MainContentHost.Content = _statsView;
                    Title = "Trivia Tracker - Stats";
                    break;
                case 2:
                    MainContentHost.Content = _playersView;
                    Title = "Trivia Tracker - Players";
                    break;
                case 3:
                    MainContentHost.Content = _settingsView;
                    Title = "Trivia Tracker - Settings";
                    break;
                default:
                    break;
            }
        }
    }   
}
