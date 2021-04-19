using System;
using System.Collections.Generic;
using System.Text;

namespace ThiefWorld.Architecture
{
    public class Sequences
    {
        public List<List<string>> SequenceList { get; private set; }
        public int Score { get; private set; }
        public int PointsForExample { get; private set; }

        public Sequences(List<List<string>> sequences)
        {
            this.SequenceList = sequences;
            this.PointsForExample = 120 / sequences.Count;
        }

        public bool CompareResult(int numberOfSequence, List<string> sequence)
        {
            if (numberOfSequence >= SequenceList.Count || sequence.Count != SequenceList[numberOfSequence].Count)
                throw new ArgumentException();
            for (var i = 0; i < sequence.Count; i++)
                if (!sequence[i].Equals(SequenceList[numberOfSequence][i]))
                    return false;
            Score += PointsForExample;
            return true;
        }
    }
}