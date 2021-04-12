using System;
using System.Collections.Generic;
using System.Text;

namespace ThiefWorld.Architecture
{
    class Level
    {
        //доступные комплекты одежды
        //успеваемость в каждом подуровне
        //три подуровня
        public int LevelNumber { get; private set;}
        public List<string> AvailableClothes=new List<string> { "Initial" };

    }
}
