using System;
using System.Collections.Generic;
using System.Text;
using ThiefWorld.Architecture;

namespace ThiefWorld.Interface
{
    public static class Helpers
    {
        public static readonly IReadOnlyDictionary<string, string> OutfitToFileMap
            = new Dictionary<string, string>()
            {
                [Outfit.Initial] = "Initial.png"
            };
    }
}
