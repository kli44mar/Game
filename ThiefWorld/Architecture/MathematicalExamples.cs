using System;
using System.Collections.Generic;
using System.Text;

namespace ThiefWorld.Architecture
{
    public class MathematicalExamples
    {
         public Dictionary<string, string> MathExamples { get; private set; }
         public int Score { get; private set; }
         public int PointsForExample { get; private set; }

         public MathematicalExamples(Dictionary<string, string> examples)
         {
             this.MathExamples = examples;
             this.PointsForExample = 120 / examples.Count;
         }

         public bool CompareResult(string example, string result)
         {
             if (!MathExamples.ContainsKey(example))
                 throw new ArgumentException();
             if (MathExamples[example] == result)
                 Score += PointsForExample;
             return (MathExamples[example] == result);
         }
    }
}
