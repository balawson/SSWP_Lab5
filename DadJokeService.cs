using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DadJokes.data;

public class DadJokeService
{
    private readonly HttpClient _httpClient;

    public DadJokeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
        public async Task<DadJoke> GetRandomDadJokeAsync()
        {
            var response = await _httpClient.GetStringAsync("https://icanhazdadjoke.com/");

            var dadJoke = JsonConvert.DeserializeObject<DadJoke>(response);

            return dadJoke;
        }

    }
