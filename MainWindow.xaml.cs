
using System.Windows;


namespace proekt1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartGameButton_Click(object sender, RoutedEventArgs e)
        {
            Window1 windows1 = new Window1();
            windows1.Show();
            this.Close();
        }
    }
}
