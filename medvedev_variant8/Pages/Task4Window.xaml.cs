using System;
using System.Windows;

namespace medvedev_variant8.Pages
{
    public partial class Task4Window : Window
    {
        private int[] array;

        public Task4Window()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            if (txtCount.Text == "")
            {
                MessageBox.Show("Введите размер массива!");
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
                MessageBox.Show("Размер массива должен быть от 2 до 20!");
                return;
            }

            array = new int[count];
            Random rnd = new Random();

            for (int i = 0; i < count; i++)
            {
                array[i] = rnd.Next(-20, 21);
            }

            string text = "";
            for (int i = 0; i < array.Length; i++)
            {
                text = text + array[i];
                if (i < array.Length - 1)
                {
                    text = text + ", ";
                }
            }
            txtArray.Text = text;
            txtResult.Text = "";
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (array == null)
            {
                MessageBox.Show("Сначала сгенерируйте массив!");
                return;
            }

            int firstEvenIndex = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    firstEvenIndex = i;
                    break;
                }
            }
            int lastNegativeIndex = -1;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] < 0)
                {
                    lastNegativeIndex = i;
                    break;
                }
            }

            if (firstEvenIndex == -1)
            {
                txtResult.Text = "В массиве нет чётных элементов.";
                return;
            }

            if (lastNegativeIndex == -1)
            {
                txtResult.Text = "В массиве нет отрицательных элементов.";
                return;
            }

            if (firstEvenIndex == lastNegativeIndex)
            {
                txtResult.Text = "Первый чётный и последний отрицательный — " +
                                 "это один и тот же элемент. Менять нечего.";
                return;
            }

            int firstEvenValue = array[firstEvenIndex];
            int lastNegativeValue = array[lastNegativeIndex];

            int temp = array[firstEvenIndex];
            array[firstEvenIndex] = array[lastNegativeIndex];
            array[lastNegativeIndex] = temp;

            string text = "Первый чётный: " + firstEvenValue +
                          " (позиция " + firstEvenIndex + ")\n" +
                          "Последний отрицательный: " + lastNegativeValue +
                          " (позиция " + lastNegativeIndex + ")\n\n" +
                          "Массив после перестановки: ";

            for (int i = 0; i < array.Length; i++)
            {
                text = text + array[i];
                if (i < array.Length - 1)
                {
                    text = text + ", ";
                }
            }

            txtResult.Text = text;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}