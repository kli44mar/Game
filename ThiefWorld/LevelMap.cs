using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThiefWorld.Architecture;
using ThiefWorld.Interface;

namespace ThiefWorld
{
    public partial class LevelMap : Form
    {
        public PictureBox Menu;
        public PictureBox level1Point;
        public PictureBox level2Point;
        public PictureBox level3Point;
        public PictureBox level4Point;
        public PictureBox level5Point;
        public PictureBox Shop;
        public PictureBox Money;
        private Label MoneyCount;
        public PictureBox picture1;
        public ShopOutfit YourShop;

        public LevelMap(Levels levels, ShopOutfit shop)
        {
            WindowState = FormWindowState.Maximized;
            Size = MaximumSize;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            BackgroundImage = LevelsImages.LevelMapBackground;
            YourShop = shop;
            Load += LevelMap_Load;
        }
        private void LevelMap_Load(object sender, EventArgs e)
        {
            level1Point = new PictureBox
            {
                Name = "1",
                BackColor = Color.Transparent,
                Image = LevelsImages.circle1,
                Location = new Point(150, 150),
                Size = new Size(200, 200),
                SizeMode = PictureBoxSizeMode.Zoom,
            };
            level2Point = new PictureBox
            {
                Name = "2",
                BackColor = Color.Transparent,
                Image = LevelsImages.circle2_0,
                Location = new Point(850, 150),
                Size = new Size(200, 200),
                SizeMode = PictureBoxSizeMode.Zoom
            };
            level3Point = new PictureBox
            {
                Name = "3",
                BackColor = Color.Transparent,
                Image = LevelsImages.circle3_0,
                Location = new Point(1650, 150),
                Size = new Size(200, 200),
                SizeMode = PictureBoxSizeMode.Zoom
            };
            level4Point = new PictureBox
            {
                Name = "4",
                BackColor = Color.Transparent,
                Image = LevelsImages.circle4_0,
                Location = new Point(400, 700),
                Size = new Size(200, 200),
                SizeMode = PictureBoxSizeMode.Zoom
            };
            level5Point = new PictureBox
            {
                Name = "5",
                BackColor = Color.Transparent,
                Image = LevelsImages.circle5_0,
                Location = new Point(1300, 700),
                Size = new Size(200, 200),
                SizeMode = PictureBoxSizeMode.Zoom
            };
            Menu = new PictureBox
            {
                BackColor = Color.Transparent,
                Image = LevelsImages.menu,
                Location = new Point(20, 800),
                Size = new Size(200,200),
                SizeMode = PictureBoxSizeMode.Zoom
            };
            Money = new PictureBox
            {
                BackColor = Color.Transparent,
                Image = LevelsImages.money,
                Location = new Point(1660, 830),
                Size = new Size(150, 150),
                SizeMode = PictureBoxSizeMode.Zoom
            };
            MoneyCount = new Label
            {
                BackColor = Color.Transparent,
                Location = new Point(1810, 892),
                Size = new Size(200, 200),
                Text = Program.World.Player.Money.ToString(),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 18, FontStyle.Bold),
            };
            Shop = new PictureBox
            {
                BackColor = Color.Transparent,
                Image = LevelsImages.shop,
                Location = new Point(880, 800),
                Size = new Size(200, 200),
                SizeMode = PictureBoxSizeMode.Zoom
            };
            Menu.Click += (sender, args) =>
            {
                string str = JsonConvert.SerializeObject(Program.World.Player);
                File.WriteAllText("./Game.json", str);
                Close();
            };
            Shop.Click += (sender, args) =>
            {
                var shop = new Shop(YourShop);
                shop.Show();
                Close();
            };
            level1Point.Click += (sender, args)=>
            {
                DialogResult result = MessageBox.Show("Начать уровень?" +
                    " " +
                    "\n" +
                    "Обратите внимание: при перезапуске уровня монеты, заработанные при предыдущем прохождении спишутся.", 
                    "Продолжение игры", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Program.World.Player.AfterLevelRestart(Program.LevelsGet.Level1.Points, Program.LevelsGet.Level1.LevelNumber);
                    Program.LevelsGet.Level1.Restart();
                    Sublevel newForm = new Sublevel(Program.LevelsGet.Level1, YourShop);
                    newForm.Show();
                    Close();
                }
            };
            level2Point.Click += (sender, args) =>
            {
                DialogResult result = MessageBox.Show("Начать уровень?" +
                    " " +
                    "\n" +
                    "Обратите внимание: при перезапуске уровня монеты, заработанные при предыдущем прохождении спишутся.", 
                    "Продолжение игры", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Program.LevelsGet.Level2.Restart();
                    Sublevel newForm = new Sublevel(Program.LevelsGet.Level2, YourShop);
                    newForm.Show();
                    Close();
                }
            };
            level3Point.Click += (sender, args) =>
            {
                DialogResult result = MessageBox.Show("Начать уровень?" +
                       " " +
                       "\n" +
                       "Обратите внимание: при перезапуске уровня монеты, заработанные при предыдущем прохождении спишутся.", 
                       "Продолжение игры", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Program.LevelsGet.Level3.Restart();
                    Sublevel newForm = new Sublevel(Program.LevelsGet.Level3, YourShop);
                    newForm.Show();
                    Close();
                }
            };
            level4Point.Click += (sender, args) =>
            {
                DialogResult result = MessageBox.Show("Начать уровень?" +
                    " " +
                    "\n" +
                    "Обратите внимание: при перезапуске уровня монеты, заработанные при предыдущем прохождении спишутся.", 
                    "Продолжение игры", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Program.LevelsGet.Level4.Restart();
                    Sublevel newForm = new Sublevel(Program.LevelsGet.Level4, YourShop);
                    newForm.Show();
                    Close();
                }
            };
            level5Point.Click += (sender, args) =>
            {
                DialogResult result = MessageBox.Show("Начать уровень?" + 
                    " " +
                    "\n" +
                    "Обратите внимание: при перезапуске уровня монеты, заработанные при предыдущем прохождении спишутся.", 
                    "Продолжение игры", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Program.LevelsGet.Level5.Restart();
                    Sublevel newForm = new Sublevel(Program.LevelsGet.Level5, YourShop);
                    newForm.Show();
                    Close();
                }
            };
            level2Point.Enabled = false;
            level3Point.Enabled = false;
            level4Point.Enabled = false;
            level5Point.Enabled = false;
            
            if (Program.LevelsGet.Level1.Complete)
            {
                level2Point.Enabled = true;
                level2Point.Image = LevelsImages.circle2;
            }
            if (Program.LevelsGet.Level2.Complete)
            {
                level3Point.Enabled = true;
                level3Point.Image = LevelsImages.circle3;
            }
            if (Program.LevelsGet.Level3.Complete)
            {
                level4Point.Enabled = true;
                level4Point.Image = LevelsImages.circle4;
            }
            if (Program.LevelsGet.Level4.Complete)
            {
                level5Point.Enabled = true;
                level5Point.Image = LevelsImages.circle5;
            }
            Controls.Add(Menu);
            Controls.Add(Money);
            Controls.Add(Shop);
            Controls.Add(MoneyCount);
            Controls.Add(level1Point);
            Controls.Add(level2Point);
            Controls.Add(level3Point);
            Controls.Add(level4Point);
            Controls.Add(level5Point);
        }
    }
}
