using NUnit.Framework;
using Moq;
using PlayersManagerLib;
using System;

namespace PlayerManager.Tests
{
    [TestFixture]
    public class PlayerTests
    {
        private Mock<IPlayerMapper> mockMapper;

        [OneTimeSetUp]
        public void Setup()
        {
            mockMapper = new Mock<IPlayerMapper>();

            mockMapper.Setup(x => x.IsPlayerNameExistsInDb(It.IsAny<string>())).Returns(false);
        }

        [Test]
        public void RegisterNewPlayer_ShouldCreatePlayer_WhenNameIsValidAndNotExists()
        {
            var player = Player.RegisterNewPlayer("Virat", mockMapper.Object);

            Assert.That(player, Is.Not.Null);
            Assert.That(player.Name, Is.EqualTo("Virat"));
            Assert.That(player.Age, Is.EqualTo(23));
            Assert.That(player.Country, Is.EqualTo("India"));
            Assert.That(player.NoOfMatches, Is.EqualTo(30));
        }

        [Test]
        public void RegisterNewPlayer_ShouldThrowException_WhenNameIsEmpty()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                Player.RegisterNewPlayer("", mockMapper.Object));

            Assert.That(ex.Message, Is.EqualTo("Player name can’t be empty."));
        }

        [Test]
        public void RegisterNewPlayer_ShouldThrowException_WhenNameAlreadyExists()
        {
            mockMapper.Setup(x => x.IsPlayerNameExistsInDb("Sachin")).Returns(true);

            var ex = Assert.Throws<ArgumentException>(() =>
                Player.RegisterNewPlayer("Sachin", mockMapper.Object));

            Assert.That(ex.Message, Is.EqualTo("Player name already exists."));
        }
    }
}