using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.IO;

namespace proekt1
{
    public partial class Window2 : Window
    {
        private int level1Result = 0; // Результат уровня 1
        private Window1 mainWindow; // Ссылка на Window1
        private int score; // Счет за уровень
        private DispatcherTimer timer;
        private TimeSpan timeElapsed;
        private int foundPairsCount = 0; // Счетчик найденных пар
        private const int totalPairsCount = 5; // Общее количество пар
        private bool[] pairsFound = new bool[totalPairsCount]; // Массив для отслеживания найденных пар;

        public object nickname { get; private set; }

        public Window2(Window1 mainWindow)
        {
            InitializeComponent();
            StartTimer();
            this.mainWindow = mainWindow; // Сохраняем ссылку на Window1
            
        }
        private void StartTimer()
        {
            timeElapsed = TimeSpan.Zero;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            timeElapsed = timeElapsed.Add(TimeSpan.FromSeconds(1));
            timerTextBox.Text = timeElapsed.ToString();
        }
        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle clickedRectangle = sender as Rectangle;
            if ((clickedRectangle == Rectangle1 || clickedRectangle == Rectangle1_1) && !pairsFound[0])
            {
                Rectangle1.Stroke = Brushes.Green;
                Rectangle1_1.Stroke = Brushes.Red;
                pairsFound[0] = true; // Устанавливаем, что пара найдена
                foundPairsCount++;
                UpdateTextBox(); // Обновляем текстовое поле
            }
            else if ((clickedRectangle == Rectangle2 || clickedRectangle == Rectangle2_2) && !pairsFound[1])
            {
                Rectangle2.Stroke = Brushes.Green;
                Rectangle2_2.Stroke = Brushes.Red;
                pairsFound[1] = true;
                foundPairsCount++;
                UpdateTextBox(); // Обновляем текстовое поле
            }
            else if ((clickedRectangle == Rectangle3 || clickedRectangle == Rectangle3_3) && !pairsFound[2])
            {
                Rectangle3.Stroke = Brushes.Green;
                Rectangle3_3.Stroke = Brushes.Red;
                pairsFound[2] = true;
                foundPairsCount++;
                UpdateTextBox(); // Обновляем текстовое поле
            }
            else if ((clickedRectangle == Rectangle4 || clickedRectangle == Rectangle4_4) && !pairsFound[3])
            {
                Rectangle4.Stroke = Brushes.Green;
                Rectangle4_4.Stroke = Brushes.Red;
                pairsFound[3] = true;
                foundPairsCount++;
                UpdateTextBox(); // Обновляем текстовое поле
            }
            else if ((clickedRectangle == Rectangle5 || clickedRectangle == Rectangle5_5) && !pairsFound[4])
            {
                Rectangle5.Stroke = Brushes.Green;
                Rectangle5_5.Stroke = Brushes.Red;
                pairsFound[4] = true;
                foundPairsCount++;
                UpdateTextBox(); // Обновляем текстовое поле

            }
            UpdateTextBox();
            if (foundPairsCount == totalPairsCount)
            {
                timer.Stop();
                MessageBox.Show("Поздравляем! Все пары найдены.");
                score = CalculateScore(timeElapsed);
                SaveResult(score); // Сохраняем результат
                Window6 windows2 = new Window6(timeElapsed);
                windows2.Show();
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
            level1Result += score; // Предположим, что это результат текущего уровня
            string resultLine = $"{level1Result};";

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

