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
        private int NumberOfLevel;

        private Levels levels;

        public PictureBox level1Point;
        public PictureBox level2Point;
        public PictureBox level3Point;
        public PictureBox level4Point;
        public PictureBox level5Point;

        public PictureBox picture1;

        public LevelMap()
        {
            WindowState = FormWindowState.Maximized;
            Size = MaximumSize;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            BackgroundImage = LevelsImages.LevelMapBackground;
            levels = new Levels();
            this.Load += LevelMap_Load;
        }


        private void LevelMap_Load(object sender, EventArgs e)
        {
            NumberOfLevel = 1;
            

            BackgroundImage = LevelsImages.LevelMapBackground;

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
                Location = new Point(20, 860),
                Size = new Size(100, 100),
                SizeMode = PictureBoxSizeMode.Zoom
            };
            Menu.Click += (sender, args) =>
              {
                  var initial = new ThiefWorld();
                  Close();
                  initial.Show();
              };
            level1Point.Click += LevelsPoint_Click;
            if (levels.Level1.Complete)
            {
                NumberOfLevel = 2;
                level2Point.Click += LevelsPoint_Click;
            }
            if (levels.Level2.Complete)
            {
                NumberOfLevel = 3;
                level3Point.Click += LevelsPoint_Click;
            }

            if (levels.Level3.Complete)
            {
                NumberOfLevel = 4;
                level4Point.Click += LevelsPoint_Click;
            }
            if (levels.Level4.Complete)
            {
                NumberOfLevel = 5;
                level5Point.Click += LevelsPoint_Click;
            }
            Controls.Add(Menu);
            Controls.Add(level1Point);
            Controls.Add(level2Point);
            Controls.Add(level3Point);
            Controls.Add(level4Point);
            Controls.Add(level5Point);
            
        }

        private void LevelsPoint_Click(object sender, EventArgs e)
        {
            Sublevel newForm = new Sublevel(NumberOfLevel);
            newForm.Show();
            Close();
        }
    }
}
