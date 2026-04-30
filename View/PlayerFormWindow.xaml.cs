using System;
using System.Windows;
using Trivia_Tracker.Model;

namespace Trivia_Tracker.View
{
    /// <summary>
    /// Interaction logic for PlayerFormWindow.xaml
    /// </summary>
    public partial class PlayerFormWindow : Window
    {
        public Player Player { get; private set; } = null!;
        private readonly bool _isEditMode;

        public PlayerFormWindow()
        {
            InitializeComponent();
            _isEditMode = false;
            CreatedDatePicker.SelectedDate = DateTime.Now;
        }

        public PlayerFormWindow(Player existingPlayer)
            : this()
        {
            _isEditMode = true;
            HeaderText.Text = "Edit Player";
            Player = existingPlayer;
            FirstNameTextBox.Text = existingPlayer.FirstName;
            LastNameTextBox.Text = existingPlayer.LastName;
            UsernameTextBox.Text = existingPlayer.Username;
            CreatedDatePicker.SelectedDate = existingPlayer.CreatedDate;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string firstName = FirstNameTextBox.Text.Trim();
            string lastName = LastNameTextBox.Text.Trim();
            string username = UsernameTextBox.Text.Trim();
            DateTime createdDate = CreatedDatePicker.SelectedDate ?? DateTime.Now;

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("First name, last name, and username are required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (_isEditMode)
            {
                Player.FirstName = firstName;
                Player.LastName = lastName;
                Player.Username = username;
                Player.CreatedDate = createdDate;
            }
            else
            {
                Player = new Player(
                    0,
                    firstName,
                    lastName,
                    username,
                    createdDate,
                    createdDate,
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    0);
            }

            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
