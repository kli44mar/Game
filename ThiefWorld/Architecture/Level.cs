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
        public Level PreviousLevel { get; private set; }
        public int Points { get; private set; }
        public List<string> AvailableClothes = new List<string> { "Initial" };
        public MathematicalExamples MathExamples;
        public Sequences Sequences;
        public Issue Issue;
        public bool Complete;

<<<<<<< HEAD
        public Level(Dictionary<string, string> mathExamples, List<string> sequences, string conditionOfIssue, string answerOfIssue, int levelNumber, List<string> clothes, Level previous)
=======
        public Level(IReadOnlyDictionary<(int, string), string> mathExamples, int countOfExamples, List<string> sequences, int countOfSequences, Dictionary<string, string> issues, int levelNumber, List<string> clothes, Level previous)
>>>>>>> 18269f6a93397a2d4c29128ec467baf25badc0af
        {
            this.LevelNumber = levelNumber;
            this.Points = 0;
            this.AvailableClothes = clothes;
            this.MathExamples = new MathematicalExamples(mathExamples, countOfExamples);
            this.Sequences = new Sequences(sequences, countOfSequences);
            this.Issue = new Issue(issues);
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

        public void ChangePoints()
        {
            Points = this.MathExamples.Score + this.Sequences.Score + this.Issue.Score;
        }
    }
}
