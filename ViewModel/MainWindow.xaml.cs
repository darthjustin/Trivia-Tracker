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

        public void ButtonAddQuestion_Click(object sender, RoutedEventArgs e)
        {
            // Add Question Button Clicked
        }

        public void ButtonAddAnswer_Click(object sender, RoutedEventArgs e)
        {
            // Add Answer Button Clicked
        }

        public void ButtonAddPlayer_Click(object sender, RoutedEventArgs e)
        {
            // Add Game Button Clicked
        }

        public void ButtonPlayerStats_Click(object sender, RoutedEventArgs e)
        {
            // Add Game Button Clicked

        }
    }
}
