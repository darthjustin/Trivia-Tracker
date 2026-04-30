using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Trivia_Tracker.Helpers;
using Trivia_Tracker.Model;

namespace Trivia_Tracker.View
{
    /// <summary>
    /// Interaction logic for PlayersView.xaml
    /// </summary>
    public partial class PlayersView : UserControl
    {
        private ObservableCollection<Player> allPlayers;
        private ObservableCollection<Player> filteredPlayers;
        private PlayerQuery playerQuery;

        public PlayersView()
        {
            InitializeComponent();
            playerQuery = new PlayerQuery();
            allPlayers = new ObservableCollection<Player>();
            filteredPlayers = new ObservableCollection<Player>();
            
            Loaded += PlayersView_Loaded;
        }

        private void PlayersView_Loaded(object sender, RoutedEventArgs e)
        {
            LoadPlayers();
        }

        private void LoadPlayers()
        {
            try
            {
                allPlayers.Clear();
                var players = playerQuery.GetAllPlayers();
                
                foreach (var player in players)
                {
                    allPlayers.Add(player);
                }

                FilterPlayers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading players: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void FilterPlayers()
        {
            string searchText = SearchBox.Text?.ToLower() ?? "";
            
            filteredPlayers.Clear();

            var filtered = allPlayers.Where(p => 
                p.FirstName.ToLower().Contains(searchText) ||
                p.LastName.ToLower().Contains(searchText) ||
                p.Username.ToLower().Contains(searchText)
            ).ToList();

            foreach (var player in filtered)
            {
                filteredPlayers.Add(player);
            }

            PlayersDataGrid.ItemsSource = filteredPlayers;
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterPlayers();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            LoadPlayers();
            MessageBox.Show("Players list refreshed.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void AddPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            var playerForm = new PlayerFormWindow();
            playerForm.Owner = Window.GetWindow(this);

            if (playerForm.ShowDialog() == true && playerForm.Player != null)
            {
                try
                {
                    playerQuery.AddPlayer(playerForm.Player);
                    LoadPlayers();
                    MessageBox.Show("Player added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding player: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (PlayersDataGrid.SelectedItem is Player selectedPlayer)
            {
                var playerForm = new PlayerFormWindow(selectedPlayer);
                playerForm.Owner = Window.GetWindow(this);

                if (playerForm.ShowDialog() == true && playerForm.Player != null)
                {
                    try
                    {
                        playerQuery.UpdatePlayer(playerForm.Player);
                        LoadPlayers();
                        MessageBox.Show("Player updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating player: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (PlayersDataGrid.SelectedItem is Player selectedPlayer)
            {
                MessageBoxResult result = MessageBox.Show(
                    $"Are you sure you want to delete {selectedPlayer.FullName}?",
                    "Confirm Delete",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        playerQuery.DeletePlayer(selectedPlayer.PlayerID);
                        LoadPlayers();
                        MessageBox.Show("Player deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting player: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void PlayersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool hasSelection = PlayersDataGrid.SelectedItem != null;
            EditButton.IsEnabled = hasSelection;
            DeleteButton.IsEnabled = hasSelection;
        }
    }
}

