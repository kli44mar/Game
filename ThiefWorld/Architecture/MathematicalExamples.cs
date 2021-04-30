using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ThiefWorld.Architecture
{
    public class MathematicalExamples
    {
        public IReadOnlyDictionary<(int, string), string> MathExamples { get; private set; }
        public int Score { get; private set; }
        public int CountOfExamples { get; private set; }
        public int PointsForEasyExample { get; private set; }
        public int PointsForMediumExample { get; private set; }
        public int PointsForHardExample { get; private set; }
        public DifficaltyOfExamples Difficalty { get; private set; }
        private List<(int, string)> UsedExamples;
        private Dictionary<DifficaltyOfExamples, int> CountOfUsedExamples;
        public enum DifficaltyOfExamples
        {
            Easy = 1,
            Medium = 2,
            Hard = 3
        }

        public MathematicalExamples(IReadOnlyDictionary<(int, string), string> examples, int countOfExamples)
        {
            this.MathExamples = examples;
            this.PointsForEasyExample = 10;
            this.PointsForMediumExample = 20;
            this.PointsForHardExample = 30;
            this.Difficalty = DifficaltyOfExamples.Easy;
            this.CountOfUsedExamples = new Dictionary<DifficaltyOfExamples, int> { [DifficaltyOfExamples.Easy] = 0, [DifficaltyOfExamples.Hard] = 0, [DifficaltyOfExamples.Medium] = 0 };
            this.UsedExamples = new List<(int, string)>();
            this.CountOfExamples = countOfExamples;
        }
         
        public void ChangeDifficalty(DifficaltyOfExamples difficalty)
        {
            this.Difficalty = difficalty;
        }

        public ((int, string), string) GetNextExample(int difficalty, bool correctnessOfResult)
        {
            if (difficalty < 1 || difficalty > 3)
                throw new ArgumentException();
            if (correctnessOfResult)
            {
                if (difficalty < 3)
                    difficalty = (difficalty + 1);
                if (difficalty == 3 && CountOfUsedExamples.ContainsKey((DifficaltyOfExamples)(difficalty)) && CountOfUsedExamples[(DifficaltyOfExamples)(difficalty)] == MathExamples.Count / 3)
                    difficalty = 2;
                if (difficalty == 2 && CountOfUsedExamples.ContainsKey((DifficaltyOfExamples)(difficalty)) && CountOfUsedExamples[(DifficaltyOfExamples)(difficalty)] == MathExamples.Count / 3)
                    difficalty = 1;
            }
            else
            {
                if (difficalty > 1)
                    difficalty = (difficalty - 1);
                if (difficalty == 1 && CountOfUsedExamples.ContainsKey((DifficaltyOfExamples)(difficalty)) && CountOfUsedExamples[(DifficaltyOfExamples)(difficalty)] == MathExamples.Count / 3)
                    difficalty = 2;
                if (difficalty == 2 && CountOfUsedExamples.ContainsKey((DifficaltyOfExamples)(difficalty)) && CountOfUsedExamples[(DifficaltyOfExamples)(difficalty)] == MathExamples.Count / 3)
                    difficalty = 3;
            }
            var difficaltyOfExample = (DifficaltyOfExamples)(difficalty);

            var random = new Random();
            var leftParts = MathExamples.Keys;
            var examplesWithThisDifficalty = leftParts.Where(x => x.Item1 == difficalty && !UsedExamples.Contains(x));
            var result = examplesWithThisDifficalty.ToList()[random.Next(0, examplesWithThisDifficalty.Count())];
            CountOfUsedExamples[difficaltyOfExample] += 1;
            UsedExamples.Add(result);
            return (result, MathExamples[result]);
        }

        public bool CompareResult((int, string) example, string result)
        {
            if (!this.MathExamples.ContainsKey(example))
                throw new ArgumentException();
            if (this.MathExamples[example] == result)
            {
                if (example.Item1 == 1)
                    this.Score += PointsForEasyExample;
                if (example.Item1 == 2)
                    this.Score += PointsForMediumExample;
                if (example.Item1 == 3)
                    this.Score += PointsForHardExample;
            }
            return (this.MathExamples[example] == result);
        }
    }
}
