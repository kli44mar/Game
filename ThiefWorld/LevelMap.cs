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

        public LevelMap(Levels levels)
        {
            WindowState = FormWindowState.Maximized;
            Size = MaximumSize;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            BackgroundImage = LevelsImages.LevelMapBackground;
            //levels = new Levels();
            this.levels = levels;
            this.Load += LevelMap_Load;
        }


        private void LevelMap_Load(object sender, EventArgs e)
        {

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
                Location = new Point(20, 800),
                Size = new Size(200,200),
                SizeMode = PictureBoxSizeMode.Zoom
            };
            Menu.Click += (sender, args) =>
            {
                  Close();
            };
            level1Point.Click += (sender, args)=>
            {
                Sublevel newForm = new Sublevel(1, levels);
                newForm.Show();
                Close();
            };
            level2Point.Click += (sender, args) =>
            {
                Sublevel newForm = new Sublevel(2, levels);
                newForm.Show();
                Close();
            };
            level3Point.Click += (sender, args) =>
            {
                Sublevel newForm = new Sublevel(3, levels);
                newForm.Show();
                Close();
            };
            level4Point.Click += (sender, args) =>
            {
                Sublevel newForm = new Sublevel(4, levels);
                newForm.Show();
                Close();
            };
            level5Point.Click += (sender, args) =>
            {
                Sublevel newForm = new Sublevel(5, levels);
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
            Controls.Add(level1Point);
            Controls.Add(level2Point);
            Controls.Add(level3Point);
            Controls.Add(level4Point);
            Controls.Add(level5Point);

        }
    }
}
