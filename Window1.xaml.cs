using System;
using System.IO;
using System.Windows;
namespace proekt1
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2(this);
            window2.Show();
            this.Close();
        }
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Window3 windows1 = new Window3();
            windows1.Show();
            this.Close();
        }
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            Window4 windows1 = new Window4();
            windows1.Show();
            this.Close();
        }
        private void ButtonReg_Click(object sender, RoutedEventArgs e)
        {
            string nickname = NicknameTextBox.Text;
            if (string.IsNullOrWhiteSpace(nickname))
            {
                MessageBox.Show("Пожалуйста, введите никнейм.");
                return;
            }
            // Форматируем строку для сохранения
            string resultLine = $"{nickname}";
            string filePath = "results.txt";
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(resultLine); // Сохраняем только никнейм и результаты
                }
                MessageBox.Show("Никнейм успешно сохранен!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при записи в файл: {ex.Message}");
            }
        }
    }
}


