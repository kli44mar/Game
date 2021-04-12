using NUnit.Framework;
using ThiefWorld;

namespace Tests
{
    public class CharacterTests
    {
        [SetUp]
        public void Setup()
        {
            //var character = new Character("John");
        }

        [Test]
        public void Initialization()
        {
            var character = new Character("John");
            Assert.AreEqual(0, character.Money);
            Assert.AreEqual("John", character.Name);
            Assert.AreEqual("Initial Outfit", character.OutfitName);
        }

        [Test]
        public void ChangeMoneyAndScore()
        {
            var character = new Character("John");
            character.AfterSublevel(200);
            Assert.AreEqual(200, character.Money);
            Assert.AreEqual(200, character.Score);
        }
    }
}