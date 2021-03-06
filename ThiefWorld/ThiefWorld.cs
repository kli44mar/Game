using Newtonsoft.Json;
using System;
using System.Media;
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

        public ThiefWorld(Character player)
        {
            
            var sp = new SoundPlayer();
            sp.Stream = Properties.Resources.didjulja_gorod_velikogo_knjazhestva;
            sp.PlayLooping();
            Program.World = this;
            this.Player = player;
            WindowState = FormWindowState.Maximized;
            BackgroundImage = Properties.Resources._3;
            Size = MaximumSize;
            DoubleBuffered = true;
            BackgroundImageLayout = ImageLayout.Stretch;
            StartPosition = FormStartPosition.CenterScreen;
            label = new Label()
            {
                Location = new Point(40, 40),
                Text = "Дорогой друг, не стоило воровать то, в чем ты не разбираешься. Ты украл магический артефакт, наказывающий людей за их злодеяния, " +
                "перенося в другие миры. Ты попал в свой собственный мир, если попробуешь что-нибудь украсть, то сразу умрешь." +
                " Единственный способ заработать деньги и выбраться из другого мира - это прохождение уровней. Успехов!",
                ForeColor = Color.Black,
                Font = new Font("Tahoma", 12),
                Size = new Size(750, 200),
                TextAlign = ContentAlignment.MiddleCenter,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(255, 239, 172)
            };

            button = new Button
            {
                Location = new Point(1641, 40),
                Text = "Помощь",
                Font = new Font("Tahoma", 16, FontStyle.Bold),
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
                var information = new Information();
                information.Show();
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
                Font = new Font("Tahoma", 14, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(220, 150),
                BackColor = Color.FromArgb(255, 239, 172)
            };

            button4 = new Button
            {
                Location = new Point(1040, 450),
                Text = "Начать заново",
                Font = new Font("Tahoma", 14, FontStyle.Bold),
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
                if (!File.Exists("Game.json"))
                    File.Create("./ Game.json");
                string str = File.ReadAllText("./Game.json");
                Character play = JsonConvert.DeserializeObject<Character>(str);
                if (play == null)
                    play = new Character("Leo");
                Program.World.Player = play;
                Program.LevelsGet.Level1.Complete = Program.World.Player.LevelPointsAndComplete[1].Item1;
                Program.LevelsGet.Level2.Complete = Program.World.Player.LevelPointsAndComplete[2].Item1;
                Program.LevelsGet.Level3.Complete = Program.World.Player.LevelPointsAndComplete[3].Item1;
                Program.LevelsGet.Level4.Complete = Program.World.Player.LevelPointsAndComplete[4].Item1;
                Program.LevelsGet.Level5.Complete = Program.World.Player.LevelPointsAndComplete[5].Item1;
                Program.LevelsGet.Level1.ChangePointsAfterDeserealize(Program.World.Player.LevelPointsAndComplete[1].Item2);
                Program.LevelsGet.Level2.ChangePointsAfterDeserealize(Program.World.Player.LevelPointsAndComplete[2].Item2);
                Program.LevelsGet.Level3.ChangePointsAfterDeserealize(Program.World.Player.LevelPointsAndComplete[3].Item2);
                Program.LevelsGet.Level4.ChangePointsAfterDeserealize(Program.World.Player.LevelPointsAndComplete[4].Item2);
                Program.LevelsGet.Level5.ChangePointsAfterDeserealize(Program.World.Player.LevelPointsAndComplete[5].Item2);
                string str1;
                if (!File.Exists("Game2.json"))
                {
                    File.Create("./ Game2.json");
                    str1 = "";
                }
                else
                    str1 = File.ReadAllText("./Game2.json");
                ShopOutfit play1 = JsonConvert.DeserializeObject<ShopOutfit>(str1);
                if (play1 == null)
                    play1 = new ShopOutfit();
                LevelMap newForm = new LevelMap(Program.LevelsGet, play1);
                newForm.Show();
            };
            button4.Click += (sender, args) =>
            {
                File.WriteAllText("./Game.json", "null");
                File.WriteAllText("./Game2.json", "null");
                Program.World.Player = new Character("Leo");
                Program.LevelsGet = new Levels();
                LevelMap newForm = new LevelMap(Program.LevelsGet, new ShopOutfit());
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
