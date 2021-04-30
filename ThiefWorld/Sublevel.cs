using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThiefWorld.Architecture;
using ThiefWorld.Interface;

namespace ThiefWorld
{
    public partial class Sublevel : Form
    {
        List<Button> extraButtons = new List<Button>();
        List<Label> extraLabels = new List<Label>();
        List<TextBox> extraBox = new List<TextBox>();
        public Levels Levels = new Levels();
        public Level level;
        Label label1 = new Label();
        public Sublevel(int numberOfLevel)
        {
            Load += (sender, args) => StartTimer();
            WindowState = FormWindowState.Maximized;
            BackgroundImage = Properties.Resources.Level_Background;
            Size = MaximumSize;
            DoubleBuffered = true;
            BackgroundImageLayout = ImageLayout.Stretch;
            StartPosition = FormStartPosition.CenterScreen;

            var labelCentr = new Label
            {
                Location = new Point(1040, 300),
                Size = new Size(700, 50),
                Text = "Выберите уровень сложности:",
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Tahoma", 14, FontStyle.Bold),
                BackColor = Color.Transparent
            };
            var buttonCentr1 = new Button
            {
                Location = new Point(1150, 400),
                Size = new Size(170, 80),
                Text = "Легко",
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                Font = new Font("Tahoma", 14, FontStyle.Bold)
            };
            buttonCentr1.Click += (sender, args) =>
            {
            };
            var buttonCentr2 = new Button
            {
                Location = new Point(1150, 500),
                Size = buttonCentr1.Size,
                Text = "Средне",
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                Font = new Font("Tahoma", 14, FontStyle.Bold)
            };
            buttonCentr2.Click += (sender, args) =>
            {
            };
            var buttonCentr3 = new Button
            {
                Location = new Point(1150, 600),
                Size = buttonCentr1.Size,
                Text = "Сложно",
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                Font = new Font("Tahoma", 14, FontStyle.Bold)
            };
            buttonCentr3.Click += (sender, args) =>
            {
            };
            Controls.Add(buttonCentr2);
            Controls.Add(labelCentr);
            Controls.Add(buttonCentr3);
            Controls.Add(buttonCentr1);
            extraButtons.Add(buttonCentr1);
            extraButtons.Add(buttonCentr2);
            extraButtons.Add(buttonCentr3);
            extraLabels.Add(labelCentr);
            var button = new Button
            {
                Location = new Point(40, 40),
                Text = "Выйти",
                Font = new Font("Tahoma", 16, FontStyle.Bold),
                Size = new Size(180, 110),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(255, 255, 192)
            };
            
            button.Click += (sender, args) =>
            {
                var newForm = new LevelMap();
                newForm.Show();
                Close();
            };

            var button22 = new Button
            {
                Location = new Point(40, 220),
                Text = "Примеры",
                Font = new Font("Tahoma", 16, FontStyle.Bold),
                Size = new Size(390, 120),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(255, 255, 192)
            };
            ///---------
            if (numberOfLevel == 1)
                level = Levels.Level1;
            if (numberOfLevel == 2)
                level = Levels.Level2;
            if (numberOfLevel == 3)
                level = Levels.Level3;
            if (numberOfLevel == 4)
                level = Levels.Level4;
            if (numberOfLevel == 5)
                level = Levels.Level5;
            var mathExamples = level.MathExamples;
            var sequences = level.Sequences;
            var issue = level.Issue;
            button22.Click += (sender, args) =>
            {
                Clear();
                GetEx(0);
            };

            var button3 = new Button
            {
                Location = new Point(40, 380),
                Text = "Последовательность",
                Font = new Font("Tahoma", 16, FontStyle.Bold),
                Size = new Size(390, 120),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(255, 255, 192)
            };
            button3.Click += (sender, args) =>
            {
                Clear();
                GetIs(0);
            };
           
            var button4 = new Button
            {
                Location = new Point(40, 540),
                Text = "Загадка",
                Font = new Font("Tahoma", 16, FontStyle.Bold),
                Size = new Size(390, 120),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(255, 255, 192)
            };
            button4.Click += (sender, args) =>
            {
                Clear();
                var label = new Label
                {
                    Location = new Point(ClientSize.Width / 2 - 100, 400),
                    Size = new Size(800, 100),
                    Text = "Отгадайте загадку: " + issue.Condition,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Tahoma", 14, FontStyle.Bold),
                    BackColor = Color.Transparent
                };
                var box = new TextBox
                {
                    Location = new Point(ClientSize.Width / 2 + 340, 600),
                    Size = new Size(180, 300),
                    BackColor = Color.White,
                    Font = new Font("Tahoma", 14, FontStyle.Bold)

                };
                var button2 = new Button
                {
                    Location = new Point(ClientSize.Width / 2 + 550, 600),
                    Size = new Size(130, 60),
                    Text = "Ответить",
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.Transparent,
                    Font = new Font("Tahoma", 10, FontStyle.Bold)
                };
                button2.Click += (sender, args) =>
                {
                    box.Enabled = false;
                    box.Text = "Ответ: " + issue.Answer;
                };
                Controls.Add(button2);
                Controls.Add(label);
                Controls.Add(box);
                extraButtons.Add(button2);
                extraLabels.Add(label);
                extraBox.Add(box);
            };
            label1 = new Label
            {
                Location = new Point(1100, 60),
                Font = new Font("Tahoma", 18, FontStyle.Bold),
                Size = new Size(290, 100),
                FlatStyle = FlatStyle.Flat,
                Padding = new Padding(60, 35, 5, 5),
                BackColor = Color.FromArgb(255, 255, 192)
            };
            

            Controls.Add(label1);
            Controls.Add(button);
            Controls.Add(button22);
            Controls.Add(button3);
            Controls.Add(button4);
        }

