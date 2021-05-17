using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ThiefWorld.Architecture
{
    public class Issue
    {
        public Dictionary<string, string> Issues { get; private set; }
        public int Score { get; private set; }

        public Issue(Dictionary<string, string> issues)
        {
            this.Issues = issues;
            //this.Score = 0;
        }

        public (string, string) GetIssue()
        {
            var random = new Random();
            var condition = Issues.Keys.ToList()[random.Next(0, 2)];
            return (condition, Issues[condition]);
        }

        public bool CompareResult(string condition, string playerAnswer)
        {
            if (playerAnswer.Equals(Issues[condition]))
                Score += 120;
            return playerAnswer.Equals(Issues[condition]);
        }
    }
}
