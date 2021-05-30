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
        public Levels Levels;
        Label label1 = new Label();
        private Level Level;
        private int Difficalty;
        Button button4 = new Button();
        Button button3 = new Button();
        private IReadOnlyDictionary<bool, string> ToRussian = new Dictionary<bool, string>()
        {
            [true] = "Верно",
            [false] = "Неверно"
        };

        public Sublevel(Level level, ShopOutfit shop)
        {
            Difficalty = 1;
            Load += (sender, args) => StartTimer();
            WindowState = FormWindowState.Maximized;
            BackgroundImage = Properties.Resources.Level_Background;
            Size = MaximumSize;
            DoubleBuffered = true;
            BackgroundImageLayout = ImageLayout.Stretch;
            StartPosition = FormStartPosition.CenterScreen;
            button3.Enabled = false;
            button4.Enabled = false;
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
                button3.Enabled = false;
                button4.Enabled = false;
                Difficalty = 1;
                Clear();
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
                button3.Enabled = false;
                button4.Enabled = false;
                Difficalty = 2;
                Clear();
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
                button3.Enabled = false;
                button4.Enabled = false;
                Difficalty = 3;
                Clear();            };
            var labelCentr2 = new Label
            {
                Location = new Point(1050, 750),
                Size = new Size(700, 50),
                Text = @"И нажмите на кнопку ""Примеры""",
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Tahoma", 14, FontStyle.Bold),
                BackColor = Color.Transparent
            };
            Controls.Add(buttonCentr2);
            Controls.Add(labelCentr);
            Controls.Add(labelCentr2);
            Controls.Add(buttonCentr3);
            Controls.Add(buttonCentr1);
            extraButtons.Add(buttonCentr1);
            extraButtons.Add(buttonCentr2);
            extraButtons.Add(buttonCentr3);
            extraLabels.Add(labelCentr);
            extraLabels.Add(labelCentr2);

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
                Level.ChangePoints();
                Program.World.Player.ChangePointsAndCompleteLevel(Level.LevelNumber, Level.Points);
                Program.World.Player.AfterSublevel(Level.Points);
                Level.ChangeConditionOfLevel();
                switch (Level.LevelNumber)
                {
                    case 1:
                        Program.LevelsGet.Level1.ChangeConditionAndPointsOfLevel(Level.Points);
                        break;
                    case 2:
                        Program.LevelsGet.Level2.ChangeConditionAndPointsOfLevel(Level.Points);
                        break;
                    case 3:
                        Program.LevelsGet.Level3.ChangeConditionAndPointsOfLevel(Level.Points);
                        break;
                    case 4:
                        Program.LevelsGet.Level4.ChangeConditionAndPointsOfLevel(Level.Points);
                        break;
                    case 5:
                        Program.LevelsGet.Level5.ChangeConditionAndPointsOfLevel(Level.Points);
                        break;
                }
                var newForm = new LevelMap(Program.LevelsGet, shop);
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
            
            Level = level;
            var mathExamples = Level.MathExamples;
            var sequences = Level.Sequences;
            var issue = Level.Issue;
            button22.Click += (sender, args) =>
            {
                button22.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                Clear();
                GetEx(0,Difficalty - 1, true);
              
            };

            button3 = new Button
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
                button3.Enabled = false;
                button22.Enabled = false;
                button4.Enabled = false;
                Clear();
                GetIs(0);
            };
           
            button4 = new Button
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
                button4.Enabled = false;
                button22.Enabled = false;
                button3.Enabled = false;
                Clear();
                var needIssue = issue.GetIssue();
                var label = new Label
                {
                    Location = new Point(ClientSize.Width / 2 - 155, 300),
                    Size = new Size(900, 200),
                    Text = "Отгадайте загадку: " + needIssue.Item1,
                    FlatStyle = FlatStyle.Flat,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Tahoma", 10, FontStyle.Bold),
                    BackColor = Color.Transparent
                };
                var box = new TextBox
                {
                    Location = new Point(ClientSize.Width / 2 + 340, 600),
                    Size = new Size(180, 300),
                    BackColor = Color.White,
                    Font = new Font("Tahoma", 12, FontStyle.Bold)

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
                    var answer = box.Text;
                    box.Enabled = false;
                    box.Text = ToRussian[Level.Issue.CompareResult(needIssue.Item1, answer)];
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
            Clear();
            var example = Level.Sequences.GetNextSequence();
            var label = new Label
            {
                Location = new Point(ClientSize.Width / 2 - 100, 350),
                Size = new Size(700, 50),
                Text = "Запомните последовательность: " + example.Item2,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Tahoma", 10, FontStyle.Bold),
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
            Controls.Add(label);
            Controls.Add(button);
            extraLabels.Add(label);
            extraButtons.Add(button);
            
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
                    var answer = box.Text;
                    box.Enabled = false;
                    
                    MessageBox.Show(ToRussian[Level.Sequences.CompareResult(example.Item1, answer)], "Answer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    i++;
                    if (i < Level.Sequences.CountOfSequences)
                    {
                        GetIs(i);
                    }
                    else
                    {
                        button2.Enabled = false;
                        button4.Enabled = true;
                    }
                };
                Controls.Add(button2);
                Controls.Add(box);
                extraButtons.Add(button2);
                extraBox.Add(box);
                
            };      
            extraButtons.Add(button);
            extraLabels.Add(label);
            return i;
        }

        private int GetEx(int i, int difficalty, bool correctResult)
        {
            var example = Level.MathExamples.GetNextExample(difficalty, correctResult);
            difficalty = example.Item1.Item1;
            var label = new Label
            {
                Location = new Point(ClientSize.Width / 2 - 100, 250 + 80 * i),
                Size = new Size(400, 50),
                Text = "Введите ответ: " + example.Item1.Item2,
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
                var answer = box.Text;
                box.Text = "Ответ: " + example.Item2;
                i++;
                button2.Enabled = false;
                if (i < Level.MathExamples.CountOfExamples)
                {
                    if (Level.MathExamples.CompareResult(example.Item1, answer))
                    { 
                        GetEx(i, difficalty, true);
                    }
                    else
                        GetEx(i, difficalty, false);
                }
                else
                    button3.Enabled = true;

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
            TimeSpan ts = new TimeSpan(0, 10, 0);
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
