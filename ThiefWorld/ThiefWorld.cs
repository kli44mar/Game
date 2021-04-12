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

namespace ThiefWorld
{
    public partial class ThiefWorld : Form
    {
        private readonly Character character;
        public ThiefWorld(DirectoryInfo imagesDirectory)
        {
            //character = new Character("");
            //ClientSize = new Size(10000, 10000);
            if (imagesDirectory == null)
                imagesDirectory = new DirectoryInfo("Additional images");
            InitializeComponent();
        }

    }
}
