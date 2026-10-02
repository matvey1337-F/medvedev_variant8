using System;
using System.Windows;
using medvedev_variant8.Pages;

namespace medvedev_variant8
{
    // Тестовый комментарий
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Второе изменение для фиксации без подготовки
        }

        private void btnTask1_Click(object sender, RoutedEventArgs e)
        {
            Task1Window task1 = new Task1Window();
            task1.Show();
            this.Hide();
        }

        private void btnTask2_Click(object sender, RoutedEventArgs e)
        {
            Task2Window task2 = new Task2Window();
            task2.Show();
            this.Hide();
        }

        private void btnTask3_Click(object sender, RoutedEventArgs e)
        {
            Task3Window task3 = new Task3Window();
            task3.Show();
            this.Hide();
        }

        private void btnTask4_Click(object sender, RoutedEventArgs e)
        {
            Task4Window task4 = new Task4Window();
            task4.Show();
            this.Hide();
        }

        private void btnTask5_Click(object sender, RoutedEventArgs e)
        {
            Task5Window task5 = new Task5Window();
            task5.Show();
            this.Hide();
        }
    }
}
