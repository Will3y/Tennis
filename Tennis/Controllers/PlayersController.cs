using Microsoft.AspNetCore.Mvc;
using Tennis.Model;
using Tennis.Service;

[Route("api/[controller]")]
[ApiController]
public class PlayersController : ControllerBase
{
    private readonly PlayersData _playersData;

    public PlayersController()
    {
        string filePath = @"Data\headtohead.json";
        _playersData = PlayersDataService.LoadPlayersDataFromFile(filePath);
    }

    [HttpGet]
    public IActionResult GetPlayers()
    {
        try
        {
            return Ok(PlayersDataService.GetPlayers());
        }
        catch (Exception ex)
        {
            return NotFound(ex);
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetPlayersById(int id)
    {
        try
        {
            var player = PlayersDataService.GetPlayersById(id);
            if (player == null)
                return NotFound();

            return Ok(player);
        }
        catch (Exception ex)
        {
            return NotFound(ex);
        }
    }

    [HttpGet("Stats")]
    public IActionResult GetPlayersStats()
    {
        try
        {
            var countryWithHighestWinRatio = PlayersDataService.GetCountryWithHighestWinRatio();
            var averageIMC = PlayersDataService.GetAverageIMC();
            var medianHeight = PlayersDataService.GetMedianHeight();

            var statistics = new
            {
                CountryWithHighestWinRatio = countryWithHighestWinRatio,
                AverageIMC = averageIMC,
                MedianHeight = medianHeight
            };

            return Ok(statistics);
        }
        catch (Exception ex)
        {
            return NotFound(ex);
        }
    }

}