        private int GetIs(int i)
        {
            var example = new List<string> { "1adf", "e2fd", "rrr3", "kj4", "kl5" };
            var label = new Label
            {
                Location = new Point(ClientSize.Width / 2 - 100, 350),
                Size = new Size(700, 50),
                Text = "Запомните последовательность за 15 сек " + String.Join(", ", example.ToArray()),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Tahoma", 14, FontStyle.Bold),
                BackColor = Color.Transparent
            };
            var button = new Button
            {
                Location = new Point(ClientSize.Width / 2 + 550, 450),
                Size = new Size(130, 60),
                Text = "Ответить",
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                Font = new Font("Tahoma", 10, FontStyle.Bold)
            };
            button.Click += (sender, args) =>
            {
                Clear();
                var box = new TextBox
                {
                    Location = new Point(ClientSize.Width / 2 + 100, 450),
                    Size = new Size(400, 300),
                    BackColor = Color.White,
                    Font = new Font("Tahoma", 14, FontStyle.Bold)
                };
                var button2 = new Button
                {
                    Location = new Point(ClientSize.Width / 2 + 550, 440),
                    Size = new Size(130, 60),
                    Text = "Ответить",
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.Transparent,
                    Font = new Font("Tahoma", 10, FontStyle.Bold)
                };
                button2.Click += (sender, args) =>
                {
                    box.Enabled = false;
                    box.Text = "Ответ: " + String.Join(", ", example.ToArray());
                    if (i < 8)
                        GetIs(i);
                };
                Controls.Add(button2);
                Controls.Add(box);
                extraButtons.Add(button2);
                extraBox.Add(box);
                i++;

            };
            Controls.Add(label);
            Controls.Add(button);
            extraLabels.Add(label);
            extraButtons.Add(button);
            return i;
        }

        private int GetEx(int i)
        {
            var example = "22+444";
            //var i = 0;
            var label = new Label
            {
                Location = new Point(ClientSize.Width / 2 - 100, 250 + 80 * i),
                Size = new Size(400, 50),
                Text = "Введите ответ: " + example,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Tahoma", 10, FontStyle.Bold),
                BackColor = Color.Transparent
            };

            var box = new TextBox
            {
                Location = new Point(ClientSize.Width / 2 + 340, 250 + 80 * i),
                Size = new Size(180, 300),
                BackColor = Color.White,
                Font = label.Font

            };
            var button2 = new Button
            {
                Location = new Point(ClientSize.Width / 2 + 550, 240 + 80 * i),
                Size = new Size(130, 60),
                Text = "Ответить",
                FlatStyle = FlatStyle.Flat,
                BackColor = label.BackColor,
                Font = new Font("Tahoma", 10, FontStyle.Bold)
            };
            button2.Click += (sender, args) =>
            {
                box.Enabled = false;
                box.Text = "Ответ: " + example;
                i++;
                if (i<8)
                    GetEx(i);

            };

            Controls.Add(box);
            Controls.Add(button2);
            Controls.Add(label);
            extraButtons.Add(button2);
            extraBox.Add(box);
            extraLabels.Add(label);
            return i;
        }

        private void Clear()
        {
            foreach (var bt in extraButtons)
            {
                Controls.Remove(bt);
            }
            extraButtons.Clear();
            foreach (var bt in extraLabels)
            {
                Controls.Remove(bt);
            }
            extraLabels.Clear();
            foreach (var bt in extraBox)
            {
                Controls.Remove(bt);
            }
            extraBox.Clear();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var graphics = e.Graphics;

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            graphics.FillRectangle(Brushes.LemonChiffon, 0, 0, 500, ClientSize.Height);
            graphics.FillRectangle(Brushes.LemonChiffon, 700, 200, 1080, ClientSize.Height-300);
        }

        private async void StartTimer()
        {
            TimeSpan ts = new TimeSpan(0, 8, 0);
            while (ts > TimeSpan.Zero)
            {
                label1.Text = ts.ToString();
                await Task.Delay(1000);
                ts -= TimeSpan.FromSeconds(1);
            }
            Close();
        }
    }
}
