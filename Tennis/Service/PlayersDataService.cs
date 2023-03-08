using Newtonsoft.Json;
using Tennis.Model;

namespace Tennis.Service
{
    public class PlayersDataService
    {
        private static PlayersData _playersData;
        public static PlayersData LoadPlayersDataFromFile(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            _playersData = JsonConvert.DeserializeObject<PlayersData>(jsonString);
            return _playersData;
        }

        public static List<Player> GetPlayers()
        {
          return _playersData.Players.OrderBy(x => x.Data.Rank).ToList();
        }

        public static Player? GetPlayersById(int id)
        {
            return _playersData.Players.Where(x => x.Id == id).FirstOrDefault();
        }

        public static double GetAverageIMC()
        {
            double totalIMC = _playersData.Players.Sum(p => (p.Data.Weight/1000) / Math.Pow((p.Data.Height/100), 2));
            return totalIMC / _playersData.Players.Count;
        }

        public static double GetMedianHeight()
        {
            var orderedPlayers = _playersData.Players.OrderBy(p => p.Data.Height);
            int count = _playersData.Players.Count;
            int mid = count / 2;
            if (count % 2 == 0)
                return  (orderedPlayers.ElementAt(mid).Data.Height + orderedPlayers.ElementAt(mid - 1).Data.Height) / 2;
            else
                return orderedPlayers.ElementAt(mid).Data.Height;
            
        }

        public static string GetCountryWithHighestWinRatio()
        {
            var countries = _playersData.Players.Select(p => p.Country).Distinct();
            string countryWithHighestWinRat = "";
            double highestWinRatio = 0;
            foreach (var country in countries)
            {
                var playersInCountry = _playersData.Players.Where(p => p.Country == country);
                double totalWins = playersInCountry.Sum(p => p.Data.Last.Select(x => x == 1).Count());
                double totalLosses = playersInCountry.Sum(p => p.Data.Last.Select(x => x == 0).Count());
                double winRatio = totalWins / (totalWins + totalLosses);
                if (winRatio > highestWinRatio)
                {
                    countryWithHighestWinRat = country.Code;
                    highestWinRatio = winRatio;
                }
            }
            return countryWithHighestWinRat;
        }


    }
}
