using System;
using System.Windows;

namespace medvedev_variant8.Pages
{
    public partial class Task1Window : Window
    {
        public Task1Window()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (txtInput.Text == "")
            {
                MessageBox.Show("Введите число!");
                return;
            }

            int number;
            bool result = int.TryParse(txtInput.Text, out number);

            if (result == false)
            {
                MessageBox.Show("Введите корректное целое число!");
                return;
            }

            if (number < -999 || number > 999)
            {
                MessageBox.Show("Число должно быть от -999 до 999!");
                return;
            }

            string description = "";

            if (number == 0)
            {
                description = "нулевое число";
            }
            else
            {

                string sign = "";
                if (number > 0)
                {
                    sign = "положительное";
                }
                else
                {
                    sign = "отрицательное";
                }

                int absNumber = Math.Abs(number);
                string digits = "";

                if (absNumber >= 1 && absNumber <= 9)
                {
                    digits = "однозначное";
                }
                else if (absNumber >= 10 && absNumber <= 99)
                {
                    digits = "двузначное";
                }
                else
                {
                    digits = "трехзначное";
                }

                description = sign + " " + digits + " число";
            }

            txtResult.Text = description;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}