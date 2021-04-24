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
        private readonly Tuple<string, Bitmap> backGround;

        public LevelMap(DirectoryInfo imagesDirectory = null)
        {
            WindowState = FormWindowState.Maximized;
            Size = MaximumSize;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            if (imagesDirectory == null)
                imagesDirectory = new DirectoryInfo("Additional images");
            backGround = Tuple.Create("LevelMap.png", (Bitmap)Image.FromFile(imagesDirectory.GetFiles().Where(x => x.Name.Equals("LevelMap.png")).First().FullName));
            BackgroundImage = backGround.Item2;
        }

        private void LevelMap_Load(object sender, EventArgs e)
        {

        }
    }
}
