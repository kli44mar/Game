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
    public class Shop
    {
        //public static IReadOnlyDictionary<string, string> OutfitAndNames
        //    = new Dictionary<string, string>()
        //    {
        //        [Outfit.Initial] = "Вор в законе"
        //    };
        public IReadOnlyDictionary<string, int> PriceOfOutfit
            = new Dictionary<string, int>()
            {
                [Outfit.Initial] = 0
            };
        public Dictionary<string, OutfitState> StateOfOutfits
            = new Dictionary<string, OutfitState>()
            {
                [Outfit.Initial] = OutfitState.AlreadyBought
            };

        public void AfterPurchase (string outfitName)
        {
            StateOfOutfits[outfitName] = OutfitState.AlreadyBought;
        }
    }
}
