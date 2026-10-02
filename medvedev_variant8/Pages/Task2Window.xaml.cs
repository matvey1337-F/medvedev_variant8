using System;
using System.Windows;

namespace medvedev_variant8.Pages
{
    public partial class Task2Window : Window
    {
        public Task2Window()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (txtInput.Text == "")
            {
                MessageBox.Show("Введите строку!");
                return;
            }

            string text = txtInput.Text.Trim();
            string newText = "";
            bool wasSpace = false;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                {
                    if (wasSpace == false)
                    {
                        newText = newText + " ";
                    }
                    wasSpace = true;
                }
                else
                {
                    newText = newText + text[i];
                    wasSpace = false;
                }
            }

            string[] words = newText.Split(' ');

            string longest = "";
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > longest.Length)
                {
                    longest = words[i];
                }
            }

            txtResult.Text = "Самое длинное слово: " + longest + "\n" +
                             "Длина: " + longest.Length + " символов";
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}