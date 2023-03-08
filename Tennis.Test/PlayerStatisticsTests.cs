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
        public void TestCountryWithHighestWinRatio()
        {
            // Act
            var countryWithHighestWinRatio = PlayersDataService.GetCountryWithHighestWinRatio();

            // Assert
            Assert.AreEqual("SRB", countryWithHighestWinRatio);
        }

        [TestMethod]
        public void TestAveragePlayerBMI()
        {
            // Act
            var averagePlayerBMI = PlayersDataService.GetAverageIMC();

            // Assert
            Assert.AreEqual(23.35, averagePlayerBMI, 0.01);
        }

        [TestMethod]
        public void TestMedianPlayerHeight()
        {
            // Act
            var medianPlayerHeight = PlayersDataService.GetMedianHeight();

            // Assert
            Assert.AreEqual(185, medianPlayerHeight);
        }
    }
}


