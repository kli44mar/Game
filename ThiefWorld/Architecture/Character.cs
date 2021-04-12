using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThiefWorld.Architecture;

namespace ThiefWorld
{
    public class Character
    {
        public string Name { get; private set; }
        public string OutfitName { get; private set; }
        public int Money { get; private set; }
        public int Score { get; private set; }
        //имя
        //внешний вид
        //количество монет

        public Character(string name)
        {
            this.Name = name;
            this.OutfitName = Outfit.Initial;
            this.Money = 0;
            this.Score = 0;
        }

        public void AfterSublevel(int income)
        {
            this.Money += income;
            this.Score += income;
        }

        public void Update (string outfit, int price)
        {
            this.OutfitName = outfit;
            this.Money -= price;
        }
    }
}
