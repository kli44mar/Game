﻿using System;
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
        public Level PreviousLevel { get; private set; }
        public int Points { get; private set; }
        public List<string> AvailableClothes = new List<string> { "Initial" };
        public MathematicalExamples MathExamples;
        public Sequences Sequences;
        public Issue Issue;
        public bool Complete;

        public Level(Dictionary<string, string> mathExamples, List<List<string>> sequences, string conditionOfIssue, string answerOfIssue, int levelNumber, List<string> clothes, Level previous)
        {
            this.LevelNumber = levelNumber;
            this.Points = 0;
            this.AvailableClothes = clothes;
            this.MathExamples = new MathematicalExamples(mathExamples);
            this.Sequences = new Sequences(sequences);
            this.Issue = new Issue(conditionOfIssue, answerOfIssue);
            this.Complete = false;
            this.PreviousLevel = previous;
        }

        public void ChangeConditionOfLevel()
        {
            if (this.Points > 120)
                this.Complete = true;
        }

        public void Restart()
        {
            this.Complete = false;
            this.Points = 0;
        }
    }
}
