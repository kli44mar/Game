using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThiefWorld.Architecture;
using ThiefWorld.Interface;

namespace ThiefWorld
{
    public partial class ThiefWorld : Form
    {
        private readonly Button button;
        private readonly Button button2;
        private readonly Button button3;
        private readonly Button button4;
        private readonly Label label;
        public readonly PictureBox pictureBox1;
        public Character Player;
        private readonly ShopOutfit ShopOutfit;

        public ThiefWorld(Character player, ShopOutfit shop)
        {
            Program.World = this;
            this.Player = player;
            this.ShopOutfit = shop;
            WindowState = FormWindowState.Maximized;
            BackgroundImage = Properties.Resources._3;
            Size = MaximumSize;
            DoubleBuffered = true;
            BackgroundImageLayout = ImageLayout.Stretch;
            StartPosition = FormStartPosition.CenterScreen;
            label = new Label()
            {
                Location = new Point(40, 40),
                Text = "Дорогой вор, не стоило воровать то, в чем ты не разбираешься. Ты украл магический артефакт, наказывающий людей за их злодеяния, " +
                "перенося в другие миры. Ты попал в свой собственный мир, если попробуешь что-нибудь украсть, то сразу умрешь." +
                " Единственный способ зароботать деньги -  проходить уровни.",
                Size = new Size(700, 200),
                Font = new Font("Tahoma", 12),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(255, 239, 172)
            };

            button = new Button
            {
                Location = new Point(1641, 40),
                Text = "Магазин",
                Font = new Font("Tahoma", 16),
                Size = new Size(180, 110),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(255, 239, 172)
            };

            pictureBox1 = new PictureBox
            {
                BackColor = Color.Transparent,
                Image = Helpers.OutfitToFileMap[Program.World.Player.OutfitName],
                Location = new Point(26, 279),
                Size = new Size(400, 575),
                SizeMode = PictureBoxSizeMode.Zoom
            };

            button.Click += (sender, args) =>
            {
                Shop shop = new Shop(player, ShopOutfit, this.pictureBox1);
                //shop.Owner = this;
                shop.Show();
            };

            button2 = new Button
            {
                Location = new Point(1641, 60 + button.Size.Height),
                Text = "Выйти",
                Font = button.Font,
                FlatStyle = FlatStyle.Flat,
                Size = button.Size,
                BackColor = Color.FromArgb(255, 239, 172)
            };
            button3 = new Button
            {
                Location = new Point(800, 450),
                Text = "Продолжить игру",
                Font = new Font("Tahoma", 16, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(220, 150),
                BackColor = Color.FromArgb(255, 239, 172)
            };

            button4 = new Button
            {
                Location = new Point(1040, 450),
                Text = "Начать сначала",
                Font = new Font("Tahoma", 16, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(220, 150),
                BackColor = Color.FromArgb(255, 239, 172)
            };

            button2.Click += (sender, args) =>
            {
                string str = JsonConvert.SerializeObject(Program.World.Player);
                File.WriteAllText("./Game.json", str);
                Close();
            };

            button3.Click += (sender, args) =>
            {
                string str = File.ReadAllText("./Game.json");
                Character play = JsonConvert.DeserializeObject<Character>(str);
                Program.World.Player = play;
                LevelMap newForm = new LevelMap(new Interface.Levels(), play);
                newForm.Show();
            };
            button4.Click += (sender, args) =>
            {
                LevelMap newForm = new LevelMap(new Interface.Levels(), Program.World.Player);
                newForm.Show();
            };

            
            
            Load += (sender, args) => OnSizeChanged(EventArgs.Empty);
            Controls.Add(button);
            Controls.Add(button2);
            Controls.Add(button3);
            Controls.Add(button4);
            Controls.Add(label);
            Controls.Add(pictureBox1);
        }

    }
}
