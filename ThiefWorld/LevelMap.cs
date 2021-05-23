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
        private Character Player;
        private Levels levels;
        public PictureBox level1Point;
        public PictureBox level2Point;
        public PictureBox level3Point;
        public PictureBox level4Point;
        public PictureBox level5Point;
        public PictureBox Money;
        private Label MoneyCount;
        public PictureBox picture1;

        public LevelMap(Levels levels, Character player)
        {
            WindowState = FormWindowState.Maximized;
            Size = MaximumSize;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            BackgroundImage = LevelsImages.LevelMapBackground;
            this.levels = levels;
            Player = player;
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
                Image = LevelsImages.circle2,
                Location = new Point(850, 150),
                Size = new Size(200, 200),
                SizeMode = PictureBoxSizeMode.Zoom
            };
            level3Point = new PictureBox
            {
                Name = "3",
                BackColor = Color.Transparent,
                Image = LevelsImages.circle3,
                Location = new Point(1650, 150),
                Size = new Size(200, 200),
                SizeMode = PictureBoxSizeMode.Zoom
            };
            level4Point = new PictureBox
            {
                Name = "4",
                BackColor = Color.Transparent,
                Image = LevelsImages.circle4,
                Location = new Point(400, 700),
                Size = new Size(200, 200),
                SizeMode = PictureBoxSizeMode.Zoom
            };
            level5Point = new PictureBox
            {
                Name = "5",
                BackColor = Color.Transparent,
                Image = LevelsImages.circle5,
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
                Location = new Point(1660, 850),
                Size = new Size(150, 150),
                SizeMode = PictureBoxSizeMode.Zoom
            };
            /*Money.Paint += new PaintEventHandler((sender, e) =>
             {
                 e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                 var font = new Font(SystemFonts.DefaultFont.FontFamily, 12, FontStyle.Regular);
                 string text = this.Player.Money.ToString();
                 var textSize = e.Graphics.MeasureString(text, Font);
                 var location = new PointF(Money.Width / 11 * 6 - textSize.Width / 2, Money.Height / 12 * 7 - textSize.Height / 2);
                 e.Graphics.DrawString(text, font, Brushes.Black, location);
             });*/
            MoneyCount = new Label
            {
                BackColor = Color.Transparent,
                Location = new Point(1810, 902),
                Size = new Size(200, 200),
                Text = Player.Money.ToString(),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 18, FontStyle.Bold),
                //Image = LevelsImages.money
            };
            //Graphics g = Graphics.FromImage(Money.Image);
            //g.DrawString("0", new Font("Arial", 10), Brushes.Black, 0, 0);
            //MoneyCount.Parent = Money;
            //Money.Controls.Add(MoneyCount);
            //MoneyCount.BringToFront();
            Menu.Click += (sender, args) =>
            {
                  Close();
            };
            level1Point.Click += (sender, args)=>
            {
                Sublevel newForm = new Sublevel(1, levels, Player);
                newForm.Show();
                Close();
            };
            level2Point.Click += (sender, args) =>
            {
                Sublevel newForm = new Sublevel(2, levels, Player);
                newForm.Show();
                Close();
            };
            level3Point.Click += (sender, args) =>
            {
                Sublevel newForm = new Sublevel(3, levels, Player);
                newForm.Show();
                Close();
            };
            level4Point.Click += (sender, args) =>
            {
                Sublevel newForm = new Sublevel(4, levels, Player);
                newForm.Show();
                Close();
            };
            level5Point.Click += (sender, args) =>
            {
                Sublevel newForm = new Sublevel(5, levels, Player);
                newForm.Show();
                Close();
            };
            level2Point.Enabled = false;
            level3Point.Enabled = false;
            level4Point.Enabled = false;
            level5Point.Enabled = false;
            
            if (levels.Level1.Complete)
            {
                level2Point.Enabled = true;
            }
            if (levels.Level2.Complete)
            {
                level3Point.Enabled = true;
            }
            if (levels.Level3.Complete)
            {
                level4Point.Enabled = true;
            }
            if (levels.Level4.Complete)
            {
                level5Point.Enabled = true;
                
            }
            Controls.Add(Menu);
            Controls.Add(Money);
            //Money.Controls.Add(MoneyCount);
            Controls.Add(MoneyCount);
            //MoneyCount.Parent = Money;
            //MoneyCount.BringToFront();
            Controls.Add(level1Point);
            Controls.Add(level2Point);
            Controls.Add(level3Point);
            Controls.Add(level4Point);
            Controls.Add(level5Point);
        }
    }
}
