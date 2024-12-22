using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Newtonsoft.Json; // Не забудьте установить Newtonsoft.Json через NuGet

namespace proekt1
{
    /// <summary>
    /// Логика взаимодействия для Window5.xaml
    /// </summary>
    public partial class Window5 : Window
    {
        private const string LeaderboardFile = "leaderboard.json"; // Объявление константы
        public Window5()
        {
            InitializeComponent();
        }
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string nickname = NicknameTextBox.Text; // Получаем никнейм из TextBox
            if (!string.IsNullOrWhiteSpace(nickname))
            {
                SavePlayerResult(nickname, 0); // Сохраняем результат (например, 0)
                MessageBox.Show("Вы зарегистрированы!");
                // Открыть окно с таблицей лидеров
                Window1 leaderboardWindow = new Window1();
                this.Close();
                leaderboardWindow.Show();
            }
            else
            {
                MessageBox.Show("Введите корректный никнейм.");
            }
        }
        private void SavePlayerResult(string nickname, int bonusPoints)
        {
            var leaderboard = LoadLeaderboard();
            leaderboard.Add(new Player(nickname) { BonusPoints = bonusPoints }); // Используем конструктор
            File.WriteAllText(LeaderboardFile, JsonConvert.SerializeObject(leaderboard));
        }


        private List<Player> LoadLeaderboard()
        {
            if (File.Exists("leaderboard.json"))
            {
                var json = File.ReadAllText("leaderboard.json");
                return JsonConvert.DeserializeObject<List<Player>>(json) ?? new List<Player>();
            }
            return new List<Player>();
        }
    }

    
}

