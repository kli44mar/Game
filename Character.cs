using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks

namespace ThiefWorld
{
    class Character
    {
        public static string Name = "John";
        public string OutfitName { get; private set; }
        public int Money { get; private set; }
        private string Image { get; private set; }
        //имя
        //внешний вид
        //количество монет

        public Character()
        {
            this.OutfitName = "Initial Outfit";
            this.Money = 0;
            this.Image = "Initial.png";
        }

        public void Update (string outfit, string image, int moneyDifference)
        {
            this.OutfitName = outfit;
            this.Image = image;
            this.Money += moneyDifference;
        }
    }
}
