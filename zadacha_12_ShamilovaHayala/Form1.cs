using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace zadacha_12_ShamilovaHayala
{
    public partial class Form1 : Form
    {
        const int n = 3;
        const int sizeButton = 50;
        public int[,] map = new int[n * n, n * n];
        public Button[,] buttons = new Button[n * n, n * n];
        public Form1()
        {
            InitializeComponent();
            GenerateMap();
        }
        private void GenerateMap()
        {
            for (int i = 0; i < n * n; i++)
            {
                for (int j = 0; j < n * n; j++)
                {
                    map[i, j] = (i * n + i / n + j) % (n * n) + 1;
                    buttons[i, j] = new Button();
                }
            }

            Random random = new Random();
            for (int i = 0; i < 40; i++)
            {
                ShuffleMap(random.Next(0, 5));
            }
            CreateMap();
            HideCells();
        }
        public void CreateMap()
        {
            for (int i = 0; i < n * n; i++)
            {
                for (int j = 0; j < n * n; j++)
                {
                    Button button = new Button();
                    buttons[i, j] = button;
                    button.Size = new Size(sizeButton, sizeButton);
                    button.Text = map[i, j].ToString();
                    button.Click += OnCellPressed;
                    button.Location = new Point(j * sizeButton, i * sizeButton);
                    this.Controls.Add(button);
                }
            }
        }
        public void HideCells()
        {
            int N = 40;
            Random random = new Random();
            while (N > 0)
            {
                for (int i = 0; i < n * n; i++)
                {
                    for (int j = 0; j < n * n; j++)
                    {
                        if (!string.IsNullOrEmpty(buttons[i, j].Text))
                        {
                            int a = random.Next(0, 3);
                            buttons[i, j].Text = a == 0 ? "" : buttons[i, j].Text;
                            buttons[i, j].Enabled = a == 0 ? true : false;

                            if (buttons[i, j].Enabled == false)
                            {
                                buttons[i, j].BackColor = Color.White;
                                buttons[i, j].ForeColor = Color.Black;
                            }
                            else
                                buttons[i, j].Cursor = Cursors.Hand;

                            if (a == 0)
                                N--;
                            if (N <= 0)
                                break;
                        }
                    }
                    if (N <= 0)
                        break;
                }
            }
        }
        public void ShuffleMap(int i)
        {
            switch (i)
            {
                case 0:
                    MatrixTransposition();
                    break;
                case 1:
                    SwapRowsInBlock();
                    break;
                case 2:
                    SwapColumnsInBlock();
                    break;
                case 3:
                    SwapBlocksInRow();
                    break;
                case 4:
                    SwapBlocksInColumn();
                    break;
                default:
                    MatrixTransposition();
                    break;
            }
        }

        public void MatrixTransposition()
        {
            int[,] tMap = new int[n * n, n * n];
            for (int i = 0; i < n * n; i++)
            {
                for (int j = 0; j < n * n; j++)
                {
                    tMap[i, j] = map[j, i];
                }
            }
            map = tMap;
        }
        public void SwapRowsInBlock()
        {
            Random random = new Random();
            var block = random.Next(0, n);
            var row1 = random.Next(0, n);
            var line1 = block * n + row1;
            var row2 = random.Next(0, n);
            while (row1 == row2)
                row2 = random.Next(0, n);
            var line2 = block * n + row2;
            for (int i = 0; i < n * n; i++)
            {
                var temp = map[line1, i];
                map[line1, i] = map[line2, i];
                map[line2, i] = temp;
            }
        }
        public void SwapColumnsInBlock()
        {
            Random random = new Random();
            var block = random.Next(0, n);
            var row1 = random.Next(0, n);
            var line1 = block * n + row1;
            var row2 = random.Next(0, n);
            while (row1 == row2)
                row2 = random.Next(0, n);
            var line2 = block * n + row2;
            for (int i = 0; i < n * n; i++)
            {
                var temp = map[i, line1];
                map[i, line1] = map[i, line2];
                map[i, line2] = temp;
            }
        }
        public void SwapBlocksInRow()
        {
            Random random = new Random();
            var block1 = random.Next(0, n);
            var block2 = random.Next(0, n);
            while (block1 == block2)
                block2 = random.Next(0, n);
            block1 *= n;
            block2 *= n;
            for (int i = 0; i < n * n; i++)
            {
                var k = block2;
                for (int j = block1; j < block1 + n; j++)
                {
                    var temp = map[j, i];
                    map[j, i] = map[k, i];
                    map[k, i] = temp;
                    k++;
                }
            }
        }
        public void SwapBlocksInColumn()
        {
            Random random = new Random();
            var block1 = random.Next(0, n);
            var block2 = random.Next(0, n);
            while (block1 == block2)
                block2 = random.Next(0, n);
            block1 *= n;
            block2 *= n;
            for (int i = 0; i < n * n; i++)
            {
                var k = block2;
                for (int j = block1; j < block1 + n; j++)
                {
                    var temp = map[i, j];
                    map[i, j] = map[i, k];
                    map[i, k] = temp;
                    k++;
                }
            }
        }
        public void OnCellPressed(object sender, EventArgs e)
        {
            Button pressedButton = sender as Button;
            string buttonText = pressedButton.Text;
            if (string.IsNullOrEmpty(buttonText))
            {
                pressedButton.Text = "1";
            }
            else
            {
                int num = int.Parse(buttonText);
                num++;
                if (num == 10)
                    num = 1;
                pressedButton.Text = num.ToString();
            }
        }

        private void Check()
        {
            bool allFilled = this.Controls.OfType<Button>().All(b => !string.IsNullOrWhiteSpace(b.Text));
            for (int i = 0; i < n * n; i++)
            {
                for (int j = 0; j < n * n; j++)
                {
                    if (!allFilled)
                    {
                        MessageBox.Show("Заполните все поля!");
                        return;
                    }
                    if (buttons[i, j].Text != map[i, j].ToString())
                    {
                        MessageBox.Show("Решено НЕПРАВИЛЬНО!");
                        return;
                    }
                }
            }
            MessageBox.Show("Решено ПРАВИЛЬНО!");
        }
        private void CheckButton_Click(object sender, EventArgs args)
        {
            Check();
        }
        private void StartOver()
        {
            for (int i = 0; i < n * n; i++)
            {
                for (int j = 0; j < n * n; j++)
                {
                    this.Controls.Remove(buttons[i, j]);
                }
            }
            GenerateMap();
        }
        private void StartOverButton_Click(object sender, EventArgs e)
        {
            StartOver();
        }
    }
}