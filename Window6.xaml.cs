using System;
using System.Collections.Generic;
using System.Linq;

using System.Windows;
namespace proekt1
{
    public partial class Window6 : Window
    {
        private TimeSpan timeElapsed;
        public Window6(TimeSpan elapsedTime)
        {
            InitializeComponent();
            timeElapsed = elapsedTime;
            DisplayElapsedTime();
        }
        private void ButtonMenu_Click(object sender, RoutedEventArgs e)
        {
            Window1 windows1 = new Window1();
            windows1.Show();
            this.Close();
        }
        private void Buttontablider_Click(object sender, RoutedEventArgs e)
        {
            Window7 windows7 = new Window7();
            windows7.Show();
        }

        private void DisplayElapsedTime()
        {
            elapsedTimeTextBlock.Text = $"{timeElapsed}";
        }
    }
}
