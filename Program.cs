using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DadJokes.data;
class Program
{
    static async Task Main()
    {
        var httpClientService = new HttpClientService();
        var httpClient = httpClientService.GetHttpClient();
        var dadJokeService = new DadJokeService(httpClient);

        List<DadJoke> favoriteJokes = new List<DadJoke>();

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Display Random Dad Joke");
            Console.WriteLine("2. Display Favorited Jokes");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option (1|2|3): ");

            string userInput = Console.ReadLine();

            switch (userInput.Trim())
            {
                case "1":
                    
                    DadJoke randomDadJoke = await dadJokeService.GetRandomDadJokeAsync();

                    Console.WriteLine($"\n{randomDadJoke.joke}");

                    Console.Write("Type 'f' if you would like to favorite this joke, press Enter to continue: ");
                    string favoriteInput = Console.ReadLine();

                    if (favoriteInput.Trim().ToLower() == "f")
                    {
                        favoriteJokes.Add(randomDadJoke);
                        Console.WriteLine("Joke marked as favorite.\n");
                    }

                    break;

                case "2":
                    
                    Console.WriteLine("\nFavorite Jokes:");
                    foreach (var joke in favoriteJokes)
                    {
                        Console.WriteLine($"{joke.joke}\n");
                    }
                    break;

                case "3":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("\nInvalid choice. Please select a valid option.\n");
                    break;
            }
        }
    }
}

