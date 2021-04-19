﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThiefWorld
{
    public partial class ThiefWorld : Form
    {
        private readonly Button button;
        private readonly Button button2;
        private readonly Button button3;
        private readonly Label label;
        private readonly PictureBox pictureBox1;
        public ThiefWorld(Game game)
        {
            WindowState = FormWindowState.Maximized;
            BackgroundImage = Image.FromFile("C:\\Users\\maria\\Pictures\\игра\\3.jpg");
            Size = MaximumSize;
            BackgroundImageLayout = ImageLayout.Stretch;
            StartPosition = FormStartPosition.CenterScreen;
            label = new Label()
            {
                Location = new Point(40, 40),
                Text = "Дорогой вор, не стоило воровать то, в чем ты не разбираешься. Ты украл магический артефакт, наказывающий людей за их злодеяния, " +
                "перенося в другие миры. Ты попал в свой собственный мир, если попробуешь что-нибудь украсть, то сразу умрешь." +
                " Единственный способ зароботать деньги -  проходить уровни.",
                Size = new Size(600, 160),
                Font = new Font("Tahoma", 14),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(255, 255, 210)
            };


            button = new Button
            {
                Location = new Point(1241, 40),
                Text = "Магазин",
                Font = new Font("Tahoma", 16),
                Size = new Size(180, 110),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(255, 255, 192)
            };

            button2 = new Button
            {
                Location = new Point(1241, 60 + button.Size.Height),
                Text = "Переиграть",
                Font = button.Font,
                FlatStyle = FlatStyle.Flat,
                Size = button.Size,
                BackColor = Color.FromArgb(255, 255, 192)
            };

            button3 = new Button
            {
                Location = new Point(730, 400),
                Text = "Играть",
                Font = new Font("Tahoma", 20, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(220, 150),
                BackColor = Color.FromArgb(255, 255, 180)
            };
            pictureBox1 = new PictureBox
            {
                BackColor = Color.Transparent,
                Image = Image.FromFile("C:\\Users\\maria\\Pictures\\игра\\8QGE.png"),
                Location = new Point(26, 279),
                Size = new Size(350, 525),
                SizeMode = PictureBoxSizeMode.Zoom
            };

            Load += (sender, args) => OnSizeChanged(EventArgs.Empty);
            Controls.Add(button);
            Controls.Add(button2);
            Controls.Add(button3);
            Controls.Add(label);
            Controls.Add(pictureBox1);
        }

        }
}