using NUnit.Framework;
using System;
using System.Collections.Generic;
using ThiefWorld;
using ThiefWorld.Architecture;

namespace Tests
{
    public class CharacterTests
    {
        [SetUp]
        public void Setup()
        {
            character = new Character("John");
        }

        private Character character;

        [Test]
        public void InitializationCharacter()
        {
            Assert.AreEqual(0, character.Money);
            Assert.AreEqual("John", character.Name);
            Assert.AreEqual("Initial Outfit", character.OutfitName);
        }

        [Test]
        public void ChangeMoneyAndScore()
        {
            character.AfterSublevel(200);
            Assert.AreEqual(200, character.Money);
            Assert.AreEqual(200, character.Score);
        }
    }

    public class MathematicalExamplesTests
    {
        [SetUp]
        public void Setup()
        {
            dict = new Dictionary<string, string>();
            dict.Add("3+5+9", "17");
            dict.Add("6*8", "48");
            examples = new MathematicalExamples(dict);
        }

        private Dictionary<string, string> dict;
        private MathematicalExamples examples;

        [Test]
        public void InitializationExamples()
        {
            Assert.AreEqual(dict, examples.MathExamples);
            Assert.AreEqual(60, examples.PointsForExample);
        }

        [Test]
        public void CompareMathResultTest()
        {
            Assert.AreEqual(false, examples.CompareResult("3+5+9", "8"));
            Assert.IsTrue(examples.CompareResult("6*8", "48"));
            Assert.Throws<ArgumentException>(() => examples.CompareResult("9-", "9"));
        }
    }

    public class SequencesTests
    {
        [SetUp]
        public void Setup()
        {
            list = new List<List<string>>();
            list.Add(new List<string> { "1", "2", "3" });
            list.Add(new List<string> { "67", "3", "90" });
            sequences = new Sequences(list);
        }

        private List<List<string>> list;
        private Sequences sequences;

        [Test]
        public void InitializationSequences()
        {
            Assert.AreEqual(list, sequences.SequenceList);
            Assert.AreEqual(60, sequences.PointsForExample);
        }

        [Test]
        public void CompareSequenceResultTest()
        {
            Assert.AreEqual(false, sequences.CompareResult(0, new List<string> { "1", "2", "2" }));
            Assert.IsTrue(sequences.CompareResult(1, new List<string> { "67", "3", "90" }));
            Assert.Throws<ArgumentException>(() => sequences.CompareResult(3, new List<string> { "8", "9" }));
        }
    }

    public class IssueTests
    {
        [SetUp]
        public void Setup()
        {
            condition = "Please, solve me!";
            answer = "Don't even ask me";
            issue = new Issue(condition, answer);
        }

        private string condition;
        private string answer;
        private Issue issue;

        [Test]
        public void InitializationIssue()
        {
            Assert.AreEqual(condition, issue.Condition);
            Assert.AreEqual(answer, issue.Answer);
        }

        [Test]
        public void CompareIssueResultTest()
        {
            Assert.AreEqual(false, issue.CompareResult("I do not want to do this"));
            Assert.IsTrue(issue.CompareResult("Don't even ask me"));
        }
    }
}