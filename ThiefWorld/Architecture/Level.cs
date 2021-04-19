using System;
using System.Collections.Generic;
using System.Text;

namespace ThiefWorld.Architecture
{
    public class Level
    {
        //доступные комплекты одежды
        //успеваемость в каждом подуровне
        //три подуровня
        public int LevelNumber { get; private set; }
        public int Points { get; private set; }
        public List<string> AvailableClothes = new List<string> { "Initial" };
        public MathematicalExamples MathExamples;
        public Sequences Sequences;
        public Issue Issue;
    }
}
