using System;
using System.Windows;

namespace medvedev_variant8.Pages
{
    public partial class Task3Window : Window
    {
        private int[] points;

        public Task3Window()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            if (txtCount.Text == "")
            {
                MessageBox.Show("Введите количество точек!");
                return;
            }

            int count;
            bool result = int.TryParse(txtCount.Text, out count);

            if (result == false)
            {
                MessageBox.Show("Введите корректное целое число!");
                return;
            }

            if (count < 2 || count > 20)
            {
                MessageBox.Show("Количество точек должно быть от 2 до 20!");
                return;
            }

            points = new int[count];
            Random rnd = new Random();

            for (int i = 0; i < count; i++)
            {
                points[i] = rnd.Next(-50, 51);
            }

            string text = "";
            for (int i = 0; i < points.Length; i++)
            {
                text = text + points[i];
                if (i < points.Length - 1)
                {
                    text = text + ", ";
                }
            }
            txtArray.Text = text;

            txtResult.Text = "";
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (points == null)
            {
                MessageBox.Show("Сначала сгенерируйте массив!");
                return;
            }

            int bestIndex = 0;
            int bestSum = int.MaxValue;

            for (int i = 0; i < points.Length; i++)
            {
                int sum = 0;
                for (int j = 0; j < points.Length; j++)
                {
                    sum = sum + Math.Abs(points[i] - points[j]);
                }

                if (sum < bestSum)
                {
                    bestSum = sum;
                    bestIndex = i;
                }
            }

            txtResult.Text = "Искомая точка: " + points[bestIndex] + "\n" +
                             "Сумма расстояний: " + bestSum;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}