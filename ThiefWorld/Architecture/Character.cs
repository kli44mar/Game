using Newtonsoft.Json;
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
        public string Name { get;  set; }
        public string OutfitName { get;  set; }
        public int Money { get;  set; }
        public int Score { get;  set; }
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

        public void AfterPurchase(string outfit, int price)
        {
            this.OutfitName = outfit;
            this.Money -= price;
        }

        public string SerializeGame()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static Character Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<Character>(json);
        }
    }
}
