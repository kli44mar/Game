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
                [Outfit.Initial] = Properties.Resources._02,
                [Outfit.GrandSon] = Properties.Resources.Initial,
                [Outfit.Gentleman] = Properties.Resources._00,
                [Outfit.JustBatman] = Properties.Resources._01,
                [Outfit.FancyGuy] = Properties.Resources._04
            };
    }
}
