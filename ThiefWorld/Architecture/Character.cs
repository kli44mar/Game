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
        public Dictionary<int, (bool, int)> LevelPointsAndComplete { get; set; }

        public Character(string name)
        {
            this.Name = name;
            this.OutfitName = Outfit.Initial;
            this.Money = 0;
            this.Score = 0;
            this.LevelPointsAndComplete = 
                new Dictionary<int, (bool, int)>() 
                { 
                    [1] = (false, 0),
                    [2] = (false, 0),
                    [3] = (false, 0),
                    [4] = (false, 0),
                    [5] = (false, 0)
            };
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

        public void AfterLevelRestart(int points, int level)
        {
            if (this.Money >= points)
                this.Money -= points;
            else this.Money = 0;
            this.Score -= points;
            this.LevelPointsAndComplete[level] = (false, 0);
        }

        public void ChangePointsAndCompleteLevel(int level, int points)
        {
            if (points > 150)
                this.LevelPointsAndComplete[level] = (true, points);
            else this.LevelPointsAndComplete[level] = (false, points);
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
