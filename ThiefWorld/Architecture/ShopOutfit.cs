using System;
using System.Collections.Generic;
using System.Text;

namespace ThiefWorld.Architecture
{
    public enum OutfitState
    {
        AlreadyBought,
        AvailableForPurchase
    }
    public class ShopOutfit
    {
        //public static IReadOnlyDictionary<string, string> OutfitAndNames
        //    = new Dictionary<string, string>()
        //    {
        //        [Outfit.Initial] = "Вор в законе"
        //    };
        public IReadOnlyDictionary<string, int> PriceOfOutfit
            = new Dictionary<string, int>()
            {
                [Outfit.Initial] = 0,
                [Outfit.GrandSon] = 0,
                [Outfit.Gentleman] = 550,
                [Outfit.JustBatman] = 820,
                [Outfit.FancyGuy] = 1075
            };
        public Dictionary<string, OutfitState> StateOfOutfits
            = new Dictionary<string, OutfitState>()
            {
                [Outfit.Initial] = OutfitState.AlreadyBought,
                [Outfit.GrandSon] = OutfitState.AvailableForPurchase,
                [Outfit.Gentleman] = OutfitState.AvailableForPurchase,
                [Outfit.JustBatman] = OutfitState.AvailableForPurchase,
                [Outfit.FancyGuy] = OutfitState.AvailableForPurchase
            };

        public void AfterPurchase (string outfitName)
        {
            StateOfOutfits[outfitName] = OutfitState.AlreadyBought;
        }
    }
}
