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
    /// Interaction logic for AddQuestion.xaml
    /// </summary>
    public partial class AddQuestion : Window
    {
        //private int questionCount = 1; // Initialize question count to 0
        public AddQuestion()
        {
            InitializeComponent();
        }

        /*
            public void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            // Back Button Clicked
            AddGame addGameWindow = new AddGame();
            addGameWindow.Show();
            this.Hide();
            addGameWindow.Closed += (s, args) => this.Show();
        }

            public void ButtonNext_Click(object sender, RoutedEventArgs e)
        {
            // Next Button Clicked
            questionCount++; // Increment question count
            if (questionCount < 5) // Check if less than 5 questions
            {
                // Show next question
                MessageBox.Show($"Question {questionCount + 1} of 5");
            }
            else
            {
                // Show finish message
                MessageBox.Show("All questions have been added.");
                this.Close(); // Close the window after adding all questions
            }
        }
        */
    }
}
