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

namespace ThiefWorld
{
    public partial class LevelMap : Form
    {
        public Bitmap Circle=LevelsImages.Circle;
        public PictureBox picture1;

        public LevelMap()
        {
            WindowState = FormWindowState.Maximized;
            Size = MaximumSize;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            BackgroundImage = LevelsImages.LevelMapBackground;

            for (var i = 0; i<3; i++)
            {
                var pictureBox = new PictureBox
                {
                    BackColor = Color.Transparent,
                    Image = Properties.Resources._18_189436_dot_for_making_logo_emblem_transparent_graphicdesign_transparent_removebg_preview,
                    Location = new Point(100+i*800, 100),
                    Size = new Size(200, 200),
                    SizeMode = PictureBoxSizeMode.Zoom
                };
                Controls.Add(pictureBox);
            }
            for (var i = 0; i < 2; i++)
            {
                var pictureBox1 = new PictureBox
                {
                    BackColor = Color.Transparent,
                    Image = Properties.Resources._18_189436_dot_for_making_logo_emblem_transparent_graphicdesign_transparent_removebg_preview,
                    Location = new Point(300 + i * 1000, 800),
                    Size = new Size(200, 200),
                    SizeMode = PictureBoxSizeMode.Zoom
                };
                Controls.Add(pictureBox1);
            }

           
        }







        private void LevelMap_Paint(object sender, PaintEventArgs e)
        {
        }   

        private void LevelMap_Load(object sender, EventArgs e)
        {

        }
    }
}
