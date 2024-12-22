using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.IO;
using System.Linq;

namespace proekt1
{

    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
            InitializeTimer(); // Инициализация таймера
        }
        private int level2Result = 0; // Результат уровня 2
        private TimeSpan timeElapsed;
        private int foundPairsCount = 0; // Счетчик найденных пар
        private const int totalPairsCount = 7; // Общее количество пар
        private bool[] pairsFound = new bool[totalPairsCount]; // Массив для отслеживания найденных пар
        private DispatcherTimer timer; // Таймер
        private TimeSpan elapsedTime; // Время, прошедшее с начала игры
        private int score; // Счет за уровень

        private void InitializeTimer()
        {
            elapsedTime = TimeSpan.Zero; // Начальное значение времени
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); // Интервал в 1 секунду
            timer.Tick += Timer_Tick; // Подписка на событие Tick
            timer.Start(); // Запуск таймера
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            timeElapsed = timeElapsed.Add(TimeSpan.FromSeconds(1));
            timerTextBox.Text = timeElapsed.ToString();
        }
        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle clickedRectangle = sender as Rectangle;

            // Проверяем каждую пару и увеличиваем счетчик только если пара еще не найдена
            if ((clickedRectangle == Rectangle1 || clickedRectangle == Rectangle1_1) && !pairsFound[0])
            {
                Rectangle1.Stroke = Brushes.Green;
                Rectangle1_1.Stroke = Brushes.Red;
                pairsFound[0] = true; // Устанавливаем, что пара найдена
                foundPairsCount++;
            }
            else if ((clickedRectangle == Rectangle2 || clickedRectangle == Rectangle2_2) && !pairsFound[1])
            {
                Rectangle2.Stroke = Brushes.Green;
                Rectangle2_2.Stroke = Brushes.Red;
                pairsFound[1] = true;
                foundPairsCount++;
            }
            else if ((clickedRectangle == Rectangle3 || clickedRectangle == Rectangle3_3) && !pairsFound[2])
            {
                Rectangle3.Stroke = Brushes.Green;
                Rectangle3_3.Stroke = Brushes.Red;
                pairsFound[2] = true;
                foundPairsCount++;
            }
            else if ((clickedRectangle == Rectangle4 || clickedRectangle == Rectangle4_4) && !pairsFound[3])
            {
                Rectangle4.Stroke = Brushes.Green;
                Rectangle4_4.Stroke = Brushes.Red;
                pairsFound[3] = true;
                foundPairsCount++;
            }
            else if ((clickedRectangle == Rectangle5 || clickedRectangle == Rectangle5_5) && !pairsFound[4])
            {
                Rectangle5.Stroke = Brushes.Green;
                Rectangle5_5.Stroke = Brushes.Red;
                pairsFound[4] = true;
                foundPairsCount++;
            }
            else if ((clickedRectangle == Rectangle6 || clickedRectangle == Rectangle6_6) && !pairsFound[5])
            {
                Rectangle6.Stroke = Brushes.Green;
                Rectangle6_6.Stroke = Brushes.Red;
                pairsFound[5] = true;
                foundPairsCount++;
            }
            else if ((clickedRectangle == Rectangle7 || clickedRectangle == Rectangle7_7) && !pairsFound[6])
            {
                Rectangle7.Stroke = Brushes.Green;
                Rectangle7_7.Stroke = Brushes.Red;
                pairsFound[6] = true;
                foundPairsCount++;
            }
            UpdateTextBox();
            if (foundPairsCount >= totalPairsCount)
            {
                timer.Stop();
                MessageBox.Show("Поздравляем! Все пары найдены.");
                score = CalculateScore(timeElapsed);
                SaveResult(score); // Сохраняем результат
                Window6 windows6 = new Window6(timeElapsed);
                windows6.Show();
                this.Close();
            }
        }

        private int CalculateScore(TimeSpan timeElapsed)
        {
            int bonusPoints = 0;

            if (timeElapsed.TotalSeconds < 15)
            {
                bonusPoints = 200;
            }
            else if (timeElapsed.TotalSeconds < 35)
            {
                bonusPoints = 150;
            }
            else
            {
                bonusPoints = 100;
            }

            return bonusPoints;
        }
        private void SaveResult(int score)
        {

            // Сохраняем результаты для текущего уровня
            level2Result += score; // Предположим, что это результат текущего уровня
            string resultLine = $"{level2Result};";

            string filePath = "results.txt";

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(resultLine); // Сохраняем никнейм и результаты
                }

                MessageBox.Show("Результаты успешно сохранены!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при записи в файл: {ex.Message}");
            }
        }
        private void UpdateTextBox()
        {
            resultTextBox.Text = $"{foundPairsCount}/{totalPairsCount}";
        }

        
    }
}

