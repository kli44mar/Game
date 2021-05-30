using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Assert.AreEqual("Еще зеленый", character.OutfitName);
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
            dict = new Dictionary<(int, string), string>();
            dict.Add((1, "3+5+9"), "17");
            dict.Add((2, "6*8"), "48");
            examples = new MathematicalExamples(dict, 2, 1);
        }

        private Dictionary<(int, string), string> dict;
        private MathematicalExamples examples;

        [Test]
        public void InitializationExamples()
        {
            Assert.AreEqual(dict, examples.MathExamples);
            Assert.AreEqual(10, examples.PointsForEasyExample);
        }

        [Test]
        public void CompareMathResultTest()
        {
            Assert.AreEqual(false, examples.CompareResult((1, "3+5+9"), "8"));
            Assert.IsTrue(examples.CompareResult((2, "6*8"), "48"));
            Assert.Throws<ArgumentException>(() => examples.CompareResult((1, "9-"), "9"));
        }

        [Test]
        public void RestartMath()
        {
            examples.RestartMath();
            Assert.AreEqual(0, examples.Score);

        }
    }

    public class SequencesTests
    {
        [SetUp]
        public void Setup()
        {
            list = new List<string>();
            list.Add( "1 2 3" );
            list.Add("67 3 90" );
            sequences = new Sequences(list, 2);
        }

        private List<string> list;
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
            Assert.AreEqual(false, sequences.CompareResult(0, "1 2 2"));
            Assert.IsTrue(sequences.CompareResult(1, "67 3 90" ));
            Assert.Throws<ArgumentException>(() => sequences.CompareResult(3,  "8 9" ));
        }

        [Test]
        public void RestartSequence()
        {
            sequences.RestartSequences();
            Assert.AreEqual(0, sequences.Score);
        }
    }

    public class IssueTests
    {
        [SetUp]
        public void Setup()
        {
            condition = "Please, solve me!";
            answer = "Don't even ask me";
            dicti = new Dictionary<string, string>() { [condition] = answer };
            issue = new Issue(dicti);
        }

        private string condition;
        private string answer;
        private Dictionary<string, string> dicti;
        private Issue issue;

        [Test]
        public void InitializationIssue()
        {
            Assert.AreEqual(condition, issue.Issues.Keys.First());
            Assert.AreEqual(answer, issue.Issues.Values.First());
        }

        [Test]
        public void CompareIssueResultTest()
        {
            Assert.AreEqual(false, issue.CompareResult("Please, solve me!", "No!"));
            Assert.IsTrue(issue.CompareResult("Please, solve me!", "Don't even ask me"));
        }
    }

    public class ShopTests
    {
        [SetUp]
        public void Setup()
        {
            shop = new ShopOutfit();
        }

        private ShopOutfit shop;

        [Test]
        public void InitializationShop()
        {
            Assert.AreEqual(0, shop.PriceOfOutfit[Outfit.Initial]);
            Assert.AreEqual(300, shop.PriceOfOutfit[Outfit.GrandSon]);
            Assert.AreEqual(550, shop.PriceOfOutfit[Outfit.Gentleman]);
            Assert.AreEqual(820, shop.PriceOfOutfit[Outfit.JustBatman]);
            Assert.AreEqual(1075, shop.PriceOfOutfit[Outfit.FancyGuy]);
        }

        [Test]
        public void AfterPurchase()
        {
            shop.AfterPurchase(Outfit.GrandSon);
            Assert.AreEqual(OutfitState.AlreadyBought, shop.StateOfOutfits[Outfit.GrandSon]);
        }
    }

    public class LevelTests
    {
        [SetUp]
        public void Setup()
        {
            level = new Level(new Dictionary<(int, string), string>() { [(1, "5+10")] = "10"}, 
                1,
                new List<string>() { "1 2 3" },
                1,
                new Dictionary<string, string>() { ["Example"] = "Answer"},
                1,
                new List<string>(),
                null);
        }

        private Level level;

        [Test]
        public void InitializationLevel()
        {
            Assert.AreEqual(1, level.LevelNumber);
            Assert.AreEqual(0, level.Points);
            Assert.AreEqual(new Dictionary<(int, string), string>() { [(1, "5+10")] = "10" },
                level.MathExamples.MathExamples);
            Assert.AreEqual(false, level.Complete);
            Assert.AreEqual(null, level.PreviousLevel);
        }

        [Test]
        public void RestartLevel()
        {
            level.Restart();
            Assert.AreEqual(0, level.Points);
        }
    }
}