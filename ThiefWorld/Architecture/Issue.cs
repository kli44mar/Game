using System;
using System.Collections.Generic;
using System.Text;

namespace ThiefWorld.Architecture
{
    public class Issue
    {
        public string Condition { get; private set; }
        public string Answer { get; private set; }
        public int Score { get; private set; }

        public Issue(string condition, string answer)
        {
            this.Condition = condition;
            this.Answer = answer;
        }

        public bool CompareResult(string playerAnswer)
        {
            if (playerAnswer.Equals(Answer))
                Score += 120;
            return playerAnswer.Equals(Answer);
        }
    }
}
