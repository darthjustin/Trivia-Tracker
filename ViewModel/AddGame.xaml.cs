﻿using System;
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
    /// Interaction logic for AddGame.xaml
    /// </summary>
    public partial class AddGame : Window
    {
        public AddGame()
        {
            InitializeComponent();
        }

        private void ButtonNext_Click(object sender, RoutedEventArgs e)
        {
            AddQuestion addQuestionWindow = new AddQuestion();
            addQuestionWindow.Show();
            this.Hide();
        }
    }
}
