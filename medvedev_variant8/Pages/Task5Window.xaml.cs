using System;
using System.Windows;

namespace medvedev_variant8.Pages
{
    public partial class Task5Window : Window
    {
        private int[,] matrix;
        private int rows;
        private int cols;

        public Task5Window()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            if (txtRows.Text == "" || txtCols.Text == "")
            {
                MessageBox.Show("Введите количество строк и столбцов!");
                return;
            }

            int r, c;
            bool okR = int.TryParse(txtRows.Text, out r);
            bool okC = int.TryParse(txtCols.Text, out c);

            if (okR == false || okC == false)
            {
                MessageBox.Show("Введите корректные целые числа!");
                return;
            }

            if (r < 1 || r > 10 || c < 1 || c > 10)
            {
                MessageBox.Show("Размеры должны быть от 1 до 10!");
                return;
            }

            rows = r;
            cols = c;

            matrix = new int[rows, cols];
            Random rnd = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = rnd.Next(-10, 11);
                }
            }

            txtOriginal.Text = MatrixToString(matrix);

            ShowSorted();
        }

        private void ShowSorted()
        {
            int total = rows * cols;
            int[] flat = new int[total];
            int k = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    flat[k] = matrix[i, j];
                    k = k + 1;
                }
            }

            int[] asc = new int[total];
            for (int i = 0; i < total; i++)
            {
                asc[i] = flat[i];
            }

            for (int i = 0; i < total - 1; i++)
            {
                for (int j = 0; j < total - 1 - i; j++)
                {
                    if (asc[j] > asc[j + 1])
                    {
                        int temp = asc[j];
                        asc[j] = asc[j + 1];
                        asc[j + 1] = temp;
                    }
                }
            }

            int[] desc = new int[total];
            for (int i = 0; i < total; i++)
            {
                desc[i] = asc[total - 1 - i];
            }

            int[,] ascMatrix = new int[rows, cols];
            int[,] descMatrix = new int[rows, cols];
            k = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    ascMatrix[i, j] = asc[k];
                    descMatrix[i, j] = desc[k];
                    k = k + 1;
                }
            }

            txtAsc.Text = MatrixToString(ascMatrix);
            txtDesc.Text = MatrixToString(descMatrix);

            int min = flat[0];
            int max = flat[0];

            for (int i = 1; i < total; i++)
            {
                if (flat[i] < min) min = flat[i];
                if (flat[i] > max) max = flat[i];
            }

            txtMinMax.Text = "Минимальный элемент: " + min + "\n" +
                             "Максимальный элемент: " + max;
        }

        private string MatrixToString(int[,] m)
        {
            string text = "";

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    string number = m[i, j].ToString();

                    if (m[i, j] >= 0 && m[i, j] < 10)
                    {
                        number = " " + number;
                    }
                    else if (m[i, j] < 0 && m[i, j] > -10)
                    {
                        number = " " + number;
                    }

                    text = text + number;

                    if (j < cols - 1)
                    {
                        text = text + "  ";
                    }
                }

                if (i < rows - 1)
                {
                    text = text + "\n";
                }
            }

            return text;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}