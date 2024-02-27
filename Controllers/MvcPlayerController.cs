using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MySoccerTeam.Models;
using MySoccerTeam.Services;
using System.Text.Json;

namespace MySoccerTeam.Controllers
{
    [Route("/[controller]")]
    public class MvcPlayerController : UrlBase
    {
        private readonly ApiSettings _settings;

        public MvcPlayerController(IOptions<ApiSettings> settings) : base(settings)
        {
           
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Player> players = new List<Player>();
            string apiUrl = $"{ApiBaseUrl}/apiplayer";
            Console.WriteLine(apiUrl);
            using (HttpClient client = new HttpClient())
            {
                
                HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true // Hace que la deserialización sea insensible a mayúsculas y minúsculas
                    };

                    try
                    {

                        Console.WriteLine(responseBody);
                        players = JsonSerializer.Deserialize<List<Player>>(responseBody, options);
                        Console.WriteLine(players);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return View("Index", players);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetPlayer(int id)
        {
            Player player = new Player();

            using (HttpClient client = new HttpClient())
            {
                string apiUrl = $"{ApiBaseUrl}/apiplayer/{ id}";

                HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true // Hace que la deserialización sea insensible a mayúsculas y minúsculas
                    };

                    try
                    {

                        Console.WriteLine(responseBody);
                        player = JsonSerializer.Deserialize<Player>(responseBody, options);
                        Console.WriteLine(player);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return View("EvaluatePlayer", player);
        }

        [HttpGet("newPlayer")]
        public IActionResult CreateNewPlayer()
        {
            return View("CreateNewPlayer");
        }

        [HttpPost]
        public async Task<ActionResult> AddPlayer([FromBody] Player player)
        {
            string apiUrl = $"{ApiBaseUrl}/apiplayer"; ;


            using (HttpClient client = new HttpClient())
            {
                var response = client.PostAsJsonAsync(apiUrl,player);
                if (response.IsCompletedSuccessfully)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return(View("Error"));
                }
            }

        }
    }
}
