using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThiefWorld.Interface;

namespace ThiefWorld
{
    public partial class Sublevel : Form
    {
        public Levels Level;
        DateTime time = DateTime.Now.AddMinutes(5);
        Timer timer = new Timer();
        List<string> example = new List<string>();

        public Sublevel(Levels Level)
        {
            this.Level = Level;
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            var min = time - DateTime.Now;
            if (DateTime.Now == time)
                timer.Stop();
            var label = new Label
            {
                Location = new Point(ClientSize.Width / 2 + 100, 60),
                Font = new Font("Tahoma", 16, FontStyle.Bold),
                Size = new Size(250, 60),
                FlatStyle = FlatStyle.Flat,
                Padding = new Padding (5, 10, 5, 5),
                BackColor = Color.FromArgb(255, 255, 192),
                Text = "Время: " + min.Minutes.ToString() + ":" + min.Seconds.ToString()
            };
            Controls.Add(label);
        }
            public Sublevel()
        {
            WindowState = FormWindowState.Maximized;
            BackgroundImage = Properties.Resources.Level_Background;
            Size = MaximumSize;
            DoubleBuffered = true;
            BackgroundImageLayout = ImageLayout.Stretch;
            StartPosition = FormStartPosition.CenterScreen;
            timer.Start();
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
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
                var newForm = new ThiefWorld();
                Close();
                newForm.ShowDialog();
            };

            var button2 = new Button
            {
                Location = new Point(40, 220),
                Text = "Примеры",
                Font = new Font("Tahoma", 16, FontStyle.Bold),
                Size = new Size(390, 120),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(255, 255, 192)
            };

            button2.Click += (sender, args) =>
            {
                AddExamples();
                for (var i = 0; i < 8; i++)
                {
                    var label = new Label
                    {
                        Location = new Point(ClientSize.Width / 2 - 100, 250 + 80 * i),
                        Size = new Size(400, 50),
                        Text = "Введите ответ: " + example[i],
                        FlatStyle = FlatStyle.Flat,
                        Font = new Font("Tahoma", 12, FontStyle.Bold),
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
                        Font = label.Font
                    };
                    button2.Click += (sender, args) => box.Text = "Правильный ответ: " + example[i].Take(example[i].Count()-1).Skip(1).ToString(); // 
                    Controls.Add(box);
                    Controls.Add(button2);
                    Controls.Add(label);
                }
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

            var button4 = new Button
            {
                Location = new Point(40, 540),
                Text = "Загадка",
                Font = new Font("Tahoma", 16, FontStyle.Bold),
                Size = new Size(390, 120),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(255, 255, 192)
            };

            Controls.Add(button);
            Controls.Add(button2);
            Controls.Add(button3);
            Controls.Add(button4);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            var graphics = e.Graphics;

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            graphics.FillRectangle(Brushes.LemonChiffon, 0, 0, 500, ClientSize.Height);
            graphics.FillRectangle(Brushes.LemonChiffon, 700, 200, 1080, ClientSize.Height-300);
        }
        private void AddExamples()
        {
            example.Add("(308 + 873) + 415");
            example.Add("268 + 608 + 72");
            example.Add("98 - 67 + 85");
            example.Add("130 - 13 + 423");
            example.Add("256 - 34 - 213");
            example.Add("968 + 6 + 8 - 458");
            example.Add("56 - 438 + 7 + 394");
            example.Add("4 - 384 + 813 + 403 - 1025");
        }
    }
}
