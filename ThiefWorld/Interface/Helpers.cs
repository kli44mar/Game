using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using ThiefWorld.Architecture;


namespace ThiefWorld.Interface
{
    public static class Helpers
    {
        public static readonly IReadOnlyDictionary<string, Bitmap> OutfitToFileMap
            = new Dictionary<string, Bitmap>()
            {
                [Outfit.Initial] = Properties.Resources._02_2,
                [Outfit.GrandSon] = Properties.Resources.Initial,
                [Outfit.Gentleman] = Properties.Resources._00_2,
                [Outfit.JustBatman] = Properties.Resources._01_2,
                [Outfit.FancyGuy] = Properties.Resources._04_2
            };
    }
}
