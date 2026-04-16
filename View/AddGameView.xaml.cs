using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for AddGameView.xaml
    /// </summary>
    public partial class AddGameView : UserControl
    {
        private ObservableCollection<Player> _players = new();

        public AddGameView()
        {
            InitializeComponent();
            LoadPlayers();
        }

        private void LoadPlayers()
        {
            PlayerQuery playerQuery = new PlayerQuery();
            var players = playerQuery.GetAllPlayers();
            _players = new ObservableCollection<Player>(players);

            foreach (var player in _players)
            {
                player.PropertyChanged += Player_PropertyChanged;
            }

            PlayerListBox.ItemsSource = _players;
            UpdateRoundPlayerColumns();
        }

        private void Player_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Player.IsSelected))
            {
                UpdateRoundPlayerColumns();
            }
        }

        private void UpdateRoundPlayerColumns()
        {
            var selectedPlayers = _players.Where(p => p.IsSelected).ToList();

            ApplySelectedPlayersToGrid(Round1Grid, new[] { Player1Header, Player2Header, Player3Header, Player4Header }, selectedPlayers);
            ApplySelectedPlayersToGrid(Round2Grid, new[] { R2Player1Header, R2Player2Header, R2Player3Header, R2Player4Header }, selectedPlayers);
            ApplySelectedPlayersToGrid(Round3Grid, new[] { R3Player1Header, R3Player2Header, R3Player3Header, R3Player4Header }, selectedPlayers);
            ApplySelectedPlayersToGrid(Round4Grid, new[] { R4Player1Header, R4Player2Header, R4Player3Header, R4Player4Header }, selectedPlayers);

            ApplySelectedPlayersToDoubleDownSection(DD1Grid, new[] { DD1Player1Label, DD1Player2Label, DD1Player3Label, DD1Player4Label }, selectedPlayers);
            ApplySelectedPlayersToDoubleDownSection(DD2Grid, new[] { DD2Player1Label, DD2Player2Label, DD2Player3Label, DD2Player4Label }, selectedPlayers);
            ApplySelectedPlayersToDoubleDownSection(DD3Grid, new[] { DD3Player1Label, DD3Player2Label, DD3Player3Label, DD3Player4Label }, selectedPlayers);
        }

        private void ApplySelectedPlayersToGrid(Grid grid, TextBlock[] headers, IReadOnlyList<Player> selectedPlayers)
        {
            if (selectedPlayers.Count == 0)
            {
                for (int i = 0; i < headers.Length; i++)
                {
                    headers[i].Text = $"Player {i + 1}";
                    headers[i].Visibility = Visibility.Visible;
                    grid.ColumnDefinitions[3 + i].Width = i < 3 ? new GridLength(90) : new GridLength(60);
                }

                return;
            }

            for (int i = 0; i < headers.Length; i++)
            {
                bool active = i < selectedPlayers.Count;
                headers[i].Text = active ? selectedPlayers[i].FullName : string.Empty;
                headers[i].Visibility = active ? Visibility.Visible : Visibility.Collapsed;
                grid.ColumnDefinitions[3 + i].Width = active ? (i < 3 ? new GridLength(90) : new GridLength(60)) : new GridLength(0);
            }
        }

        private void ApplySelectedPlayersToDoubleDownSection(Grid grid, TextBlock[] labels, IReadOnlyList<Player> selectedPlayers)
        {
            for (int i = 0; i < labels.Length; i++)
            {
                bool active = i < selectedPlayers.Count;
                labels[i].Text = active ? selectedPlayers[i].FullName : string.Empty;
                labels[i].Visibility = active ? Visibility.Visible : Visibility.Collapsed;
                grid.RowDefinitions[i].Height = active ? GridLength.Auto : new GridLength(0);
            }
        }
    }
}
