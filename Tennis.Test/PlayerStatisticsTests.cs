using System.Collections.Generic;
using System.Linq;
using Tennis.Model;
using Tennis.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Tennis.Test
{

    [TestClass]
    public class PlayerStatisticsTests
    {
        private readonly PlayersData _players;
        private PlayersDataService _playerService;

        [TestInitialize]
        public void Initialize()
        {
            string filePath = @"Data\headtohead.json";
            PlayersDataService.LoadPlayersDataFromFile(filePath);

        }

        [TestMethod]
        public void TestGetPlayers()
        {
            var Players = PlayersDataService.GetPlayers();
            Assert.AreEqual(5, Players.Count);
        }

        [TestMethod]
        public void TestGetPlayersById()
        {
            var Player = PlayersDataService.GetPlayersById(52);
            Assert.AreEqual("Novak", Player.FirstName);
        }

        [TestMethod]
        public void TestCountryWithHighestWinRatio()
        {
            var countryWithHighestWinRatio = PlayersDataService.GetCountryWithHighestWinRatio();
            Assert.AreEqual("SRB", countryWithHighestWinRatio);
        }

        [TestMethod]
        public void TestAveragePlayerBMI()
        {
            var averagePlayerBMI = PlayersDataService.GetAverageIMC();
            Assert.AreEqual(23.35, averagePlayerBMI, 0.01);
        }

        [TestMethod]
        public void TestMedianPlayerHeight()
        {
            var medianPlayerHeight = PlayersDataService.GetMedianHeight();
            Assert.AreEqual(185, medianPlayerHeight);
        }
    }
}


