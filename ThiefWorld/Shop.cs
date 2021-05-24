using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ThiefWorld.Architecture;
using ThiefWorld.Interface;

namespace ThiefWorld
{
    public partial class Shop : Form
    {
        public PictureBox Menu;
        public Character Player;
        public PictureBox InitialCostum;
        public PictureBox GrandsonCostum;
        public PictureBox GentlemanCostum;
        public PictureBox BatmanCostum;
        public PictureBox FancyGuyCostum;
        public PictureBox MainCharacter;
        public PictureBox Money;
        public ShopOutfit BigShop;
        public PictureBox Picture;
        private IReadOnlyDictionary<OutfitState, string> ConditionOutfit
            = new Dictionary<OutfitState, string>()
            {
                [OutfitState.AlreadyBought] = "Выбрать",
                [OutfitState.AvailableForPurchase] = "Купить"
            };
        private Label MoneyCount;
        private Button Condition;
        //public ThiefWorld World;


        public Shop(Character player, ShopOutfit shopOutfit, PictureBox picture)
        {
            WindowState = FormWindowState.Maximized;
            Size = MaximumSize;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            BackgroundImage = LevelsImages.ShopBackground;
            Player = player;
            BigShop = shopOutfit;
            Picture = picture;
            //World = (ThiefWorld)this.Owner;
            Load += Shop_Load;
        }

        private void Shop_Load(object sender, EventArgs e)
        {
            InitialCostum = new PictureBox
            {
                Name = Outfit.Initial,
                BackColor = Color.Transparent,
                Image = LevelsImages.initial4,
                Location = new Point(150, 100),
                Size = new Size(230, 230),
                SizeMode = PictureBoxSizeMode.Zoom
            };
            GrandsonCostum = new PictureBox
            {
                Name = Outfit.GrandSon,
                BackColor = Color.Transparent,
                Image = LevelsImages.grandson2,
                Location = new Point(450, 100),
                Size = new Size(230, 230),
                SizeMode = PictureBoxSizeMode.Zoom
            };
            GentlemanCostum = new PictureBox
            {
                Name = Outfit.Gentleman,
                BackColor = Color.Transparent,
                Image = LevelsImages.gentle3,
                Location = new Point(150, 400),
                Size = new Size(230, 230),
                SizeMode = PictureBoxSizeMode.Zoom
            };
            BatmanCostum = new PictureBox
            {
                Name = Outfit.JustBatman,
                BackColor = Color.Transparent,
                Image = LevelsImages.batman4,
                Location = new Point(450, 400),
                Size = new Size(230, 230),
                SizeMode = PictureBoxSizeMode.Zoom
            };
            FancyGuyCostum = new PictureBox
            {
                Name = Outfit.FancyGuy,
                BackColor = Color.Transparent,
                Image = LevelsImages.guy5,
                Location = new Point(300, 700),
                Size = new Size(230, 230),
                SizeMode = PictureBoxSizeMode.Zoom
            };
            MainCharacter = new PictureBox
            {
                Name = Player.OutfitName,
                BackColor = Color.Transparent,
                Image = Helpers.OutfitToFileMap[Program.World.Player.OutfitName],
                Location = new Point(1100, 120),
                Size = new Size(750, 750),
                SizeMode = PictureBoxSizeMode.Zoom
            };
            Menu = new PictureBox
            {
                Name = "1",
                BackColor = Color.Transparent,
                Image = LevelsImages.ShopMenu,
                Location = new Point(30, 830),
                Size = new Size(200, 200),
                SizeMode = PictureBoxSizeMode.Zoom
            };
            Money = new PictureBox
            {
                Name = "2",
                BackColor = Color.Transparent,
                Image = LevelsImages.money,
                Location = new Point(1650, 5),
                Size = new Size(120, 120),
                SizeMode = PictureBoxSizeMode.Zoom
            };
            MoneyCount = new Label
            {
                BackColor = Color.Transparent,
                Location = new Point(1780, 37),
                Size = new Size(150, 150),
                Text = Program.World.Player.Money.ToString(),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 20, FontStyle.Bold)
            };
            Condition = new Button
            {
                BackColor = Color.FromArgb(255, 239, 172),
                Location = new Point(1355, 870),
                Size = new Size(200, 80),
                Text = ConditionOutfit[BigShop.StateOfOutfits[MainCharacter.Name]],
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 18, FontStyle.Bold)
            };
            Menu.Click += (sender, args) => { Close(); };
            InitialCostum.Click += (sender, args) => 
            {
                MainCharacter.Name = Outfit.Initial;
                MainCharacter.Image = Helpers.OutfitToFileMap[Outfit.Initial];
                Condition.Text = ConditionOutfit[BigShop.StateOfOutfits[MainCharacter.Name]];
            };
            GrandsonCostum.Click += (sender, args) => 
            {
                MainCharacter.Name = Outfit.GrandSon;
                MainCharacter.Image = Helpers.OutfitToFileMap[Outfit.GrandSon];
                Condition.Text = ConditionOutfit[BigShop.StateOfOutfits[MainCharacter.Name]];
            };
            GentlemanCostum.Click += (sender, args) => 
            {
                MainCharacter.Name = Outfit.Gentleman;
                MainCharacter.Image = Helpers.OutfitToFileMap[Outfit.Gentleman];
                Condition.Text = ConditionOutfit[BigShop.StateOfOutfits[MainCharacter.Name]];
            };
            BatmanCostum.Click += (sender, args) => 
            {
                MainCharacter.Name = Outfit.JustBatman;
                MainCharacter.Image = Helpers.OutfitToFileMap[Outfit.JustBatman];
                Condition.Text = ConditionOutfit[BigShop.StateOfOutfits[MainCharacter.Name]];
            };
            FancyGuyCostum.Click += (sender, args) => 
            {
                MainCharacter.Name = Outfit.FancyGuy;
                MainCharacter.Image = Helpers.OutfitToFileMap[Outfit.FancyGuy];
                Condition.Text = ConditionOutfit[BigShop.StateOfOutfits[MainCharacter.Name]];
            };
            Condition.Click += (sender, args) => 
            {
                if (Condition.Text == "Купить")
                    if (Program.World.Player.Money >= BigShop.PriceOfOutfit[MainCharacter.Name])
                    {
                        /*var form = new Form();
                        form.Size = new Size(300, 300);
                        form.Show();*/
                        DialogResult result = MessageBox.Show("Вы действительно хотите приобрести данный комплект?", "Подтверждение покупки", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            BigShop.AfterPurchase(MainCharacter.Name);
                            Program.World.Player.AfterPurchase(MainCharacter.Name, BigShop.PriceOfOutfit[MainCharacter.Name]);
                            Condition.Text = "Выбрать";
                            MoneyCount.Text = Program.World.Player.Money.ToString();
                            Program.World.pictureBox1.Image = Helpers.OutfitToFileMap[MainCharacter.Name];
                        }
                    }
                    else MessageBox.Show("Недостаточно монет для покупки", "Мало денег", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    Program.World.Player.OutfitName = MainCharacter.Name;
                    Program.World.pictureBox1.Image = Helpers.OutfitToFileMap[MainCharacter.Name];
                }

            };
            //Menu.Click += (sender, args) => { Close(); };
            Controls.Add(MainCharacter);
            Controls.Add(InitialCostum);
            Controls.Add(GrandsonCostum);
            Controls.Add(GentlemanCostum);
            Controls.Add(BatmanCostum);
            Controls.Add(FancyGuyCostum);
            Controls.Add(Menu);
            Controls.Add(Money);
            Controls.Add(MoneyCount);
            Controls.Add(Condition);
        }

    }
}
