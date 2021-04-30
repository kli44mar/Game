using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ThiefWorld.Architecture
{
    public class Sequences
    {
<<<<<<< HEAD
        public List<string> SequenceList { get; private set; }
=======
        public IReadOnlyList<string> SequenceList { get; private set; }
>>>>>>> 18269f6a93397a2d4c29128ec467baf25badc0af
        public int Score { get; private set; }
        public int PointsForExample { get; private set; }
        public int CountOfSequences { get; private set; }
        private List<string> UsedSequences;

<<<<<<< HEAD
        public Sequences(List<string> sequences)
=======
        public Sequences(List<string> sequences, int countOfSequences)
>>>>>>> 18269f6a93397a2d4c29128ec467baf25badc0af
        {
            this.SequenceList = sequences;
            this.CountOfSequences = countOfSequences;
            this.PointsForExample = 120 / countOfSequences;
            this.UsedSequences = new List<string>();
        }

        public string GetNextSequence()
        {
<<<<<<< HEAD
            if (numberOfSequence >= SequenceList.Count || sequence.Count != SequenceList[numberOfSequence].Length)
=======
            var random = new Random();
            var newList = SequenceList.Where(x => !UsedSequences.Contains(x));
            var result = newList.ToList()[random.Next(0, newList.Count())];
            UsedSequences.Add(result);
            return result;
        }

        public bool CompareResult(int numberOfSequence, string sequence)
        {
            if (numberOfSequence >= SequenceList.Count || sequence.Length != SequenceList[numberOfSequence].Length)
>>>>>>> 18269f6a93397a2d4c29128ec467baf25badc0af
                throw new ArgumentException();
            if (sequence.Equals(SequenceList[numberOfSequence]))
            {
                Score += PointsForExample;
                return true;
            }
            return false;
        }
    }
}